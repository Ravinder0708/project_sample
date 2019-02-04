using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class CustomersController : Controller
	{
		private ApplicationDbContext _context;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		public ActionResult Index()
		{
			//return View(GetCustomers()); Code is commented. Because these is only practice in part 2 in exercise2.
			var getCustomers = _context.Customers;//Deffered Loading
			var getCustomers1 = _context.Customers.Include(c => c.MembershipType).ToList();//Egar Loading
			return View(getCustomers1);
		}

		private List<Customer> GetCustomers()
		{
			var customer = new List<Customer>
			{
				new Customer{Id=1,Name="John"},
				new Customer{Id=2,Name="Cena"}
			};
			return customer;
		}

		public ActionResult Display(int id)
		{
			//var customerList = GetCustomers().SingleOrDefault(i => i.Id == id);Code is commented. Because these is only practice in part 2 in exercise2.
			var customerList = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(i => i.Id == id);
			if (customerList == null)
			{
				return HttpNotFound("No customer to display");
			}
			else
			{
				return View(customerList);
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(CustomerFormViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				if (viewModel.customerProp.Id == 0)
				{
					_context.Customers.Add(viewModel.customerProp);
				}
				else
				{
					var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == viewModel.customerProp.Id);
					customerInDb.Name = viewModel.customerProp.Name;
					customerInDb.IsSubscribedToNewsletter = viewModel.customerProp.IsSubscribedToNewsletter;
					customerInDb.BirthDate = viewModel.customerProp.BirthDate;
					customerInDb.MembershipTypeId = viewModel.customerProp.MembershipTypeId;
				}

				_context.SaveChanges();
				return RedirectToAction("Index", "Customers");
			}
			else
			{
				viewModel.customerProp = new Customer();
				var v = new CustomerFormViewModel()
				{
					membershipTypeProp = _context.MembershipTypes.ToList()
				};
				viewModel.membershipTypeProp = _context.MembershipTypes.ToList();
				return View("CustomerForm", v);
			}
		}

		public ActionResult New()
		{
			var membershipType = _context.MembershipTypes.ToList();
			var viewModel = new CustomerFormViewModel()
			{
				membershipTypeProp = membershipType,
				customerProp = new Customer()
			};
			return View("CustomerForm", viewModel);
		}

		public ActionResult Edit(int id)
		{
			var customerData = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
			var viewModel = new CustomerFormViewModel()
			{
				customerProp = customerData,
				membershipTypeProp = _context.MembershipTypes.ToList()
			};
			return View("CustomerForm", viewModel);
		}
	}
}