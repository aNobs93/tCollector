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
        public int ID { get; set; }        
        
        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Pick up day: ")]
        public string PickUpDay { get; set; }

        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }

        [Display(Name = "Street Address: ")]
        public string StreetAddress { get; set; }

        [Display(Name = "City: ")]
        public string City { get; set; }

        [Display(Name = "State: ")]
        public string State { get; set; }

        [Display(Name = "Zipcode: ")]
        public int ZipCode { get; set; }

        [Display(Name = "Balance Due: ")]
        public double Balance { get; set; }

        [Display(Name = "Extra Pick Up Date: ")]
        public DateTime? ExtraPickUpDate { get; set; }

        [Display(Name = "Start Of Trash Suspension: ")]
        public DateTime? SuspendedStart { get; set; }

        [Display(Name = "End Of Trash Suspension: ")]
        public DateTime? SuspendedEnd { get; set; }

        [Display(Name = "Pick Up Confirmed: ")]
        public bool PickUpConfirmation { get; set; }


    }
}