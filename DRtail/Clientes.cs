using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Bunifu.Framework.UI;

namespace DRtail
{
    public partial class Clientes : UserControl
    {
        #region "Variables"
        public List<DatosSocios> dtosSocios;
        public int ordenDGV = 0;
        public string codClienteSelec = "";
        DataTable dtSocios = new DataTable();
        #endregion
        public Clientes()
        {
            InitializeComponent();
            //this.Dock = DockStyle.Fill;
            
            ClosePanel();
            GetData();


        }

       

        private void GetData()
        {
            dtosSocios = Servicios.getSocios();

            SetDataSocios(dtosSocios);

        }

        private void SetDataSocios(List<DatosSocios> dtosSocios)
        {
            bfgSocios.Rows.Clear();
            foreach (DatosSocios ds in dtosSocios)
            {
                bfgSocios.Rows.Add(ds.CodigoCliente, ds.NombreCliente, ds.RFC, ds.Telefono, ds.Email, "...", "...", "...");
            }
        }



        private void btnProspectos_Click(object sender, EventArgs e)
        {

        }



        private void btnCreaCrearCliente_Click(object sender, EventArgs e)
        {
            if (CrearSocio())
            {
                txtCrearCodCli.ResetText();
                txtCrearNombreCli.ResetText();
                txtCreaDirCli.ResetText();
                txtCreaCPCli.ResetText();
                txtCreaTelCli.ResetText();
                txtCreaRFCCli.ResetText();
                txtCreaCelCli.ResetText();
                txtCreaCiudadCli.ResetText();
                txtCreaEmailCli.ResetText();
                txtCreaCalleCli.ResetText();
                txtCrearCodCli.Focus();
            }
        }

        public Boolean CrearSocio()
        {
            Boolean generado = false;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.RutaApi + "crearSocio");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = JsonConvert.SerializeObject(new
                    {
                        Codigo = txtCrearCodCli.Text,
                        Nombre = txtCrearNombreCli.Text,
                        Tipo = "C",
                        ListaPrecios = "1",
                        Direccion = txtCreaDirCli.Text,
                        CodigoPostal = txtCreaCPCli.Text,
                        Telefono = txtCreaTelCli.Text,
                        RFC = txtCreaRFCCli.Text,
                        Celular = txtCreaCelCli.Text,
                        Ciudad = txtCreaCiudadCli.Text,
                        Email = txtCreaEmailCli.Text,
                        Calle = txtCreaCalleCli.Text
                    });
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var j = JsonConvert.DeserializeObject<RespuestaAPI>(result);
                    MessageBox.Show(j.Message);
                    if (j.Error == "false")
                        generado = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Crear Socios:" + ex.Message);
            }
            return generado;
        }
        


        private void btnBuscar_Click(object sender, EventArgs e)
        {

            List<DatosSocios> temp = dtosSocios.Where(s => (s.CodigoCliente.ToLower().Contains(txtBuscar.Text.ToLower())
                                                            || s.NombreCliente.ToLower().Contains(txtBuscar.Text.ToLower())
                                                            || s.RFC.ToLower().Contains(txtBuscar.Text.ToLower()))
                                                            ).ToList();
            SetDataSocios(temp);

        }

        private void btnCreaCrearCliente_Click(object sender, EventArgs e)
        {

            if(btnCreaCrearCliente.Text == "Actualizar")
            {
                MessageBox.Show("Se ha actualizado correctamente el usuario correctamente");
            }
            else
            {
                if (CrearSocio())
                {
                    MessageBox.Show("Se ha creado el usuario correctamente");
                }
                else
                {
                    MessageBox.Show("Se hubo un error al crear usuario");
                }               
            }

            LimpiarForm();
            btnCreaCrearCliente.Text = "Crear Cliente";
            controlTabClientes.SelectedIndex = 0;

        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            List<DatosSocios> temp = dtosSocios.Where(s => (s.CodigoCliente.ToLower().Contains(txtBuscar.Text.ToLower())
                                                           || s.NombreCliente.ToLower().Contains(txtBuscar.Text.ToLower())
                                                           || s.RFC.ToLower().Contains(txtBuscar.Text.ToLower()))
                                                           ).ToList();
            SetDataSocios(temp);
        }

        #region "Acciones tabs Detalle"
        private void btnTabDatosGEnerales_Click(object sender, EventArgs e)
        {
            if (!pnlPestañaBodyDG.Visible)
            {
                OpenPanel(pnlPestañaDG, pnlPestañaBodyDG);
            }

        }
        private void btnPestañaDC_Click(object sender, EventArgs e)
        {
            if (!pnlPestañaBodyDC.Visible)
            {
                OpenPanel(pnlPestañaDC, pnlPestañaBodyDC);
            }
        }

        private void btnPestañaDirs_Click(object sender, EventArgs e)
        {
            if (!pnlPestañaBodyDirs.Visible)
            {
                OpenPanel(pnlPestañaDirecciones, pnlPestañaBodyDirs);
            }
        }
        private void OpenPanel(Panel tabPanel, Panel bodyTab)
        {
            ClosePanel();
            BunifuFlatButton buttonTab = (BunifuFlatButton)tabPanel.Controls[0];
            Panel lineTab = (Panel)tabPanel.Controls[1];
            lineTab.Visible = true;
            bodyTab.Visible = true;
        }


        private void ClosePanel()
        {
            pnlPestañaBodyDC.Visible = false;
            pnlPestañaBodyDG.Visible = false;
            pnlPestañaBodyDirs.Visible = false;
            pnltabLineDG.Visible = false;
            pnlTabLineDC.Visible = false;
            pnlTabLineDirs.Visible = false;
        }


        #endregion

        private void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            pnlDir_1.Visible = true;
        }

        private void bfgSocios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 5)
            {
                BunifuCustomDataGrid bdg = (BunifuCustomDataGrid)sender;
                string headerName = bdg.SelectedCells[0].Value + "-" + bdg.SelectedCells[1].Value;
                lblAccionesHeadpnl.Text = headerName;
                Point xy = bdg.SelectedCells[5].AccessibilityObject.Bounds.Location;
                pnlAcciones.Location = new Point((xy.X - 725),(xy.Y - 150));
                pnlAcciones.Visible = true;
                pnlAcciones.BringToFront();
                
                   
            }
        }

        private void btnAccionesEditar_Click(object sender, EventArgs e)
        {
            pnlAcciones.Visible = false;
            tabDetalle.Text = "EDITAR";
            controlTabClientes.SelectedIndex = 1;
            DataGridViewRow dg =  bfgSocios.SelectedRows[0];
            Editar(dg);
            btnCreaCrearCliente.Text = "Actualizar";
            OpenPanel(pnlPestañaDG, pnlPestañaBodyDG);
        }

        private void Editar(DataGridViewRow row)
        {

            txtCrearCodCli.Text         = row.Cells[0].Value.ToString();
            txtCrearNombreCli.Text      = row.Cells[1].Value.ToString();
            txtCreaRFCCli.Text          = row.Cells[2].Value.ToString();
            txtCreaTelCli.Text         = row.Cells[3].Value.ToString();
            txtCreaEmailCli.Text         = row.Cells[4].Value.ToString();


        }
        private void LimpiarForm()
        {
            tabDetalle.Text = "NUEVO";
            txtCrearCodCli.Text     = "";
            txtCrearNombreCli.Text  = "";
            txtCreaRFCCli.Text      = "";
            txtCreaTelCli.Text      = "";
            txtCreaEmailCli.Text    = "";
            btnCreaCrearCliente.Text = "Crear Cliente";
        }

        private void controlTabClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(controlTabClientes.SelectedIndex == 1)
            {
                OpenPanel(pnlPestañaDG, pnlPestañaBodyDG);
            }

            if(tabDetalle.Text == "EDITAR" && controlTabClientes.SelectedIndex == 0)
            {
                
                if (MessageBox.Show("Desea salir de la edición?", "Editando...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                {
                    
                    LimpiarForm();
                }
                else
                {
                    controlTabClientes.SelectedIndex = 1;
                }
                    
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlAcciones.Visible = false; 
        }

        private void btnAccionCCoti_Click(object sender, EventArgs e)
        {
            frmMenuLateral ml = (frmMenuLateral)this.ParentForm;
            ml.SelectedLineMenu("pnlLineCotizaciones");
            DatosCotizacion dc = new DatosCotizacion();
            dc.Cliente = bfgSocios.SelectedRows[0].Cells[0].Value.ToString();
            Cotizaciones cot = new Cotizaciones(dc);
            
            foreach (Control c in ml.Controls)
            {
                if (c.Name == "pnlMain")
                {
                    c.Controls.Clear();

                    c.Controls.Add(cot);
                }
            }
        }

        private void btnAccionCPedido_Click(object sender, EventArgs e)
        {
            frmMenuLateral ml = (frmMenuLateral)this.ParentForm;
            ml.SelectedLineMenu("pnlLinePedidos");
            DatosCotizacion dc = new DatosCotizacion();
            dc.Cliente = bfgSocios.SelectedRows[0].Cells[0].Value.ToString();
            Pedidos cot = new Pedidos(dc);

            foreach (Control c in ml.Controls)
            {
                if (c.Name == "pnlMain")
                {
                    c.Controls.Clear();

                    c.Controls.Add(cot);
                }
            }
        }
        private void bfgSocios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                //MessageBox.Show(bfgSocios.Rows[bfgSocios.CurrentRow.Index].Cells[0].Value.ToString());
                Servicios.menuLateral.pnlMain.Controls.Clear();
                Servicios.menuLateral.pnlMain.Controls.Add(new Cotizaciones(bfgSocios.Rows[bfgSocios.CurrentRow.Index].Cells[0].Value.ToString()));
                Servicios.menuLateral.SelectedLineMenu();
                Servicios.menuLateral.pnlLineCotizaciones.Visible = true;
                Servicios.menuLateral.LblTitle.Text = "COTIZACIONES";
            }
            if (e.ColumnIndex == 6)
            {
                //MessageBox.Show(bfgSocios.Rows[bfgSocios.CurrentRow.Index].Cells[0].Value.ToString());
                Servicios.menuLateral.pnlMain.Controls.Clear();
                Servicios.menuLateral.pnlMain.Controls.Add(new Pedidos(bfgSocios.Rows[bfgSocios.CurrentRow.Index].Cells[0].Value.ToString(), "", ""));
                Servicios.menuLateral.SelectedLineMenu();
                Servicios.menuLateral.pnlLinePedidos.Visible = true;
                Servicios.menuLateral.LblTitle.Text = "PEDIDOS";

            }
        }

    }
}
