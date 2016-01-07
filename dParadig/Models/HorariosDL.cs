using System.Collections.Generic;
using System.IO;

namespace dParadig.Models
{
    public class HorariosDL
    {
        public List<Horarios> ObtenerHorarios()
        {
            List<Horarios> listaHorarios = new List<Horarios>();
            string fuente = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/Fuente"), "Horarios.txt");

            using (TextReader tr = new StreamReader(new FileStream(fuente, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                string linea;
                while ((linea = tr.ReadLine()) != null)
                {
                    var datos = linea.Split(';');

                    Horarios horario = new Horarios();
                    horario.IdJefe = int.Parse(datos[0].Trim());
                    horario.Lunes = int.Parse(datos[1].Trim());
                    horario.Martes = int.Parse(datos[2].Trim());
                    horario.Miercoles = int.Parse(datos[3].Trim());
                    horario.Jueves = int.Parse(datos[4].Trim());
                    horario.Viernes = int.Parse(datos[5].Trim());

                    listaHorarios.Add(horario);
                }
            }

            return listaHorarios;
        }

        public Horarios ObtenerHorario(int idJefe)
        {
            Horarios horario = null;
            string fuente = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/Fuente"), "Horarios.txt");
            int idJefeLinea;

            using (TextReader tr = new StreamReader(new FileStream(fuente, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                string linea;
                while ((linea = tr.ReadLine()) != null)
                {
                    var datos = linea.Split(';');
                    idJefeLinea = int.Parse(datos[0].Trim());

                    if (idJefe == idJefeLinea)
                    {
                        horario = new Horarios();
                        horario.IdJefe = idJefeLinea;
                        horario.Lunes = int.Parse(datos[1].Trim());
                        horario.Martes = int.Parse(datos[2].Trim());
                        horario.Miercoles = int.Parse(datos[3].Trim());
                        horario.Jueves = int.Parse(datos[4].Trim());
                        horario.Viernes = int.Parse(datos[5].Trim());
                        break;
                    }
                }
            }

            if (horario == null)
            {
                horario = new Horarios();
                horario.IdJefe = idJefe;
                horario.Lunes = 0;
                horario.Martes = 0;
                horario.Miercoles = 0;
                horario.Jueves = 0;
                horario.Viernes = 0;
            }

            return horario;
        }

    }
}