using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using operacionesBancarias;

namespace verificaciones
{
    class PruebaOperacionesBancarias
    {
        static void Main(string[] args)
        {
            Banco banco = new Banco();
            Cliente cliente;

            Console.WriteLine("Creando al cliente Juan Perez");
            banco.AgregaCliente("Juan", "Pérez");
            cliente = banco.GetCliente(0);
            Console.WriteLine("Creando una caja de ahorros con 500.00 de balance con el 3% de interés.");
            cliente.AgregaCuenta(new CajaDeAhorro(500.00, 0.03));

            Console.WriteLine("Creando al cliente Pedro García.");
            banco.AgregaCliente("Pedro", "García");
            Console.WriteLine("Creando una cuenta corriente con 500.00 de balance y sin protección de sobregiro.");
            cliente = banco.GetCliente(1);
            cliente.AgregaCuenta(new CuentaCorriente(500.00));

            Console.WriteLine("Creando al cliente Oscar Toma.");
            banco.AgregaCliente("Oscar", "Toma");
            cliente = banco.GetCliente(2);
            Console.WriteLine("Creando una cuenta corriente con 500.00 de balance y 500.00 de protección de sobregiro.");
            cliente.AgregaCuenta(new CuentaCorriente(500.00, 500.00));
            cliente.AgregaCuenta(new CajaDeAhorro(0.00, 0.03));

            Console.WriteLine("Creando a la cliente Maria Soley.");
            banco.AgregaCliente("Maria", "Soley");
            cliente = banco.GetCliente(3);
            // Maria y Oscar tienen una caja de ahorros en común
            Console.WriteLine("María comparte su caja de ahorro con su esposo Oscar.");
            cliente.AgregaCuenta(banco.GetCliente(2).GetCuenta(1));

            Console.WriteLine();

            Console.WriteLine("Recuperando al cliente Juan Perez y su caja de ahorro.");
            cliente = banco.GetCliente(0);
            Cuenta cuenta = cliente.GetCuenta(0);
            Console.WriteLine("Retira 150.00: " + cuenta.Retira(150.00));
            Console.WriteLine("Deposita 22.50: " + cuenta.Deposita(22.50));
            Console.WriteLine("Retira 47.62: " + cuenta.Retira(150.00));
            Console.WriteLine("Retira 400.00: " + cuenta.Retira(400.00));
            Console.WriteLine("Cliente [" + cliente.Apellido + ", "
                    + cliente.PrimerNombre + "] tiene un balance de "
                    + cuenta.Balance);

            Console.WriteLine();

            Console.WriteLine("Recuperando al cliente Pedro García y su cuenta corriente.");
            cliente = banco.GetCliente(1);
            cuenta = cliente.GetCuenta(0);
            Console.WriteLine("Retira 150.00: " + cuenta.Retira(150.00));
            Console.WriteLine("Deposita 22.50: " + cuenta.Deposita(22.50));
            Console.WriteLine("Retira 47.62: " + cuenta.Retira(150.00));
            Console.WriteLine("Retira 400.00: " + cuenta.Retira(400.00));
            Console.WriteLine("Cliente [" + cliente.Apellido + ", "
                    + cliente.PrimerNombre + "] tiene un balance de "
                    + cuenta.Balance);

            Console.WriteLine();

            Console.WriteLine("Recuperando al cliente Oscar Toma y su cuenta corriente.");
            cliente = banco.GetCliente(2);
            cuenta = cliente.GetCuenta(0);
            Console.WriteLine("Retira 150.00: " + cuenta.Retira(150.00));
            Console.WriteLine("Deposita 22.50: " + cuenta.Deposita(22.50));
            Console.WriteLine("Retira 47.62: " + cuenta.Retira(150.00));
            Console.WriteLine("Retira 400.00: " + cuenta.Retira(400.00));
            Console.WriteLine("Cliente [" + cliente.Apellido + ", "
                    + cliente.PrimerNombre + "] tiene un balance de "
                    + cuenta.Balance);

            Console.WriteLine();

            Console.WriteLine("Recuperando a la cliente Maria Soley y su caja de ahorro unida a su esposo Oscar.");
            cliente = banco.GetCliente(3);
            cuenta = banco.GetCliente(2).GetCuenta(1);
            Console.WriteLine("Deposita 150.00: " + cuenta.Deposita(150.00));
            Console.WriteLine("Retira 750.00: " + cuenta.Retira(750.00));
            Console.WriteLine("Cliente [" + cliente.Apellido + ", "
                    + cliente.PrimerNombre + "] tiene un balance de "
                    + cuenta.Balance);
            Console.ReadKey();
        }
    }
}
