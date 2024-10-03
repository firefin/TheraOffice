using UI.ViewModels;

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
        Shell.Current.GoToAsync("//AppointmentView?appointment=0");
    }
    private void EditAppointment_Clicked(object sender, EventArgs e)
    {
        var apptId = (BindingContext as AppointmentManagementViewModel)?.SelectedPatient?.Id ?? 0;
        Shell.Current.GoToAsync($"//AppointmentView?appointment={apptId}");
    }
    private void DeleteAppointment_Clicked(object sender, EventArgs e)
    {

    }
}