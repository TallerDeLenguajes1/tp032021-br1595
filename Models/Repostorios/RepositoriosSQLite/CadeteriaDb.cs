using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using EntidadesSistema;
using System.Data.SQLite;
using NLog;


namespace tp032021_br1595.Models.SQLite
{
    public class RepositorioCadeteria : IRepositorioCadeterias
    {        
        private readonly string connectionString;
        private readonly Logger log;

        public RepositorioCadeteria(string _ConnectionString, Logger log)
        {
            this.connectionString = _ConnectionString;
            this.log = log;
        }

        public List<Cadeteria> getAll()
        {           
            List <Cadeteria> ListadoCadeterias = new List<Cadeteria>();
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string SQLQuery = "SELECT * FROM Cadeterias;";
                    SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                    SQLiteDataReader DataReader = command.ExecuteReader();
                    while (DataReader.Read())
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
            }
            catch(Exception ex)
            {
                string error = ex.ToString();
            }
            return ListadoCadeterias;
        }
    }
}