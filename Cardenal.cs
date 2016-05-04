using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabemusPapa2012
{
    class Cardenal
    {
        /*Variables*/
        private int _cantidadVotosRecibidos;
        private ENacionalidades _nacionalidad;
        private string _nombre;
        private string _nombrePapal;


        //-----------------------------------------------------------

        /*Constructores*/
        private Cardenal()
        {
            this._cantidadVotosRecibidos = 0;
        }

        public Cardenal(string nombre, string nombrePapal):this()
        {
            this._nombre = nombre;
            this._nombrePapal = nombrePapal;
        }

        public Cardenal(string nombre, string nombrePapal, ENacionalidades nacionalidad):this(nombre, nombrePapal)
        {
            this._nacionalidad = nacionalidad;
        }

        public int getCantidadVotosRecibidos()
        {
            return this._cantidadVotosRecibidos;
        }

        //-------------------------------------------------------------------------------
        
        /*Metodos*/
        private string Mostrar()
        {
            string final = "";

            final = string.Concat(ObtenerNombreYNombrePapal() + "\nSu nacionalidad es " + this._nacionalidad + " recibió " + this._cantidadVotosRecibidos + "votos\n");

            return final;
        }

        public static string Mostrar(Cardenal c)
        {
            string final = "";

            final = c.Mostrar();

            return final;
        }

        public string ObtenerNombreYNombrePapal()
        {
            string resultado = "";

            resultado = string.Concat("\nEl cardenal " + this._nombre + " se llamará " + this._nombrePapal);

            return resultado;
        }

        //--------------------------------------------------------------------------------

        /*Sobrecarga de operadores*/
        public static bool operator !=(Cardenal c1, Cardenal c2)
        {
            return !(c1 == c2);
        }

        public static Cardenal operator ++(Cardenal c)
        {
            c._cantidadVotosRecibidos++;

            return c;
        }

        public static bool operator ==(Cardenal c1, Cardenal c2)
        {
            bool rta = false;
            /*
            if (c1._nombre == c2._nombre && c1._nombrePapal == c2._nombrePapal && c1._nacionalidad == c2._nacionalidad)
            {
                rta = true;
            }*/

            if (c1.Mostrar() == c2.Mostrar() && c1._nacionalidad == c2._nacionalidad)
            {
                rta = true;
            }

            return rta;
        }
    }

    //Enumerador
    public enum ENacionalidades
    {
        Italiano, Polaco, Español, Argentino, Nigeriano
    }
}
