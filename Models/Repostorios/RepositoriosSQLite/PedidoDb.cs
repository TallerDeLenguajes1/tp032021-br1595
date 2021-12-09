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
                string SQLQuery = @"INSERT INTO Pedidos (pedidoObservacion, clienteID) VALUES (@pedidoObservacion,  @ClienteID)";
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@pedidoObservacion", _Pedido.Observacion);
                        command.Parameters.AddWithValue("@ClienteID", _Pedido.ClienteID);               
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

        public void cancelPedido(Pedido _Pedido)
        {
            executeTaskPedido(_Pedido, "Cancelado");
        }
        public void finishPedido(Pedido _Pedido)
        {
            executeTaskPedido(_Pedido, "Completado");
        }

        public void executeTaskPedido(Pedido _Pedido, string _Accion)
        {
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    string SQLQuery = @"UPDATE Pedidos SET pedidoEstado= @Accion WHERE pedidoID = @pedidoID;";
                    using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@pedidoEstado", _Accion);
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
        public PedidoViewModel getOneCadetesClientes(DataContext _DB)
        {
            PedidoViewModel cadeteElegido = new PedidoViewModel();
            cadeteElegido.Cadetes = _DB.Cadetes.getAll();
            cadeteElegido.Pedido = new Pedido();
            return cadeteElegido;
        }
    }
}

