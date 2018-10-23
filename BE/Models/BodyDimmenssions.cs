using System;
using System.ComponentModel.DataAnnotations;

namespace BE.Models
{
    public class BodyDimmenssions
    {
        public BodyDimmenssions()
        {
            Id = Guid.NewGuid();
            Height = 0;
        }

        public Guid Id { get; set; }

        [Key]
        public DateTime DateTime { get; set; }

        public float Height { get; set; }

        public float Weight { get; set; }

    }
}
