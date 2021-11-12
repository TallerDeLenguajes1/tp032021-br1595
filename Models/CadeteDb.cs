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
                while(DataReader.Read() )
                {/*
                    var Id = (DataReader["cadeteID"]);
                    var Nombre = DataReader["cadeteNombre"];
                    var Telefono = DataReader["cadeteTelefono"];
                    var Direccion = DataReader["cadeteDireccion"];
                    var CadeteriaId = DataReader["cadeteriaID"];
                    var Activo = (DataReader["cadeteActivo"]);
                    var TotalPagos =(DataReader["cadeteTotalPagos"]);
                    var PedidosActivos = (DataReader["cadetePedidosActivos"]);
                    var PedidosRealizados = (DataReader["cadetePedidosRealizados"]);*/
                    Cadete cadete = new Cadete()
                    {
                        Id = Convert.ToInt32(DataReader["cadeteID"]) ,
                        Nombre = DataReader["cadeteNombre"].ToString(),
                        Telefono = DataReader["cadeteTelefono"].ToString(),
                        Direccion = DataReader["cadeteDireccion"].ToString(),
                        CadeteriaId = DataReader["cadeteriaID"].ToString(),
                        Activo = Convert.ToInt32(DataReader["cadeteActivo"]),
                        TotalPagos = Convert.ToDecimal(DataReader["cadeteTotalPagos"]),
                        PedidosActivos = Convert.ToInt32(DataReader["cadetePedidosActivos"]),
                        PedidosRealizados = Convert.ToInt32(DataReader["cadetePedidosRealizados"])
                    };
                    ListadoCadetes.Add(cadete);
                }
                DataReader.Close();
                conexion.Close();
            }
            return ListadoCadetes;
        }

        public Cadete getOne(int _CadeteCodigo)
        {
            Cadete cadeteElegido = new Cadete();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "SELECT * FROM Cadetes WHERE cadeteID = " + _CadeteCodigo + ";";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                SQLiteDataReader DataReader = command.ExecuteReader();
                if (DataReader.Read())
                {
                    cadeteElegido.Id = Convert.ToInt32(DataReader["cadeteID"]);
                    cadeteElegido.Nombre = DataReader["cadeteNombre"].ToString();
                    cadeteElegido.Telefono = DataReader["cadeteTelefono"].ToString();
                    cadeteElegido.Direccion = DataReader["cadeteDireccion"].ToString();
                    cadeteElegido.CadeteriaId = DataReader["cadeteriaID"].ToString();
                    cadeteElegido.TotalPagos = Convert.ToDecimal(DataReader["cadeteTotalPagos"]);
                    cadeteElegido.PedidosRealizados = Convert.ToInt32(DataReader["cadetePedidosRealizados"]);
                    cadeteElegido.PedidosActivos = Convert.ToInt32(DataReader["cadetePedidosActivos"]);
                }
                DataReader.Close();
                conexion.Close();
            }
            return cadeteElegido;
        }
        public CadetePedidosViewModel getOneCadeteria(int _CadeteCodigo, RepositorioCadeteria _DBC)
        {
            CadetePedidosViewModel cadeteElegido = new CadetePedidosViewModel();
            cadeteElegido.Cadete = getOne(_CadeteCodigo);
            cadeteElegido.ListaCadeterias = _DBC.getAll();
            return cadeteElegido;
        }

        public void addCadete(Cadete _Cadete)
        {
            string SQLQuery = @"INSERT INTO Cadetes (cadeteNombre, cadeteTelefono, cadeteDireccion, cadeteriaID) VALUES (@cadeteNombre, @cadeteTelefono, @cadeteDireccion, @cadeteCadeteriaID)";
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                {
                    command.Parameters.AddWithValue("@cadeteNombre", _Cadete.Nombre);
                    command.Parameters.AddWithValue("@cadeteTelefono", _Cadete.Telefono);
                    command.Parameters.AddWithValue("@cadeteDireccion", _Cadete.Direccion);
                    command.Parameters.AddWithValue("@cadeteCadeteriaID", _Cadete.CadeteriaId);
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }
        public void modifyCadete(Cadete _Cadete)
        {
            string SQLQuery = @"UPDATE Cadetes SET cadeteNombre = @cadeteNombre, cadeteTelefono = @cadeteTelefono, cadeteDireccion = @cadeteDireccion, cadeteriaID = @cadeteCadeteriaID WHERE cadeteID = @cadeteCodigo";
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                {
                    command.Parameters.AddWithValue("@cadeteNombre", _Cadete.Nombre);
                    command.Parameters.AddWithValue("@cadeteTelefono", _Cadete.Telefono);
                    command.Parameters.AddWithValue("@cadeteDireccion", _Cadete.Direccion);
                    command.Parameters.AddWithValue("@cadeteCadeteriaID", _Cadete.CadeteriaId);
                    command.Parameters.AddWithValue("@cadeteCodigo", _Cadete.Id);
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }

        public void readmitCadete(int _CadeteCodigo)
        {
            string SQLQuery = "UPDATE Cadetes SET cadeteEstado = @estado WHERE cadeteID = @cadeteCodigo;";
            executeQueryEstado(_CadeteCodigo, SQLQuery, 1);
        }
        public void deleteCadete(int _CadeteCodigo)
        {
            string SQLQuery = "UPDATE Cadetes SET cadeteEstado = @estado WHERE cadeteID = @cadeteCodigo";
            executeQueryEstado(_CadeteCodigo, SQLQuery, 0);
        }

        public void executeQueryEstado(int _CadeteCodigo, string SQLQuery, int _Estado)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                {
                    command.Parameters.AddWithValue("@estado", _Estado);
                    command.Parameters.AddWithValue("@cadeteCodigo", _CadeteCodigo);
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }
    }
}