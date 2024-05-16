using AppUTNMauiCuascotaRoberto.Models;

namespace AppUTNMauiCuascotaRoberto;

public partial class Tiendas_Online : ContentPage
{
    private string ApiUrl = "https://utncloudcomputingapivideojuegos.azurewebsites.net/api/Tiendas_online";
    public Tiendas_Online()
    {
        InitializeComponent();
    }

    private void cmdCreate_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTienda_Online.Text))
        {
            DisplayAlert("Error", "Por favor complete todos los campos.", "OK");
            return;
        }

        var resultado = API.Crud<Tienda_Online>.Create(ApiUrl, new Tienda_Online
        {
            Id = 0,
            Empresa = txtTienda_Online.Text
        });

        if (resultado != null)
        {
            DisplayAlert("Éxito", "Tienda creada con éxito.", "OK");
            txtId.Text = resultado.Id.ToString();
        }
    }

    private void cmdLeer_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtId.Text))
        {
            DisplayAlert("Error", "Ingrese el ID de la Tienda que desea buscar.", "OK");
            return;
        }

        var (resultado, found) = API.Crud<Tienda_Online>.Read_ById(ApiUrl, int.Parse(txtId.Text));
        if (found)
        {
            txtId.Text = resultado.Id.ToString();
            txtTienda_Online.Text = resultado.Empresa;
            DisplayAlert("Éxito", "Tienda leída con éxito.", "OK");
        }
        else
        {
            DisplayAlert("Error", "No existe la Tienda", "OK");
        }
    }


    private void cmdUpdate_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtId.Text) ||
            string.IsNullOrWhiteSpace(txtTienda_Online.Text))
        {
            DisplayAlert("Error", "Campos incompletos, por favor complete todos los campos.", "OK");
            return;
        }

        bool success = API.Crud<Tienda_Online>.Update(ApiUrl, int.Parse(txtId.Text), new Tienda_Online
        {
            Id = int.Parse(txtId.Text),
            Empresa = txtTienda_Online.Text
        });

        if (!success)
        {
            DisplayAlert("Error", "Actualización fallida. La Tienda no existe.", "OK");
        }
        else
        {
            DisplayAlert("Éxito", "Tienda actualizada correctamente.", "OK");
        }
    }

    private void cmdDelete_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtId.Text))
        {
            DisplayAlert("Error", "Ingrese el ID de la Tienda que desea eliminar.", "OK");
            return;
        }

        bool success = API.Crud<Tienda_Online>.Delete(ApiUrl, int.Parse(txtId.Text));
        if (!success)
        {
            DisplayAlert("Error", "Tienda no encontrada para eliminar.", "OK");
        }
        else
        {
            DisplayAlert("Éxito", "Tienda eliminada correctamente.", "OK");
            txtId.Text = "";
            txtTienda_Online.Text = "";
        }
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    // Manejador de evento para el botón de ir a otra página
    private async void OnNextPageButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Videojuegos());
    }
}