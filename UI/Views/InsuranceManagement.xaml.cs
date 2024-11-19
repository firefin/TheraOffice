using UI.ViewModels;

namespace UI.Views;

public partial class InsuranceManagement : ContentPage
{
	public InsuranceManagement()
	{
		InitializeComponent();
        BindingContext = new InsuranceManagementViewModel();
    }
	private void AddInsurance_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InsuranceView?insuranceId=0");
    }
	private void EditInsurance_Clicked(object sender, EventArgs e)
    {
        var selectedInsuranceId = (BindingContext as InsuranceManagementViewModel)?.SelectedInsurance?.Id ?? 0;
        Shell.Current.GoToAsync($"//InsuranceView?insuranceId={selectedInsuranceId}");
    }
    private void Exit_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Home");
    }
    private void DeleteInsurance_Clicked(object sender, EventArgs e)
    {
        (BindingContext as InsuranceManagementViewModel)?.DeleteInsurance();
    }
    private void InsuranceManagement_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InsuranceManagementViewModel)?.Refresh();
    }
}