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
    public partial class AppPut : ContentPage
    {
        string codigo = "";
        public AppPut(Datos datos)
        {
            InitializeComponent();
            txtNombre.Text = datos.nombre;
            txtApellido.Text = datos.apellido;
            txtEdad.Text = datos.edad.ToString();
            codigo = datos.codigo.ToString();
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                cliente.UploadValues("http://192.168.100.4/moviles/post.php?codigo="+ Int32.Parse(codigo)+"&"+"nombre="+ 
                    txtNombre.Text + "&" + "apellido=" + txtApellido.Text + "&" + "edad=" + Int32.Parse(txtEdad.Text), "PUT", parametros);
                await DisplayAlert("alerta", "Dato actualizado correctamente", "ok");
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