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
                            PedidosRealizados = Convert.ToInt32(DataReader["cadetePedidosRealizados"]),
                            UsuarioID = Convert.ToInt32(DataReader["usuarioID"])
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

        public Cadete getOne(int _CadeteCodigo, int _CodigoUsuario)
        {
            Cadete cadeteElegido = new Cadete();
            int _CodigoAUsar = 0;
            string SQLQuery = "";
            try
            {
                if(_CodigoUsuario != 0)
                {
                    _CodigoAUsar = _CodigoUsuario;
                    SQLQuery = @"SELECT * FROM Cadetes WHERE usuarioID = @Codigo";
                }
                else
                {
                    _CodigoAUsar = _CadeteCodigo;
                    SQLQuery = @"SELECT * FROM Cadetes WHERE cadeteID = @Codigo";
                }
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                    {
                        conexion.Open();
                        command.Parameters.AddWithValue("@codigo", _CodigoAUsar);
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
                            cadeteElegido.UsuarioID = Convert.ToInt32(DataReader["usuarioID"]);
;                        }
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
            cadeteElegido.Cadete = getOne(_CadeteCodigo, 0);
            cadeteElegido.ListaCadeterias = _db.Cadeterias.getAll();
            return cadeteElegido;
        }

        public void addCadete(Cadete _Cadete)
        {
            try
            {
                string SQLQuery = @"INSERT INTO Cadetes (cadeteNombre, cadeteTelefono, cadeteDireccion, cadeteriaID, usuarioID) VALUES (@cadeteNombre, @cadeteTelefono, @cadeteDireccion, @cadeteCadeteriaID, @usuarioID)";
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@cadeteNombre", _Cadete.Nombre);
                        command.Parameters.AddWithValue("@cadeteTelefono", _Cadete.Telefono);
                        command.Parameters.AddWithValue("@cadeteDireccion", _Cadete.Direccion);
                        command.Parameters.AddWithValue("@cadeteCadeteriaID", _Cadete.CadeteriaId);
                        command.Parameters.AddWithValue("@usuarioID", _Cadete.UsuarioID);
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

        public void readmitCadete(int _CadeteCodigo, int _UsuarioID)
        {
            executeQueryEstadoCadete(_CadeteCodigo, 1);
            executeQueryEstadoUser(_UsuarioID, 1);
        }
        public void deleteCadete(int _CadeteCodigo, int _UsuarioID)
        {
            executeQueryEstadoCadete(_CadeteCodigo, 0);
            executeQueryEstadoUser(_UsuarioID, 0);
        }

        public void executeQueryEstadoCadete(int _CadeteCodigo, int _Estado)
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
        public void executeQueryEstadoUser(int _UsuarioID, int _Estado)
        {
            try
            {
                string SQLQuery = @"UPDATE Usuarios SET usuarioActivo = @usuarioActivo WHERE usuarioID = @usuarioID;";
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@usuarioActivo", _Estado);
                        command.Parameters.AddWithValue("@usuarioID", _UsuarioID);
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