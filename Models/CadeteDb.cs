using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesSistema;
using System.Data.SQLite;

namespace tp032021_br1595.Models
{
    public class RepositorioCadete
    {        
        private readonly string connectionString;

        public RepositorioCadete(string _ConnectionString)
        {
            this.connectionString = _ConnectionString;
        }

        public List<Cadete> getAll()
        {
            List<Cadete> ListadoCadetes = new List<Cadete>();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "SELECT * FROM Cadetes;";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                SQLiteDataReader DataReader = command.ExecuteReader();
                while(DataReader.Read())
                {
                    Cadete cadete = new Cadete()
                    {
                        Id = (int) DataReader["cadeteID"],
                        Nombre = DataReader["cadeteNombre"].ToString()
                    };
                    ListadoCadetes.Add(cadete);
                }
                conexion.Close();
            }
            return ListadoCadetes;
        }   
        public void modifyCadete(Cadete _Cadete)
        {
            Cadete CadeteSelecionado = new Cadete();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "UPDATE Cadetes SET cadeteNombre =" + _Cadete.Nombre + ", cadeteTelefono = " + _Cadete.Direccion + " ,cadeteriaID=" + _Cadete.CadeteriaId + "WHERE cadeteID = " + _Cadete.Id + ";";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                conexion.Close();
            }
        }   
        public void addCadete(Cadete _Cadete)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "INSERT INTO Cadetes SET activo = 0 WHERE cadeteID =" + _Cadete.Id + ";";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                conexion.Close();
            }  
        }
        public void addCadetePedido(int _CodigoCadete, int _CodigoPedido)
        {
            List<Pedido> ListadoPedidos = new List<Pedido>();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "UPDATE Pedidos SET cadeteID =" + _CodigoCadete + "WHERE pedidoID =" + _CodigoPedido + ";";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                conexion.Close();
            }
        }
        public void deleteCadete(Cadete _Cadete)
        {
            Cadete CadeteSelecionado = new Cadete();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "UPDATE Cadetes SET activo = 0 WHERE cadeteID =" + _Cadete.Id + ";";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                conexion.Close();
            }  
        }
    }
}