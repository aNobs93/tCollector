using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollector.Models
{
    public class EmployeeCustomersViewModel
    {
        public List<Customer> customers { get; set; }

        public string selectedFilterDay { get; set; }

        public SelectList daysOfWeek { get; set; }
    }
}