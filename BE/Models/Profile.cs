using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BE.Models
{
    public  class Profile
    {
        public Profile()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public String FiestName { get; set; }

        public String LastName { get; set; }

        public DateTime? Birthday { get; set; }

        public GENDER Sex { get; set; }

    }

   public enum GENDER
    {
        MALE,
        FEMALE
    }
}
