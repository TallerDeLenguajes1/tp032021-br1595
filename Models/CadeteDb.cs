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
                {
                    Cadete cadete = new Cadete()
                    {
                        Id = Convert.ToInt32(DataReader["cadeteID"]) ,
                        Nombre = DataReader["cadeteNombre"].ToString(),
                        Telefono = DataReader["cadeteTelefono"].ToString(),
                        Direccion = DataReader["cadeteDireccion"].ToString(),
                        CadeteriaId = DataReader["cadeteriaID"].ToString(),
                        TotalPagos = Convert.ToDecimal(DataReader["cadeteTotalPagos"]),
                        Activo = Convert.ToInt32(DataReader["cadeteActivo"])
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
            string SQLQuery = @"INSERT INTO Cadetes (cadeteNombre, cadeteTelefono, cadeteDireccion, cadeteActivo) VALUES (@nombreCadete, @nombreTelefono, @nombreDireccion, @nombreCadeteriaID)";

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                {
                    command.Parameters.AddWithValue("@nombreCadete", _Cadete.Nombre);
                    command.Parameters.AddWithValue("@nombreTelefono", _Cadete.Telefono);
                    command.Parameters.AddWithValue("@nombreDireccion", _Cadete.Direccion);
                    command.Parameters.AddWithValue("@nombreCadeteriaID", _Cadete.CadeteriaId);
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }
        public void modifyCadete(Cadete _Cadete)
        {
            string SQLQuery = @"UPDATE Cadetes SET (cadeteNombre, cadeteTelefono, cadeteDireccion, cadeteActivo) VALUES (@nombreCadete, @nombreTelefono, @nombreDireccion, @nombreCadeteriaID)";

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                {
                    command.Parameters.AddWithValue("@nombreCadete", _Cadete.Nombre);
                    command.Parameters.AddWithValue("@nombreTelefono", _Cadete.Telefono);
                    command.Parameters.AddWithValue("@nombreDireccion", _Cadete.Direccion);
                    command.Parameters.AddWithValue("@nombreCadeteriaID", _Cadete.CadeteriaId);
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }   
        public void readmitCadete(Cadete _Cadete)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                string SQLQuery = "UPDATE Cadetes SET cadeteActivo = 1 WHERE cadeteID =" + _Cadete.Id + ";";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                {
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }
        public void deleteCadete(int _CadeteCodigo)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                string SQLQuery = @"UPDATE Cadetes SET cadeteActivo = 0 WHERE cadeteID = @id;";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                {
                    command.Parameters.AddWithValue("@id", _CadeteCodigo);
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
            }  
        }
    }
}