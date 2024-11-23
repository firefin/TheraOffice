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

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(coverage))
        {
            DisplayAlert("Error", "Please enter a name and coverage.", "OK");
            return;
        }

		if (decimal.TryParse(coverage, out decimal c))
		{
			bool? tryAdd = (BindingContext as InsuranceViewModel)?.TryAddCoverage(name, c);

			if (tryAdd != null)
			{
				if (tryAdd == true)
				{
					//DisplayAlert("Success", "Information added.", "OK");
					ProcedureEntry.Text = string.Empty;
					CoverageEntry.Text = string.Empty;
					(BindingContext as InsuranceViewModel)?.Refresh();
				}
				else
				{
					DisplayAlert("Error", "Procedure already exists.", "OK");
				}
			}
			else
			{
				DisplayAlert("Error", "An error occurred.", "OK");
			}
		}
    }

	private void RemoveProcedure_Clicked(object sender, EventArgs e)
	{
		var binding = (BindingContext as InsuranceViewModel);
        if (binding != null && binding?.CoveragesObservableCollection.Count > 0)
		{
			var success = binding?.TryRemoveCoverage(binding.SelectedCoverage.Key);
            if (success == false)
            {
				DisplayAlert("Error", "Unable to remove.", "OK");
				return;
            }
            binding?.Refresh();
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