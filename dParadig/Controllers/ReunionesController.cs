using dParadig.Models;
using dParadig.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace dParadig.Controllers
{
    public class ReunionesController : Controller
    {
        //
        // GET: /Reuniones/

        public ActionResult Index()
        {
            JefeAreaDL jefeAreaData = new JefeAreaDL();
            ReunionesDL reunionesData = new ReunionesDL();
            List<ReunionesVM> listaReunionesVM = new List<ReunionesVM>();
            List<Reuniones> listaReuniones = reunionesData.ObtenerReuniones();

            foreach (Reuniones item in listaReuniones)
            {
                ReunionesVM reunionVM = new ReunionesVM();
                reunionVM.IdJefe = item.IdJefe;
                JefeArea jefeArea = jefeAreaData.ObtenerJefe(item.IdJefe);
                reunionVM.NombreJefe = jefeArea.Nombre + " " + jefeArea.Apellidos;

                reunionVM.Fecha = item.Fecha.ToString("dddd") + ", " + item.Fecha.ToString("M") + " del " + item.Fecha.ToShortDateString().Substring(6, 4);

                listaReunionesVM.Add(reunionVM);
            }

            return PartialView(listaReunionesVM);
        }
    }
}
