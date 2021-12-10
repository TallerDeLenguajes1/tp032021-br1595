using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using EntidadesSistema;
using NLog;
using tp032021_br1595.Models.Repostorios;

namespace tp032021_br1595.Models.SQLite
{
    public class RepositorioPedido : IRepositorioPedidos
    {
        private readonly string connectionString; 
        private readonly Logger log;

        public RepositorioPedido(string _ConnectionString, Logger log)
        {
            this.connectionString = _ConnectionString;
            this.log = log;
        }
        public List<Pedido> getAll()
        {
            List<Pedido> ListadoPedidos = new List<Pedido>();
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string SQLQuery = "SELECT * FROM Pedidos;";
                    SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                    SQLiteDataReader DataReader = command.ExecuteReader();
                    while (DataReader.Read())
                    {
                        Pedido pedido = new Pedido()
                        {
                            Numero = Convert.ToInt32(DataReader["pedidoID"]),
                            Observacion = DataReader["pedidoObservacion"].ToString(),
                            Estado = DataReader["pedidoEstado"].ToString(),
                            Direccion = DataReader["pedidoDireccion"].ToString(),
                            ClienteID = Convert.ToInt32(DataReader["clienteID"]),
                            CodigoCadete = Convert.ToInt32(DataReader["cadeteID"])
                        };
                        ListadoPedidos.Add(pedido);
                    }
                    DataReader.Close();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            return ListadoPedidos;
        }
        public void addPedido(Pedido _Pedido)
        {
            try
            {
                string SQLQuery = @"INSERT INTO Pedidos (pedidoObservacion, clienteID, pedidoDireccion) VALUES (@pedidoObservacion,  @ClienteID, @pedidoDireccion)";
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@pedidoObservacion", _Pedido.Observacion);
                        command.Parameters.AddWithValue("@ClienteID", _Pedido.ClienteID); 
                        command.Parameters.AddWithValue("@pedidoDireccion", _Pedido.Direccion);
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

        public void addPedidoCadete(Pedido _Pedido, Cadete _Cadete)
        {
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    string SQLQuery = @"UPDATE Pedidos SET cadeteId= @cadeteId, estadoPedido= 'En camino' WHERE pedidoID = @pedidoID;";
                    using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@cadeteId", _Pedido.CodigoCadete);
                        command.Parameters.AddWithValue("@pedidoID", _Pedido.Numero);
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

        public void cancelPedido(int _CodigoPedido)
        {
            executeTaskPedido(_CodigoPedido, "Cancelado");
        }
        public void finishPedido(int _CodigoPedido)
        {
            executeTaskPedido(_CodigoPedido, "Completado");
        }
        public void AceptarPedido(int _CodigoPedido, int Codigo)
        {
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    string SQLQuery = @"UPDATE Pedidos SET pedidoEstado= @pedidoEstado, cadeteID= @cadeteID WHERE pedidoID = @pedidoID;";
                    using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@pedidoEstado", "En Camino");
                        command.Parameters.AddWithValue("@pedidoID", _CodigoPedido);
                        command.Parameters.AddWithValue("@cadeteID", Codigo);
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
        public List<Pedido> getAllPedidosCadete(int _Id)
        {
            List<Pedido> ListadoPedidos = new List<Pedido>();
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string SQLQuery = "SELECT * FROM Pedidos WHERE cadeteID = @cadeteID;";
                    SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                    command.Parameters.AddWithValue("@cadeteID", _Id);
                    SQLiteDataReader DataReader = command.ExecuteReader();
                    while (DataReader.Read())
                    {
                        Pedido pedido = new Pedido()
                        {
                            Numero = Convert.ToInt32(DataReader["pedidoID"]),
                            Observacion = DataReader["pedidoObservacion"].ToString(),
                            Estado = DataReader["pedidoEstado"].ToString(),
                            Direccion = DataReader["pedidoDireccion"].ToString(),
                            ClienteID = Convert.ToInt32(DataReader["clienteID"]),
                            CodigoCadete = Convert.ToInt32(DataReader["cadeteID"])
                        };
                        ListadoPedidos.Add(pedido);
                    }
                    DataReader.Close();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            return ListadoPedidos;
        }
        public void executeTaskPedido(int _CodigoPedido, string _Accion)
        {
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    string SQLQuery = @"UPDATE Pedidos SET pedidoEstado= @pedidoEstado WHERE pedidoID = @pedidoID;";
                    using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@pedidoEstado", _Accion);
                        command.Parameters.AddWithValue("@pedidoID", _CodigoPedido);
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
        public PedidoViewModel getOneCadetesClientes(DataContext _DB)
        {
            PedidoViewModel cadeteElegido = new PedidoViewModel();
            cadeteElegido.Cadetes = _DB.Cadetes.getAll();
            cadeteElegido.Pedido = new Pedido();
            return cadeteElegido;
        }
        public List<Pedido> getAllPedidosCliente(int _CodigoCliente)
        {
            List<Pedido> ListadoPedidos = new List<Pedido>();
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string SQLQuery = @"SELECT * FROM Pedidos WHERE ClienteID = @ClienteID;";
                    SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                    command.Parameters.AddWithValue("@ClienteID", _CodigoCliente);
                    SQLiteDataReader DataReader = command.ExecuteReader();
                    while (DataReader.Read())
                    {
                        Pedido pedido = new Pedido()
                        {
                            Numero = Convert.ToInt32(DataReader["pedidoID"]),
                            Observacion = DataReader["pedidoObservacion"].ToString(),
                            Estado = DataReader["pedidoEstado"].ToString(),
                            ClienteID = Convert.ToInt32(DataReader["clienteID"]),
                            Direccion = DataReader["pedidoDireccion"].ToString(),
                            CodigoCadete = Convert.ToInt32(DataReader["cadeteID"])
                        };
                        ListadoPedidos.Add(pedido);
                    }
                    DataReader.Close();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            return ListadoPedidos;
        }
        public List<Pedido> getAllDisponibles()
        {
            List<Pedido> ListadoPedidos = new List<Pedido>();
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string SQLQuery = "SELECT * FROM Pedidos WHERE CadeteID = 0;";
                    SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                    SQLiteDataReader DataReader = command.ExecuteReader();
                    while (DataReader.Read())
                    {
                        Pedido pedido = new Pedido()
                        {
                            Numero = Convert.ToInt32(DataReader["pedidoID"]),
                            Observacion = DataReader["pedidoObservacion"].ToString(),
                            Estado = DataReader["pedidoEstado"].ToString(),
                            ClienteID = Convert.ToInt32(DataReader["clienteID"]),
                            Direccion = DataReader["pedidoDireccion"].ToString(),
                            CodigoCadete = Convert.ToInt32(DataReader["cadeteID"])
                        };
                        ListadoPedidos.Add(pedido);
                    }
                    DataReader.Close();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            return ListadoPedidos;
        }
        public void cancelarPedido(int _Id)
        {
            try
            {
                string SQLQuery = @"UPDATE Pedidos SET pedidoEstado = @pedidoEstado, pedidoActivo = 0 WHERE pedidoID = @pedidoID;";
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@pedidoID", _Id);
                        command.Parameters.AddWithValue("@pedidoEstado", "Cancelado");
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

