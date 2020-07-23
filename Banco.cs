using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace operacionesBancarias
{
    class Banco
    {
        private int MAX_CLIENTES = 10;

        private Cliente[] clientes;
        private int numeroDeClientes;

        public Banco()
        {
            clientes = new Cliente[MAX_CLIENTES];
            numeroDeClientes = 0;
        }

        public void AgregaCliente(String pn, String a)
        {
            int i = numeroDeClientes++;
            clientes[i] = new Cliente(pn, a);
        }
        public Cliente GetCliente(int indiceCliente)
        {
            return clientes[indiceCliente];
        }
        public int NumeroDeClientes
        {
            get
            {
                return numeroDeClientes;
            }
        }
    }
}
