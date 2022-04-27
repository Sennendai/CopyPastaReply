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
        #region· VARIABLES

        private int lastSelectedIndex = -1;
        bool editar;
        List<SerializableMenuItem> elementos = new List<SerializableMenuItem>();
        BindingList<SerializableMenuItem> elementosComboBox = new BindingList<SerializableMenuItem>();
        SerializableMenuItem actualElemento;

        #endregion

        #region· CONSTRUCTORES
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

            this.editar = editar;
        }

        #endregion

        #region· FUNCIONES
        private void Posicionarventana()
        {
            int ejeX = MousePosition.X - this.Width;
            int ejeY = MousePosition.Y - this.Height;

            this.Location = new Point(ejeX, ejeY);
        }

        private void CargarElementos()
        {
            elementos = new List<SerializableMenuItem>();
            elementos = Utilidades.UtilidadesGenerales.CargarDocumento(elementos);
        }

        private void CargarBindingList()
        {
            elementosComboBox = new BindingList<SerializableMenuItem>();
            foreach (var elemento in elementos)
            {
                elementosComboBox.Add(elemento);
            }

            ActualizarComboElemento();

            if (elementosComboBox.Count != 0)
            {
                cmbElementos.SelectedItem = elementosComboBox.FirstOrDefault();
            }
            cmbElementos.Visible = true;
            btnBorrar.Visible = true;
        }

        private bool ComprobrarNombre()
        {
            foreach (var elemento in elementos)
            {
                if (elemento.titulo == actualElemento?.titulo || elemento.titulo == txtNombre.Text)
                    return false;
            }

            return true;
        }

        private void BorrarElemento()
        {
            SerializableMenuItem elementoABorrar = new SerializableMenuItem();
            foreach (var elemento in elementos)
            {
                if (elemento.Identifier == actualElemento.Identifier)
                {
                    elementoABorrar = elemento;
                }
            }

            if (elementoABorrar.Identifier != null) elementos.Remove(elementoABorrar);

            Utilidades.UtilidadesGenerales.GuardarDocumento(elementos);
            CargarElementos();
            CargarBindingList();
        }

        private void ActualizarComboElemento()
        {
            cmbElementos.DataSource = null;
            cmbElementos.DisplayMember = nameof(SerializableMenuItem.titulo);
            cmbElementos.DataSource = elementosComboBox;
        }

        #endregion

        #region· EVENTOS
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!editar && ComprobrarNombre())
            {
                Guid guid = Guid.NewGuid();
                SerializableMenuItem elemento = new SerializableMenuItem(guid);
                elemento.titulo = txtNombre.Text;
                elemento.copyPasta = rtxtPasta.Text;

                elementos.Add(elemento);
            }
            else
            {
                if (elementos.Count() != 0)
                {
                    SerializableMenuItem elementoModificado = elementos.Where(x => x.Identifier == actualElemento?.Identifier).FirstOrDefault();
                    if (elementoModificado != null)
                    {
                        elementoModificado.titulo = txtNombre.Text;
                        elementoModificado.copyPasta = rtxtPasta.Text;
                    }
                }
            }

            Utilidades.UtilidadesGenerales.GuardarDocumento(elementos);
            //this.Close();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.RefrescarNotifyIcon();
        }

        private void cmbElementos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbElementos.SelectedIndex != lastSelectedIndex && cmbElementos.SelectedItem != null)
            {
                lastSelectedIndex = cmbElementos.SelectedIndex;
                actualElemento = (SerializableMenuItem)cmbElementos.SelectedItem;
                txtNombre.Text = actualElemento.titulo;
                rtxtPasta.Text = actualElemento.copyPasta;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (elementos.Count() != 0) BorrarElemento();
        }

        #endregion

    }
}
