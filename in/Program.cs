using InteresCompuestoCalculo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace @in
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int IngresoMenual = 0;
            double CantidadInicial = 0;
            double CantidadFinal = 0;
            double Interes = 0.0;
            int CantidadMeses = 1;

            Console.WriteLine("¿Quiere agregar inversion mensual? S|N");
            string IngresoMensualValidar = Console.ReadLine().ToLower();

            if (IsIngresoMensual(IngresoMensualValidar))
            {
                do
                {
                    try
                    {
                        Console.WriteLine("Ingrese la cantidad mensual de inversion");
                        IngresoMenual = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Tiene que ingresar un dato valido o que sea mayor a 0");
                    }
                } while (IngresoMenual == 0);
            }

            do
            {
                try
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Ingrese la cantidad Incial se su inversion");
                    CantidadInicial = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Debe ingresar un valor mayor a 0");
                }
                
            } while (CantidadInicial == 0);

            do
            {
                try
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Ingrese el % mensual generado");
                    Interes = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Debe ingresar un valor mayor a 0");
                }

            } while (Interes == 0);

            do
            {
                try
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Ingrese la cantidad de meses a cacular");
                    CantidadMeses = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Debe ingresar un valor mayor a 0");
                }

            } while (CantidadMeses == 0);

            for (int i = 1; i < CantidadMeses + 1; i++)
            {
                double InteresCompuesto;
                if (i == 1)
                {
                    CantidadFinal = CantidadInicial + 0;
                    InteresCompuesto = (CantidadFinal / 100) * Interes;
                    CantidadFinal = CantidadInicial + InteresCompuesto;
                }
                else
                {
                    CantidadFinal = CantidadFinal + IngresoMenual;
                    InteresCompuesto = (CantidadFinal / 100) * Interes;
                    CantidadFinal = CantidadFinal + InteresCompuesto;
                }
                
                
                Console.WriteLine("Interes ganado mes "+i+ " : " + Convert.ToInt64(InteresCompuesto));
                
                
            }
            ObtenerValorDolarAClp();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Cantidad Inicial : " + Convert.ToInt64(CantidadInicial));
            Console.WriteLine("Dolar : " + Convert.ToInt64(CantidadFinal));
            Console.WriteLine("Peso chileno : "+Convert.ToInt64(CantidadFinal * ObtenerValorDolarAClp()));
            Console.ReadLine();
        }

        //Validamo que quiera ingresar las inversiones mensuales
        private static bool IsIngresoMensual(string dato)
        {
            bool isRespuesta = false;
            try
            {
                dato = dato.ToLower();
                if (dato == "s" || dato == "si")
                {
                    isRespuesta = true;
                }
                else
                {
                    if (dato == "n" || dato == "no")
                    {

                    }
                    else
                    {
                        Console.WriteLine("Tiene que ingresar S o N");
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Tiene que ingresar S o N");
            }

            return isRespuesta;
        }

        private static double ObtenerValorDolarAClp()
        {
            ObtenerValorDolar obtenerValorDolar = new ObtenerValorDolar();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://mindicador.cl/api");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                obtenerValorDolar = JsonConvert.DeserializeObject<ObtenerValorDolar>(json);
            }

            return obtenerValorDolar.dolar.valor;
        }
    }
}
