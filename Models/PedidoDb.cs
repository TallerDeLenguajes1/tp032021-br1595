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
                conexion.Open();
                string SQLQuery = "INSERT INTO Pedidos SET pedidoObservacion ='" + _Pedido.Observacion + "', clienteID =" + _Pedido.ClienteID + ", cadeteID =" + _Pedido.CodigoCadete + ", pedidoEstado = 'Recibido';";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                conexion.Close();
            }
        }
        public void addPedidoCadete(Pedido _Pedido, Cadete _Cadete)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "UPDATE Pedidos SET cadeteId=" + _Cadete.Id + ", estadoPedido= 'En camino' WHERE pedidoID =" + _Pedido.Numero + ";";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                conexion.Close();
            }
        }

        public void cancelPedido(Pedido _Pedido)
        {
            Pedido PedidoSelecionado = new Pedido();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "UPDATE Pedidos SET pedidoEstado= 'Cancelado' WHERE pedidoID =" + _Pedido.Numero + ";";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                conexion.Close();
            }
        }
        public void finishPedido(Pedido _Pedido)
        {
            Pedido PedidoSelecionado = new Pedido();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "UPDATE Pedidos SET pedidoEstado= 'Completado' WHERE pedidoID =" + _Pedido.Numero + ";";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                conexion.Close();
            }
        }
    }
}

