using eCommerce.Contract.Repositories;
using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.WebUI.Controllers
{
    public class AdminController : Controller
    {
		IRepositoryBase<Customer> customer;
		IRepositoryBase<Product> products;

		public AdminController(IRepositoryBase<Customer> customer, IRepositoryBase<Product> product)
		{
			this.customer = customer;
			this.products = product;
		}
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult ProductList()
		{
			var model = products.GetAll();
			return View(model);
		}

		public ActionResult CreateProduct()
		{
			var model = new Product();

			return View(model);
		}
		[HttpPost]
		public ActionResult CreateProduct(Product product)
		{
			products.Insert(product);
			products.Commit();

			return RedirectToAction("ProductList");
		}

		public ActionResult EditProduct(int id)
		{
			Product product = products.GetById(id);

			return View(product);
		}

		[HttpPost]
		public ActionResult EditProduct(Product product)
		{
			products.Update(product);
			products.Commit();

			return RedirectToAction("ProductList");
		}
	}
}