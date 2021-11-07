using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesSistema;
using System.Data.SQLite;

namespace tp032021_br1595.Models
{
    public class RepositorioCadeteria
    {        
        private readonly string connectionString;

        public RepositorioCadeteria(string _ConnectionString)
        {
            this.connectionString = _ConnectionString;
        }

        public List<Cadeteria> getAll()
        {
            List<Cadeteria> ListadoCadeterias = new List<Cadeteria>();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "SELECT * FROM Cadeterias;";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                SQLiteDataReader DataReader = command.ExecuteReader();
                while(DataReader.Read() )
                {
                    Cadeteria cadeteria = new Cadeteria()
                    {
                        CadeteriaID = DataReader["cadeteriaID"].ToString(),
                        CadeteriaNombre = DataReader["cadeteriaNombre"].ToString()
                    };
                    ListadoCadeterias.Add(cadeteria);
                }
                conexion.Close();
            }
            return ListadoCadeterias;
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
        {/*
            string instruccion = @"INSERT INTO 
                                       Cadetes (cadeteNombre, cadeteTelefono, cadeteDireccion, cadeteActivo)
                                       VALUES (@nombre, @telefono, @direccion, 1)";

            using (var conexion = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                {
                    command.Parameters.AddWithValue("@nombre", nuevo.Nombre);
                    command.Parameters.AddWithValue("@telefono", nuevo.Telefono);
                    command.Parameters.AddWithValue("@direccion", nuevo.Direccion);

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
            }*/
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