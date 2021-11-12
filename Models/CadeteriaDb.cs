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
    }
}