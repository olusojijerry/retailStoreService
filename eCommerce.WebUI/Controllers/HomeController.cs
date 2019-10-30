using eCommerce.Contract.Repositories;
using eCommerce.DAL.Data;
using eCommerce.DAL.Repositories;
using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.WebUI.Controllers
{
	public class HomeController : Controller
	{
		IRepositoryBase<Customer> customers;
		public HomeController(IRepositoryBase<Customer> customer)
		{
			this.customers = customer;
		}
		public ActionResult Index()
		{
			ProductRepository product = new ProductRepository(new DataContext()); 
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}