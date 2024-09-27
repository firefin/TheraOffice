using Library.Models;
using Library.Services;

namespace UI.Views;
[QueryProperty(nameof(PhysicianId), "physicianId")]
public partial class PhysicianView : ContentPage
{
	public PhysicianView()
	{
		InitializeComponent();
	}
	public int PhysicianId { get; set; }
	private void Exit_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//PhysicianManagement");
	}
	private void Confirm_Clicked(object sender, EventArgs e)
	{
		var p = BindingContext as Physician;
		if(p != null) 
			PhysicianServiceProxy.Current.AddOrUpdatePhysician(p);
		Shell.Current.GoToAsync("//PhysicianManagement");
	}
	private void PhysicianView_NagivatedTo(object sender, EventArgs e)
	{
		if (PhysicianId > 0)
			BindingContext = PhysicianServiceProxy.Current.Physicians.FirstOrDefault(p => p.Id == PhysicianId);
		else
			BindingContext = new Physician();
	}
}