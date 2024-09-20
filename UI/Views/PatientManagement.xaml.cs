using System.ComponentModel;
using UI.ViewModels;

namespace UI.Views;

public partial class PatientManagement : ContentPage, INotifyPropertyChanged
{
	public PatientManagement()
	{
		InitializeComponent();
		BindingContext = new PatientManagementViewModel();
	}
	private void AddNewPatient_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//PatientView");
	}
	private void EditPatient_Clicked(object sender, EventArgs e)
	{
		var selectedPatientId = (BindingContext as PatientManagementViewModel)?.SelectedPatient?.Id ?? 0;
		Shell.Current.GoToAsync("//PatientView?");//missing something like ?Id=
	}
    private void Exit_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Home");
    }
}