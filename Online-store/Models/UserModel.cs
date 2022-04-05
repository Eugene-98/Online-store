using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_store.Models
{
	[Table("users")]
	public class UserModel : IdentityUser

	{
	public int Id { get; set; }

	[Column("UserName")] 
	public string? Name { get; set; }

	[DataType(DataType.Password)]
	public string Password { get; set; }
	[NotMapped] public List<ItemModel> Сart { get; set; }

	}
}
