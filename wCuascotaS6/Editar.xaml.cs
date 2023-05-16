using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wCuascotaS6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Editar : ContentPage
    {
        public Editar(string id)
        {
            InitializeComponent();
            lblCodigo.Text = id;
            Obtener();
        }
        public async void Obtener()
        {
            try
            {
                WebClient cliente = new WebClient();
                string codigo = lblCodigo.Text;
                string url = "http://192.168.1.109/moviles/post.php?codigo=" + codigo;
                string content = cliente.DownloadString(url);
                var data = JsonConvert.DeserializeObject<wCuascotaS6.WS.Datos>(content);
                txtNombre.Text = data.nombre;
                txtApellido.Text = data.apellido;
                txtEdad.Text = data.edad.ToString();
            }
            catch (Exception ex) 
            {
                await DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
        private void btGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", lblCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                byte[] responseBytes = cliente.UploadValues("http://192.168.1.109/moviles/post.php", "PUT", parametros);
                string responseString = Encoding.UTF8.GetString(responseBytes);
                if (responseString != "OK")
                {
                    DisplayAlert("Mensaje", "Dato Actualizado", "Aceptar");
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    DisplayAlert("Alerta", "No se pudo actualizar el dato", "Cerrar");
                }
            }
            catch (Exception ex)
            {
                 DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private void btRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}