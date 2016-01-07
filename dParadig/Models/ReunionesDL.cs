using System.Collections.Generic;
using System.IO;
using System;

namespace dParadig.Models
{
    public class ReunionesDL
    {
        public List<Reuniones> ObtenerReuniones()
        {
            List<Reuniones> listaReuniones = new List<Reuniones>();
            string fuente = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/Fuente"), "Reuniones.txt");

            using (TextReader tr = new StreamReader(new FileStream(fuente, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                string linea;
                while ((linea = tr.ReadLine()) != null)
                {
                    var datos = linea.Split(';');

                    Reuniones reunion = new Reuniones();
                    reunion.IdJefe = int.Parse(datos[0].Trim());
                    reunion.Fecha = DateTime.Parse(datos[1].Trim());

                    listaReuniones.Add(reunion);
                }
            }

            return listaReuniones;
        }

        public List<Reuniones> ObtenerReuniones(DateTime fechaInicio, DateTime fechaFinal, int idJefe)
        {
            List<Reuniones> listaReuniones = new List<Reuniones>();
            string fuente = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/Fuente"), "Reuniones.txt");

            using (TextReader tr = new StreamReader(new FileStream(fuente, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                string linea;
                while ((linea = tr.ReadLine()) != null)
                {
                    var datos = linea.Split(';');

                    Reuniones reunion = new Reuniones();
                    reunion.IdJefe = int.Parse(datos[0].Trim());
                    reunion.Fecha = DateTime.Parse(datos[1].Trim());

                    if (reunion.Fecha >= fechaInicio && reunion.Fecha <= fechaFinal && reunion.IdJefe == idJefe)
                        listaReuniones.Add(reunion);
                }
            }

            return listaReuniones;
        }
    }
}