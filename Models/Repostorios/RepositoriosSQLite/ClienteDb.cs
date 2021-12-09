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
                            Id = (int)DataReader["clienteID"],
                            Nombre = DataReader["clienteNombre"].ToString(),
                            Telefono = DataReader["clienteTelefono"].ToString(),
                            Direccion = DataReader["clienteDireccion"].ToString()
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
                    conexion.Open();
                    string SQLQuery = @"INSERT INTO Clientes SET clienteNombre ='" + _Cliente.Nombre + "', clienteTelefono ='" + _Cliente.Telefono + "', clienteDireccion ='" + _Cliente.Direccion + "', clienteEstado = 1 ;";
                    SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
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
        }
        public void deleteCliente(int _ClienteCodigo)
        {
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
    }
}

