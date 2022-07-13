using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VentasWeb.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Permisos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
        public JsonResult ObtenerProducto(int idcategoria)
        {
            List<ReporteProducto> lista = CD_Reportes.Instancia.DashProductoTienda(idcategoria);

            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerVentaBeneficio(int idcategoria)
        {
            List<ListaGanancias> lista = CD_Reportes.Instancia.DashVentaBeneficiotb(idcategoria);

            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerProductoCaducidad(int idcategoria)
        {
            List<ReporteProducto> lista = CD_Reportes.Instancia.DashProductoTiendaCaducidad(idcategoria);

            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Obtener()
        {
            List<Categoria> lista = CD_Categoria.Instancia.ObtenerCategoria();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerBeneficioCat(int idcategoria)
        {
            List<IndicadorBeneficioBruto> lista = CD_Reportes.Instancia.ObtenerBeneficioCat(idcategoria);

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

    }
}