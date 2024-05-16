using AppUTNMauiCuascotaRoberto.Models;

namespace AppUTNMauiCuascotaRoberto;

public partial class Videojuegos : ContentPage
{
    private string ApiUrlProd = "https://utncloudcomputingapivideojuegos.azurewebsites.net/api/Videojuegos";
    public Videojuegos()
    {
        InitializeComponent();
    }

    private void cmdCreateProd_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombreVideojuego.Text) ||
            string.IsNullOrWhiteSpace(txtGenero.Text) ||
            string.IsNullOrWhiteSpace(txtPrecio.Text) ||
            string.IsNullOrWhiteSpace(txtTienda_OnlineID.Text))
        {
            DisplayAlert("Error", "Campos incompletos, por favor complete todos los campos.", "OK");
            return;
        }
        var prod = API.Crud<Videojuego>.Create(ApiUrlProd, new Videojuego
        {
            Id = 0,
            Nombre = txtNombreVideojuego.Text,
            Genero = txtGenero.Text,
            Precio = double.Parse(txtPrecio.Text),
            Tienda_onlineId = int.Parse(txtTienda_OnlineID.Text)
        });
        if (prod != null)
        {
            DisplayAlert("Éxito", "Videojuego Creado con exito", "OK");
            txtIdVideojuego.Text = prod.Id.ToString();
        }
    }
    private void cmdLeerProd_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIdVideojuego.Text))
        {
            DisplayAlert("Error", "Ingrese el ID del Videojuego que desea buscar.", "OK");
            return;
        }
        var (prod, found) = API.Crud<Videojuego>.Read_ById(ApiUrlProd, int.Parse(txtIdVideojuego.Text));
        if (found)
        {
            txtIdVideojuego.Text = prod.Id.ToString();
            txtNombreVideojuego.Text = prod.Nombre.ToString();
            txtGenero.Text = prod.Genero.ToString();
            txtPrecio.Text = prod.Precio.ToString();
            txtTienda_OnlineID.Text = prod.Tienda_onlineId.ToString();
            DisplayAlert("Éxito", "Videojuego leído con éxito.", "OK");
        }
        else
        {
            DisplayAlert("Error", "No existe el Videojuego", "OK");
        }
    }


    private void cmdUpdateProd_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIdVideojuego.Text) ||
            string.IsNullOrWhiteSpace(txtNombreVideojuego.Text) ||
            string.IsNullOrWhiteSpace(txtGenero.Text) ||
            string.IsNullOrWhiteSpace(txtPrecio.Text) ||
            string.IsNullOrWhiteSpace(txtTienda_OnlineID.Text))
        {
            DisplayAlert("Error", "Campos incompletos, por favor complete todos los campos.", "OK");
            return;
        }
        bool success = API.Crud<Videojuego>.Update(ApiUrlProd, int.Parse(txtIdVideojuego.Text), new Videojuego
        {
            Id = int.Parse(txtIdVideojuego.Text),
            Nombre = txtNombreVideojuego.Text,
            Genero = txtGenero.Text,
            Precio = double.Parse(txtPrecio.Text),
            Tienda_onlineId = int.Parse(txtTienda_OnlineID.Text)
        });
        if (!success)
        {
            DisplayAlert("Error", "Actualización fallida. El Videojuego no existe.", "OK");
        }
        else
        {
            DisplayAlert("Éxito", "Videojuego actualizado correctamente.", "OK");
        }
    }

    private void cmdDeleteProd_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTienda_OnlineID.Text))
        {
            DisplayAlert("Error", "Ingrese el ID del Videojuego que desea eliminar.", "OK");
            return;
        }
        bool success = API.Crud<Videojuego>.Delete(ApiUrlProd, int.Parse(txtIdVideojuego.Text));
        if (!success)
        {
            DisplayAlert("Error", "Videojuego no encontrado para eliminar.", "OK");
        }
        else
        {
            DisplayAlert("Éxito", "Videojuego eliminado correctamente.", "OK");
            txtIdVideojuego.Text = "";
            txtNombreVideojuego.Text = "";
            txtGenero.Text = "";
            txtPrecio.Text = "";
            txtTienda_OnlineID.Text = "";
        }
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void OnNextPageButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Tiendas_Online());
    }
}