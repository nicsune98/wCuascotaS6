using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wCuascotaS6.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(MensajeAndroid))] //considera este archivo para la ejecución del proyecto

namespace wCuascotaS6.Droid
{
    public class MensajeAndroid : Mensaje
    {
        public void LongAlert(string mensaje) //Mensaje largo 5 segundos
        {
            Toast.MakeText(Application.Context, mensaje, ToastLength.Long).Show();
        }

        public void ShortAlert(string mensaje) //Mensaje corto 3 segundos
        {
            Toast.MakeText(Application.Context, mensaje, ToastLength.Short).Show();
        }
    }
}