using System.ComponentModel.DataAnnotations;

namespace LETSGO.Models
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string IdentityCardNum { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PosCode { get; set; }
        public string InvestmentType { get; set; }
        public int InvestAmount { get; set; }
        public AppUser()
        {
            UserId = 0;
            Password = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            FullName = string.Empty;
            IdentityCardNum = string.Empty;
            BirthDate = DateTime.MinValue;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            Address = string.Empty;
            City = string.Empty;
            PosCode = string.Empty;
            InvestmentType = string.Empty;
            InvestAmount = 0;
        }
    }
}
