using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using capaentidades;
using System.Data;

namespace capadato
{
    public class accesodatoscomentarios
    {
        SqlConnection cnx;
        comentarios s = new comentarios();
        conexion cn = new conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<comentarios> listacomentarios = null;

        public int insertarcomentarios(comentarios co)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("idcomentarios", "");
                cm.Parameters.AddWithValue("@nombres", co.nombre);
                cm.Parameters.AddWithValue("@correo", co.correo);
                cm.Parameters.AddWithValue("@telefono", co.telefono);
                cm.Parameters.AddWithValue("@mensaje", co.mensaje);

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
        public List<comentarios> listarcomentarios()
        {
            try
            {
                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("idcomentarios", "");
                cm.Parameters.AddWithValue("@nombres", "");
                cm.Parameters.AddWithValue("@correo", "");
                cm.Parameters.AddWithValue("@telefono", "");
                cm.Parameters.AddWithValue("@mensaje", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                indicador = 1;
                listacomentarios = new List<comentarios>();

                while (dr.Read())
                {
                    comentarios c = new comentarios();
                    c.idcomentarios = Convert.ToInt32(dr["idcomentario"].ToString());
                    c.nombre = dr["nombre"].ToString();
                    c.correo = dr["correo"].ToString();
                    c.telefono = dr["telefono"].ToString();
                    c.mensaje = dr["mensaje"].ToString();
                    listacomentarios.Add(c);
                }


            }
            catch (Exception e)
            {
                e.Message.ToString();
                listacomentarios = null;
            }

            finally
            {
                cm.Connection.Close();
            }
            return listacomentarios;


        }
        public int eliminarcomentarios(int idcoment)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("idcomentarios", idcoment);
                cm.Parameters.AddWithValue("@nombres", "");
                cm.Parameters.AddWithValue("@correo", "");
                cm.Parameters.AddWithValue("@telefono", "");
                cm.Parameters.AddWithValue("@mensaje", "");

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
        public int editarcomentarios(comentarios co)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("idcomentarios", co.idcomentarios);
                cm.Parameters.AddWithValue("@nombres", "");
                cm.Parameters.AddWithValue("@correo", "");
                cm.Parameters.AddWithValue("@telefono", "");
                cm.Parameters.AddWithValue("@mensaje", co.mensaje);

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
        public List<comentarios> buscarcomentarios(string dato)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("idcomentarios", "");
                cm.Parameters.AddWithValue("@nombres", dato);
                cm.Parameters.AddWithValue("@correo", "");
                cm.Parameters.AddWithValue("@telefono", "");
                cm.Parameters.AddWithValue("@mensaje", dato);

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listacomentarios = new List<comentarios>();
                while (dr.Read())
                {
                    comentarios c = new comentarios();
                    c.idcomentarios = Convert.ToInt32(dr["idcomentario"].ToString());
                    c.nombre = dr["nombre"].ToString();
                    c.correo = dr["correo"].ToString();
                    c.telefono = dr["telefono"].ToString();
                    c.mensaje = dr["mensaje"].ToString();
                    listacomentarios.Add(c);
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
                listacomentarios = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listacomentarios;
        }


    }
   
}
