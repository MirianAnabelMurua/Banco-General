using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace operacionesBancarias
{   //Creo la subclase de Cuenta, Cuenta de Ahorro
    class CajaDeAhorro : Cuenta
    {
        private double porcentajeInteres;

        public CajaDeAhorro(double bal, double porcentaje) : base(bal)
        {
            porcentajeInteres = porcentaje;
        }

        //Sobreescribo el método Retira
        public override bool Retira(double cantidad)
        {
            bool resultado = true;

            if (balance < cantidad)
            {
                // No hay suficiente protección de giro para la cantidad solicitada
                resultado = false;
            }
            else
            {
                // Hay suficiente  para la cantidad solicitada
                // Proceder normalmente
                balance = balance - cantidad;
            }
            return resultado;
        }
        public double PorcentajeInteres
        {
            get
            {
                return porcentajeInteres;
            }
        }
    }
}
