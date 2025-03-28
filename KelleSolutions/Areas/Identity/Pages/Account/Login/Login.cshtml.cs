﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using KelleSolutions.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace KelleSolutions.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<User> signInManager, UserManager<User> userManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        // Model used to bind user login input from the UI
        public class InputModel
        {
            [Required(ErrorMessage = "Email or Phone Number is required.")]
            public string EmailOrPhone { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        // Initializes login page, signs out any external auth, sets return URL
        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Sign out any previous external login cookies
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        // Handles login form submission and redirects based on user role
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Determine whether input is email or phone number
            var isEmail = new EmailAddressAttribute().IsValid(Input.EmailOrPhone);

            // Try to find the user by email or phone
            User user = isEmail
                ? await _userManager.FindByEmailAsync(Input.EmailOrPhone)
                : await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == Input.EmailOrPhone);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            // Attempt to sign in the user
            var result = await _signInManager.PasswordSignInAsync(user, Input.Password, Input.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");

                // Get roles assigned to the user
                var roles = await _userManager.GetRolesAsync(user);

                // Redirect based on role
                return roles switch
                {
                    var r when r.Contains("Admin") => RedirectToPage("/Admin/AdminDashboard"),
                    var r when r.Contains("Broker") || r.Contains("Agent") => RedirectToPage("/AT_Dashboard"),
                    _ => LocalRedirect(returnUrl) // Fallback if role not recognized
                };
            }

            // If two-factor auth is required
            if (result.RequiresTwoFactor)
            {
                return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, Input.RememberMe });
            }

            // If user is locked out
            if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out.");
                return RedirectToPage("./Lockout");
            }

            // For all other login failures
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }

        // Optional validation attribute for email or international phone number
        public class EmailOrPhoneNumberAttribute : ValidationAttribute
        {
            public EmailOrPhoneNumberAttribute() : base("Invalid email or mobile number.") { }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                string input = value as string;

                if (!string.IsNullOrEmpty(input))
                {
                    var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                    var phonePattern = @"^\+?[1-9]\d{1,14}$";

                    if (Regex.IsMatch(input, emailPattern) || Regex.IsMatch(input, phonePattern))
                    {
                        return ValidationResult.Success;
                    }
                }

                return new ValidationResult("Please enter a valid email or mobile number.");
            }
        }
    }
}