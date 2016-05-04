using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabemusPapa2012
{
    class Conclave
    {
        //Variables
        private int _cantMaxCardenales;
        private List<Cardenal> _cardenales;
        private bool _habemusPapa;
        private string _lugarEleccion;
        private Cardenal _papa;

        public static int cantidadVotaciones;
        public static DateTime fechaVotacion;

        //--------------------------------------------------------------

        /*Constructores*/
        static Conclave()
        {
            cantidadVotaciones = 0;
            fechaVotacion = DateTime.Now;
        }

        public Conclave()
        {
            this._cantMaxCardenales = 1;
            this._lugarEleccion = "Capilla Sixtina";
            this._cardenales = new List<Cardenal>();
        }

        private Conclave(int cantidadCardenales):this()
        {
            this._cantMaxCardenales = cantidadCardenales;
        }

        public Conclave(int cantidadCardenales, string lugarEleccion):this()
        { }

        //---------------------------------------------------------------

        /*Sobrecarga de operadores de conversion*/
        public static explicit operator bool(Conclave con)
        {
            bool respuesta = false;

            if (con._habemusPapa == true)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public static implicit operator Conclave(int cantidadCardenales)
        {
            return new Conclave(cantidadCardenales);
        }

        //----------------------------------------------------------------

        /*Metodos*/
        private static void ContarVotos(Conclave conclave)
        {
            int indice = 0;

            foreach (Cardenal item in conclave._cardenales)
            {
                if (item.getCantidadVotosRecibidos() >= conclave._cardenales[indice].getCantidadVotosRecibidos())
                {
                    indice = conclave._cardenales.IndexOf(item);
                }
            }

            conclave._habemusPapa = true;
            conclave._papa = conclave._cardenales[indice];
        }
        
        private bool HayLugar()
        {
            bool respuesta=false;

            if (this._cantMaxCardenales > this._cardenales.Count)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public string Mostrar()
        {
            string rta = "";

            if (this._habemusPapa == true)
            {
                rta = string.Concat("\nLugar de votacion: " + this._lugarEleccion + "\nFecha de votacion: " + fechaVotacion + "\nCantidad de votaciones: " + cantidadVotaciones + "\nHABEMUS PAPA" + "\n" + this._papa.ObtenerNombreYNombrePapal());
            }
            else
            {
                rta = string.Concat("\nLugar de votacion: " + this._lugarEleccion + "\nFecha de votacion: " + fechaVotacion + "\nCantidad de votaciones: " + cantidadVotaciones + "\nNO HABEMUS PAPA" + "\n" + MostrarCardenales());
            }

            return rta;
        }

        private string MostrarCardenales()
        {
            string rta = "";

            foreach (Cardenal item in _cardenales)
            {
                rta += Cardenal.Mostrar(item);
            }

            return rta;
        }

        public static void VotarPapa(Conclave conclave)
        {
            Random rnd = new Random();

            //foreach (Cardenal item in conclave._cardenales)
            //{

                int IndicePapal = rnd.Next(0, conclave._cardenales.Count - 1);

                conclave._cardenales[IndicePapal]++;
                ContarVotos(conclave);

            //}
        }

        //---------------------------------------------------------------------

        /*Sobrecarga de operadores*/
        public static bool operator !=(Conclave con, Cardenal c)
        {
            return !(con == c);
        }
        //REVISAR
        public static Conclave operator +(Conclave con, Cardenal c)
        {  /*  
            
            if (con.HayLugar() == true)
            {
                if (!con._cardenales.Where(cc => cc == c).Any())
                {
                    con._cardenales.Add(c);
                }
            }*/


            if (con.HayLugar() == true && (con != c))
            {
                con._cardenales.Add(c);
            }
            return con;
            
            //if (con.HayLugar() == true)
            //{
            //    foreach (Cardenal item in con._cardenales)
            //    {
            //        if (item != c)
            //        {
            //            con._cardenales.Add(c);
            //        }
            //    }
            //}
        }

        public static bool operator ==(Conclave con, Cardenal c)
        {
            bool rta = false;

            foreach (Cardenal item in con._cardenales)
            {
                if (c == item)
                {
                    rta = true;
                }
            }

            return rta;
        }        
    }
}
