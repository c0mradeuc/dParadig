using dParadig.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace dParadig.Controllers
{
    public class JefesAreaController : Controller
    {
        //
        // GET: /JefesArea/

        public ActionResult Index()
        {
            JefeAreaDL jefeAreaData = new JefeAreaDL();
            List<JefeArea> listaJefes = jefeAreaData.ObtenerJefes();

            return View(listaJefes);
        }

        public ActionResult FormCrear()
        {
            return View();
        }

        public ActionResult FormEditar(string fIdJefe)
        {
            JefeAreaDL jefeAreaData = new JefeAreaDL();
            JefeArea jefeArea = jefeAreaData.ObtenerJefe(int.Parse(fIdJefe));

            return View(jefeArea);
        }

        public ActionResult Crear(string fNombre, string fApellido)
        {
            JefeAreaDL jefeAreaData = new JefeAreaDL();
            JefeArea jefeArea = new JefeArea();
            string resultado;
            jefeArea.Nombre = fNombre;
            jefeArea.Apellidos = fApellido;

            resultado = jefeAreaData.Crear(jefeArea);

            return Content(resultado);
        }

        public string Editar(string fIdJefe, string fNombre, string fApellido)
        {
            JefeAreaDL jefeAreaData = new JefeAreaDL();
            JefeArea jefeArea = new JefeArea();
            string resultado;
            jefeArea.IdJefe = int.Parse(fIdJefe);
            jefeArea.Nombre = fNombre;
            jefeArea.Apellidos = fApellido;

            resultado = jefeAreaData.Editar(jefeArea);

            return resultado;
        }

        public string Eliminar(string fIdJefe)
        {
            JefeAreaDL jefeAreaData = new JefeAreaDL();
            string resultado = string.Empty;
            int idJefe = int.Parse(fIdJefe);

            resultado = jefeAreaData.Eliminar(idJefe);

            return resultado;
        }
    }
}
