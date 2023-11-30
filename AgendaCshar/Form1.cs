using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AgendaCshar
{
    public partial class Form1 : Form
    {
        private DataAccess dataAccess = new DataAccess();
        public Form1()
        {
            InitializeComponent();
            cargarActividades();
            

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cargarActividades() 
        {
            List<Actividad> listaTodasActividades = dataAccess.ObternerActividades();
            dataGridView1.DataSource = listaTodasActividades;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Actividad nuevActividad = new Actividad
            {
                Tarea = textproject.Text,
                Date = dateTimePicker1.Value,
                Status = textstate.Text
            };
            dataAccess.AgregarActividad(nuevActividad);
            cargarActividades();
            limpiarCampos();
        }

        private void limpiarCampos() 
        {
            textproject.Text = "";
            textstate.Text = "";
        }
    }
}

