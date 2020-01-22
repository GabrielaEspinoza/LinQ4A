using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3_LinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //Obtener el promedio de todos los números mayores a 50.

            List<Operacion> numeros = new List<Operacion>();
            var seed = Environment.TickCount;
            var random = new Random(seed);
            for (int i = 0; i < 50; i++)
            {
                numeros.Add(new Operacion (random.Next(0, 100)));
            }

            Console.WriteLine("Lista de números");
            foreach (var item in numeros)
            {
                Console.WriteLine("{0}", item.Numero);
            }
            Console.WriteLine();

            IEnumerable<Operacion> mayoresA50 =
                  (numeros.Where(x => x.Numero > 50));

            Console.WriteLine("******Promedio de los números mayores a 50 son:******");
            Console.WriteLine(mayoresA50.Average(x => x.Numero));
            Console.WriteLine();

    
            //Contar en la lista la cantidad de números pares e impares. 
            //Este problema debe resolverse en una sentencia o en una sola consulta.

            IEnumerable<Operacion> listaPar =
                   numeros.Where(x => x.Numero % 2 == 0);

            Console.WriteLine("******Cantidad de números pares son:******");
            Console.WriteLine(listaPar.Count());
            Console.WriteLine();
            Console.WriteLine("******Cantidad de números impares son:******");
            Console.WriteLine(numeros.Count() - listaPar.Count());
            Console.WriteLine();

            //Mostrar por consola cada elemento y la cantidad de veces que se repite en la lista.
            int contador = 0;
            Console.WriteLine("******Números y cantidad de veces que se repiten:******");
            foreach (var item in numeros)
            {
               int  cont = 0;
                for (int i = 0; i < 1; i++)
                {
                    foreach (var num in numeros)
                    {
                        if (item.Numero == num.Numero)
                        {
                            cont++;
                        }
                    }
                }
                Console.WriteLine("{0}", item.Numero + "---" + cont);
            }
            Console.WriteLine();
            Console.ReadKey();

        }
    }


}
        //Console.ReadKey();

    

