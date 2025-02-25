﻿namespace KelleSolutions.Models.ViewModels
{
    public class ViewUserProperties
    {
        public int ID { get; set; }
        public DateOnly CreationDate { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public int Postal { get; set; }
        public string Street { get; set; }
        public int Bed { get; set; }
        public int Bath { get; set; }
    }
}
