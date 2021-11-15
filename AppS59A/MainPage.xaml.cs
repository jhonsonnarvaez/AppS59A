using AppS59A.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppS59A
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.100.4/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppS59A.Modelos.Datos> _post;

        private Datos datos;
        public MainPage()
        {
            InitializeComponent();
            cargarDatos();

        }

        private async void cargarDatos()
        {
            var content = await client.GetStringAsync(Url);
            List<AppS59A.Modelos.Datos> posts = JsonConvert.DeserializeObject<List<AppS59A.Modelos.Datos>>(content);
            _post = new ObservableCollection<AppS59A.Modelos.Datos>(posts);

            MyListView.ItemsSource = _post;


            MyListView.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    datos = (Modelos.Datos)e.SelectedItem;
                }
            };
        }

        private async void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new AppPost());
            }catch(Exception ex)
            {
                await DisplayAlert("Mensaje de advertencia", ex.Message, "OK");
            }
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new AppPut(datos));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Mensaje de advertencia", ex.Message, "OK");
            }
   
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new AppDelete(datos));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Mensaje de advertencia", ex.Message, "OK");
            }
        }
    }
}
