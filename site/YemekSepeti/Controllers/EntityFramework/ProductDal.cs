using System.Data.Entity;
using YemekSepeti.DataAccess.EntityFramework;
using YemekSepetiProje.Entities;
using YemekSepetiProje.Entitys;

namespace YemekSepeti.Controllers.EntityFramework
{
	public class ProductDal
	{
		public List<Product> GetProducts()
		{
			using (YemekSepetiContext context = new YemekSepetiContext())
			{
				return context.Products.ToList();
			}
		}

		public void Add(Product product)
		{
			using (YemekSepetiContext context = new YemekSepetiContext())
			{
				var entity = context.Entry(product);
				entity.State = EntityState.Added;
				context.SaveChanges();
			}
		}

		public void Update(Product product)
		{
			using (YemekSepetiContext context = new YemekSepetiContext())
			{
				var entity = context.Entry(product);
				entity.State = EntityState.Modified;
				context.SaveChanges();
			}
		}
		public void Delete(Product product)
		{
			using (YemekSepetiContext context = new YemekSepetiContext())
			{
				var entity = context.Entry(product);
				entity.State = EntityState.Deleted;
				context.SaveChanges();
			}
		}

		public List<Product> GetByProductName(string key)
		{
			using (YemekSepetiContext context = new YemekSepetiContext())
			{
				return context.Products.Where(p => p.ProductName.Contains(key.ToLower())).ToList();
			}
		}
	}
}
