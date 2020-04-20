using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using capaentidades;
using System.Data;


namespace capadato
{
    class accesodatosrecursos
    {
        SqlConnection cnx;
        recursos rec = new recursos();
        conexion cn = new conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<recursos> Listarecursos = null;
        public int insertarrecursos(recursos rec)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("cuentas", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@idrecursos", "");
                cm.Parameters.AddWithValue("@nombres", rec.nombres);
                cm.Parameters.AddWithValue("@clave", rec.codigo);
                cm.Parameters.AddWithValue("@rol", rec.descripcion);
                

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally
            {
                cm.Connection.Close();
            }
            return indicador;

        }
        public List<recursos> Listarrecursos()
        {
            try
            {
                cm = new SqlCommand("cuentas", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("idrecursos", "");
                cm.Parameters.AddWithValue("@nombre", "");
                cm.Parameters.AddWithValue("@codigo", "");
                cm.Parameters.AddWithValue("@descripcion", "");
                


                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                Listarecursos = new List<recursos>();

                while (dr.Read())
                {
                    recursos rec = new recursos();
                    rec.idrecursos = Convert.ToInt32(dr["idcuenta"].ToString());
                    rec.nombres = dr["nombre"].ToString();
                    rec.codigo = dr["clave"].ToString();
                    rec.descripcion = dr["rol"].ToString();
                    


                    Listarecursos.Add(rec);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                Listarecursos = null;
            }

            finally
            {
                cm.Connection.Close();
            }
            return Listarecursos;
        }
        public int eliminarrecursos(int idrecursos)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("idrecursos", idrecursos);
                cm.Parameters.AddWithValue("@nombre", "");
                cm.Parameters.AddWithValue("@codigo", "");
                cm.Parameters.AddWithValue("@descripcion", "");
                


                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally
            {
                cm.Connection.Close();
            }
            return indicador;
        }
        public int editarrecursos(recursos rec)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("idrecursos", rec.idrecursos);
                cm.Parameters.AddWithValue("@nombres", rec.nombres);
                cm.Parameters.AddWithValue("@codigo", rec.codigo);
                cm.Parameters.AddWithValue("@descripcion", rec.descripcion);
             


                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally
            {
                cm.Connection.Close();
            }
            return indicador;
        }
        public List<recursos> buscarrecursos(string dato)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("idccuenta", "");
                cm.Parameters.AddWithValue("@nombre", dato);
                cm.Parameters.AddWithValue("@codigo", dato);
                cm.Parameters.AddWithValue("@descripcion", "");
                


                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                Listarecursos= new List<recursos>();
                while (dr.Read())
                {
                    recursos rec = new recursos();
                    rec.idrecursos = Convert.ToInt32(dr["idrecursos"].ToString());
                    rec.nombres = dr["nombre"].ToString();
                    rec.codigo= dr["codido"].ToString();
                    rec.descripcion = dr["descripcion"].ToString();
                    

                    Listarecursos.Add(rec);
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
                Listarecursos = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return Listarecursos;
        }
    }
}