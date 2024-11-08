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
		Shell.Current.GoToAsync("//PatientView?patientId=0");
	}
	private void EditPatient_Clicked(object sender, EventArgs e)
	{
		var selectedPatientId = (BindingContext as PatientManagementViewModel)?.SelectedPatient?.Id ?? 0;
		Shell.Current.GoToAsync($"//PatientView?patientId={selectedPatientId}");
	}
    private void Exit_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Home");
    }
	private void Delete_Clicked(object sender, EventArgs e)
	{
		(BindingContext as PatientManagementViewModel)?.DeletePatient();
	}
    private void PatientManagement_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as PatientManagementViewModel)?.Refresh();
    }
}