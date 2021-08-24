namespace DRtail
{
    partial class Ventas
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlCotizacion = new System.Windows.Forms.Panel();
            this.lblCambioCot = new System.Windows.Forms.Label();
            this.lblPagoCot = new System.Windows.Forms.Label();
            this.lblTotalCobCot = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProductosTotal = new System.Windows.Forms.Label();
            this.lblTotalProd = new System.Windows.Forms.Label();
            this.btnCobrarCotizacion = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnCobradoCotizaciones = new System.Windows.Forms.Button();
            this.btnGenerarCotizacion = new System.Windows.Forms.Button();
            this.dgvProductosCotizacion = new System.Windows.Forms.DataGridView();
            this.codBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.existencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBorrarProd = new System.Windows.Forms.Button();
            this.btnSalidasProd = new System.Windows.Forms.Button();
            this.btnEntradasProd = new System.Windows.Forms.Button();
            this.btnBuscarProd = new System.Windows.Forms.Button();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkLblBuscarCliente = new System.Windows.Forms.LinkLabel();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCotizacion.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosCotizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCotizacion
            // 
            this.pnlCotizacion.AutoScroll = true;
            this.pnlCotizacion.Controls.Add(this.lblCambioCot);
            this.pnlCotizacion.Controls.Add(this.lblPagoCot);
            this.pnlCotizacion.Controls.Add(this.lblTotalCobCot);
            this.pnlCotizacion.Controls.Add(this.panel1);
            this.pnlCotizacion.Controls.Add(this.btnCobradoCotizaciones);
            this.pnlCotizacion.Controls.Add(this.btnGenerarCotizacion);
            this.pnlCotizacion.Controls.Add(this.dgvProductosCotizacion);
            this.pnlCotizacion.Controls.Add(this.btnBorrarProd);
            this.pnlCotizacion.Controls.Add(this.btnSalidasProd);
            this.pnlCotizacion.Controls.Add(this.btnEntradasProd);
            this.pnlCotizacion.Controls.Add(this.btnBuscarProd);
            this.pnlCotizacion.Controls.Add(this.btnAgregarProducto);
            this.pnlCotizacion.Controls.Add(this.txtProducto);
            this.pnlCotizacion.Controls.Add(this.label2);
            this.pnlCotizacion.Controls.Add(this.lnkLblBuscarCliente);
            this.pnlCotizacion.Controls.Add(this.txtCliente);
            this.pnlCotizacion.Controls.Add(this.label1);
            this.pnlCotizacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCotizacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCotizacion.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCotizacion.Location = new System.Drawing.Point(0, 0);
            this.pnlCotizacion.Name = "pnlCotizacion";
            this.pnlCotizacion.Size = new System.Drawing.Size(1348, 880);
            this.pnlCotizacion.TabIndex = 14;
            // 
            // lblCambioCot
            // 
            this.lblCambioCot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCambioCot.AutoSize = true;
            this.lblCambioCot.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambioCot.Location = new System.Drawing.Point(240, 806);
            this.lblCambioCot.Name = "lblCambioCot";
            this.lblCambioCot.Size = new System.Drawing.Size(93, 27);
            this.lblCambioCot.TabIndex = 21;
            this.lblCambioCot.Text = "Cambio:";
            // 
            // lblPagoCot
            // 
            this.lblPagoCot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPagoCot.AutoSize = true;
            this.lblPagoCot.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagoCot.Location = new System.Drawing.Point(135, 808);
            this.lblPagoCot.Name = "lblPagoCot";
            this.lblPagoCot.Size = new System.Drawing.Size(66, 27);
            this.lblPagoCot.TabIndex = 20;
            this.lblPagoCot.Text = "Pagó:";
            // 
            // lblTotalCobCot
            // 
            this.lblTotalCobCot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalCobCot.AutoSize = true;
            this.lblTotalCobCot.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCobCot.Location = new System.Drawing.Point(11, 806);
            this.lblTotalCobCot.Name = "lblTotalCobCot";
            this.lblTotalCobCot.Size = new System.Drawing.Size(66, 27);
            this.lblTotalCobCot.TabIndex = 19;
            this.lblTotalCobCot.Text = "Total:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblProductosTotal);
            this.panel1.Controls.Add(this.lblTotalProd);
            this.panel1.Controls.Add(this.btnCobrarCotizacion);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Location = new System.Drawing.Point(8, 710);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1327, 75);
            this.panel1.TabIndex = 18;
            // 
            // lblProductosTotal
            // 
            this.lblProductosTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProductosTotal.AutoSize = true;
            this.lblProductosTotal.Location = new System.Drawing.Point(21, 35);
            this.lblProductosTotal.Name = "lblProductosTotal";
            this.lblProductosTotal.Size = new System.Drawing.Size(376, 31);
            this.lblProductosTotal.TabIndex = 12;
            this.lblProductosTotal.Text = "Productos en la cotización actual";
            // 
            // lblTotalProd
            // 
            this.lblTotalProd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalProd.AutoSize = true;
            this.lblTotalProd.Location = new System.Drawing.Point(1, 35);
            this.lblTotalProd.Name = "lblTotalProd";
            this.lblTotalProd.Size = new System.Drawing.Size(28, 31);
            this.lblTotalProd.TabIndex = 14;
            this.lblTotalProd.Text = "0";
            // 
            // btnCobrarCotizacion
            // 
            this.btnCobrarCotizacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCobrarCotizacion.BackColor = System.Drawing.Color.White;
            this.btnCobrarCotizacion.Location = new System.Drawing.Point(785, 21);
            this.btnCobrarCotizacion.Name = "btnCobrarCotizacion";
            this.btnCobrarCotizacion.Size = new System.Drawing.Size(211, 42);
            this.btnCobrarCotizacion.TabIndex = 16;
            this.btnCobrarCotizacion.Text = "F12- Cobrar";
            this.btnCobrarCotizacion.UseVisualStyleBackColor = false;
            this.btnCobrarCotizacion.Visible = false;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(1032, 21);
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(290, 49);
            this.txtTotal.TabIndex = 13;
            this.txtTotal.Text = "0.0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCobradoCotizaciones
            // 
            this.btnCobradoCotizaciones.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCobradoCotizaciones.BackColor = System.Drawing.Color.White;
            this.btnCobradoCotizaciones.Location = new System.Drawing.Point(415, 801);
            this.btnCobradoCotizaciones.Name = "btnCobradoCotizaciones";
            this.btnCobradoCotizaciones.Size = new System.Drawing.Size(123, 34);
            this.btnCobradoCotizaciones.TabIndex = 17;
            this.btnCobradoCotizaciones.Text = "Cobrado";
            this.btnCobradoCotizaciones.UseVisualStyleBackColor = false;
            this.btnCobradoCotizaciones.Visible = false;
            // 
            // btnGenerarCotizacion
            // 
            this.btnGenerarCotizacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGenerarCotizacion.BackColor = System.Drawing.Color.White;
            this.btnGenerarCotizacion.Location = new System.Drawing.Point(794, 801);
            this.btnGenerarCotizacion.Name = "btnGenerarCotizacion";
            this.btnGenerarCotizacion.Size = new System.Drawing.Size(211, 34);
            this.btnGenerarCotizacion.TabIndex = 15;
            this.btnGenerarCotizacion.Text = "Generar Cotización";
            this.btnGenerarCotizacion.UseVisualStyleBackColor = false;
            // 
            // dgvProductosCotizacion
            // 
            this.dgvProductosCotizacion.AllowUserToAddRows = false;
            this.dgvProductosCotizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductosCotizacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductosCotizacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductosCotizacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProductosCotizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosCotizacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codBarras,
            this.descProducto,
            this.precioVenta,
            this.cantidad,
            this.importe,
            this.existencia});
            this.dgvProductosCotizacion.Location = new System.Drawing.Point(8, 161);
            this.dgvProductosCotizacion.Name = "dgvProductosCotizacion";
            this.dgvProductosCotizacion.ReadOnly = true;
            this.dgvProductosCotizacion.RowHeadersVisible = false;
            this.dgvProductosCotizacion.RowHeadersWidth = 51;
            this.dgvProductosCotizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductosCotizacion.Size = new System.Drawing.Size(1321, 543);
            this.dgvProductosCotizacion.TabIndex = 11;
            // 
            // codBarras
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codBarras.DefaultCellStyle = dataGridViewCellStyle1;
            this.codBarras.HeaderText = "Código de Barras";
            this.codBarras.MinimumWidth = 6;
            this.codBarras.Name = "codBarras";
            this.codBarras.ReadOnly = true;
            // 
            // descProducto
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descProducto.DefaultCellStyle = dataGridViewCellStyle2;
            this.descProducto.HeaderText = "Descripción del Producto";
            this.descProducto.MinimumWidth = 6;
            this.descProducto.Name = "descProducto";
            this.descProducto.ReadOnly = true;
            // 
            // precioVenta
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precioVenta.DefaultCellStyle = dataGridViewCellStyle3;
            this.precioVenta.HeaderText = "Precio V.";
            this.precioVenta.MinimumWidth = 6;
            this.precioVenta.Name = "precioVenta";
            this.precioVenta.ReadOnly = true;
            // 
            // cantidad
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle4;
            this.cantidad.HeaderText = "Cantidad V.";
            this.cantidad.MinimumWidth = 6;
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // importe
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importe.DefaultCellStyle = dataGridViewCellStyle5;
            this.importe.HeaderText = "Importe";
            this.importe.MinimumWidth = 6;
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
            // 
            // existencia
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.existencia.DefaultCellStyle = dataGridViewCellStyle6;
            this.existencia.HeaderText = "Existencia";
            this.existencia.MinimumWidth = 6;
            this.existencia.Name = "existencia";
            this.existencia.ReadOnly = true;
            // 
            // btnBorrarProd
            // 
            this.btnBorrarProd.BackColor = System.Drawing.Color.White;
            this.btnBorrarProd.Location = new System.Drawing.Point(752, 113);
            this.btnBorrarProd.Name = "btnBorrarProd";
            this.btnBorrarProd.Size = new System.Drawing.Size(240, 42);
            this.btnBorrarProd.TabIndex = 10;
            this.btnBorrarProd.Text = "DEL - Borra Art.";
            this.btnBorrarProd.UseVisualStyleBackColor = false;
            // 
            // btnSalidasProd
            // 
            this.btnSalidasProd.BackColor = System.Drawing.Color.White;
            this.btnSalidasProd.Location = new System.Drawing.Point(506, 113);
            this.btnSalidasProd.Name = "btnSalidasProd";
            this.btnSalidasProd.Size = new System.Drawing.Size(240, 42);
            this.btnSalidasProd.TabIndex = 9;
            this.btnSalidasProd.Text = "F8 - Salidas";
            this.btnSalidasProd.UseVisualStyleBackColor = false;
            // 
            // btnEntradasProd
            // 
            this.btnEntradasProd.BackColor = System.Drawing.Color.White;
            this.btnEntradasProd.Location = new System.Drawing.Point(260, 113);
            this.btnEntradasProd.Name = "btnEntradasProd";
            this.btnEntradasProd.Size = new System.Drawing.Size(240, 42);
            this.btnEntradasProd.TabIndex = 8;
            this.btnEntradasProd.Text = "F7 - Entradas";
            this.btnEntradasProd.UseVisualStyleBackColor = false;
            // 
            // btnBuscarProd
            // 
            this.btnBuscarProd.BackColor = System.Drawing.Color.White;
            this.btnBuscarProd.Location = new System.Drawing.Point(14, 113);
            this.btnBuscarProd.Name = "btnBuscarProd";
            this.btnBuscarProd.Size = new System.Drawing.Size(240, 42);
            this.btnBuscarProd.TabIndex = 7;
            this.btnBuscarProd.Text = "F10 - Buscar";
            this.btnBuscarProd.UseVisualStyleBackColor = false;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(490, 56);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(240, 42);
            this.btnAgregarProducto.TabIndex = 6;
            this.btnAgregarProducto.Text = "Enter - Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(260, 56);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(221, 38);
            this.txtProducto.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Código del producto:";
            // 
            // lnkLblBuscarCliente
            // 
            this.lnkLblBuscarCliente.AutoSize = true;
            this.lnkLblBuscarCliente.Location = new System.Drawing.Point(484, 9);
            this.lnkLblBuscarCliente.Name = "lnkLblBuscarCliente";
            this.lnkLblBuscarCliente.Size = new System.Drawing.Size(175, 31);
            this.lnkLblBuscarCliente.TabIndex = 3;
            this.lnkLblBuscarCliente.TabStop = true;
            this.lnkLblBuscarCliente.Text = "Buscar Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(260, 9);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(221, 38);
            this.txtCliente.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente:";
            // 
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCotizacion);
            this.Name = "Ventas";
            this.Size = new System.Drawing.Size(1348, 880);
            this.pnlCotizacion.ResumeLayout(false);
            this.pnlCotizacion.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosCotizacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlCotizacion;
        private System.Windows.Forms.Label lblCambioCot;
        private System.Windows.Forms.Label lblPagoCot;
        private System.Windows.Forms.Label lblTotalCobCot;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblProductosTotal;
        private System.Windows.Forms.Label lblTotalProd;
        private System.Windows.Forms.Button btnCobrarCotizacion;
        private System.Windows.Forms.TextBox txtTotal;
        public System.Windows.Forms.Button btnCobradoCotizaciones;
        private System.Windows.Forms.Button btnGenerarCotizacion;
        private System.Windows.Forms.DataGridView dgvProductosCotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn codBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn descProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn existencia;
        private System.Windows.Forms.Button btnBorrarProd;
        private System.Windows.Forms.Button btnSalidasProd;
        private System.Windows.Forms.Button btnEntradasProd;
        private System.Windows.Forms.Button btnBuscarProd;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkLblBuscarCliente;
        public System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label1;
    }
}
