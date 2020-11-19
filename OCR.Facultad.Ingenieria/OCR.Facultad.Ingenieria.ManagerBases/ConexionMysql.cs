using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace OCR.Facultad.Ingenieria.ManagerBases
{
    public class ConexionMysql
    {
        DataSet dataset;
        public DataSet DataSet
        {
            get {
                return this.dataset;
            }
            set {
                this.dataset = value;
            }
        }
        static List<String> listatablas = new List<string> { "batch_ocr", "batch_ocr_his", "batch_ocr_ruta", "ocr", "ocr_estadisticas", "ocr_estadisticas_his", "ocr_exportado", "ocr_exportado_his", "ocr_his", "ocr_linea", "ocr_linea_his", "ocr_pagina", "ocr_pagina_his" };

        public static bool Test(string _ip, int _puerto, string _usuario, string _contrasenia, string _baseDatos)
        {
            MySqlConnection con = new MySqlConnection();
            try
            {
                MySqlConnectionStringBuilder conexion = new MySqlConnectionStringBuilder();
                conexion.Server = _ip;
                conexion.Port = Convert.ToUInt16(_puerto);
                conexion.UserID = _usuario;
                conexion.Password = _contrasenia;
                //conexion.Database = _baseDatos;
                con = new MySqlConnection(conexion.ToString()) ;
                con.Open();
                return true;
            }
            catch (Exception error)
            {
                
                
            }
            finally{
                con.Close();

            } return false;
        }
        public static bool ValidarTablasBase(string _ip, int _puerto, string _usuario, string _contrasenia, string _baseDatos)
        {
            List<string> lista = new List<string>();
            DataSet temporal = new DataSet();
            MySqlConnection con = new MySqlConnection();
            try
            {
                bool esvailada = true;
                MySqlConnectionStringBuilder conexion = new MySqlConnectionStringBuilder();
                conexion.Server = _ip;
                conexion.Port = Convert.ToUInt16(_puerto);
                conexion.UserID = _usuario;
                conexion.Password = _contrasenia;
                conexion.Database = _baseDatos;
                con = new MySqlConnection(conexion.ToString());
                MySqlDataAdapter adpatador = new MySqlDataAdapter(String.Format("SHOW TABLES FROM {0}",_baseDatos), con);
                con.Open();
                adpatador.Fill(temporal);
                con.Close();
                int filas = temporal.Tables[0].Rows.Count;
                for (int i = 0; i < filas; i++)
                {
                    lista.Add((string)temporal.Tables[0].Rows[i].ItemArray[0]);
                }
                                  
                    foreach (string tabla in listatablas)
                    {
                        esvailada=lista.Contains(tabla);
                        if (!esvailada)
                        {
                            break;
                        }
                    }                    
                
               
                return esvailada;
            }
            catch (Exception error)
            {
                con.Close();
                return false;
            }
           
        }
        public static string[] BasesDeDatos(string _ip, int _puerto, string _usuario, string _contrasenia, string _baseDatos)
        {
            List<string> lista = new List<string>();
            DataSet temporal=new DataSet();
            MySqlConnection con = new MySqlConnection();
            try
            {
                MySqlConnectionStringBuilder conexion = new MySqlConnectionStringBuilder();
                conexion.Server = _ip;
                conexion.Port = Convert.ToUInt16(_puerto);
                conexion.UserID = _usuario;
                conexion.Password = _contrasenia;
                //conexion.Database = _baseDatos;
                con = new MySqlConnection(conexion.ToString());
                MySqlDataAdapter adpatador = new MySqlDataAdapter("SHOW DATABASES", con);
                con.Open();
                adpatador.Fill(temporal);
                con.Close();
                int filas=temporal.Tables[0].Rows.Count;
                for (int i = 0; i < filas; i++)
                {
                    lista.Add((string)temporal.Tables[0].Rows[i].ItemArray[0]);
                }               
                return lista.ToArray();
            }
            catch (Exception error)
            {
                con.Close();
                return null;
            }
            return null;
        }
        public static bool ExisteServer(string _ip, int _puerto, string _usuario, string _contrasenia, string _baseDatos)
        {
            bool existe = false;
            DataSet temporal = new DataSet();
            MySqlConnection con = new MySqlConnection();
            try
            {
                MySqlConnectionStringBuilder conexion = new MySqlConnectionStringBuilder();
                conexion.Server = _ip;
                conexion.Port = Convert.ToUInt16(_puerto);
                conexion.UserID = _usuario;
                conexion.Password = _contrasenia;
                conexion.Database = _baseDatos;
                con = new MySqlConnection(conexion.ToString());
                MySqlDataAdapter adpatador = new MySqlDataAdapter("select count(*) from server", con);
                con.Open();
                adpatador.Fill(temporal);
                con.Close();
                int filas = Convert.ToInt32(temporal.Tables[0].Rows[0].ItemArray[0]);
                if (filas > 0)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception error)
            {
                con.Close();
                
            }
            return false;
        }
        
        public static bool UpdateServidor(string _ip, int _puerto, string _usuario, string _contrasenia, string _contraseniacifrada,string _baseDatos,string _tiposerver)
        {
            
            DataSet temporal = new DataSet();
            MySqlConnection con = new MySqlConnection();
            try
            {
                bool esvailada = true;
                MySqlConnectionStringBuilder conexion = new MySqlConnectionStringBuilder();
                conexion.Server = _ip;
                conexion.Port = Convert.ToUInt16(_puerto);
                conexion.UserID = _usuario;
                conexion.Password = _contrasenia;
                conexion.Database = _baseDatos;
                con = new MySqlConnection(conexion.ToString());
                string insert = String.Format("Update server set ser_ip_ser=\"{0}\", ser_puerto_ser={1}, ser_user_ser=\"{2}\",ser_contrasenia_ser=\"{3}\", ser_nombre_base_ser=\"{4}\" where ser_tipo_ser = \"{5}\"  ", _ip, _puerto.ToString(), _usuario.ToString(), _contraseniacifrada, _baseDatos, _tiposerver);
                MySqlCommand comando = new MySqlCommand(insert,con);
                con.Open();
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                con.Close();  
                return esvailada;
            }
            catch (Exception error)
            {
                con.Close();
                return false;
            }

        }
        public static bool GuardarServidor(string _ip, int _puerto, string _usuario, string _contrasenia, string _contraseniacifrada, string _baseDatos, string _tiposerver)
        {

            DataSet temporal = new DataSet();
            MySqlConnection con = new MySqlConnection();
            try
            {
                bool esvailada = true;
                MySqlConnectionStringBuilder conexion = new MySqlConnectionStringBuilder();
                conexion.Server = _ip;
                conexion.Port = Convert.ToUInt16(_puerto);
                conexion.UserID = _usuario;
                conexion.Password = _contrasenia;
                conexion.Database = _baseDatos;
                con = new MySqlConnection(conexion.ToString());
                string insert = String.Format("INSERT INTO server(ser_ip_ser, ser_puerto_ser, ser_user_ser,ser_contrasenia_ser, ser_nombre_base_ser, ser_tipo_ser) values (\"{0}\",{1},\"{2}\",\"{3}\",\"{4}\",\"{5}\")", _ip, _puerto.ToString(), _usuario.ToString(), _contraseniacifrada, _baseDatos, _tiposerver);
                MySqlCommand comando = new MySqlCommand(insert, con);
                con.Open();
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                con.Close();
                return esvailada;
            }
            catch (Exception error)
            {
                con.Close();
                return false;
            }

        }
    }

}
