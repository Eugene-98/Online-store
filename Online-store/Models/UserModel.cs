using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_store.Models
{
	[Table("users")]
	public class UserModel
	{
	public int Id { get; set; }

	[Column("UserName")] 
	public string? Name { get; set; }

	[DataType(DataType.Password)]
	public string Password { get; set; }

	}
}
