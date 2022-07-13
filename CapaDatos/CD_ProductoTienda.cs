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
    public class CD_ProductoTienda
    {
        public static CD_ProductoTienda _instancia = null;

        private CD_ProductoTienda()
        {

        }

        public static CD_ProductoTienda Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_ProductoTienda();
                }
                return _instancia;
            }
        }

        public List<ProductoTienda> ObtenerProductoTienda()
        {
            List<ProductoTienda> rptListaProductoTienda = new List<ProductoTienda>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerProductoTienda", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaProductoTienda.Add(new ProductoTienda()
                        {
                            IdProductoTienda = Convert.ToInt32(dr["IdProductoTienda"].ToString()),
                            oProducto = new Producto()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"].ToString()),
                                Codigo = dr["CodigoProducto"].ToString(),
                                Nombre = dr["NombreProducto"].ToString(),
                                Descripcion = dr["DescripcionProducto"].ToString(),
                            },
                            oTienda = new Tienda()
                            {
                                IdTienda = Convert.ToInt32(dr["IdTienda"].ToString()),
                                RUC = dr["RUC"].ToString(),
                                Nombre = dr["NombreTienda"].ToString(),
                                Direccion = dr["DireccionTienda"].ToString(),
                            },
                            PrecioUnidadCompra = Convert.ToDecimal(dr["PrecioUnidadCompra"].ToString(), new CultureInfo("es-CL")),
                            PrecioUnidadVenta = Convert.ToDecimal(dr["PrecioUnidadVenta"].ToString(), new CultureInfo("es-CL")),
                            Stock = Convert.ToInt32(dr["Stock"].ToString()),
                            Iniciado = Convert.ToBoolean(dr["Iniciado"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaProductoTienda;

                }
                catch (Exception ex)
                {
                    rptListaProductoTienda = null;
                    return rptListaProductoTienda;
                }
            }
        }
        public List<ProductoTienda> ObtenerProductoParaVenta()
        {
            List<ProductoTienda> rptListaProductoTienda = new List<ProductoTienda>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerProductoParaVenta", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaProductoTienda.Add(new ProductoTienda()
                        {
                            IdProductoTienda = Convert.ToInt32(dr["IdProductoTienda"].ToString()),
                            oProducto = new Producto()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"].ToString()),
                                Codigo = dr["CodigoProducto"].ToString(),
                                Nombre = dr["NombreProducto"].ToString(),
                                Descripcion = dr["DescripcionProducto"].ToString(),
                            },
                            oTienda = new Tienda()
                            {
                                IdTienda = Convert.ToInt32(dr["IdTienda"].ToString()),
                                RUC = dr["RUC"].ToString(),
                                Nombre = dr["NombreTienda"].ToString(),
                                Direccion = dr["DireccionTienda"].ToString(),
                            },
                            PrecioUnidadCompra = Convert.ToDecimal(dr["PrecioUnidadCompra"].ToString(), new CultureInfo("es-CL")),
                            PrecioUnidadVenta = Convert.ToDecimal(dr["PrecioUnidadVenta"].ToString(), new CultureInfo("es-CL")),
                            Stock = Convert.ToInt32(dr["Stock"].ToString()),
                            Iniciado = Convert.ToBoolean(dr["Iniciado"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaProductoTienda;

                }
                catch (Exception ex)
                {
                    rptListaProductoTienda = null;
                    return rptListaProductoTienda;
                }
            }
        }
        public List<IndicadorStock> ObtenerIndicadorStock()
        {
            List<IndicadorStock> indStock = new List<IndicadorStock>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_IndicadorDeStock", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        indStock.Add(new IndicadorStock()
                        {
                            StockDisponible = Convert.ToInt32(dr["StockDisponible"].ToString()),
                        });
                    }
                    dr.Close();

                    return indStock;

                }
                catch (Exception ex)
                {
                    indStock = null;
                    return indStock;
                }
            }
        }
        public List<IndicadorStock> ObtenerIndicadorStock2()
        {
            List<IndicadorStock> indStock = new List<IndicadorStock>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("IndicadorDeStock2", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        indStock.Add(new IndicadorStock()
                        {
                            StockAgotado = Convert.ToInt32(dr["StockAgotado"].ToString()),
                        });
                    }
                    dr.Close();

                    return indStock;

                }
                catch (Exception ex)
                {
                    indStock = null;
                    return indStock;
                }
            }
        }
        public List<IndicadorStock> ObtenerIndicadorStock3()
        {
            List<IndicadorStock> indStock = new List<IndicadorStock>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("IndicadorDeStock3", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        indStock.Add(new IndicadorStock()
                        {
                            StockCritico = Convert.ToInt32(dr["StockCritico"].ToString()),
                        });
                    }
                    dr.Close();

                    return indStock;

                }
                catch (Exception ex)
                {
                    indStock = null;
                    return indStock;
                }
            }
        }
        public List<IndicadorFechaVencimiento> ObtenerIndicadorFechaVencimiento()
        {
            List<IndicadorFechaVencimiento> stocksinpro = new List<IndicadorFechaVencimiento>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_IndicadorStockSinProblemas", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        stocksinpro.Add(new IndicadorFechaVencimiento()
                        {
                            SinProblemas = Convert.ToInt32(dr["SinProblemas"].ToString()),
                        });
                    }
                    dr.Close();

                    return stocksinpro;

                }
                catch (Exception ex)
                {
                    stocksinpro = null;
                    return stocksinpro;
                }
            }
        }
        public List<IndicadorFechaVencimiento> ObtenerIndicadorFechaVencimiento2()
        {
            List<IndicadorFechaVencimiento> stocksporven = new List<IndicadorFechaVencimiento>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_IndicadorStockPorVencer", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        stocksporven.Add(new IndicadorFechaVencimiento()
                        {
                            PorVencer = Convert.ToInt32(dr["PorVencer"].ToString()),
                        });
                    }
                    dr.Close();

                    return stocksporven;

                }
                catch (Exception ex)
                {
                    stocksporven = null;
                    return stocksporven;
                }
            }
        }
        public List<IndicadorFechaVencimiento> ObtenerIndicadorFechaVencimiento3()
        {
            List<IndicadorFechaVencimiento> stocksven = new List<IndicadorFechaVencimiento>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_IndicadorStockVencidos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        stocksven.Add(new IndicadorFechaVencimiento()
                        {
                            Vencidos = Convert.ToInt32(dr["Vencidos"].ToString()),
                        });
                    }
                    dr.Close();

                    return stocksven;

                }
                catch (Exception ex)
                {
                    stocksven = null;
                    return stocksven;
                }
            }
        }
        public bool RegistrarProductoTienda(ProductoTienda oProductoTienda)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarProductoTienda", oConexion);
                    cmd.Parameters.AddWithValue("IdProducto", oProductoTienda.oProducto.IdProducto);
                    cmd.Parameters.AddWithValue("IdTienda", oProductoTienda.oTienda.IdTienda);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public bool ModificarProductoTienda(ProductoTienda oProductoTienda)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ModificarProductoTienda", oConexion);
                    cmd.Parameters.AddWithValue("IdProductoTienda", oProductoTienda.IdProductoTienda);
                    cmd.Parameters.AddWithValue("IdProducto", oProductoTienda.oProducto.IdProducto);
                    cmd.Parameters.AddWithValue("IdTienda", oProductoTienda.oTienda.IdTienda);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }

        public bool EliminarProductoTienda(int IdProductoTienda)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarProductoTienda", oConexion);
                    cmd.Parameters.AddWithValue("IdProductoTienda", IdProductoTienda);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }

        public bool ControlarStock(int IdProducto, int IdTienda, int Cantidad, bool Restar)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ControlarStock", oConexion);
                    cmd.Parameters.AddWithValue("IdProducto", IdProducto);
                    cmd.Parameters.AddWithValue("IdTienda", IdTienda);
                    cmd.Parameters.AddWithValue("Cantidad", Cantidad);
                    cmd.Parameters.AddWithValue("Restar", Restar);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        public List<IndicadorBeneficioBruto> ObtenerMargenBeneficioBruto()
        {
            List<IndicadorBeneficioBruto> indStock = new List<IndicadorBeneficioBruto>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_IndicadorBeneficioBruto", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        indStock.Add(new IndicadorBeneficioBruto()
                        {
                            MargenBeneficioBruto = dr["MargenBeneficioBruto"].ToString(),
                        });
                    }
                    dr.Close();

                    return indStock;

                }
                catch (Exception ex)
                {
                    indStock = null;
                    return indStock;
                }
            }
        }
        public List<IndicadorBeneficioBruto> ObtenerBeneficioBruto()
        {
            List<IndicadorBeneficioBruto> indStock = new List<IndicadorBeneficioBruto>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_IndicadorSumBeneficioBruto", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        indStock.Add(new IndicadorBeneficioBruto()
                        {
                            BeneficioBruto = dr["BeneficioBruto"].ToString(),
                        });
                    }
                    dr.Close();

                    return indStock;

                }
                catch (Exception ex)
                {
                    indStock = null;
                    return indStock;
                }
            }
        }
    }
}
