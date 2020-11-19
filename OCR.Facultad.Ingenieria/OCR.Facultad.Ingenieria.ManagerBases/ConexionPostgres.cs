using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
namespace OCR.Facultad.Ingenieria.ManagerBases
{
    public class ConexionPostgres
    {
        public static bool Test(string _ip,int _puerto,string _usuario,string _contrasenia,string _baseDatos)
        {
            NpgsqlConnection con=null ;
            try
            {
                NpgsqlConnectionStringBuilder conexion = new NpgsqlConnectionStringBuilder();
                conexion.Host = _ip;
                conexion.Port = _puerto;
                conexion.UserName = _usuario;
                conexion.Password = _contrasenia;
                conexion.Database = _baseDatos;
                con= new NpgsqlConnection(conexion.ToString());;
                con.Open();
                return true;
            }
            catch (Exception error)
            {
                con.Close();
                return false;
            }

            
                


            
            
        }
            
    }
}
