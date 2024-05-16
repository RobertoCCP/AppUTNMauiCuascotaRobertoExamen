namespace AppUTNMauiCuascotaRoberto
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void cmdIngresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Tiendas_Online());
        }

        private async void cmdIngresar1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Videojuegos());
        }
    }

}
