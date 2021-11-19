using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using EntidadesSistema;

namespace tp032021_br1595.Models
{
    public class RepositorioPedido
    {
        private readonly string connectionString;

        public RepositorioPedido(string _ConnectionString)
        {
            this.connectionString = _ConnectionString;
        }
        public List<Pedido> getAll()
        {
            List<Pedido> ListadoPedidos = new List<Pedido>();
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
            return ListadoPedidos;
        }
        public void addPedido(Pedido _Pedido)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                string SQLQuery = @"INSERT INTO Pedidos SET pedidoObservacion = @Observacion, clienteID = @ClienteID, cadeteID = @CodigoCadete, pedidoEstado = 'Recibido';";
                using(SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                {
                    command.Parameters.AddWithValue("@Observacion", _Pedido.Observacion);
                    command.Parameters.AddWithValue("@ClienteID", _Pedido.ClienteID);
                    command.Parameters.AddWithValue("@CodigoCadete", _Pedido.CodigoCadete);
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }
        public void addPedidoCadete(Pedido _Pedido, Cadete _Cadete)
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
        public PedidoCadetesViewModel getOneCadetes(RepositorioCadete _DB)
        {
            PedidoCadetesViewModel cadeteElegido = new PedidoCadetesViewModel();
            cadeteElegido.Cadetes = _DB.getAll();
            cadeteElegido.Pedido = new Pedido();
            return cadeteElegido;
        }
    }
}

