﻿using System;
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

        [Display(Name = "Pick up day")]
        public string PickUpDay { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        [Display(Name = "Balance Due: $")]
        public double Balance { get; set; }

        [Display(Name = "Extra Pick Up Date")]
        public string ExtraPickUpDate { get; set; }

        [Display(Name = "Start Of Trash Suspension")]
        public string SuspendedStart { get; set; }

        [Display(Name = "End Of Trash Suspension")]
        public string SuspendedEnd { get; set; }

        [Display(Name = "Pick Up Confirmed")]
        public bool PickUpConfirmation { get; set; }


    }
}