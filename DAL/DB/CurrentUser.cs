using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB
{
   public class CurrentAccount 
    {
        public CurrentAccount()
        {
            Id = Guid.NewGuid();
            AccountID = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid AccountID { get; set; }

    }
}
