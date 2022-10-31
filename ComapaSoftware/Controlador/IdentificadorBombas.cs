using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComapaSoftware.Controlador
{
    internal class IdentificadorBombas<T>
    {

        private T[] arr = new T[99];

        public T this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }

        public IdentificadorBombas(){

            }
    }
}
