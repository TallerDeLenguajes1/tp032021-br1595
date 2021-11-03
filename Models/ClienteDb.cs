using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using EntidadesSistema;

namespace tp032021_br1595.Models
{
    public class RepositorioCliente
    {

        private readonly string connectionString;

        public RepositorioCliente(string _ConnectionString)
        {
            this.connectionString = _ConnectionString;
        }
        public List<Cliente> getAll()
        {
            List<Cliente> ListadoClientes = new List<Cliente>();
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
                conexion.Close();
            }
            return ListadoClientes;
        }

        public void addCliente(Cliente _Cliente)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "INSERT INTO Clientes SET clienteNombre ='" + _Cliente.Nombre + "', clienteTelefono ='" + _Cliente.Telefono + "', clienteDireccion ='" + _Cliente.Direccion + "', clienteEstado = 1 ;";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                conexion.Close();
            }
        }
        public void deleteCliente(Cliente _Cliente)
        {
            Cliente ClienteSelecionado = new Cliente();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "UPDATE Clientes SET clienteEstado= 0 WHERE clienteID =" + _Cliente.Id + ";";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                conexion.Close();
            }
        }

        public void readmitCliente(Cliente _Cliente)
        {
            Cliente ClienteSelecionado = new Cliente();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "UPDATE Clientes SET clienteEstado= 1 WHERE clienteID =" + _Cliente.Id + ";";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                conexion.Close();
            }
        }
    }
}

