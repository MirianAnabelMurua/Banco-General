using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace operacionesBancarias
{
    class CuentaCorriente : Cuenta
    {
        private double SIN_PROTECTION = -1.0;

        private double proteccionSobregiro;

        public CuentaCorriente(double bal, double proteccion) : base(bal)
        {
            proteccionSobregiro = proteccion;
        }
        public CuentaCorriente(double bal) : this(bal, -1.0)
        {
        }

        public override bool Retira(double cantidad)
        {
            bool resultado = true;

            if (balance < cantidad)
            {
                // No hay suficiente saldo para el retiro solicitado
                // Verificar que en caso que exista haya suficiente protección de sobregiro
                double sobregiroNecesario = cantidad - balance;
                if ((proteccionSobregiro == SIN_PROTECTION)
                || (proteccionSobregiro < sobregiroNecesario))
                {
                    // No hay suficiente protección de giro para la cantidad solicitada
                    resultado = false;
                }
                else
                {
                    // Hay suficiente protección de giro para la cantidad solicitada y cubre
                    balance = 0.0;
                    proteccionSobregiro = proteccionSobregiro - sobregiroNecesario;
                }
            }
            else
            {
                // Hay suficiente  para la cantidad solicitada
                // Proceder normalmente
                balance = balance - cantidad;
            }
            return resultado;
        }
    }
}
