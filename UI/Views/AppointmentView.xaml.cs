using UI.ViewModels;

namespace UI.Views;

public partial class AppointmentView : ContentPage
{
	public AppointmentView()
	{
		InitializeComponent();
		BindingContext = new AppointmentViewModel();
	}
	private void Confirm_Clicked(object sender, EventArgs e)
	{
		(BindingContext as AppointmentViewModel)?.AddOrUpdate();
		Shell.Current.GoToAsync("//AppointmentManagement");
	}
    private void Exit_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//AppointmentManagement");
    }

    private void AppointmentView_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
		(BindingContext as AppointmentViewModel)?.Refresh();
    }
}