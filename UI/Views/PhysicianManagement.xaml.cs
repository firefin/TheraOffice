using System.ComponentModel;
using UI.ViewModels;

namespace UI.Views;

public partial class PhysicianManagement : ContentPage, INotifyPropertyChanged
{
	public PhysicianManagement()
	{
		InitializeComponent();
		BindingContext = new PhysicianManagementViewModel();
	}
	private void Exit_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Home");
	}
	private void AddPhysician_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//PhysicianView?physicianId=0");
	}

	private void EditPhysician_Clicked(object sender, EventArgs e)
	{
		var phyId = (BindingContext as PhysicianManagementViewModel)?.SelectedPhysician?.Id ?? 0;
		Shell.Current?.GoToAsync($"PhysicianView?physicianId={phyId}");
	}
	private void Delete_Clicked(object sender, EventArgs e)
	{
		(BindingContext as PhysicianManagementViewModel)?.Delete();
	}
	private void PhysicianManagement_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		(BindingContext as PhysicianManagementViewModel)?.Refresh();
	}
}