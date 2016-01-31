using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PostCodeDataAccess.Models;
using PostCodeDataAccess.Models.General;

namespace PostCodeWeb.ViewModels
{
    public class PostCodeResultVm
    {
        [DisplayName("My PostCode is ...")]
        [Required(ErrorMessage = "Please enter a postcode")]
        [RegularExpression(@"^\s*([A-z]{1,2}[ ]?[0-9]{1,2}[A-z]?[ ]*[0-9][A-z]{2})\s*$",
                            ErrorMessage = "Please enter a full, valid postcode")]
        public string Postcode { get; set; }
        public int Quality { get; set; }
        public string Country { get; set; }
        public string Nhs_Ha { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Parliamentary_Constituency { get; set; }
        public string European_Electoral_Region { get; set; }
        public string Primary_Care_Trust { get; set; }
        public string Region { get; set; }
        public string Admin_District { get; set; }
        public object Admin_County { get; set; }
        public string Admin_Ward { get; set; }
        public Codes Codes { get; set; }
    }
}