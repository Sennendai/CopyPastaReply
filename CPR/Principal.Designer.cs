namespace CPR
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.lbllTitulo = new System.Windows.Forms.Label();
            this.lblTexto = new System.Windows.Forms.Label();
            this.rtxtPasta = new System.Windows.Forms.RichTextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cmbElementos = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbllTitulo
            // 
            this.lbllTitulo.AutoSize = true;
            this.lbllTitulo.Location = new System.Drawing.Point(12, 51);
            this.lbllTitulo.Name = "lbllTitulo";
            this.lbllTitulo.Size = new System.Drawing.Size(44, 13);
            this.lbllTitulo.TabIndex = 1;
            this.lbllTitulo.Text = "Nombre";
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Location = new System.Drawing.Point(12, 74);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(34, 13);
            this.lblTexto.TabIndex = 3;
            this.lblTexto.Text = "Texto";
            // 
            // rtxtPasta
            // 
            this.rtxtPasta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtPasta.Location = new System.Drawing.Point(6, 90);
            this.rtxtPasta.Name = "rtxtPasta";
            this.rtxtPasta.Size = new System.Drawing.Size(326, 89);
            this.rtxtPasta.TabIndex = 4;
            this.rtxtPasta.Text = "";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(62, 48);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(270, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Image = global::CPR.Properties.Resources.disk_blue;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(6, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cmbElementos
            // 
            this.cmbElementos.FormattingEnabled = true;
            this.cmbElementos.Location = new System.Drawing.Point(100, 6);
            this.cmbElementos.Name = "cmbElementos";
            this.cmbElementos.Size = new System.Drawing.Size(232, 21);
            this.cmbElementos.TabIndex = 0;
            this.cmbElementos.Visible = false;
            this.cmbElementos.SelectedIndexChanged += new System.EventHandler(this.cmbElementos_SelectedIndexChanged);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 181);
            this.Controls.Add(this.cmbElementos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.rtxtPasta);
            this.Controls.Add(this.lblTexto);
            this.Controls.Add(this.lbllTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 220);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Añadir nuevo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbllTitulo;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.RichTextBox rtxtPasta;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cmbElementos;
    }
}

