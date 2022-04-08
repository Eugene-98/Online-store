using System.ComponentModel.DataAnnotations;

namespace Online_store.ViewModel;

public class LoginViewModel
{
	[Required(ErrorMessage = "Username тot specified ")]
	public string Username { get; set; }

	[Required(ErrorMessage = "password not specified")]
	[DataType(DataType.Password)]
	public string Password { get; set; }
}