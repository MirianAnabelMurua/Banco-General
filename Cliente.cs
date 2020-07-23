using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace operacionesBancarias
{
    class Cliente
    {
        // Atributos para datos
        private String primerNombre;
        private String apellido;
        // Atributos para la agregación
        private Cuenta[] cuentas = new Cuenta[5];
        private int numeroDeCuentas = 0;

        public Cliente(String p, String a)
        {
            primerNombre = p;
            apellido = a;
        }


        public void AgregaCuenta(Cuenta cta)
        {
            int i = numeroDeCuentas++;
            cuentas[i] = cta;
        }
        public Cuenta GetCuenta(int indice_cuenta)
        {
            return cuentas[indice_cuenta];
        }

        public String PrimerNombre
        {
            get
            {
                return primerNombre;
            }
        }
        public String Apellido
        {
            get
            {
                return apellido;
            }
        }
        public int NumeroDeCuentas
        {
            get
            {
                return numeroDeCuentas;
            }
        }
    }
}
