using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3_LinQ
{
    public class Operacion
    {
        private int numero;

        public Operacion(int numero)
        {
            Numero = numero;
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public int NumerosPrimos()
        {
            int contador = 0;
            for (int i = 1; i <= this.Numero; i++)
            {
                int mod = this.Numero % i;
                if (mod == 0)
                    contador++;
            }
            return contador;
        }

        //Contar en la lista la cantidad de números pares e impares. 
        //Este problema debe resolverse en una sentencia o en una sola consulta.
        public int NumerosPares()
        {
            int par = 0;
            int mod = this.Numero % 2;
            if (mod == 0)
            {
                par++;
            }
            return par;
        }

       


    }
}
