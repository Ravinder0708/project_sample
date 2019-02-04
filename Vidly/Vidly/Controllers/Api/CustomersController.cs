using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using AutoMapper;
using Vidly.DTOs;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
	public class CustomersController : ApiController
	{
		private ApplicationDbContext _dbContext;

		public CustomersController()
		{
			_dbContext = new ApplicationDbContext();
		}

		/// <summary>
		/// Get all Customers
		/// URL: api/customers
		/// </summary>
		/// <returns></returns>
		public IHttpActionResult GetCustomers(string query = null)
		{
			//We convert IEnumerable to IHttpActionResult, so that 
			//var customersList = _dbContext.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
			//var customersList = _dbContext.Customers.Include(mem=>mem.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>);

			var customersQuery = _dbContext.Customers.Include(mem => mem.MembershipType);

			if (!String.IsNullOrWhiteSpace(query))
				customersQuery = customersQuery.Where(c => c.Name.Contains(query));

			var customersList = customersQuery.ToList().Select(Mapper.Map<Customer, CustomerDto>);
			return Ok(customersList);
		}

		/// <summary>
		/// Get particular Customer from Id
		/// URL: api/customers/id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public IHttpActionResult GetCustomers(int id)
		{
			var customer = _dbContext.Customers.SingleOrDefault(i => i.Id == id);
			if(customer==null)
			{
				//throw new HttpResponseException(HttpStatusCode.NotFound);
				return NotFound();
			}
			else
			{
				//return Mapper.Map<Customer,CustomerDto>(customer);
				return Ok(Mapper.Map<Customer, CustomerDto>(customer));
			}
		}


		/// <summary>
		/// Create customer by customer Model
		/// POST: URL: api/customers
		/// </summary>
		/// <param name="customerModel"></param>
		/// <returns></returns>
		[HttpPost]
		public IHttpActionResult CreateCustomer(CustomerDto customerModel)
		{
			if (!ModelState.IsValid)
			{
				//throw new HttpResponseException(HttpStatusCode.BadRequest);
				return BadRequest();
			}
			var customer = Mapper.Map<CustomerDto,Customer>(customerModel);
			_dbContext.Customers.Add(customer);
			_dbContext.SaveChanges();
			//return customerModel;
			return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerModel);
		}


		/// <summary>
		/// Update Customer data
		/// PUT: URL:api/customers/id
		/// </summary>
		/// <param name="customerModel"></param>
		/// <param name="id"></param>
		[HttpPut]
		public IHttpActionResult UpdateCustomer(CustomerDto customerModel,int id)
		{
			if(!ModelState.IsValid)
			{
				//throw new HttpResponseException(HttpStatusCode.BadRequest);
				return BadRequest();
			}
			var customerInDb = _dbContext.Customers.SingleOrDefault(i => i.Id == id);
			if(customerInDb == null)
			{
				//throw new HttpResponseException(HttpStatusCode.NotFound);
				return NotFound();
			}
			else
			{
				//IDE0001 C# Name can be simplified.
				//Mapper.Map<CustomerDto, Customer>(customerModel, customerInDb);
				Mapper.Map(customerModel, customerInDb);
			}
			_dbContext.SaveChanges();
			return Ok();
		}

		/// <summary>
		/// Delete Customer by using ID
		/// DELETE: URL:api/customers/id
		/// </summary>
		/// <param name="id"></param>
		[HttpDelete]
		public IHttpActionResult DeleteCustomer(int id)
		{
			var customerInDb = _dbContext.Customers.SingleOrDefault(i => i.Id == id);
			if (customerInDb == null)
			{
				//throw new HttpResponseException(HttpStatusCode.NotFound);
				return NotFound();
			}
			else
			{
				_dbContext.Customers.Remove(customerInDb);
				_dbContext.SaveChanges();
				return Ok();
			}
		}

		#region CodeCommentedDueToAutoMapper

		/*
		 /// <summary>
		/// Get all Customers
		/// URL: api/customers
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Customer> GetCustomers()
		{
			return _dbContext.Customers.ToList();
		}

		/// <summary>
		/// Get particular Customer from Id
		/// URL: api/customers/id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Customer GetCustomers(int id)
		{
			var customer = _dbContext.Customers.SingleOrDefault(i => i.Id == id);
			if(customer==null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			else
			{
				return customer;
			}
		}


		/// <summary>
		/// Create customer by customer Model
		/// POST: URL: api/customers
		/// </summary>
		/// <param name="customerModel"></param>
		/// <returns></returns>
		[HttpPost]
		public Customer CreateCustomer(Customer customerModel)
		{
			if (!ModelState.IsValid)
			{
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}
			_dbContext.Customers.Add(customerModel);
			_dbContext.SaveChanges();
			return customerModel;
		}


		/// <summary>
		/// Update Customer data
		/// PUT: URL:api/customers/id
		/// </summary>
		/// <param name="customerModel"></param>
		/// <param name="id"></param>
		public void UpdateCustomer(Customer customerModel,int id)
		{
			if(!ModelState.IsValid)
			{
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}
			var customerInDb = _dbContext.Customers.SingleOrDefault(i => i.Id == customerModel.Id);
			if(customerInDb == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			else
			{
				customerInDb.Name = customerModel.Name;
				customerInDb.IsSubscribedToNewsletter = customerModel.IsSubscribedToNewsletter;
				customerInDb.BirthDate = customerModel.BirthDate;
				customerInDb.MembershipTypeId = customerModel.MembershipTypeId;
			}
			_dbContext.SaveChanges();
		}

		/// <summary>
		/// Delete Customer by using ID
		/// DELETE: URL:api/customers/id
		/// </summary>
		/// <param name="id"></param>
		[HttpDelete]
		public void DeleteCustomer(int id)
		{
			var customerInDb = _dbContext.Customers.SingleOrDefault(i => i.Id == id);
			if (customerInDb == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			else
			{
				_dbContext.Customers.Remove(customerInDb);
			}
			_dbContext.SaveChanges();
		}
		 */

		#endregion
	}
}
