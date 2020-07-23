using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace operacionesBancarias
{
    class Cuenta
    {
        protected double balance;

        public Cuenta(double bal)
        {
            balance = bal;
        }

        public virtual bool Deposita(double cantidad)
        {
            balance = balance + cantidad;
            return true;
        }
        public virtual bool Retira(double cantidad)
        {
            bool resultado = true;
            if (balance < cantidad)
            {
                resultado = false;
            }
            else
            {
                balance = balance - cantidad;
            }
            return resultado;
        }
        public double Balance
        {
            get
            {
                return balance;
            }
        }
    }
}
