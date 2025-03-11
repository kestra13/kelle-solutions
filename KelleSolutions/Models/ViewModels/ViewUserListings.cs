namespace KelleSolutions.Models.ViewModels
{
    public class ViewUserListings
    {
        public int ID { get; set; }
        public DateOnly ListingDate { get; set; }
        public string Status { get; set; }
        public string Operator { get; set; }
        public string Affiliation { get; set; }
        public double Price { get; set; }
        public string Address { get; set; }
    }
}
