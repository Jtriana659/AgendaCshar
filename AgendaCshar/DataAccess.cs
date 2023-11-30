using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace AgendaCshar
{
    internal class DataAccess
    {
        private string connectionString = "Data Source=miBaseDeDatos.db;Version=3;";
        public DataAccess() 
        {
            // En el constructor, asegúrate de que la tabla "Agenda" exista en la base de datos
            CrearTablaAgenda();
        }

        public void CrearTablaAgenda()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)) 
            {
                connection.Open();
                // Consulta SQL para crear la tabla "Agenda" si no existe
                string query = "CREATE TABLE IF NOT EXISTS Agenda (Id INTEGER PRIMARY KEY AUTOINCREMENT, Tarea TEXT, Status TEXT, Date DATE)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public List<Actividad> ObternerActividades() 
        { 
            List<Actividad> listaActividades = new List<Actividad>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Agenda";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader= cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaActividades.Add(new Actividad
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Tarea = reader["Tarea"].ToString(),
                                Date = Convert.ToDateTime(reader["Date"]),
                                Status = reader["Status"].ToString()
                            });
                        }
                    }
                }
            }
            return listaActividades;
        }
        public void AgregarActividad(Actividad listaActividad) 
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)) 
            { 
                connection.Open();
                string query = "INSERT INTO Agenda (Tarea, Date,Status) VALUES (@Tarea, @Date,@Status)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection)) 
                {
                    cmd.Parameters.AddWithValue("@Tarea", listaActividad.Tarea);
                    cmd.Parameters.AddWithValue("@Date", listaActividad.Date);
                    cmd.Parameters.AddWithValue("@Status", listaActividad.Status);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    
    }
}
