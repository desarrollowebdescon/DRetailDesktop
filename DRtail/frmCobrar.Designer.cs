namespace DRtail
{
    partial class frmCobrar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCobro = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btnEfectivo = new System.Windows.Forms.Button();
            this.btnCredito = new System.Windows.Forms.Button();
            this.btnTarjetaCred = new System.Windows.Forms.Button();
            this.btnDebito = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numUpDwPago = new System.Windows.Forms.NumericUpDown();
            this.lblCambio = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwPago)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(691, 32);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Cobrar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total a Cobrar:";
            // 
            // lblCobro
            // 
            this.lblCobro.AutoSize = true;
            this.lblCobro.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCobro.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCobro.Location = new System.Drawing.Point(208, 91);
            this.lblCobro.Name = "lblCobro";
            this.lblCobro.Size = new System.Drawing.Size(28, 31);
            this.lblCobro.TabIndex = 2;
            this.lblCobro.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnFacturar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnCobrar);
            this.panel1.Location = new System.Drawing.Point(491, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 412);
            this.panel1.TabIndex = 3;
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(13, 337);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(175, 62);
            this.btnFacturar.TabIndex = 14;
            this.btnFacturar.Text = "Facturar Nota";
            this.btnFacturar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(13, 91);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(175, 62);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCobrar
            // 
            this.btnCobrar.Location = new System.Drawing.Point(13, 12);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(175, 62);
            this.btnCobrar.TabIndex = 12;
            this.btnCobrar.Text = "F1 - Cobrar e Imprimir Ticket";
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // btnEfectivo
            // 
            this.btnEfectivo.Location = new System.Drawing.Point(12, 144);
            this.btnEfectivo.Name = "btnEfectivo";
            this.btnEfectivo.Size = new System.Drawing.Size(95, 34);
            this.btnEfectivo.TabIndex = 4;
            this.btnEfectivo.Text = "Efectivo";
            this.btnEfectivo.UseVisualStyleBackColor = true;
            // 
            // btnCredito
            // 
            this.btnCredito.Location = new System.Drawing.Point(113, 144);
            this.btnCredito.Name = "btnCredito";
            this.btnCredito.Size = new System.Drawing.Size(95, 34);
            this.btnCredito.TabIndex = 5;
            this.btnCredito.Text = "Crédito";
            this.btnCredito.UseVisualStyleBackColor = true;
            this.btnCredito.Click += new System.EventHandler(this.btnCredito_Click);
            // 
            // btnTarjetaCred
            // 
            this.btnTarjetaCred.Location = new System.Drawing.Point(214, 144);
            this.btnTarjetaCred.Name = "btnTarjetaCred";
            this.btnTarjetaCred.Size = new System.Drawing.Size(170, 34);
            this.btnTarjetaCred.TabIndex = 6;
            this.btnTarjetaCred.Text = "Tarjeta de Crédito";
            this.btnTarjetaCred.UseVisualStyleBackColor = true;
            // 
            // btnDebito
            // 
            this.btnDebito.Location = new System.Drawing.Point(390, 144);
            this.btnDebito.Name = "btnDebito";
            this.btnDebito.Size = new System.Drawing.Size(95, 34);
            this.btnDebito.TabIndex = 7;
            this.btnDebito.Text = "Débito";
            this.btnDebito.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Pagó con:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Su cambio:";
            // 
            // numUpDwPago
            // 
            this.numUpDwPago.DecimalPlaces = 2;
            this.numUpDwPago.Location = new System.Drawing.Point(130, 254);
            this.numUpDwPago.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.numUpDwPago.Name = "numUpDwPago";
            this.numUpDwPago.Size = new System.Drawing.Size(120, 32);
            this.numUpDwPago.TabIndex = 10;
            this.numUpDwPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDwPago.ValueChanged += new System.EventHandler(this.numUpDwPago_ValueChanged);
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambio.ForeColor = System.Drawing.Color.Green;
            this.lblCambio.Location = new System.Drawing.Point(169, 337);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(28, 31);
            this.lblCambio.TabIndex = 11;
            this.lblCambio.Text = "0";
            // 
            // frmCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(691, 412);
            this.Controls.Add(this.lblCambio);
            this.Controls.Add(this.numUpDwPago);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDebito);
            this.Controls.Add(this.btnTarjetaCred);
            this.Controls.Add(this.btnCredito);
            this.Controls.Add(this.btnEfectivo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblCobro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCobrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DRetail - Venta de productos - Cobrar";
            this.Load += new System.EventHandler(this.frmCobrar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCobrar_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmCobrar_KeyPress);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCobro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEfectivo;
        private System.Windows.Forms.Button btnCredito;
        private System.Windows.Forms.Button btnTarjetaCred;
        private System.Windows.Forms.Button btnDebito;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numUpDwPago;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Button btnFacturar;
    }
}