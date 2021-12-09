using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesSistema;
using System.Data.SQLite;
using NLog;
using tp032021_br1595.Models.Repostorios;

namespace tp032021_br1595.Models.SQLite
{
    public class RepositorioCadete : IRepositorioCadetes
    {        
        private readonly string connectionString;
        private readonly Logger log;

        public RepositorioCadete(string _ConnectionString, Logger log)
        {
            this.connectionString = _ConnectionString;
            this.log = log;
        }

        public List<Cadete> getAll()
        {
            List<Cadete> ListadoCadetes = new List<Cadete>();
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string SQLQuery = "SELECT * FROM Cadetes;";
                    SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                    SQLiteDataReader DataReader = command.ExecuteReader();
                    while (DataReader.Read())
                    {
                        Cadete cadete = new Cadete()
                        {
                            Id = Convert.ToInt32(DataReader["cadeteID"]),
                            Nombre = DataReader["cadeteNombre"].ToString(),
                            Telefono = DataReader["cadeteTelefono"].ToString(),
                            Direccion = DataReader["cadeteDireccion"].ToString(),
                            CadeteriaId = DataReader["cadeteriaID"].ToString(),
                            Activo = Convert.ToInt32(DataReader["cadeteActivo"]),
                            PedidosActivos = Convert.ToInt32(DataReader["cadetePedidosActivos"]),
                            PedidosRealizados = Convert.ToInt32(DataReader["cadetePedidosRealizados"])
                        };
                        ListadoCadetes.Add(cadete);
                    }
                    DataReader.Close();
                    conexion.Close();
                }
            }
            catch(Exception ex)
            {
                string error = ex.ToString();
            }
            return ListadoCadetes;
        }

        public Cadete getOne(int _CadeteCodigo)
        {
            Cadete cadeteElegido = new Cadete();
            try
            {
                string SQLQuery = @"SELECT * FROM Cadetes WHERE cadeteID = " + _CadeteCodigo + ";"; 
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                    {
                        conexion.Open();
                        SQLiteDataReader DataReader = command.ExecuteReader();
                        if (DataReader.Read())
                        {
                            cadeteElegido.Id = Convert.ToInt32(DataReader["cadeteID"]);
                            cadeteElegido.Nombre = DataReader["cadeteNombre"].ToString();
                            cadeteElegido.Telefono = DataReader["cadeteTelefono"].ToString();
                            cadeteElegido.Direccion = DataReader["cadeteDireccion"].ToString();
                            cadeteElegido.CadeteriaId = DataReader["cadeteriaID"].ToString();
                            cadeteElegido.PedidosRealizados = Convert.ToInt32(DataReader["cadetePedidosRealizados"]);
                            cadeteElegido.PedidosActivos = Convert.ToInt32(DataReader["cadetePedidosActivos"]);
                        }
                        DataReader.Close();
                        conexion.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            return cadeteElegido;
        }
        public CadeteViewModel getOneCadeteria(int _CadeteCodigo, DataContext _db)
        {
            CadeteViewModel cadeteElegido = new CadeteViewModel();
            cadeteElegido.Cadete = getOne(_CadeteCodigo);
            cadeteElegido.ListaCadeterias = _db.Cadeterias.getAll();
            return cadeteElegido;
        }

        public void addCadete(Cadete _Cadete)
        {
            try
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
            catch(Exception ex)
            {
                string error = ex.ToString();
            }
        }
        public void modifyCadete(Cadete _Cadete)
        {
            try
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
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        public void readmitCadete(int _CadeteCodigo)
        {
            executeQueryEstado(_CadeteCodigo, 1);
        }
        public void deleteCadete(int _CadeteCodigo)
        {
            executeQueryEstado(_CadeteCodigo, 0);
        }

        public void executeQueryEstado(int _CadeteCodigo, int _Estado)
        {
            try
            {
                string SQLQuery = @"UPDATE Cadetes SET cadeteActivo = @cadeteActivo WHERE cadeteID = @cadeteID;";
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@cadeteActivo", _Estado);
                        command.Parameters.AddWithValue("@cadeteID", _CadeteCodigo);
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