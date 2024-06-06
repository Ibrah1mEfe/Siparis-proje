namespace YemekSepeti.Controllers.EntityFramework
{
	public class ProductUpdateAddModel
	{
		public int Id { get; set; }
		public string AddProductName { get; set; }
		public decimal AddUnitPrice { get; set; }
		public string AddProductCategory { get; set; }
		public string UpdateProductName { get; set; }
		public decimal UpdateUnitPrice { get; set; }
		public string UpdateProductCategory { get; set; }
	}
}