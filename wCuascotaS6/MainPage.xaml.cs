using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using wCuascotaS6.WS;
using Xamarin.Forms;

namespace wCuascotaS6
{
    public partial class MainPage : ContentPage
    {
        
        private const string Url = "http://192.168.1.109/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<wCuascotaS6.WS.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
            obtener();
        }
        public async void obtener() 
        {
                var content = await client.GetStringAsync(Url);
                List<wCuascotaS6.WS.Datos> posts = JsonConvert.DeserializeObject<List<wCuascotaS6.WS.Datos>>(content);
                _post = new ObservableCollection<wCuascotaS6.WS.Datos>(posts);
                Lista.ItemsSource = _post;
            
        }
        private void btRegistro_Clicked(object sender, EventArgs e)
        {
            var mensaje = "BIENVENIDO";
            DependencyService.Get<Mensaje>().LongAlert(mensaje);
            Navigation.PushAsync(new Registro());
        }
        private async void BtEliminar_Clicked(object sender, EventArgs e)
        {
            string id = ((MenuItem)sender).CommandParameter.ToString();
            if (await DisplayAlert("Confirmación","¿Está seguro que desea eliminar el elementos. Esta acción no se puede revertir","SI","NO")) 
            {                
                //WebClient cliente = new WebClient();
                var eliminar = await client.DeleteAsync($"http://192.168.1.109/moviles/post.php?codigo={id}");
                if (eliminar.IsSuccessStatusCode) 
                {
                    obtener();
                    await DisplayAlert("Mensaje","Estudiante eliminado","Aceptar");
                }
                else 
                {
                    await DisplayAlert("Mensaje", "No se pudo eliminar al estudiante", "Aceptar");
                }
            } 
        }

        private void BtEditar_Clicked(object sender, EventArgs e)
        {
            string id = ((MenuItem)sender).CommandParameter.ToString();
            Navigation.PushAsync(new Editar(id));
        }
    }
}
