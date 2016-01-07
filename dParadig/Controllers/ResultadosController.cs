using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dParadig.Models;
using dParadig.ViewModels;

namespace dParadig.Controllers
{
    public class ResultadosController : Controller
    {
        //
        // GET: /Resultados/

        public ActionResult Index()
        {
            DateTime fechaInicio = DateTime.Now.AddDays(-365);
            DateTime fechaFin = DateTime.Now;

            while (((int)fechaInicio.DayOfWeek == 0 ? 7 : (int)fechaInicio.DayOfWeek) != 1)
            {
                fechaInicio = fechaInicio.AddDays(1);
            }

            List<Semanas> listaSemanas = new List<Semanas>();

            int nroSemana = 1;
            foreach (DateTime sem in CadaSemana(fechaInicio, fechaFin))
            {
                Semanas semana = new Semanas();
                semana.Rango = nroSemana + ": " + sem.ToShortDateString() + " - " + sem.AddDays(7).ToShortDateString();
                semana.NroSemana = nroSemana;
                listaSemanas.Add(semana);

                nroSemana++;
            }

            return View(listaSemanas);
        }

        public ActionResult ObtenerResultado(int? semanaResultado)
        {
            JefeAreaDL jefeAreaData = new JefeAreaDL();
            ReunionesDL reunionesData = new ReunionesDL();
            HorariosDL horarioData = new HorariosDL();
            List<JefeArea> listaJefes = jefeAreaData.ObtenerJefes();
            List<Reuniones> listaReuniones;
            Horarios horarioJefe;
            DateTime inicioResultado = new DateTime();
            DateTime finResultado = new DateTime();
            DateTime fechaInicio = DateTime.Now.AddDays(-365);
            DateTime fechaFin = DateTime.Now;
            
            while (((int)fechaInicio.DayOfWeek == 0 ? 7 : (int)fechaInicio.DayOfWeek) != 1)
            {
                fechaInicio = fechaInicio.AddDays(1);
            }

            int nroSemana = 1;
            foreach (DateTime sem in CadaSemana(fechaInicio, fechaFin))
            {
                if (nroSemana == semanaResultado)
                {
                    inicioResultado = sem;
                    finResultado = sem.AddDays(7);
                    break;
                }

                nroSemana++;
            }


            List<ResultadosVM> listaResultados = new List<ResultadosVM>();

            foreach (JefeArea iJefe in listaJefes)
            {
                ResultadosVM resultadoJefe = new ResultadosVM();
                horarioJefe = horarioData.ObtenerHorario(iJefe.IdJefe);
                listaReuniones = reunionesData.ObtenerReuniones(inicioResultado, finResultado, iJefe.IdJefe);

                resultadoJefe.NombreJefe = iJefe.Nombre + " " + iJefe.Apellidos;
                resultadoJefe.Cumplimiento = CalcularCumplimiento(horarioJefe, listaReuniones);

                listaResultados.Add(resultadoJefe);
            }

            return PartialView(listaResultados);
        }

        private int CalcularCumplimiento(Horarios horarioJefe, List<Reuniones> reunionesJefe)
        {
            int diaReunion;
            int maxCumplimiento = horarioJefe.Lunes + horarioJefe.Martes + horarioJefe.Miercoles + horarioJefe.Jueves + horarioJefe.Viernes;
            int diasCumple = 0;

            foreach (Reuniones iReunion in reunionesJefe)
            {   
                diaReunion = (int)iReunion.Fecha.DayOfWeek == 0 ? 7 : (int)iReunion.Fecha.DayOfWeek;
                if (diaReunion == 1)
                {
                    if (horarioJefe.Lunes > 0)
                    {
                        horarioJefe.Lunes--;
                        diasCumple++;
                    }
                }
                else if (diaReunion == 2)
                {
                    if (horarioJefe.Martes > 0)
                    {
                        horarioJefe.Martes--;
                        diasCumple++;
                    }
                }
                else if (diaReunion == 3)
                {
                    if (horarioJefe.Miercoles > 0)
                    {
                        horarioJefe.Miercoles--;
                        diasCumple++;
                    }
                }
                else if (diaReunion == 4)
                {
                    if (horarioJefe.Jueves > 0)
                    {
                        horarioJefe.Jueves--;
                        diasCumple++;
                    }
                }
                else if (diaReunion == 5)
                {
                    if (horarioJefe.Viernes > 0)
                    {
                        horarioJefe.Viernes--;
                        diasCumple++;
                    }
                }
            }

            if (diasCumple == 0 && maxCumplimiento == 0)
                return 100;
            else
                return (int)((decimal)diasCumple / (decimal)maxCumplimiento * 100);
        }

        private IEnumerable<DateTime> CadaSemana(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(7))
                yield return day;
        }


    }
}


