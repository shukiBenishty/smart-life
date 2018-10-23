using System;
using System.ComponentModel.DataAnnotations;

namespace BE.Models
{
    public  class Goals
    {
        public Goals()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int CaloriesConsume { get; set; }
        public int TotalfatConsume { get; set; }
        public int SodiumConsume { get; set; }
        public int ProteinConsume { get; set; }
        public int CarbohydrateConsume { get; set; }
        public int DietaryFiberConsume { get; set; }
        public int CholesterolConsume { get; set; }


    }
}
