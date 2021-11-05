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
                        TotalPagos = Convert.ToDecimal(DataReader["cadeteTotalPagos"])
                };
                    ListadoCadetes.Add(cadete);
                }
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
                string SQLQuery = "SELECT * FROM Cadetes WHERE cadeteID= " + _CadeteCodigo + ";";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                SQLiteDataReader DataReader = command.ExecuteReader();
                Cadete cadete = new Cadete()
                {
                    Id = (int)DataReader["cadeteID"],
                    Nombre = DataReader["cadeteNombre"].ToString()
                };                
                conexion.Close();
            }
            return cadeteElegido;
        }
        public void addCadete(Cadete _Cadete)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = $"INSERT INTO Cadetes (cadeteNombre, cadeteTelefono, cadeteDireccion, cadeteteriaID) values  {_Cadete.Nombre},{_Cadete.Telefono},{_Cadete.Direccion},{_Cadete.CadeteriaId}";// VALUES"/*@nombreCadete"*/ + _Cadete.Nombre + ", " + _Cadete.Telefono + ", " + _Cadete.Direccion + ", " + _Cadete.CadeteriaId + ");";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                {
                
                
                /*command.Parameters.AddWithValue("@nombreCadete", _Cadete.Nombre);
                command.Parameters.AddWithValue("@nombreTelefono", _Cadete.Telefono);
                command.Parameters.AddWithValue("@nombreDireccion", _Cadete.Direccion);
                command.Parameters.AddWithValue("@nombreCadeteriaID", _Cadete.CadeteriaId);*/
                command.ExecuteNonQuery();
                }
            conexion.Close();
            }
        }
        public void modifyCadete(Cadete _Cadete)
        {
            Cadete CadeteSelecionado = new Cadete();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {/*
                conexion.Open();
                string SQLQuery = @"UPDATE Cadetes SET cadeteNombre = @nombreCadete , cadeteTelefono = '" + _Cadete.Direccion + "' ,cadeteriaID=" + _Cadete.CadeteriaId + "WHERE cadeteID = " + _Cadete.Id + ";";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                command.Parameters.Add("@nombreCadete",  _Cadete.Nombre);
                command.AddParametersWithValue.<addCadete>;  
                conexion.Close();*/
            }
        }   
        public void readmitCadete(Cadete _Cadete)
        {
            Cadete CadeteSelecionado = new Cadete();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "UPDATE Cadetes SET cadeteEstado = 1 WHERE cadeteID =" + _Cadete.Id + ";";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                conexion.Close();
            }
        }
        public void deleteCadete(int _CadeteCodigo)
        {
            Cadete CadeteSelecionado = new Cadete();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "UPDATE Cadetes SET cadeteEstado = 0 WHERE cadeteID =" + _CadeteCodigo + ";";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                conexion.Close();
            }  
        }
    }
}