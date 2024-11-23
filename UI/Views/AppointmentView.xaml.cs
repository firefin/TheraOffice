using Library.Models;
using Library.Services;
using UI.ViewModels;

namespace UI.Views;

[QueryProperty(nameof(AppointmentId), "appointmentId")]

public partial class AppointmentView : ContentPage
{

	public int AppointmentId { get; set; }

	public AppointmentView()
	{
		InitializeComponent();
		BindingContext = new AppointmentViewModel(); 
	}
	private void Confirm_Clicked(object sender, EventArgs e)
	{
        var binding = BindingContext as AppointmentViewModel;
        if (binding?.AddOrUpdate() ?? false) //the ?? false bit is slightly problematic cuz it breaks the whole mf thang. but w/e..
            Shell.Current.GoToAsync("//AppointmentManagement");
        else
        {
            DisplayAlert("Error", binding?.SchedulingErrorMessage, "OK");
            (BindingContext as AppointmentViewModel)?.Refresh();
        }
	}
    private void Exit_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//AppointmentManagement");
    }

    private void AppointmentView_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
		//(BindingContext as AppointmentViewModel)?.Refresh();

        if (AppointmentId > 0)
        {
            var model = AppointmentServiceProxy.Current
                .Appointments.FirstOrDefault(a => a.Id == AppointmentId);
            if (model != null)
            {
                BindingContext = new AppointmentViewModel(model);
            }
            else
            {
                BindingContext = new AppointmentViewModel();
            }

        }
        else
        {
            BindingContext = new AppointmentViewModel();
        }
    }

    private void TimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
		(BindingContext as AppointmentViewModel)?.RefreshTime();
    }
}