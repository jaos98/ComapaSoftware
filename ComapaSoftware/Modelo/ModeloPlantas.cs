using ComapaSoftware.Controlador;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ComapaSoftware.Modelo
{
    //LA CLASE INTERNA HEREDA LA CLASE CONEXION PARA USO DE LAS VARIABLES RESERVADAS
    internal class ModeloPlantas : Conexion
    {
        // COMIENZA CREACION DE METODOS PARA LA CLASE RegPlanta

        //AL HABER INSTANCIA DE LA CLASE CONEXION, NO ES NECESARIO LLAMAR DE NUEVO A QUERY, CONNECTION Y READER EN SQL

        //EL METODO, ES UNA LISTA QUE RECOGE LA INFORMACION DE LOS SECTORES Y RETORNA UNA LISTA
        public List<string> consultarSector()
        {
            List<string> lista = new List<string>();
            try
            {
                conectarBase();
                Query.CommandText = "SELECT IdSector,NombreSector FROM sector";
                Query.Connection = Conn;
                Consultar = Query.ExecuteReader();
                while (Consultar.Read())
                {
                    string result = Consultar.GetString(1);
                    Console.WriteLine(result);
                    lista.Add(result);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }
            return lista;
        }
        //EL METODO INSERTA EL CODIGO CON PARAMETROS Y EVITAR POSIBLE ROBO DE DATOS
        public int insertarPlanta(string idPlantas, string numMedidor, string numServicio, string tipoPlanta, string estatus, string descFunciones,string subestacionkva, string colonia, string sector, string latitud, string longitud, string elevacion, string servicio, string domicilio)
        {
            int numRegistros = 0;
            string sqlEjecutar = "INSERT INTO `plantascomapa`(`IdPlantas`, `NumMedidor`, `NumServicio`, `TipoPlantas`, `Estatus`, " +
                    "`DescFunciones`,`SubestacionKva`, `Colonia`, `Sector`, `Latitud`, `Longitud`, `Elevacion`, `Servicio`, `Domicilio`) " +
                    "VALUES (@idPlantas,@numMedidor,@numServicio,@tipoPlanta,@estatus,@descFunciones,@subestacionkva,@colonia,@sector,@latitud,@longitud,@elevacion,@servicio,@domicilio);";
            try
            {
                Conn.Close();
                Query.Connection = Conn;
                Query.CommandText = sqlEjecutar;
                Query.Parameters.Add("@idPlantas", MySqlDbType.String).Value = idPlantas;
                Query.Parameters.Add("@numMedidor", MySqlDbType.String).Value = numMedidor;
                Query.Parameters.Add("@numServicio", MySqlDbType.String).Value = numServicio;
                Query.Parameters.Add("@tipoPlanta", MySqlDbType.String).Value = tipoPlanta;
                Query.Parameters.Add("@estatus", MySqlDbType.String).Value = estatus;
                Query.Parameters.Add("@descFunciones", MySqlDbType.String).Value = descFunciones;
                Query.Parameters.Add("@subestacionkva", MySqlDbType.String).Value = subestacionkva+" kva";
                Query.Parameters.Add("@colonia", MySqlDbType.String).Value = colonia;
                Query.Parameters.Add("@sector", MySqlDbType.String).Value = sector;
                Query.Parameters.Add("@latitud", MySqlDbType.String).Value = latitud;
                Query.Parameters.Add("@longitud", MySqlDbType.String).Value = longitud;
                Query.Parameters.Add("@elevacion", MySqlDbType.String).Value = elevacion+" mts";
                Query.Parameters.Add("@servicio", MySqlDbType.String).Value = servicio;
                Query.Parameters.Add("@domicilio", MySqlDbType.String).Value = domicilio;
                Conn.Open();
                numRegistros = Query.ExecuteNonQuery();
                return numRegistros;//1 si se ha registrado
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error ");
                Console.WriteLine(ex);
                return numRegistros; //0 si ha habido algún error
            }
            finally
            {
                Conn.Close();
            }
        }
        // EL METODO OBTIENE EL ID DEL SECTOR EN FUNCION DE EL NOMBRE 
        public string obtenerID(string idObtenido)
        {
            try
            {
                conectarBase();
                Query.CommandText = "SELECT IdSector FROM sector WHERE NombreSector = '" + idObtenido + "'";
                Query.Connection = Conn;
                Consultar = Query.ExecuteReader();
                while (Consultar.Read())
                {
                    idObtenido = Consultar.GetString(0);
                    Console.WriteLine(idObtenido);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return idObtenido;
        }
        /**EL METODO LISTA OBTIENE LOS VALORES QUE COINCIDAN CON EL idSector Y EL NombreColonia
        MEDIANTE EL INNER TRAE LAS COINCIDENCIAS Y LAS ALMACENA EN LA LISTA**/
        public List<string> compararDatos(string resultId)
        {
            List<string> helper = new List<string>();
            conectarBase();
            Query.CommandText = "SELECT sector.IdSector, colonia.NombreColonia FROM sector " +
                "INNER JOIN colonia ON sector.IdSector = colonia.IdSector WHERE sector.IdSector = '" + resultId + "'";
            Query.Connection = Conn;
            Consultar = Query.ExecuteReader();
            while (Consultar.Read())
            {
                string res = Consultar.GetString(1);
                helper.Add(res);
            }
            return helper;
        }
        //EL METODO VALIDA SI EXISTE UNA PLANTA CON EL MISMO ID
        public bool noRepite(string idPlanta)
        {
            conectarBase();
            Query.CommandText = "SELECT IdPlantas FROM plantascomapa WHERE IdPlantas ='" + idPlanta + "'";
            Query.Connection = Conn;
            Consultar = Query.ExecuteReader();
            if (Consultar.HasRows)
            {
                return false;
            }
            return true;
        }
        //COMIENZA CREACION DE METODOS PARA LA CLASE ConsPlanta
        public DataTable llevarDatos(string globalReceiver)
        {
            string sql = "SELECT IdPlantas,NumMedidor,NumServicio,TipoPlantas,Estatus,Domicilio,Servicio,SubestacionKva " +
                "FROM plantascomapa WHERE IdPlantas = '" + globalReceiver + "' OR TipoPlantas = '" + globalReceiver + "' ";
            conectarBase();
            try
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, Conn);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                Conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Conn.Close();
                throw;
            }
        }
        public DataTable dataSender()
        {
            string sql = "SELECT * " +
                "FROM plantascomapa";
            conectarBase();
            try
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, Conn);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable consultaAdicional(string globalEntry)
        {
            string sql = "SELECT IdPlantas,NumMedidor,NumServicio,TipoPlantas,Estatus,Domicilio,Servicio,SubestacionKva " +
                "FROM plantascomapa WHERE (IdPlantas = '" + globalEntry + "') OR (TipoPlantas ='" + globalEntry + "') ";
            conectarBase();
            try
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, Conn);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        //ACTUALIZAR INFORMACION
        public List<ControladorPlantas> GetUpdateInfo(string idReceiver)
        {
            List<ControladorPlantas> list = new List<ControladorPlantas>();
            try
            {
                conectarBase();
                Query.CommandText = "SELECT * FROM plantascomapa WHERE IdPlantas= '" + idReceiver + "' ";
                Query.Connection = Conn;
                Consultar = Query.ExecuteReader();
                while (Consultar.Read())
                {
                    list.Add(new ControladorPlantas(Consultar.GetString(0), Consultar.GetString(1)
                        , Consultar.GetString(2), Consultar.GetString(3), Consultar.GetString(4)
                        , Consultar.GetString(5), Consultar.GetString(6), Consultar.GetString(7)
                        , Consultar.GetString(8), Consultar.GetString(9), Consultar.GetString(10)
                        , Consultar.GetString(11), Consultar.GetString(12),Consultar.GetString(13)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return list;
        }
        public int UpdateInfo(string idPlantas, string numMedidor, string numServicio, 
            string tipoPlanta, string estatus, string descFunciones, string subestacionkva, 
            string colonia, string sector, string latitud, string longitud, 
            string elevacion, string servicio, string domicilio)
        {
            int numRegistros = 0;
            string sqlEjecutar = "UPDATE `plantascomapa` SET `IdPlantas`=@idPlantas," +
                   "`NumMedidor`=@numMedidor,`NumServicio`=@numServicio,`TipoPlantas`=@tipoPlanta," +
                   "`Estatus`=@estatus,`DescFunciones`=@descFunciones,`SubestacionKva`=@subestacionKva," +
                   "`Colonia`=@colonia,`Sector`=@sector,`Latitud`=@latitud," +
                   "`Longitud`=@longitud,`Elevacion`=@elevacion,`Servicio`=@servicio," +
                   "`Domicilio`=@domicilio WHERE IdPlantas = '" + idPlantas + "'";
            try
            {
               

                    Conn.Close();
                    Query.Connection = Conn;
                    Query.CommandText = sqlEjecutar;
                    Query.Parameters.Add("@idPlantas", MySqlDbType.String).Value = idPlantas;
                    Query.Parameters.Add("@numMedidor", MySqlDbType.String).Value = numMedidor;
                    Query.Parameters.Add("@numServicio", MySqlDbType.String).Value = numServicio;
                    Query.Parameters.Add("@tipoPlanta", MySqlDbType.String).Value = tipoPlanta;
                    Query.Parameters.Add("@estatus", MySqlDbType.String).Value = estatus;
                    Query.Parameters.Add("@descFunciones", MySqlDbType.String).Value = descFunciones;
                    Query.Parameters.Add("@subestacionkva", MySqlDbType.String).Value = subestacionkva + " kva";
                    Query.Parameters.Add("@colonia", MySqlDbType.String).Value = colonia;
                    Query.Parameters.Add("@sector", MySqlDbType.String).Value = sector;
                    Query.Parameters.Add("@latitud", MySqlDbType.String).Value = latitud;
                    Query.Parameters.Add("@longitud", MySqlDbType.String).Value = longitud;
                    Query.Parameters.Add("@elevacion", MySqlDbType.String).Value = elevacion + " mts";
                    Query.Parameters.Add("@servicio", MySqlDbType.String).Value = servicio;
                    Query.Parameters.Add("@domicilio", MySqlDbType.String).Value = domicilio;
                    Conn.Open();
                numRegistros = Query.ExecuteNonQuery();
                return numRegistros;//1 si se ha registrado
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex);
                return numRegistros;
                throw;
            }
            finally
            {
                Conn.Close();
            }
            }
        //BORRAR INFORMACION (DELETE SQL)
        public bool Delete(string receiver)
        {
            conectarBase();
            try
            {
                Query.CommandText = "DELETE FROM `plantascomapa` WHERE IdPlantas = '"+receiver+"' ";
                Query.Connection = Conn;
                if (Query.ExecuteNonQuery()>0)
                {
                    return true;
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return false;
        }


    }
}
