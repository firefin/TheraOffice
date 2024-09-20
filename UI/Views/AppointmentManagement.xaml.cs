namespace UI.Views;

public partial class AppointmentManagement : ContentPage
{
	public AppointmentManagement()
	{
		InitializeComponent();
	}
    private void Exit_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Home");
    }
    private void CreateNewAppointment_Clicked(object sender, EventArgs e)
    {

    }
    private void EditAppointment_Clicked(object sender, EventArgs e)
    {

    }
}