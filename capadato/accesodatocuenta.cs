using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using capaentidades;
using System.Data;


namespace capadato
{
    public class accesodatocuenta
    {
        SqlConnection cnx;
        cuentas cue = new cuentas();
        conexion cn = new conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<cuentas> Listacuentas = null;
        public int insertarcuentas(cuentas cue)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("cuentas", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@idcuenta", "");
                cm.Parameters.AddWithValue("@nombres", cue.nombreuser);
                cm.Parameters.AddWithValue("@clave", cue.clave);
                cm.Parameters.AddWithValue("@rol", cue.rol);
                cm.Parameters.AddWithValue("@idusuario", cue.idusuario);

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
        public List<cuentas> Listarcuentas()
        {
            try
            {
                cm = new SqlCommand("cuentas", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("idcuenta", "");
                cm.Parameters.AddWithValue("@nombreuser", "");
                cm.Parameters.AddWithValue("@clave", "");
                cm.Parameters.AddWithValue("@rol", "");
                cm.Parameters.AddWithValue("@idusuario", "");
                

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                Listacuentas = new List<cuentas>();

                while (dr.Read())
                {
                    cuentas cue = new cuentas();
                    cue.idcuenta = Convert.ToInt32(dr["idcuenta"].ToString());
                    cue.nombreuser = dr["nombre"].ToString();
                    cue.clave = dr["clave"].ToString();
                    cue.rol = dr["rol"].ToString();
                    cue.idusuario = Convert.ToInt32(dr["idusuario".ToString()]); ;
                    

                    Listacuentas.Add(cue);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                Listacuentas = null;
            }

            finally
            {
                cm.Connection.Close();
            }
            return Listacuentas;
        }
        public int eliminarcuenta(int idcuenta)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("idcuenta", idcuenta);
                cm.Parameters.AddWithValue("@nombreuser", "");
                cm.Parameters.AddWithValue("@clave", "");
                cm.Parameters.AddWithValue("@roll", "");
                cm.Parameters.AddWithValue("@idusuario", "");
                

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
        public int editarcuenta(cuentas cue)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("idcuenta", cue.idcuenta);
                cm.Parameters.AddWithValue("@nombres", cue.nombreuser);
                cm.Parameters.AddWithValue("@rol", cue.rol);
                cm.Parameters.AddWithValue("@clave", cue.clave);
                cm.Parameters.AddWithValue("@idusuario", cue.idusuario);
                

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
        public List<cuentas> buscarcuentas(string dato)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("idccuenta", "");
                cm.Parameters.AddWithValue("@nombresuser", dato);
                cm.Parameters.AddWithValue("@rol", "");
                cm.Parameters.AddWithValue("@clave", dato);
                cm.Parameters.AddWithValue("@idusuario", "");
                

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                Listacuentas = new List<cuentas>();
                while (dr.Read())
                {
                    cuentas cue = new cuentas();
                    cue.idcuenta = Convert.ToInt32(dr["idcuenta"].ToString());
                    cue.nombreuser = dr["nombre"].ToString();
                    cue.rol = dr["correo"].ToString();
                    cue.clave = dr["telefono"].ToString();
                    cue.idusuario = Convert.ToInt32(dr["idusuario"].ToString());
                    
                    Listacuentas.Add(cue);
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
                Listacuentas = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return Listacuentas;
        }
    }
}







