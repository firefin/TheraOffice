namespace UI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void ManagePatients_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//PatientManagement");
        }
        private void ManagePhysicians_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//PhysicianManagement");
        }
        private void ManageAppointments_Clicked(object sender, EventArgs e) 
        {
            Shell.Current.GoToAsync("//AppointmentManagement");
        }
        private void ManageInsurance_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//InsuranceManagement");
        }

    }

}
