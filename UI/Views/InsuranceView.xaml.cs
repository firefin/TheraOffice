using Library.Models;
using Library.Services;
using UI.ViewModels;

namespace UI.Views;
[QueryProperty(nameof(InsuranceId), "insuranceId")]

public partial class InsuranceView : ContentPage
{
	public InsuranceView()
	{
		InitializeComponent();
		BindingContext = new InsuranceViewModel();
	}
	public int InsuranceId { get; set; }
	private void Exit_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//InsuranceManagement");
	}

	private void Confirm_Clicked(object sender, EventArgs e)
	{
		if((BindingContext as InsuranceViewModel)?.AddOrUpdate() ?? false)
            Shell.Current.GoToAsync("//InsuranceManagement");
        else
            (BindingContext as InsuranceViewModel)?.Refresh();
	}

	private void AddProcedure_Clicked(object sender, EventArgs e)
	{
		string name = ProcedureEntry.Text;
		string coverage = CoverageEntry.Text;


		//TODO: Move all this to the InsuranceServiceProxy (or InsuranceViewModel?)
		if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(coverage))
		{
			DisplayAlert("Error", "Please enter a name and coverage.", "OK");
			return;
		}
		if (decimal.TryParse(coverage, out decimal c))
		{
			bool? addSuccess = (BindingContext as InsuranceViewModel)?.Coverages.TryAdd(name, c);
			if(addSuccess != null)
			{
				if (addSuccess == false)
				{
					DisplayAlert("Error", "Procedure already exists.", "OK");
					return;
				}
				ProcedureEntry.Text = string.Empty;
				CoverageEntry.Text = string.Empty;
				DisplayAlert("Success", "Information added.", "OK");
			}
			else
			{
				//TODO: Theoretically, this is when an insurance is not created. So
				//      maybe create a temporary Dictionary and add to that, then after 
				//      confirming, add to the actual Dictionary
				//      For now, just display an error.
				DisplayAlert("Error", "An error occurred. (insurance may not exist yet)", "OK");
				return;
			}
		}
		else
		{
			DisplayAlert("Error", "Coverage must be a number.", "OK");
		}
	}

	private void InsuranceView_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		//TODO: this really needs to be in a view Model
		if (InsuranceId > 0)
			BindingContext = InsuranceServiceProxy.Current.Insurances.FirstOrDefault(p => p.Id == InsuranceId);
		else
			BindingContext = new Insurance();

	}
}