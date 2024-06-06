
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Diagnostics;
using System.Security.Claims;
using System.Xml.Linq;
using YemekSepeti.Controllers.EntityFramework;
using YemekSepeti.DataAccess.EntityFramework;

using YemekSepetiProje.Entities;
using YemekSepetiProje.Entitys;


namespace YemekSepetiProje.Controllers
{
	public class HomeController : Controller
	{

		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult CustomerOrder()
		{
			return View();
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult adminPanel()
		{

			return View();
		}
		public IActionResult adminPanelProduct()
		{
			var products = (productDal.GetProducts());
			return View(products);
		}

		public IActionResult adminPanelCustomer()
		{
			var customers = (customerDal.GetProducts());
			return View(customers);
		}

		CustomerDal customerDal = new CustomerDal();
		ProductDal productDal = new ProductDal();

		[HttpPost]
		public IActionResult CustomerOrder(string BuyProduct)
		{
			var userEmail = HttpContext.Session.GetString("UserSession");
			var customer = customerDal.GetByEmail(userEmail);

			if (customer != null)
			{
				if (!string.IsNullOrEmpty(customer.BuyProduct))
				{
					customer.BuyProduct += "," + BuyProduct;
				}
				else
				{
					customer.BuyProduct = BuyProduct;				
				}
				//customerDal.SendEmail("gonderilecek mail", "Satýn Alma Bilgisi", "Ürün: " + BuyProduct);
				customerDal.Update(customer);
			}

			return RedirectToAction("CustomerOrder");
		}

		[HttpPost]
		public IActionResult DeleteCustomer(int id)
		{
			using (var context = new YemekSepetiContext())
			{
				var cutomerToDelete = context.Customers.Find(id);
				if (cutomerToDelete != null)
				{
					customerDal.Delete(cutomerToDelete);
					return RedirectToAction("adminPanel");
				}
				return View();
			}
		}
		[HttpPost]
		public IActionResult DeleteProduct(int id)
		{
			using (var context = new YemekSepetiContext())
			{
				var productToDelete = context.Products.Find(id);
				if (productToDelete != null)
				{
					productDal.Delete(productToDelete);
					return RedirectToAction("adminPanel");
				}
				return View();
			}
		}

		[HttpPost]
		public IActionResult adminPanelProduct(ProductUpdateAddModel updateModel, string key)
		{
			if (updateModel.UpdateProductName != null && updateModel.UpdateUnitPrice != null && updateModel.UpdateProductCategory != null)
			{
				productDal.Update(new Product
				{
					Id = updateModel.Id,
					ProductName = updateModel.UpdateProductName,
					UnitPrice = updateModel.UpdateUnitPrice,
					ProductCategory = updateModel.UpdateProductCategory
				});
			}
			else if (updateModel.AddProductName != null && updateModel.AddUnitPrice != null && updateModel.AddProductCategory != null)
			{
				productDal.Add(new Product
				{
					ProductName = updateModel.AddProductName,
					UnitPrice = updateModel.AddUnitPrice,
					ProductCategory = updateModel.AddProductCategory
				});

			}
			if (key != null)
			{
				var search = productDal.GetByProductName(key.ToLower());
				return View(search.ToList());
			}
			return RedirectToAction("adminPanelProduct");
		}

		[HttpPost]
		public IActionResult adminPanelCustomer(CustomerUpdateAddModel updateModel, string key)
		{
			if (updateModel.UpdateCustomerName != null && updateModel.UpdateCustomerLastName != null && updateModel.UpdateCustomerMail != null && updateModel.UpdateCustomerPassword != null && updateModel.UpdateCustomerAddress != null && updateModel.UpdateCustomerBuyProduct != null)
			{
				customerDal.Update(new Customer
				{
					Id = updateModel.Id,
					FirstName = updateModel.UpdateCustomerName,
					LastName = updateModel.UpdateCustomerLastName,
					Email = updateModel.UpdateCustomerMail,
					Password = updateModel.UpdateCustomerPassword,
					Address = updateModel.UpdateCustomerAddress,
					BuyProduct = updateModel.UpdateCustomerBuyProduct,

				});
			}
			else if (updateModel.AddCustomerName != null && updateModel.AddCustomerLastName != null && updateModel.AddCustomerMail != null && updateModel.AddCustomerPassword != null && updateModel.AddCustomerAddress != null && updateModel.AddCustomerBuyProduct != null)
			{
				customerDal.Add(new Customer
				{
					FirstName = updateModel.AddCustomerName,
					LastName = updateModel.AddCustomerLastName,
					Email = updateModel.AddCustomerMail,
					Password = updateModel.AddCustomerPassword,
					Address = updateModel.AddCustomerAddress,
					BuyProduct = updateModel.AddCustomerBuyProduct,

				});
			}
			if (key != null)
			{
				var search = customerDal.GetByCustomerName(key.ToLower());
				return View(search.ToList());
			}
			return RedirectToAction("adminPanelCustomer");
		}

		[HttpPost]
		public IActionResult Index(string FirstName, string LastName, string Email, string Password)
		{
			//var validator = new CustomerValidator();
			//var result = validator.Validate(customer);

			var usermail = customerDal.GetByEmail(Email);
			var customerPassword = customerDal.GetByPassword(Password);
			

			//validation
			//if (!result.IsValid)
			//{
			//	ModelState.Clear();
			//	foreach (var error in result.Errors)
			//	{
			//		ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
			//	}

			//	return View("/Views/Home/Index.cshtml");
			//}


			if (FirstName == null && LastName == null)
			{
				if (Email == "admin@gmail.com" && Password == "1234")
				{
					var products = (productDal.GetProducts());
					return View("/Views/Home/adminPanel.cshtml", products);
				}
				else
				{								
					if (customerPassword != null && usermail != null)
					{
						HttpContext.Session.SetString("UserSession", Email);
						var session = HttpContext.Session.GetString("UserSession");
						
						return RedirectToAction("Index", "Home");
					}
					else
					{
						return View("/Views/Home/Index.cshtml");
					}

				}

			}
			else
			{
				
				if (usermail != null)
				{

					ModelState.AddModelError("Email", "Bu e-posta adresi zaten kullanýlmaktadýr.");
				}
				else
				{

					customerDal.Add(new Customer
					{
						FirstName = FirstName,
						LastName = LastName,
						Email = Email,
						Password = Password
					});

				}
				return RedirectToAction("Index", "Home");

			}


		}

	}

}



