using Business;
using Data;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerController
        public ActionResult Index()
        {

            BCustomer bCustomer = new BCustomer();
            List<Customer> customers = bCustomer.GetAllCustomers();

            //Convertir listado de entidades a listado de modelo
            //Entity>>>Model
            List<CustomerModel> models = new List<CustomerModel>();

            //Expresiones Lambda
            models = customers.Select(x => new CustomerModel
            {
                CustomerId = x.CustomerId,
                Name = x.Name,
                Address = x.Address,
                Phone = x.Phone,
                Active = x.Active
            }).ToList();

            return View(models);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                DCustomer dataCustomer = new DCustomer();
                dataCustomer.InsertCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }


        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            BCustomer bCustomer = new BCustomer();
            Customer customer = bCustomer.GetCustomerById(id);

            if (customer != null)
            {
                CustomerModel model = new CustomerModel
                {
                    CustomerId = customer.CustomerId,
                    Name = customer.Name,
                    Address = customer.Address,
                    Phone = customer.Phone,
                    Active = customer.Active
                };

                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                BCustomer bCustomer = new BCustomer();
                Customer customer = new Customer
                {
                    CustomerId = model.CustomerId,
                    Name = model.Name,
                    Address = model.Address,
                    Phone = model.Phone,
                    Active = model.Active
                };

                try
                {
                    bCustomer.UpdateCustomer(customer);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log ex (manejar la excepción adecuadamente)
                    ModelState.AddModelError(string.Empty, "Error al editar el cliente.");
                    return View(model);
                }
            }

            // Si el modelo no es válido, se retorna la vista con los datos del modelo
            return View(model);
        }



        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
