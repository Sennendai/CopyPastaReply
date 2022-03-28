using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CPR
{
    public partial class Principal : Form
    {
        List<SerializableMenuItem> elementos = new List<SerializableMenuItem>();
        BindingList<SerializableMenuItem> elementosComboBox = new BindingList<SerializableMenuItem>();

        public Principal()
        {
            InitializeComponent();
            Posicionarventana();
            CargarElementos();
        }

        public Principal(bool editar)
        {
            InitializeComponent();
            Posicionarventana();
            CargarElementos();
            CargarBindingList();
            
            cmbElementos.DataSource = elementosComboBox;
            cmbElementos.DisplayMember = nameof(SerializableMenuItem.titulo);
            if (elementosComboBox.Count != 0) cmbElementos.SelectedItem = elementosComboBox.FirstOrDefault();
            cmbElementos.Visible = editar;
        }

        public Principal(cprMenuItem menuItem)
        {
            InitializeComponent();
            Posicionarventana();
            CargarElementos();

            txtNombre.Text = menuItem.titulo;
            rtxtPasta.Text = menuItem.copyPasta;
        }

        private void Posicionarventana()
        {
            int ejeX = MousePosition.X - this.Width;
            int ejeY = MousePosition.Y - this.Height;

            this.Location = new Point(ejeX, ejeY);
        }

        private void CargarElementos()
        {
            elementos = Utilidades.UtilidadesGenerales.CargarDocumento(elementos);        
        }

        private void CargarBindingList()
        {
            foreach (var elemento in elementos)
            {
                elementosComboBox.Add(elemento);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SerializableMenuItem elemento = new SerializableMenuItem();
            elemento.titulo = txtNombre.Text;
            elemento.copyPasta = rtxtPasta.Text;

            elementos.Add(elemento);

            Utilidades.UtilidadesGenerales.GuardarDocumento(elementos);
            this.Close();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.RefrescarNotifyIcon();
        }

        private void cmbElementos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
