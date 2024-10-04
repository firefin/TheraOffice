namespace UI.Views;

public partial class AppointmentView : ContentPage
{
	public AppointmentView()
	{
		InitializeComponent();
	}
	private void Confirm_Clicked(object sender, EventArgs e)
	{

	}
    private void Exit_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//AppointmentManagement");
    }
}