using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCRUD.Models;

namespace WebCRUD.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDataAccessLayer objCustomerDAL = new CustomerDataAccessLayer();
        /// <summary>
        /// Create constructor and return list of object
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            //
            List<Customer> lstCust = new List<Customer>();
            lstCust = objCustomerDAL.GetAllCustomers().ToList();
            return View(lstCust);
        }
        /// <summary>
        /// Create constructor and if CustomerId exists, return the object customer
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateUpdate(int? CustomerId)
        {
            Customer objCust = new Customer();
            if (CustomerId != null)
                objCust = objCustomerDAL.GetCustomerById(CustomerId);
            return View(objCust);
        }
        /// <summary>
        /// Create new customer or update customer's details
        /// </summary>
        /// <param name="cust"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateUpdate(Customer cust)
        {
            //Validate fields
            if (ModelState.IsValid)
            {
                //Check if new or existing customer
                if (cust.CustomerId != 0)
                    //update customer details
                    objCustomerDAL.UpdateCustomerById(cust);
                else
                    //create new customer
                    objCustomerDAL.CreateCustomer(cust);
                //redirect to the main page
                return RedirectToAction("Index");
            }
            return View(cust);
        }
        /// <summary>
        /// Delete customer by Id
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(int CustomerId)
        {
            objCustomerDAL.DeleteCustomerById(CustomerId);
            return RedirectToAction("Index");
        }
    }
}