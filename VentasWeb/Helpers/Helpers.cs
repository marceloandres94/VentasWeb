using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace VentasWeb.Helpers
{
    public static class Helpers
    {
        public static MvcHtmlString ActionLinkAllow(this HtmlHelper helper)
        {

            StringBuilder sb = new StringBuilder();

            if (HttpContext.Current.Session["Usuario"] != null)
            {

                Usuario oUsuario = (Usuario)HttpContext.Current.Session["Usuario"];

                Usuario rptUsuario = CD_Usuario.Instancia.ObtenerDetalleUsuario(oUsuario.IdUsuario);


                foreach (Menu item in rptUsuario.oListaMenu)
                {
                    sb.AppendLine("<li class='nav-item dropdown'>");
                    sb.AppendLine("<a class='nav-link dropdown-toggle' href='#' data-toggle='dropdown'><i class='" + item.Icono +"'></i> " + item.Nombre + "</a>");

                    sb.AppendLine("<div class='dropdown-menu drop-menu'>");
                    foreach (SubMenu subitem in item.oSubMenu)
                    {
                        //fas fa-caret-right
                        if(subitem.Activo == true)
                            sb.AppendLine("<a class='dropdown-item' name='" + item.Nombre + "' href='/" + subitem.Controlador + "/" + subitem.Vista + "'><i class='" + subitem.Icono + "'></i> " + subitem.Nombre + "</a>");

                    }
                    sb.AppendLine("</div>");

                    sb.AppendLine("</li>");
                }


            }


            return new MvcHtmlString(sb.ToString());
        }
        public static MvcHtmlString Ultimas5Ventas(this HtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            List<Venta> oVenta = CD_Venta.Instancia.ObtenerUltimasVenta();
            if (HttpContext.Current.Session["Usuario"] != null)
            {
                foreach (Venta item in oVenta)
                {
                    sb.AppendLine("<div class='d-flex border-bottom py-2'>");

                    sb.AppendLine("<div class='d-flex mr-3'>");

                    sb.AppendLine("<h2 class='align-self-center mb-0'><i class='icon ion-md-pricetag'></i></h2>");

                    sb.AppendLine("</div>");

                    sb.AppendLine("<div class='align-self-center'>");

                    sb.AppendLine("<h6 class='d-inline-block mb-0'>$" + item.TotalCosto + "</h6>");

                    sb.AppendLine("<small class='d-block text-muted'>Fecha venta: " + item.FechaRegistro + " </small>");

                    sb.AppendLine("</div>");

                    sb.AppendLine("</div>");

                }

            }
            return new MvcHtmlString(sb.ToString());
        }
        public static MvcHtmlString StockDeProductos(this HtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            List<IndicadorStock> indStock = CD_ProductoTienda.Instancia.ObtenerIndicadorStock();
            if (HttpContext.Current.Session["Usuario"] != null)
            {
                foreach (IndicadorStock item in indStock)
                {
                    sb.AppendLine("<h3 class='font - weight - bold'>" + item.StockDisponible + "</h3>");
                }

            }
            return new MvcHtmlString(sb.ToString());
        }
        public static MvcHtmlString StockCritico(this HtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            List<IndicadorStock> indStock = CD_ProductoTienda.Instancia.ObtenerIndicadorStock3();
            if (HttpContext.Current.Session["Usuario"] != null)
            {
                foreach (IndicadorStock item in indStock)
                {
                    sb.AppendLine("<h3 class='font - weight - bold'>" + item.StockCritico + "</h3>");
                }

            }
            return new MvcHtmlString(sb.ToString());
        }
        public static MvcHtmlString SinStock(this HtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            List<IndicadorStock> indStock = CD_ProductoTienda.Instancia.ObtenerIndicadorStock2();
            if (HttpContext.Current.Session["Usuario"] != null)
            {
                foreach (IndicadorStock item in indStock)
                {
                    sb.AppendLine("<h3 class='font - weight - bold'>" + item.StockAgotado + "</h3>");
                }

            }
            return new MvcHtmlString(sb.ToString());
        }
        public static MvcHtmlString SinProblemas(this HtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            List<IndicadorFechaVencimiento> indStock = CD_ProductoTienda.Instancia.ObtenerIndicadorFechaVencimiento();
            if (HttpContext.Current.Session["Usuario"] != null)
            {
                foreach (IndicadorFechaVencimiento item in indStock)
                {
                    sb.AppendLine("<h3 class='font-weight-bold text-white text-center'>" + item.SinProblemas + "</h3>");
                }

            }
            return new MvcHtmlString(sb.ToString());
        }
        public static MvcHtmlString PorVencer(this HtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            List<IndicadorFechaVencimiento> indStock = CD_ProductoTienda.Instancia.ObtenerIndicadorFechaVencimiento2();
            if (HttpContext.Current.Session["Usuario"] != null)
            {
                foreach (IndicadorFechaVencimiento item in indStock)
                {
                    sb.AppendLine("<h3 class='font-weight-bold text-white text-center'>" + item.PorVencer + "</h3>");
                }

            }
            return new MvcHtmlString(sb.ToString());
        }
        public static MvcHtmlString Vencidos(this HtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            List<IndicadorFechaVencimiento> indStock = CD_ProductoTienda.Instancia.ObtenerIndicadorFechaVencimiento3();
            if (HttpContext.Current.Session["Usuario"] != null)
            {
                foreach (IndicadorFechaVencimiento item in indStock)
                {
                    sb.AppendLine("<h3 class='font-weight-bold text-white text-center'>" + item.Vencidos + "</h3>");
                }

            }
            return new MvcHtmlString(sb.ToString());
        }
        public static MvcHtmlString MargenBeneficioBruto(this HtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            List<IndicadorBeneficioBruto> indStock = CD_ProductoTienda.Instancia.ObtenerMargenBeneficioBruto();
            if (HttpContext.Current.Session["Usuario"] != null)
            {
                foreach (IndicadorBeneficioBruto item in indStock)
                {
                    sb.AppendLine("<h3 class='font - weight - bold text-center'>" + item.MargenBeneficioBruto +"%</h3>");
                }

            }
            return new MvcHtmlString(sb.ToString());
        }
        public static MvcHtmlString SumBeneficioBruto(this HtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            List<IndicadorBeneficioBruto> indStock = CD_ProductoTienda.Instancia.ObtenerBeneficioBruto();
            if (HttpContext.Current.Session["Usuario"] != null)
            {
                foreach (IndicadorBeneficioBruto item in indStock)
                {
                    sb.AppendLine("<h3 class='font - weight - bold text-center'>$"+ item.BeneficioBruto + "</h3>");
                }

            }
            return new MvcHtmlString(sb.ToString());
        }
    }
}