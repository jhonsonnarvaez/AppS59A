using AppS59A.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppS59A
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppDelete : ContentPage
    {
        string codigo = "";
        public AppDelete(Datos datos)
        {
            InitializeComponent();
            lblNombre.Text = datos.nombre;
            lblApellido.Text = datos.apellido;
            lblEdad.Text = datos.edad.ToString();
            codigo = datos.codigo.ToString();
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                cliente.UploadValues("http://192.168.100.4/moviles/post.php?codigo=" + Int32.Parse(codigo), "DELETE", parametros);
                await DisplayAlert("alerta", "Dato eliminado correctamente", "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("alerta", "Error: " + ex.Message, "ok");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}