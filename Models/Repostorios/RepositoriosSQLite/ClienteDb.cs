using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using EntidadesSistema;
using NLog;

namespace tp032021_br1595.Models.SQLite
{
    public class RepositorioCliente : IRepositorioClientes
    {

        private readonly string connectionString;
        private readonly Logger log;

        public RepositorioCliente(string _ConnectionString, Logger log)
        {
            this.connectionString = _ConnectionString;
            this.log = log;
        }
        public List<Cliente> getAll()
        {
            List<Cliente> ListadoClientes = new List<Cliente>();
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string SQLQuery = "SELECT * FROM Clientes;";
                    SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                    SQLiteDataReader DataReader = command.ExecuteReader();
                    while (DataReader.Read())
                    {
                        Cliente cliente = new Cliente()
                        {
                            Id = Convert.ToInt32(DataReader["clienteID"]),
                            Nombre = DataReader["clienteNombre"].ToString(),
                            Telefono = DataReader["clienteTelefono"].ToString(),
                            Direccion = DataReader["clienteDireccion"].ToString(),
                            UsuarioID = Convert.ToInt32(DataReader["usuarioID"])
                        };
                        ListadoClientes.Add(cliente);
                    }
                    DataReader.Close();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            return ListadoClientes;
        }

        public void addCliente(Cliente _Cliente)
        {
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    string SQLQuery = @"INSERT INTO Clientes (clienteNombre, clienteTelefono, clienteDireccion, usuarioID) VALUES (@clienteNombre, @clienteTelefono, @clienteDireccion, @usuarioID);";
                    using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@clienteNombre", _Cliente.Nombre);
                        command.Parameters.AddWithValue("@clienteTelefono", _Cliente.Telefono);
                        command.Parameters.AddWithValue("@clienteDireccion", _Cliente.Direccion);
                        command.Parameters.AddWithValue("@usuarioID", _Cliente.UsuarioID);
                        conexion.Open();
                        command.ExecuteNonQuery();
                        conexion.Close();
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }
        public void readmitCliente(int _ClienteCodigo)
        {
            executeQueryEstadoCliente(_ClienteCodigo, 1);
            executeQueryEstadoCliente(_ClienteCodigo, 0);
        }
        public void deleteCliente(int _ClienteCodigo)
        {
            executeQueryEstadoCliente(_ClienteCodigo, 0);
            executeQueryEstadoCliente(_ClienteCodigo, 0);
        }

        public void executeQueryEstadoCliente(int _ClienteCodigo, int _Estado)
        {
            try
            {
                Cliente ClienteSelecionado = new Cliente();
                string SQLQuery = "UPDATE Clientes SET clienteEstado= @estado WHERE clienteID = @clienteCodigo;";
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@estado", _Estado);
                        command.Parameters.AddWithValue("@clienteCodigo", _ClienteCodigo);
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
        public void executeQueryEstadoClienteUser(int _UsuarioID, int _Estado)
        {
            try
            {
                string SQLQuery = @"UPDATE Usuarios SET usuarioActivo = @usuarioActivo WHERE usuarioID = @usuarioID;";
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@usuarioActivo", _Estado);
                        command.Parameters.AddWithValue("@usuarioID", _UsuarioID);
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
    }
}

