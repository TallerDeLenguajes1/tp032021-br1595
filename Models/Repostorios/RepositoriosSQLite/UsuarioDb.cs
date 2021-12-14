using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using EntidadesSistema;
using NLog;

namespace tp032021_br1595.Models.SQLite
{
    public class RepositorioUsuario : IRepositorioUsuarios
    {
        private readonly string connectionString;
        private readonly Logger log;

        public RepositorioUsuario(string _ConnectionString, Logger log)
        {
            this.connectionString = _ConnectionString;
            this.log = log;
        }
        public List<Usuario> GetAll()
        {
            List<Usuario> ListadoUsuarios = new List<Usuario>();
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string SQLQuery = "SELECT usuarioID, usuarioNombre, usuarioClearance, usuarioEmail FROM Usuarios;";
                    SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                    SQLiteDataReader DataReader = command.ExecuteReader();
                    while (DataReader.Read())
                    {
                        Usuario usuario = new Usuario()
                        {
                            UsuarioID = DataReader["usuarioID"].ToString(),
                            Nombre = DataReader["usuarioNombre"].ToString(),
                            Email = DataReader["usuarioEmail"].ToString(),
                            Clearance = Convert.ToInt32(DataReader["usuarioClearance"])
                        };
                        ListadoUsuarios.Add(usuario);
                    }
                    DataReader.Close();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            return ListadoUsuarios;
        }
        public int getID(string cadeteNombre)
        {
            try
            {
                int id = 999;
                string SQLQuery = @"SELECT usuarioID FROM Usuarios WHERE usuarioNombre = @username;";
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@username", cadeteNombre);
                        conexion.Open();
                        SQLiteDataReader DataReader = command.ExecuteReader();
                        if (DataReader.Read())
                        {
                            id = Convert.ToInt32(DataReader["usuarioID"]);
                        }
                        DataReader.Close();
                        conexion.Close();
                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return 0;
            }
        }
        public void addUsuario(Usuario _Usuario)
        {
            try
            {
                string SQLQuery = @"INSERT INTO Usuarios (usuarioNombre, usuarioPassword, usuarioClearance, usuarioEmail) VALUES (@usuarioNombre, @usuarioPassword, @usuarioClearance, @usuarioEmail)";
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@usuarioNombre", _Usuario.Nombre);
                        command.Parameters.AddWithValue("@usuarioPassword", _Usuario.Contrasenia);
                        command.Parameters.AddWithValue("@usuarioEmail", _Usuario.Email);
                        command.Parameters.AddWithValue("@usuarioClearance", _Usuario.Clearance); 
                        conexion.Open();
                        command.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }
        public bool controlNombre(string _Nombre)
        {
            bool resultado = false;
            try
            {
                string SQLQuery = @"SELECT usuarioID FROM Usuarios WHERE usuarioNombre = @username;";
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@username", _Nombre);
                        conexion.Open();
                        SQLiteDataReader DataReader = command.ExecuteReader();
                        if (!DataReader.Read())
                        {
                            resultado = true;
                        }
                        DataReader.Close();
                        conexion.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            return resultado;
        }
        public Usuario StartLogin(string _Username, string _Contrasena)
        {
            Usuario usuario = new Usuario()
            {
                UsuarioID = "",
                Nombre = "",
                Clearance = 0
            };
            try
            {
                string SQLQuery = @"SELECT usuarioID, usuarioNombre, usuarioClearance FROM Usuarios WHERE usuarioNombre = @username AND usuarioPassword = @contrasena AND usuarioActivo = 1;";
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
                            usuario.UsuarioID = DataReader["usuarioID"].ToString();
                            usuario.Nombre = DataReader["usuarioNombre"].ToString();
                            usuario.Clearance = Convert.ToInt32(DataReader["usuarioClearance"]);
                        }
                        DataReader.Close();
                        conexion.Close();
                    }
                }
                usuario.Codigo = obtenerCodigo(Convert.ToInt32(usuario.UsuarioID)); 
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            return usuario;
        }

        public string obtenerCodigo(int _Codigo)
        {
            string codigo = "";
            string SQLQuery = @"SELECT cadeteID FROM Cadetes WHERE usuarioID = @usuarioID";
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                {
                    command.Parameters.AddWithValue("@usuarioID", _Codigo);
                    conexion.Open();
                    SQLiteDataReader DataReader = command.ExecuteReader();
                    if (DataReader.Read())
                    {
                        codigo = DataReader["cadeteID"].ToString();
                    }
                    DataReader.Close();
                    conexion.Close();
                }
            }
            return codigo;
        }

        public List<OpcionMenu> ObtenerOpciones(int _Clearance)
        {
            List<OpcionMenu> opciones = new List<OpcionMenu>();
            try
            {
                if(_Clearance != 0)
                {
                    string SQLQuery = @"SELECT opcionURL, opcionNombre, opcionControlador FROM Opciones WHERE opcionClearance = @opcionClearance;";
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
                                    Controlador = DataReader["opcionControlador"].ToString()
                                };
                                opciones.Add(opcion);
                            }
                            DataReader.Close();
                            conexion.Close();
                        }
                    }
                }
                else
                {///VER////
                    var opcion = new OpcionMenu()
                    {
                        Clearance = 0,
                        Url = "Index",
                        Controlador = "Home",
                        Nombre = "Ingresar"
                    };
                    opciones.Add(opcion);
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                var opcion = new OpcionMenu()
                {
                    Clearance = 0,
                    Url = "Index",
                    Controlador = "Home",
                    Nombre = "Ingresar"
                };
                opciones.Add(opcion);
            }
            return opciones;
        }
    }
}
