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
        public bool StartLogin(string _Username, string _Contrasena)
        {
            bool resultado = false;
            string SQLQuery = @"SELECT usuarioNombre FROM Usuarios WHERE usuarioNombre = @username AND usuarioPassword = @contrasena";
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                {
                    command.Parameters.AddWithValue("@username", _Username);
                    command.Parameters.AddWithValue("@contrasena", _Contrasena);
                    conexion.Open();
                    command.ExecuteNonQuery();
                    SQLiteDataReader DataReader = command.ExecuteReader();
                    if (DataReader.Read())
                    {
                        resultado = true;
                    }
                    DataReader.Close();
                    conexion.Close();
                }
            }
            return resultado;
        }
    }
}
