using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using capaentidades;
using System.Data;

namespace capadato
{
     public class accesodatosusuarios
     {
        SqlConnection cnx;
        usuarios s = new usuarios();
        conexion cn = new conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<usuarios> Listausuarios = null;

        public int insertarusuarios(usuarios usu)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("usuarios", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("idusuario", "");
                cm.Parameters.AddWithValue("@nombres", usu.nombres);
                cm.Parameters.AddWithValue("@apellidos", usu.apellidos);
                cm.Parameters.AddWithValue("@cedula", usu.cedula);
                cm.Parameters.AddWithValue("@telefono", usu.telefono);
                cm.Parameters.AddWithValue("@email", usu.email);

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
        public List<usuarios> Listarusuarios()
        {
            try
            {
                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("idusuarios", "");
                cm.Parameters.AddWithValue("@nombres", "");
                cm.Parameters.AddWithValue("@apellidos", "");
                cm.Parameters.AddWithValue("@cedula", "");
                cm.Parameters.AddWithValue("@telefono", "");
                cm.Parameters.AddWithValue("@email", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                Listausuarios= new List<usuarios>();

                while (dr.Read())
                {
                    usuarios us = new usuarios();
                    us.idusuario = Convert.ToInt32(dr["idusuario"].ToString());
                    us.nombres = dr["nombre"].ToString();
                    us.apellidos= dr["apellidos"].ToString();
                    us.cedula= dr["telefono"].ToString();
                    us.telefono = dr["mensaje"].ToString();
                    us.email = dr["@email"].ToString();
                    
                    Listausuarios.Add(us);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                Listausuarios = null;
            }

            finally
            {
                cm.Connection.Close();
            }
            return Listausuarios;
        }
        public int eliminarusuario(int idusuario)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("idusuarios", idusuario);
                cm.Parameters.AddWithValue("@nombres", "");
                cm.Parameters.AddWithValue("@apellidos", "");
                cm.Parameters.AddWithValue("@telefono", "");
                cm.Parameters.AddWithValue("@mensaje", "");
                cm.Parameters.AddWithValue("@email", "");

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
        public int editarusuarios(usuarios us)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("idcomentarios", us.idusuario);
                cm.Parameters.AddWithValue("@nombres", us.nombres);
                cm.Parameters.AddWithValue("@apellidos", us.apellidos);
                cm.Parameters.AddWithValue("@cedula",us.cedula);
                cm.Parameters.AddWithValue("@telefono", us.telefono);
                cm.Parameters.AddWithValue("@email", us.email);

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
        public List<usuarios> buscarusuarios (string dato)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("idusuario", "");
                cm.Parameters.AddWithValue("@nombres", dato);
                cm.Parameters.AddWithValue("@apellidos", "");
                cm.Parameters.AddWithValue("@cedula", dato);
                cm.Parameters.AddWithValue("@telefono", "");
                cm.Parameters.AddWithValue("@email.", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                Listausuarios= new List<usuarios>();
                while (dr.Read())
                {
                    usuarios us = new usuarios();
                    us.idusuario = Convert.ToInt32(dr["idcomentario"].ToString());
                    us.nombres = dr["nombre"].ToString();
                    us.apellidos= dr["correo"].ToString();
                    us.cedula = dr["telefono"].ToString();
                    us.telefono = dr["mensaje"].ToString();
                    us.email = dr["email"].ToString();
                    Listausuarios.Add(us);
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
                Listausuarios = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return Listausuarios;
        }
    }
}

    
