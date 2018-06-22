namespace CarDealerShip.UI.ViewModel
{
	public interface ILoginViewModel : IViewModel
	{
		string Password { get; set; }
		string UserName { get; set; }
	}
}