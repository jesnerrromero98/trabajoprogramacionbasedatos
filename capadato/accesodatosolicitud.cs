using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using capaentidades;
using System.Data;


namespace capadato
{
    public class accesodatosolicitud
    {
        SqlConnection cnx;
        solicitud sol = new solicitud();
        conexion cn = new conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<solicitud> Listasolicitud = null;

        public int insertarsolicitud(solicitud sol)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("usuarios", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("idusolicitud", "");
                cm.Parameters.AddWithValue("@aula", sol.aula);
                cm.Parameters.AddWithValue("@nivel", sol.nivel);
                cm.Parameters.AddWithValue("@fechasolicitud", sol.fechasolicitud);
                cm.Parameters.AddWithValue("@fechauso", sol.fechauso);
                cm.Parameters.AddWithValue("@horainicio", sol.horainicio);
                cm.Parameters.AddWithValue("@horafinal", sol.horafinal);
                cm.Parameters.AddWithValue("@carrera", sol.carrera);
                cm.Parameters.AddWithValue("@asignatura", sol.asignatura);
                cm.Parameters.AddWithValue("@idrecursos", sol.idrecursos);
                cm.Parameters.AddWithValue("@idusuario", sol.idusuario);

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
        public List<solicitud> Listarsolicitud()
        {
            try
            {
                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("idusolicitud", " ");
                cm.Parameters.AddWithValue("@aula", " ");
                cm.Parameters.AddWithValue("@nivel", " ");
                cm.Parameters.AddWithValue("@fechasolicitud", " ");
                cm.Parameters.AddWithValue("@fechauso", " ");
                cm.Parameters.AddWithValue("@horainicio", " ");
                cm.Parameters.AddWithValue("@horafinal", " ");
                cm.Parameters.AddWithValue("@carrera", " ");
                cm.Parameters.AddWithValue("@asignatura", " ");
                cm.Parameters.AddWithValue("@idrecursos", " ");
                cm.Parameters.AddWithValue("@idusuario", " ");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                Listasolicitud = new List<solicitud>();

                while (dr.Read())
                {
                    solicitud sol = new solicitud();
                    sol.idsolicitud = Convert.ToInt32(dr["idusuario"].ToString());
                    sol.aula = dr["aula"].ToString();
                    sol.nivel = dr["nivel"].ToString();
                    sol.fechasolicitud = Convert.ToDateTime(dr["fechasolicitud"].ToString());
                    sol.fechauso = Convert.ToDateTime(dr["fechauso"].ToString());
                    sol.horainicio= Convert.ToDateTime(dr["horainicio"].ToString());
                    sol.horafinal = Convert.ToDateTime(dr["horafinal"].ToString());
                    sol.carrera = dr["carrera"].ToString();
                    sol.asignatura = dr["asignatura"].ToString();
                    sol.idrecursos= Convert.ToInt32(dr["idrecursos"].ToString());
                    sol.idusuario= Convert.ToInt32(dr["idusuario"].ToString());

                    Listasolicitud.Add(sol);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                Listasolicitud = null;
            }

            finally
            {
                cm.Connection.Close();
            }
            return Listasolicitud;
        }
        public int eliminarsolicitud(int idsolicitud)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("idusuarios", idsolicitud);
                cm.Parameters.AddWithValue("@aula", " ");
                cm.Parameters.AddWithValue("@nivel", " ");
                cm.Parameters.AddWithValue("@fechasolicitud", " ");
                cm.Parameters.AddWithValue("@fechauso", " ");
                cm.Parameters.AddWithValue("@horainicio", " ");
                cm.Parameters.AddWithValue("@horafinal", " ");
                cm.Parameters.AddWithValue("@carrera", " ");
                cm.Parameters.AddWithValue("@asignatura", " ");
                cm.Parameters.AddWithValue("@idrecursos", " ");
                cm.Parameters.AddWithValue("@idusuario", " ");

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
        public int editarsolicitud(solicitud sol)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("idsolicitud", sol.idsolicitud);
                cm.Parameters.AddWithValue("@aula", sol.aula);
                cm.Parameters.AddWithValue("@nivel", sol.nivel);
                cm.Parameters.AddWithValue("@fechasolicitud", sol.fechasolicitud);
                cm.Parameters.AddWithValue("@fechauso", sol.fechauso);
                cm.Parameters.AddWithValue("@horainicio", sol.horainicio);
                cm.Parameters.AddWithValue("@horafinal", sol.horafinal);
                cm.Parameters.AddWithValue("@carrera", sol.carrera);
                cm.Parameters.AddWithValue("@asignatura", sol.asignatura);
                cm.Parameters.AddWithValue("@idrecursos", sol.idrecursos);
                cm.Parameters.AddWithValue("@idusuario", sol.idusuario);

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
        public List<solicitud> buscarsolicitud(string dato)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("idsolicitud", dato);
                cm.Parameters.AddWithValue("@aula", " ");
                cm.Parameters.AddWithValue("@nivel", dato);
                cm.Parameters.AddWithValue("@fechasolicitud", " ");
                cm.Parameters.AddWithValue("@fechauso", " ");
                cm.Parameters.AddWithValue("@fehainicio", " ");
                cm.Parameters.AddWithValue("@fechafinal", " ");
                cm.Parameters.AddWithValue("@carrera", " ");
                cm.Parameters.AddWithValue("@asignatura", dato);
                cm.Parameters.AddWithValue("@idrecursos", " ");
                cm.Parameters.AddWithValue("@idusuario", " ");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                Listasolicitud = new List<solicitud>();
                while (dr.Read())
                {
                    usuarios us = new usuarios();
                    sol.idsolicitud = Convert.ToInt32(dr["idusuario"].ToString());
                    sol.aula = dr["aula"].ToString();
                    sol.nivel = dr["nivel"].ToString();
                    sol.fechasolicitud = Convert.ToDateTime(dr["fechasolicitud"].ToString());
                    sol.fechauso = Convert.ToDateTime(dr["fechauso"].ToString());
                    sol.horainicio = Convert.ToDateTime(dr["horainicio"].ToString());
                    sol.horafinal = Convert.ToDateTime(dr["horafinal"].ToString());
                    sol.carrera = dr["carrera"].ToString();
                    sol.asignatura = dr["asignatura"].ToString();
                    sol.idrecursos = Convert.ToInt32(dr["idrecursos"].ToString());
                    sol.idusuario = Convert.ToInt32(dr["idusuario"].ToString());
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
                Listasolicitud = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return Listasolicitud;
        }
    }
}