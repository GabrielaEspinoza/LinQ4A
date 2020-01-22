using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinQ2.Clases;

namespace LinQ2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Cliente> cliente = new List<Cliente>
            {
                new Cliente{Id=1305036422,Nombre="Kevin" }, new Cliente{Id=1312804734,Nombre="Mero"},
                new Cliente{Id=1307004240,Nombre="Jose"}, new Cliente{Id=1304050789,Nombre="Moreira"},
                new Cliente{Id=1305566879,Nombre="Juleydy"}, new Cliente{Id=1050748596,Nombre="Baque"},
                new Cliente{Id=1305078406,Nombre="Jung"}, new Cliente{Id=1340507840,Nombre="Espinal" },
                new Cliente{Id=1304758410,Nombre="Danny"}, new Cliente{Id=1305048795,Nombre="Mendoza"},
            };

            List<Factura> factura = new List<Factura>
            {
                new Factura{Observacion="Plato",Fecha=new DateTime(2020,2,02),IdCliente=1312804734,Total=15},
                new Factura{Observacion="Plato",Fecha=new DateTime(2020,4,28),IdCliente=1312804734,Total=15},
                new Factura{Observacion="Comida",Fecha=new DateTime(2020,7,18),IdCliente=1312804734,Total=7},
                new Factura{Observacion="Macbook Pro",Fecha=new DateTime(2020,5,08),IdCliente=1050748596,Total=1999},
                new Factura{Observacion="Lenovo",Fecha=new DateTime(2020,2,4),IdCliente=1050748596,Total=800},
                new Factura{Observacion="Pan",Fecha=new DateTime(2020,1,7),IdCliente=1340507840,Total=5},
                new Factura{Observacion="Pan",Fecha=new DateTime(2020,1,7),IdCliente=1340507840,Total=5},
                new Factura{Observacion="Pescado",Fecha=new DateTime(2020,1,4),IdCliente=1305048795,Total=12},
                new Factura{Observacion="Manzana",Fecha=new DateTime(2019,3,4),IdCliente=1305048795,Total=3},
                new Factura{Observacion="Cafe",Fecha=new DateTime(2019,3,4),IdCliente=1050748596,Total=2},

            };

            var lista =
                from facturas in factura
                join clientes in cliente on facturas.IdCliente equals clientes.Id
                select new { nombre = clientes.Nombre, observacion = facturas.Observacion, fecha = facturas.Fecha, total = facturas.Total };

            var mayorVenta =
                from buscarMayor in lista
                orderby buscarMayor.total descending
                select new { buscarMayor.total, buscarMayor.nombre };

            var menorVenta =
                from buscarMenor in lista
                orderby buscarMenor.total ascending
                select new { buscarMenor.total, buscarMenor.nombre };

            var anio2019 =
                from buscarAntigua in lista
                where buscarAntigua.fecha == new DateTime(2019,3,4)
                select buscarAntigua;

            var ventaAntigua =
                from antigua in lista
                orderby antigua.fecha ascending
                select new { antigua.fecha, antigua.nombre, antigua.total };

            var buscarplato =
                from platos in lista
                where platos.observacion == "Plato"
                select platos;

            int contador = 0;
            int contador2 = 0;
            int contador3 = 0;

            Console.WriteLine("********************************VENTA MAYOR*****************************************");
            foreach (var item in mayorVenta)
            {
                if (contador == 0)
                {
                    Console.WriteLine("El cliente con mayor venta realizada es: {0} y el total de la venta es: {1}", item.nombre, item.total);
                }

                if (contador < 3)
                {
                    Console.WriteLine("El cliente con mas ventas es: {0}, con un total de: {1}", item.nombre, item.total);
                }
                contador++;
            }
            Console.WriteLine("*******************************VENTAS MENOR******************************************");
            foreach (var item in menorVenta)
            {
                if (contador2 < 3)
                {
                    Console.WriteLine("El cliente con menor venta es: {0} con un total de: {1} ventas", item.nombre, item.total);
                }
                contador2++;
            }

            Console.WriteLine("****************************TODOS LOS CLIENTES*********************************************");
            foreach (var item in lista)
            {
                Console.WriteLine("Clientes: {0}, Total: {1}", item.nombre, item.total);
            }

            Console.WriteLine("***************************VENTA EN 2019**********************************************");
            foreach (var item in anio2019)
            {
                Console.WriteLine("La venta que sucedio en el anio 2019 es de: {0}", item.nombre);
            }

            Console.WriteLine("***************************VENTA ANTIGUA**********************************************");
            foreach (var item in ventaAntigua)
            {
                if (contador3 == 0)
                {
                    Console.WriteLine("El cliente con la venta mas antigua es: {0} \n El total de la venta es de: {1} " +
                        "\n La fecha de la venta fue en: {2}", item.nombre, item.total, item.fecha);
                }
            }

            Console.WriteLine("***************************VENTA DE PLATO**********************************************");
            foreach (var item in buscarplato)
            {
                Console.WriteLine("Los clientes que compraron un plato es: {0}", item.nombre);
            }
            Console.ReadKey();
        }
    }
}
