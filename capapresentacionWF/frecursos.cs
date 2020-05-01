using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capanegocio;
using capaentidades;

namespace capapresentacionWF
{
    public partial class frecursos : Form
    {
        logisticanegociorecursos logicaNR = new logisticanegociorecursos();
        public frecursos()
        {
            InitializeComponent();
        }

        private void frecursos_Load(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonGuardar.Text == "Guardar")
                {
                    recursos objetorecurso = new recursos();
                    
                    objetorecurso.nombres = textBoxNombre.Text;
                    objetorecurso.codigo = textBoxCodigo.Text;
                    objetorecurso.descripcion = textBoxDescrpcion.Text;

                    if (logicaNR.insertarrecursos(objetorecurso)>0)
                    {
                        MessageBox.Show("Agregado con éxito");
                        dataGridViewRecursos.DataSource = logicaNR.listarrecursos();
                        textBoxNombre.Text = "";
                        textBoxCodigo.Text = "";
                        textBoxDescrpcion.Text= "";
                        tabRecursos.SelectedTab = tabPage2;
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar Recurso");
                    }
                }
                if (buttonGuardar.Text == "Actualizar")
                {
                    recursos objetorecurso = new recursos();
                    objetorecurso.idrecursos = Convert.ToInt32(textBoxId.Text);
                    objetorecurso.nombres = textBoxNombre.Text;
                    objetorecurso.codigo = textBoxCodigo.Text;
                    objetorecurso.descripcion = textBoxDescrpcion.Text;

                    if (logicaNR.editarrecursos(objetorecurso) > 0)
                    {
                        dataGridViewRecursos.DataSource = logicaNR.listarrecursos();
                        textBoxNombre.Text = "";
                        textBoxCodigo.Text = "";
                        textBoxDescrpcion.Text = "";
                        tabRecursos.SelectedTab = tabPage2;
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar recuros");
                    }
                    buttonGuardar.Text = "Guardar";
                
                 catch
            {

                MessageBox.Show("ERROR");
            }
        }
           
        }
    }

