using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Models
{
   public class Account
    {
        public Account()
        {
            Id = Guid.NewGuid();
            Meals = new List<Meal>();
            BodyDimmenssionsList = new List<BodyDimmenssions>();
            GoogleProfile = new GoogleProfile();
        }
        [Key]
        public Guid Id { get; set; }

        [EmailAddress]
        public String Email { get; set; }

        public string GoogleSub { get; set; }

      //  [Required(ErrorMessage = "Password is required")]
        //[StringLength(255, ErrorMessage = "Must be between 6 and 255 characters", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        public Profile Profile { get; set; }

        public GoogleProfile GoogleProfile { get; set; }

        public List<Meal> Meals { get; set; }

        public List<BodyDimmenssions> BodyDimmenssionsList { get; set; }




    }
}
