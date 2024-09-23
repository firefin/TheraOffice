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
            (sender as Button).TextColor = Color.FromRgb(70,46,135);
            for(int i = 0; i<100000; i++) 
            {
                int j = i;
            }
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

    }

}
