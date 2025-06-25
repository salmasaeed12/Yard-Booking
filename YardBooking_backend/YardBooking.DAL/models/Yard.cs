using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YardBooking.DAL.Models
{
    public class Yard
    {
        [Key]
        public int YardID { get; set; }

        public int OwnerID { get; set; }  

        [Required]
        [StringLength(100)]
        public string YardName { get; set; }

        [Required]
        [StringLength(200)]
        public string YardLocation { get; set; }

        public decimal YardArea { get; set; }

        public string ServicesOffered { get; set; }

       
        public string YardPhotos { get; set; }
    }
}