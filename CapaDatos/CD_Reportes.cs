using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Reportes
    {
        public static CD_Reportes _instancia = null;

        private CD_Reportes()
        {

        }

        public static CD_Reportes Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Reportes();
                }
                return _instancia;
            }
        }

        public List<ReporteProducto> ReporteProductoTienda(int IdTienda, string CodigoProducto)
        {
            List<ReporteProducto> lista = new List<ReporteProducto>();

            NumberFormatInfo formato = new CultureInfo("es-CL").NumberFormat;
            formato.CurrencyGroupSeparator = ".";

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_rptProductoTienda", oConexion);
                cmd.Parameters.AddWithValue("@IdTienda", IdTienda);
                cmd.Parameters.AddWithValue("@Codigo", CodigoProducto);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    
                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read()) {
                            lista.Add(new ReporteProducto()
                            {
                                RucTienda = dr["Ruc Tienda"].ToString(),
                                NombreTienda = dr["Nombre Tienda"].ToString(),
                                DireccionTienda = dr["Direccion Tienda"].ToString(),
                                CodigoProducto = dr["Codigo Producto"].ToString(),
                                NombreProducto = dr["Nombre Producto"].ToString(),
                                DescripcionProducto = dr["Descripcion Producto"].ToString(),
                                StockenTienda = dr["Stock en tienda"].ToString(),
                                PrecioCompra = dr["Precio Compra"].ToString(),
                                PrecioVenta = dr["Precio Venta"].ToString()
                            });
                        }

                    }

                }
                catch (Exception ex)
                {
                    lista = new List<ReporteProducto>();
                }
            }

            return lista;
        }
        public List<ReporteProducto> DashProductoTienda(int IdCategoria)
        {
            List<ReporteProducto> lista = new List<ReporteProducto>();

            NumberFormatInfo formato = new CultureInfo("es-CL").NumberFormat;
            formato.CurrencyGroupSeparator = ".";

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("Inv_Stock", oConexion);
                cmd.Parameters.AddWithValue("@IdCategoria", IdCategoria);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteProducto()
                            {
                                RucTienda = dr["RUC"].ToString(),
                                NombreTienda = dr["NombreTienda"].ToString(),
                                NombreCategoria = dr["Categoria"].ToString(),
                                DireccionTienda = dr["DireccionTienda"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                DescripcionProducto = dr["DescripcionProducto"].ToString(),
                                StockenTienda = dr["Stock"].ToString(),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioUnidadCompra"].ToString(), new CultureInfo("es-CL")).ToString("N", formato),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioUnidadVenta"].ToString(), new CultureInfo("es-CL")).ToString("N", formato)
                            });
                        }

                    }

                }
                catch (Exception ex)
                {
                    lista = new List<ReporteProducto>();
                }
            }

            return lista;
        }
        public List<ReporteProducto> DashProductoTiendaCaducidad(int IdCategoria)
        {
            List<ReporteProducto> lista = new List<ReporteProducto>();

            NumberFormatInfo formato = new CultureInfo("es-CL").NumberFormat;
            formato.CurrencyGroupSeparator = ".";

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerProductosCaducidad", oConexion);
                cmd.Parameters.AddWithValue("@IdCategoria", IdCategoria);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteProducto()
                            {
                                RucTienda = dr["RUC"].ToString(),
                                NombreTienda = dr["NombreTienda"].ToString(),
                                NombreCategoria = dr["Categoria"].ToString(),
                                DireccionTienda = dr["DireccionTienda"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                DescripcionProducto = dr["DescripcionProducto"].ToString(),
                                StockenTienda = dr["Stock"].ToString(),
                                PrecioCompra = dr["PrecioUnidadCompra"].ToString(),
                                PrecioVenta =dr["PrecioUnidadVenta"].ToString(),
                                FechaVencimiento = dr["FechaVencimiento"].ToString(),
                            });
                        }

                    }

                }
                catch (Exception ex)
                {
                    lista = new List<ReporteProducto>();
                }
            }

            return lista;
        }

        public List<ReporteVenta> ReporteVenta(DateTime FechaInicio, DateTime FechaFin, int IdTienda)
        {
            List<ReporteVenta> lista = new List<ReporteVenta>();

            NumberFormatInfo formato = new CultureInfo("es-CL").NumberFormat;
            formato.CurrencyGroupSeparator = ".";

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_rptVenta", oConexion);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                cmd.Parameters.AddWithValue("@IdTienda", IdTienda);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVenta()
                            {
                                FechaVenta = dr["Fecha Venta"].ToString(),
                                NumeroDocumento = dr["Numero Documento"].ToString(),
                                TipoDocumento = dr["Tipo Documento"].ToString(),
                                NombreTienda = dr["Nombre Tienda"].ToString(),
                                RucTienda = dr["Ruc Tienda"].ToString(),
                                NombreEmpleado = dr["Nombre Empleado"].ToString(),
                                CantidadUnidadesVendidas = dr["Cantidad Unidades Vendidas"].ToString(),
                                CantidadProductos = dr["Cantidad Productos"].ToString(),
                                TotalVenta = dr["Total Venta"].ToString(),
                            });
                        }

                    }

                }
                catch (Exception ex)
                {
                    lista = new List<ReporteVenta>();
                }
            }

            return lista;

        }
        public List<IndicadorVenta> InidicadorVenta(DateTime FechaInicio, DateTime FechaFin, int IdTienda)
        {
            List<ReporteVenta> lista = new List<ReporteVenta>();
            List<IndicadorVenta> list = new List<IndicadorVenta>();

            NumberFormatInfo formato = new CultureInfo("es-CL").NumberFormat;
            formato.CurrencyGroupSeparator = ".";

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_IndicadorVentasRealizadas", oConexion);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                cmd.Parameters.AddWithValue("@IdTienda", IdTienda);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(new IndicadorVenta()
                            {
                                VentasRealizadas = dr["VentasRealizadas"].ToString(),
                            });
                        }

                    }

                }
                catch (Exception ex)
                {
                    lista = new List<ReporteVenta>();
                    list = new List<IndicadorVenta>();
                }
            }

            return list;
        }
         public List<ListaGanancias> DashVentaBeneficiotb(int IdCategoria)
        {
             List<ListaGanancias> lista = new List<ListaGanancias>();

            NumberFormatInfo formato = new CultureInfo("es-CL").NumberFormat;
            formato.CurrencyGroupSeparator = ".";

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerVentaBeneficio", oConexion);
                cmd.Parameters.AddWithValue("@IdCategoria", IdCategoria);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ListaGanancias()
                            {
                                Nombre = dr["Nombre"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                PrecioUnidadVenta = dr["PrecioUnidadVenta"].ToString(),
                                ImporteTotal = dr["ImporteTotal"].ToString(),
                                Ganancia = dr["Ganancia"].ToString(),
                            });
                        }

                    }

                }
                catch (Exception ex)
                {
                    lista = new List<ListaGanancias>();
                }
            }

            return lista;
        }
        public List<IndicadorBeneficioBruto> ObtenerBeneficioCat(int IdCategoria)
        {
            List<IndicadorBeneficioBruto> lista = new List<IndicadorBeneficioBruto>();

            NumberFormatInfo formato = new CultureInfo("es-CL").NumberFormat;
            formato.CurrencyGroupSeparator = ".";

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[usp_BeneficioBrupoCat]", oConexion);
                cmd.Parameters.AddWithValue("@IdCategoria", IdCategoria);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new IndicadorBeneficioBruto()
                            {
                                BeneficioBruto = dr["BeneficioBruto"].ToString(),
                            });
                        }

                    }

                }
                catch (Exception ex)
                {
                    lista = new List<IndicadorBeneficioBruto>();
                }
            }

            return lista;
        }
    }
}
