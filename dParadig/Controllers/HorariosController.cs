using dParadig.Models;
using dParadig.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace dParadig.Controllers
{
    public class HorariosController : Controller
    {
        //
        // GET: /Horarios/

        public ActionResult Index()
        {
            HorariosDL horariosData = new HorariosDL();
            JefeAreaDL jefeAreaData = new JefeAreaDL();
            List<HorariosVM> listaHorariosVM = new List<HorariosVM>();
            List<JefeArea> listaJefes = jefeAreaData.ObtenerJefes();

            foreach (JefeArea item in listaJefes)
            {
                HorariosVM horarioVM = new HorariosVM();
                horarioVM.IdJefe = item.IdJefe;
                JefeArea jefeArea = jefeAreaData.ObtenerJefe(item.IdJefe);
                horarioVM.NombreJefe = jefeArea.Nombre + " " + jefeArea.Apellidos;
                Horarios horario = horariosData.ObtenerHorario(item.IdJefe);

                horarioVM.Lunes = horario.Lunes;
                horarioVM.Martes = horario.Martes;
                horarioVM.Miercoles = horario.Miercoles;
                horarioVM.Jueves = horario.Jueves;
                horarioVM.Viernes = horario.Viernes;
                listaHorariosVM.Add(horarioVM);
            }

            return PartialView(listaHorariosVM);
        }

    }
}
