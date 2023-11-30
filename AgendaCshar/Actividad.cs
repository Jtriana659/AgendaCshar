using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaCshar
{
    internal class Actividad
    {
        public int Id { get; set; }
        public string Tarea { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
