using Library.Services;
using UI.ViewModels;

namespace UI.Views;

public partial class AppointmentManagement : ContentPage
{
	public AppointmentManagement()
	{
		InitializeComponent();
        BindingContext = new AppointmentManagementViewModel();
	}
    private void Exit_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Home");
    }
    private void CreateNewAppointment_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AppointmentView?appointmentId=0");
    }
    private void EditAppointment_Clicked(object sender, EventArgs e)
    {
        var apptId = (BindingContext as AppointmentManagementViewModel)?.SelectedAppointment?.Id ?? 0;
        Shell.Current.GoToAsync($"//AppointmentView?appointmentId={apptId}");
    }
    private void DeleteAppointment_Clicked(object sender, EventArgs e)
    {
        AppointmentServiceProxy.Current.RemoveAppointment(0);
        
    }
    private void AppointmentManagement_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        ///TODO: Returns as null. Need to see why it does.
        (BindingContext as AppointmentManagementViewModel)?.Refresh();
    }
}