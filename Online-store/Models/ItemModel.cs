using System.ComponentModel.DataAnnotations.Schema;

namespace Online_store.Models
{
	[Table("item")]
	public class ItemModel
	{
		public int Id { get; set; }
		[Column("ProductName")]
		public string? Name { get; set; }
		public float Price { get; set; }
		public string? Сategory { get; set; }
	}
}
