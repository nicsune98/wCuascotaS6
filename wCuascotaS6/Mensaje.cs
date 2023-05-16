using System;
using System.Collections.Generic;
using System.Text;

namespace wCuascotaS6
{
    public interface Mensaje
    {
        void LongAlert(String mensaje); //Alerta corta
        void ShortAlert(String mensaje); //Alerta larga
    }
}
