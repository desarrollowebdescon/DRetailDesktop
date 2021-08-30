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

namespace DRtail
{
    public partial class Cotizaciones : UserControl
    {
        #region "Variables"
        public List<DatosSocios> dtosSocios;
        List<DatosArticulos> items;
        List<DatosCotizacion> cotizacionesList;
        public int ordenDGV = 0;
        public string codClienteSelec = "";
        DataTable dtSocios = new DataTable();
        int numArticulos = 0;
        double importeTotal = 0;
        string tempDescuento = "";
        string tempDescuentoOld = "";
        #endregion
        public Cotizaciones(string impCliente)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            GetData();
            AutoCompletar(txtProducto, "DatosArticulos");
            AutoCompletar(txtCliente, "DatosSocios");


            if (impCliente == "")
            {
                tabControlCotizaciones.SelectedIndex = 0;
            }
            else
            {
                tabControlCotizaciones.SelectedIndex = 1;
                txtCliente.Text = impCliente;
            }
        }


        private void GetData()
        {
            try
            {
                dtosSocios = Servicios.getSocios();
                items = Servicios.GetArticulos();
                cotizacionesList = Servicios.getCotizaciones();
                int i = 0;
                foreach (DatosCotizacion dc in cotizacionesList)
                {                    
                    bdgCotizaciones.Rows.Add(dc.docentryCotizacion,dc.NoCotizacion, dc.Cliente, dc.Nombre, dc.FechaDocumento.ToString("yyyy-MM-dd"), double.Parse(dc.Total).ToString("N2"), dc.Moneda, dc.Estatus, "...");
                    i++;
                }

            }
            catch (Exception ex)
            {

            }
        }

        void AutoCompletar(TextBox txtAutoCmpletar, string clase)
        {
            txtAutoCmpletar.AutoCompleteCustomSource = LoadAutoComplete(clase);
            txtAutoCmpletar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtAutoCmpletar.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        public AutoCompleteStringCollection LoadAutoComplete(string clase)
        {
            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            if (clase == "DatosArticulos")
            {
                foreach (DatosArticulos i in items)
                {
                    stringCol.Add(i.Codigo);
                }
            }
            else if (clase == "DatosSocios")
            {
                foreach (DatosSocios s in dtosSocios)
                {
                    stringCol.Add(s.CodigoCliente);
                }
            }
            return stringCol;
        }

        private void btnBuscarCot_Click(object sender, EventArgs e)
        {
            List<DatosCotizacion> dcTemp = new List<DatosCotizacion>();
            bdgCotizaciones.Rows.Clear();

            dcTemp = cotizacionesList;
            dcTemp = dcTemp.Where(dc => (dc.FechaDocumento >= bdpInicio.Value && dc.FechaDocumento <= bdpFin.Value)).ToList();

            if (txtBuscar.Text != "")
            {
                dcTemp = dcTemp.Where(dc => (dc.NoCotizacion == txtBuscar.Text || dc.Cliente == txtBuscar.Text)).ToList();
            }

            if (bddEstatus.selectedIndex > 0)
            {
                dcTemp = dcTemp.Where(dc => dc.Estatus == bddEstatus.selectedValue).ToList();
            }

            foreach (DatosCotizacion dc in dcTemp)
            {
                bdgCotizaciones.Rows.Add(dc.NoCotizacion, dc.Cliente, dc.Nombre, dc.FechaDocumento.ToString("yyyy-MM-dd"), double.Parse(dc.Total).ToString("N2"), dc.Moneda, dc.Estatus, "...");

            }


        }

        private void lnkLblBuscarCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (DatosSocios da in dtosSocios)
            {
                dgBuscarClientes.Rows.Add(da.CodigoCliente, da.NombreCliente);
            }
            pnlBuscarSocio.Visible = true;
            pnlBuscarSocio.BringToFront();

        }



        void AgregarArticuloDGV()
        {
            int valid = 0;
            foreach (DatosArticulos i in items)
            {
                if (txtProducto.Text == i.Codigo)
                {
                    if (dgvProductosCotizacion.RowCount > 0)
                    {
                        int rep = 0;
                        foreach (DataGridViewRow r in dgvProductosCotizacion.Rows)
                        {
                            if (r.Cells[0].Value.ToString() == txtProducto.Text)
                            {
                                r.Cells[5].Value = (int.Parse(r.Cells[5].Value.ToString()) + 1).ToString();
                                valid = 1;
                                rep = 1;
                                importeTotal = importeTotal + double.Parse(r.Cells[2].Value.ToString());
                                txtProducto.ResetText();
                                txtProducto.Focus();
                                break;
                            }
                        }

                        if (rep == 0)
                        {

                            dgvProductosCotizacion.Rows.Add(i.Codigo, i.Descripcion, i.Costo, "IVA", 0.0, 1, (i.Costo * 0.16), i.Costo, 0, (i.Costo * 0.16), i.TotalStock);
                            numArticulos++;
                            valid = 1;
                            rep = 0;
                            importeTotal = importeTotal + i.Costo;
                            txtProducto.ResetText();
                            txtProducto.Focus();
                            break;
                        }


                    }
                    else
                    {
                        dgvProductosCotizacion.Rows.Add(i.Codigo, i.Descripcion, i.Costo, "IVA", 0.0, 1, (i.Costo * 0.16), i.Costo, 0, (i.Costo * 0.16), i.TotalStock);

                        numArticulos++;
                        valid = 1;
                        importeTotal = importeTotal + i.Costo;
                        txtProducto.ResetText();
                        txtProducto.Focus();
                        break;
                    }

                    valid = 1;
                    txtProducto.ResetText();
                    txtProducto.Focus();
                    break;
                }
            }
            if (valid == 0)
            {
                MessageBox.Show("Artículo no encontrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valid = 0;
            }
            lblTotalProd.Text = numArticulos.ToString();
            txtTotal.Text = importeTotal.ToString("C");
        }

        private void btnCobrarCotizacion_Click(object sender, EventArgs e)
        {
            frmCobrar cobrar = new frmCobrar();
            //cobrar.menu2 = this;
            cobrar.totalVenta = importeTotal;
            cobrar.ShowDialog();
        }

        private void btnBorrarProd_Click(object sender, EventArgs e)
        {
            if(dgvProductosCotizacion.Rows.Count > 0)
            {
                EliminarProducto();
            }            
        }
        void EliminarProducto()
        {
            dgvProductosCotizacion.Rows.Remove(dgvProductosCotizacion.Rows[dgvProductosCotizacion.CurrentRow.Index]);
            numArticulos--;
            lblTotalProd.Text = numArticulos.ToString();
        }

        private void btnGenerarCotizacion_Click(object sender, EventArgs e)
        {
            try
            {
                DatosCotizacion cotizacion = new DatosCotizacion();
                cotizacion.Cliente = txtCliente.Text;
                cotizacion.FechaContabilizacion = DateTime.Now;
                cotizacion.FechaVencimiento = DateTime.Now.AddDays(3);
                cotizacion.Moneda = "MXP";
                cotizacion.Comentarios = "Cotización generada desde DRtail";

                foreach (DataGridViewRow dRow in dgvProductosCotizacion.Rows)
                {
                    ArticulosCotizacion articulosCotizacion = new ArticulosCotizacion();
                    articulosCotizacion.Articulo = dRow.Cells[0].Value.ToString();
                    articulosCotizacion.Cantidad = double.Parse(dRow.Cells[5].Value.ToString());
                    cotizacion.articulosCotizaciones.Add(articulosCotizacion);
                }

                if (CrearCotizacion(cotizacion))
                {
                    btnCobrarCotizacion.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Generar Cotización: " + ex.Message);
            }

            //MessageBox.Show("Se ha generado correctamente la Cotización: ");
            //dgvProductosCotizacion.Rows.Clear();
            //txtCliente.Text = "";
            //txtProducto.Text = "";
            //lblTotalProd.Text = "0";
        }
        public void LimpiarCotizacion()
        {
            txtCliente.ResetText();
            dgvProductosCotizacion.Rows.Clear();
            btnCobrarCotizacion.Visible = false;
            btnCobradoCotizaciones.Visible = false;
        }
        public Boolean CrearCotizacion(DatosCotizacion cotizacion)
        {
            Boolean generado = false;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://54.39.26.9:62436/api/crearCotizacion");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = JsonConvert.SerializeObject(cotizacion);
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
                MessageBox.Show("Error al Crear Cotización:" + ex.Message);
            }
            return generado;
        }
        public void ObtenerCotizaciones()
        {

            var j = Servicios.getCotizaciones();
        }
        private void btnCobradoCotizaciones_Click(object sender, EventArgs e)
        {
            LimpiarCotizacion();
        }

        private void txtProducto_KeyUp(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Enter)
            {
                AgregarArticuloDGV();
            }
        }

        private void bdgCotizaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                DataGridViewRow dgvr = bdgCotizaciones.Rows[e.RowIndex];
                lblNCotizacion.Text = dgvr.Cells[1].Value.ToString();
                lblNCliente.Text = dgvr.Cells[2].Value.ToString();
                lblNombre.Text = dgvr.Cells[3].Value.ToString();
                lblMontoAcciones.Text = dgvr.Cells[5].Value.ToString();
                lblAccionesMensaje.Text = "";
                pnlPOAcciones.BringToFront();
                pnlPOAcciones.Visible = true;

            }
        }

        private void btnAccionReenviar_Click(object sender, EventArgs e)
        {
            lblAccionesMensaje.Text = "Se ha enviado con éxito la cotización " + lblNCotizacion.Text;
        }

        private void btnAccionesReimp_Click(object sender, EventArgs e)
        {
            lblAccionesMensaje.Text = "Se ha reeimpreso con éxito la cotización " + lblNCotizacion.Text;
        }

        private void btnAccionesGPedido_Click(object sender, EventArgs e)
        {
            lblAccionesMensaje.Text = "Se ha Generado el pedido con éxito la cotización " + lblNCotizacion.Text;

            Servicios.menuLateral.pnlMain.Controls.Clear();
            Servicios.menuLateral.pnlMain.Controls.Add(new Pedidos(bdgCotizaciones.Rows[bdgCotizaciones.CurrentRow.Index].Cells[2].Value.ToString(), bdgCotizaciones.Rows[bdgCotizaciones.CurrentRow.Index].Cells[0].Value.ToString()));
            Servicios.menuLateral.SelectedLineMenu();
            Servicios.menuLateral.pnlLinePedidos.Visible = true;
            Servicios.menuLateral.LblTitle.Text = "PEDIDOS";

        }

        private void btnCerrarPOAcciones_Click(object sender, EventArgs e)
        {
            pnlPOAcciones.Visible = false;
        }

        private void dgvProductosCotizacion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            string descuento = tempDescuento;
            string articulo = dgvProductosCotizacion.Rows[e.RowIndex].Cells[0].Value.ToString();
            DialogResult dr = MessageBox.Show("¿Desea aplicar el descuento de $" + descuento + " al articulo " + articulo + "?", "Autorizar descuento", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr.Equals(DialogResult.OK))
            {
                pnlConfirmación.Visible = true;
                pnlConfirmación.BringToFront();
            }
            else
            {
                dgvProductosCotizacion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = tempDescuentoOld;
            }
        }


        private void dgvProductosCotizacion_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            tempDescuentoOld = dgvProductosCotizacion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        private void dgvProductosCotizacion_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            tempDescuento = e.FormattedValue.ToString();
        }

        private void btnAceptarPass_Click_1(object sender, EventArgs e)
        {
            pnlConfirmación.Visible = false;
            passAdministradorConf.Text = "";
        }


        private void btnAdminCancelar_Click(object sender, EventArgs e)
        {
            pnlConfirmación.Visible = false;
            dgvProductosCotizacion.SelectedCells[0].Value = tempDescuentoOld;


        }

        private void txtBuscarArtTraspaso_KeyUp(object sender, KeyEventArgs e)
        {
            List<DatosArticulos> tempItems = items;
            dgBuscadorArticulo.Rows.Clear();
            tempItems = tempItems.Where(i => (i.Codigo.Contains(txtBuscarArtTraspaso.Text)
                                           || (i.Descripcion != null
                                                ? i.Descripcion
                                                : "").Contains(txtBuscarArtTraspaso.Text))
                                        ).ToList();

            foreach (DatosArticulos da in tempItems)
            {
                dgBuscadorArticulo.Rows.Add(da.Codigo, da.Descripcion);
            }
        }

        private void btnAgregarBusqueda_Click(object sender, EventArgs e)
        {
            string codigo = dgBuscadorArticulo.SelectedRows[0].Cells[0].Value.ToString();
            txtProducto.Text = codigo;
            pnlbusquedaArticulo.Visible = false;
            dgBuscadorArticulo.Rows.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (DatosArticulos da in items)
            {
                dgBuscadorArticulo.Rows.Add(da.Codigo, da.Descripcion);
            }

            pnlbusquedaArticulo.Visible = true;
            pnlbusquedaArticulo.BringToFront();
        }

        private void txtBuscarCliente_KeyUp(object sender, KeyEventArgs e)
        {
            List<DatosSocios> tempItems = dtosSocios;
            dgBuscarClientes.Rows.Clear();
            tempItems = tempItems.Where(i => (i.CodigoCliente.Contains(txtBuscarCliente.Text)
                                           || (i.NombreCliente != null
                                                ? i.NombreCliente
                                                : "").Contains(txtBuscarCliente.Text))
                                        ).ToList();

            foreach (DatosSocios da in tempItems)
            {
                dgBuscarClientes.Rows.Add(da.CodigoCliente, da.NombreCliente);
            }
        }

        private void btnAgregarBuscarSocio_Click(object sender, EventArgs e)
        {
            string codigo = dgBuscarClientes.SelectedRows[0].Cells[0].Value.ToString();
            txtCliente.Text = codigo;
            pnlBuscarSocio.Visible = false;
            dgBuscarClientes.Rows.Clear();
        }

        private void btnAgregarProducto_Click_1(object sender, EventArgs e)
        {
            AgregarArticuloDGV();
        }

        private void tabControlCotizaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlCotizaciones.SelectedIndex == 1)
            {
                frmMenuLateral ml = (frmMenuLateral)this.ParentForm;
                dgvProductosCotizacion.Rows.Clear();
                importeTotal = 0;
                numArticulos = 0;
                List<DatosArticulos> tempList = ml.ObtenerArticulosCotizacion();



                foreach (DatosArticulos daT in tempList)
                {
                    numArticulos++;
                    bool agregado = false;
                    if (dgvProductosCotizacion.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in dgvProductosCotizacion.Rows)
                        {

                            if (row.Cells[0].Value.ToString().Equals(daT.Codigo))
                            {
                                int cant = int.Parse(row.Cells[5].Value.ToString());
                                row.Cells[5].Value = cant + 1;
                                row.Cells[6].Value = (cant + 1) * (daT.Costo * 0.16);
                                row.Cells[7].Value = (cant + 1) * (daT.Costo * 1.16);
                                importeTotal += (daT.Costo * 1.16);
                                agregado = true;
                                break;
                            }

                        }
                        if (!agregado)
                        {
                            dgvProductosCotizacion.Rows.Add(daT.Codigo, daT.Descripcion, daT.Costo, "IVA", 0, 1, (daT.Costo * 0.16), (daT.Costo * 1.16), daT.TotalStock);
                            importeTotal += (daT.Costo * 1.16);
                        }

                    }
                    else
                    {
                        dgvProductosCotizacion.Rows.Add(daT.Codigo, daT.Descripcion, daT.Costo, "IVA", 0, 1, (daT.Costo * 0.16), (daT.Costo * 1.16), daT.TotalStock);
                        importeTotal += (daT.Costo * 1.16);
                    }

                }
                txtTotal.Text = importeTotal.ToString("N2");
                lblTotalProd.Text = numArticulos.ToString();
            }
        }

        private void btnCotLimpiar_Click(object sender, EventArgs e)
        {
            frmMenuLateral ml = (frmMenuLateral)this.ParentForm;
            ml.itemsCotizacion.Clear();
            dgvProductosCotizacion.Rows.Clear();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            pnlBuscarSocio.Visible = false;
            pnlBuscarSocio.BringToFront();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            pnlbusquedaArticulo.Visible = false;
        }
    }
}
