namespace UI.Views;

public partial class PhysicianManagement : ContentPage
{
	public PhysicianManagement()
	{
		InitializeComponent();
	}
	private void Exit_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Home");
	}
	private void AddPhysician_Clicked(object sender, EventArgs e)
	{

	}
}