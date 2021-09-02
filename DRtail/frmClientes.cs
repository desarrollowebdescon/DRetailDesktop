using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace DRtail
{
    public partial class frmClientes : Form
    {
        public frmClientes() 
        {
            InitializeComponent();
        }

        public frmMenu menu;
        public List<DatosSocios> dtosSocios;
        public int ordenDGV = 0;
        public string codClienteSelec = "";

        private void frmClientes_Load(object sender, EventArgs e)
        {
            ObtenerSocios();
            dgvClientes.DataSource = CrearDTSocios();
            dgvClientes.Sort(dgvClientes.Columns[0], ListSortDirection.Ascending);
            foreach (DataGridViewColumn col in dgvClientes.Columns)
            {
                col.HeaderText = dtSocios.Columns[col.HeaderText].Caption;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            codClienteSelec = dgvClientes.Rows[dgvClientes.CurrentRow.Index].Cells[0].Value.ToString();
            menu.codClienteSelec = codClienteSelec;
            //menu.txtCliente.Text = codClienteSelec;
            this.Dispose();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
         //   menu.MostrarPanel(menu.pnlClientes, menu.btnCrearCliente);
         //   menu.MostrarSubPanel(menu.pnlClientes, menu.pnlClientesCrea, menu.btnCrearCliente);
            this.Dispose();
        }

        DataTable dtSocios = new DataTable();

        DataTable CrearDTSocios()
        {

            DataColumn dtClmCodigo = new DataColumn();
            dtClmCodigo.ColumnName = "codCliente";
            dtClmCodigo.Caption = "Código Cliente";
            dtClmCodigo.ReadOnly = true;
            DataColumn dtClmNombre = new DataColumn();
            dtClmNombre.ColumnName = "nomCliente";
            dtClmNombre.Caption = "Nombre Cliente";
            dtClmNombre.ReadOnly = true;
            dtSocios.Columns.Add(dtClmCodigo);
            dtSocios.Columns.Add(dtClmNombre);

            try
            {
                foreach (DatosSocios s in dtosSocios)
                {
                    dtSocios.Rows.Add(s.CodigoCliente, s.NombreCliente);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error CrearDTSocios:" + ex.Message);
            }

            return dtSocios;
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (ordenDGV == 0)
                dtSocios.DefaultView.RowFilter = $"codCliente LIKE '{txtCliente.Text}%'";
            else if (ordenDGV == 1)
                dtSocios.DefaultView.RowFilter = $"nomCliente LIKE '{txtCliente.Text}%'";
        }

        private void dgvClientes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvClientes.SortedColumn == dgvClientes.Columns[0])
            {
                ordenDGV = 0;
            }
            else if (dgvClientes.SortedColumn == dgvClientes.Columns[1])
            {
                ordenDGV = 1;
            }
        }

        private void dgvClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codClienteSelec = dgvClientes.Rows[dgvClientes.CurrentRow.Index].Cells[0].Value.ToString();
            menu.codClienteSelec = codClienteSelec;
           // menu.txtCliente.Text = codClienteSelec;
            this.Dispose();
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codClienteSelec = dgvClientes.Rows[dgvClientes.CurrentRow.Index].Cells[0].Value.ToString();
            menu.codClienteSelec = codClienteSelec;
           // menu.txtCliente.Text = codClienteSelec;
            this.Dispose();
        }

        void ObtenerSocios()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["urlAPI"] +"/api/consultarAllSociosEsc");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                dtosSocios = JsonConvert.DeserializeObject<List<DatosSocios>>(json);
            }
        }
    }
}
