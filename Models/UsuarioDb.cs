using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using EntidadesSistema;

namespace tp032021_br1595.Models
{
    public class RepositorioUsuario
    {
        private readonly string connectionString;

        public RepositorioUsuario(string _ConnectionString)
        {
            this.connectionString = _ConnectionString;
        }
        public Usuario StartLogin(string _Username, string _Contrasena)
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "",
                Clearance = 0
            };
            string SQLQuery = @"SELECT usuarioNombre, usuarioClearance FROM Usuarios WHERE usuarioNombre = @username AND usuarioPassword = @contrasena;";
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                {
                    command.Parameters.AddWithValue("@username", _Username);
                    command.Parameters.AddWithValue("@contrasena", _Contrasena);
                    conexion.Open();
                    SQLiteDataReader DataReader = command.ExecuteReader();
                    if (DataReader.Read())
                    {
                        usuario.Nombre = DataReader["usuarioNombre"].ToString();
                        usuario.Clearance = Convert.ToInt32(DataReader["usuarioClearance"]);                     
                    }
                    DataReader.Close();
                    conexion.Close();
                }
            }
            return usuario;
        }

        public List<OpcionMenu> ObtenerOpciones(int _Clearance)
        {
            List<OpcionMenu> opciones = new List<OpcionMenu>();
            string SQLQuery = @"SELECT opcionURL, opcionNombre, opcionControlador,opcionClearance FROM Opciones WHERE opcionClearance = @opcionClearance;";
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                {                    
                    command.Parameters.AddWithValue("@opcionClearance", _Clearance);
                    conexion.Open();
                    SQLiteDataReader DataReader = command.ExecuteReader();
                    while (DataReader.Read())
                    {
                        OpcionMenu opcion = new OpcionMenu
                        {
                            Url = DataReader["opcionURL"].ToString(),
                            Nombre = DataReader["opcionNombre"].ToString(),
                            Clearance = Convert.ToInt32(DataReader["opcionClearance"]),
                            Controlador = DataReader["opcionControlador"].ToString()
                        };
                        opciones.Add(opcion); 
                    }
                    DataReader.Close();
                    conexion.Close();
                }
            }
            return opciones;
        }
    }
}
