using Library.Models;
using Library.Services;

namespace UI.Views;
[QueryProperty(nameof(PatientId), "patientId")]
public partial class PatientView : ContentPage
{
	public PatientView()
	{
		InitializeComponent();
	}
    public int PatientId { get; set; }
	private void Exit_Clicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync("//PatientManagement");
    }

    private void Confirm_Clicked(object sender, EventArgs e)
    {
		var p = BindingContext as Patient;
		if(p != null) 
			PatientServiceProxy.Current.AddOrUpdatePatient(p);

		Shell.Current.GoToAsync("//PatientManagement");
    }

    private void PatientView_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        //TODO: this really needs to be in a view model
        if (PatientId > 0)
        {
            BindingContext = PatientServiceProxy.Current
                .Patients.FirstOrDefault(p => p.Id == PatientId);
        }
        else
        {
            BindingContext = new Patient();
        }

    }
}