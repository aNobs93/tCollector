using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        int ID { get; set; }        
        
        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        int PickUpDay { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string StreetAddress { get; set; }
        string City { get; set; }
        string State { get; set; }
        int ZipCode { get; set; }
        double Balance { get; set; }
        string ExtraPickUpDate { get; set; }
        string SuspendedStart { get; set; }
        string SuspendedEnd { get; set; }
        bool PickUpConfirmation { get; set; }



    }
}