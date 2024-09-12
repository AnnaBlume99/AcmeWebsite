using System.ComponentModel.DataAnnotations;

namespace AcmeWebsite.Client
{
    public class Submission
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "A valid email address must be valid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A valid serial number is required.")]
        public string SerialNumber { get; set; }
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must be at least 18 to participate.")]
        public bool Above18 { get; set;  }

        public override bool Equals(object obj)
        {
            var item = obj as Submission;

            if (item == null)
            {
                return false;
            }

            return FirstName == item.FirstName && LastName == item.LastName && Email == item.Email && SerialNumber == item.SerialNumber;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode() + Email.GetHashCode() + SerialNumber.GetHashCode();
        }
    }
}
