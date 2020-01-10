using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            EmployeeCustomersViewModel employeeCustomersViewModel = new EmployeeCustomersViewModel();
            string userId = User.Identity.GetUserId();
            string todaysDay = DateTime.Today.DayOfWeek.ToString();
            var employee = db.Employees.Where(u => u.ApplicationId == userId).FirstOrDefault();
            employeeCustomersViewModel.customers = db.Customers.Where(u => u.ZipCode == employee.ZipCode && u.PickUpDay == todaysDay).ToList();
            employeeCustomersViewModel.daysOfWeek = new SelectList(new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });
            return View(employeeCustomersViewModel);
        }
        [HttpPost]
        public ActionResult Index(EmployeeCustomersViewModel employeeCustomersViewModel)
        {
            string userId = User.Identity.GetUserId();
            var employee = db.Employees.Where(u => u.ApplicationId == userId).FirstOrDefault();
            employeeCustomersViewModel.customers = db.Customers.Where(u => u.ZipCode == employee.ZipCode && u.PickUpDay == employeeCustomersViewModel.selectedFilterDay).ToList();
            employeeCustomersViewModel.daysOfWeek = new SelectList(new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });

            return View(employeeCustomersViewModel);
        }

        // GET: Employees/Details/5
        public ActionResult Details()
        {
            string userId = User.Identity.GetUserId();
            var employee = db.Employees.Where(u => u.ApplicationId == userId).FirstOrDefault();
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {

            try
            {
                string userId = User.Identity.GetUserId();
                employee.ApplicationId = userId;
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async System.Threading.Tasks.Task<ActionResult> CustomerLocationAsync(int id)
        {
            Customer customer = db.Customers.Find(id);
            GeoCoderToFindCustomerLocation geoCoderToFindCustomerLocation = new GeoCoderToFindCustomerLocation();         
            var splitAddress = customer.StreetAddress.Split(new[] { ' ' }, 4);
            var finalAddress = string.Join("+", splitAddress);
            geoCoderToFindCustomerLocation.address = finalAddress;
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + geoCoderToFindCustomerLocation.address + "&key=" + PrivateKeys.key1;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                GeoResult postManJSON = JsonConvert.DeserializeObject<GeoResult>(jsonResult);
                geoCoderToFindCustomerLocation.longit = postManJSON.results[0].geometry.location.lng;
                geoCoderToFindCustomerLocation.latit = postManJSON.results[0].geometry.location.lng;
                geoCoderToFindCustomerLocation.key = PrivateKeys.key1;
                return View(geoCoderToFindCustomerLocation);

            }



            return View();
        }

        [HttpGet]
        public ActionResult CustomerLocation(double lat, double lng)
        {
            return View();
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            Customer customer = db.Customers.Find(id);
            return View(customer);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                Customer updatedCustomer = db.Customers.Find(id);
                updatedCustomer.PickUpConfirmation = customer.PickUpConfirmation;
                if (updatedCustomer.PickUpConfirmation == true)
                {
                    updatedCustomer.Balance += (15 + customer.Balance);

                }
                db.SaveChanges();
                return View("Index");

            }
            catch
            {
                return View();
            }


        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
