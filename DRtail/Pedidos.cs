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
    public partial class Pedidos : UserControl
    {


        #region "Variables"
        public List<DatosSocios> dtosSocios;
        List<DatosArticulos> items;
        List<DatosPedido> pedidosList;
        Cotización cotizacionOrigen;
        public int ordenDGV = 0;
        public string codClienteSelec = "";
        DataTable dtSocios = new DataTable();
        int numArticulos = 0;
        double importeTotal = 0;
        string tempDescuento = "";
        string tempDescuentoOld = "";
        string flagPago = "";
        string docEntryCot = "";
        string docNumCot = "";
        #endregion
        public Pedidos(string impCliente, string docEntryCotizacion, string docNumCotizacion)
        {
            InitializeComponent();
           
            GetData();
            AutoCompletar(txtProducto, "DatosArticulos");
            AutoCompletar(txtCliente, "DatosSocios");
        }
        public Pedidos(DatosCotizacion dc)
        {
            InitializeComponent();
            if(dc.Cliente != "")
            {
                txtCliente.Text = dc.Cliente;
                tabControlPedidos.SelectedIndex = 1;
            }
            this.Dock = DockStyle.Fill;
            docEntryCot = docEntryCotizacion;
            docNumCot = docNumCotizacion;
            GetData();
            AutoCompletar(txtProducto, "DatosArticulos");
            AutoCompletar(txtCliente, "DatosSocios");

            if (impCliente == "")
            {
                tabControlPedidos.SelectedIndex = 0;
            }
            else
            {
                tabControlPedidos.SelectedIndex = 1;
                txtCliente.Text = impCliente;

            }
        }

        private void GetData()
        {
            try
            {
                dtosSocios = Servicios.getSocios();
                items = Servicios.GetArticulos();
                pedidosList = Servicios.getPedidos();


                foreach (DatosPedido dc in pedidosList)
                {
                    bdgPedidos.Rows.Add(dc.noPedido, dc.Cliente, dc.Nombre, dc.FechaDocumento.ToString("yyyy-MM-dd"), double.Parse(dc.Total).ToString("N2"), dc.Moneda, dc.Estatus, "...");

                }

                if (docEntryCot != "")
                {
                    int numArticulosCotPed = 0;
                    double totCotPed = 0;

                    cotizacionOrigen = Servicios.getCotizacionOrigen(docNumCot);

                    foreach (Lineas l in cotizacionOrigen.lineas)
                    {
                        dgvProductosPed.Rows.Add(l.Articulo, "", l.PrecioU, "", l.Descuento, l.Cantidad, "", l.Total, "");
                    }

                    foreach (DataGridViewRow row in dgvProductosPed.Rows)
                    {
                        numArticulosCotPed++;
                        totCotPed = totCotPed + double.Parse(row.Cells["ImporteM"].Value.ToString());
                    }
                    lblTotalProd.Text = numArticulosCotPed.ToString();
                    txtTotal.Text = totCotPed.ToString();

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
        private void btnPedLimpiar_Click(object sender, EventArgs e)
        {
            frmMenuLateral ml = (frmMenuLateral)this.ParentForm;
            ml.itemsPedido.Clear();
            dgvProductosPed.Rows.Clear();
        }

        private void lnkLblBuscarCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlBuscarSocio.Visible = true;
            pnlBuscarSocio.BringToFront();
            dgBuscarClientes.Rows.Clear();

            foreach (DatosSocios da in dtosSocios)
            {
                dgBuscarClientes.Rows.Add(da.CodigoCliente, da.NombreCliente);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlbusquedaArticulo.Visible = true;
            pnlbusquedaArticulo.BringToFront();

            dgBuscadorArticulo.Rows.Clear();

            foreach (DatosArticulos da in items)
            {
                dgBuscadorArticulo.Rows.Add(da.Codigo, da.Descripcion);
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            AgregarArticuloDGV();
        }
        private void txtProducto_KeyUp(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Enter)
            {
                AgregarArticuloDGV();
            }
        }

        void AgregarArticuloDGV()
        {
            int valid = 0;
            foreach (DatosArticulos i in items)
            {
                if (txtProducto.Text == i.Codigo)
                {
                    if (dgvProductosPed.RowCount > 0)
                    {
                        int rep = 0;
                        foreach (DataGridViewRow r in dgvProductosPed.Rows)
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

                            dgvProductosPed.Rows.Add(i.Codigo, i.Descripcion, i.Costo, "IVA", 0.0, 1, (i.Costo * 0.16), i.Costo, 0, (i.Costo * 0.16), i.TotalStock);
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
                        dgvProductosPed.Rows.Add(i.Codigo, i.Descripcion, i.Costo, "IVA", 0.0, 1, (i.Costo * 0.16), i.Costo, 0, (i.Costo * 0.16), i.TotalStock);

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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            pnlbusquedaArticulo.Visible = false;
            pnlbusquedaArticulo.BringToFront();
        }

        private void txtBuscarArtTraspaso_KeyUp(object sender, KeyEventArgs e)
        {
            List<DatosArticulos> tempItems = items;
            dgBuscadorArticulo.Rows.Clear();
            tempItems = tempItems.Where(i => (i.Codigo.Contains(txtBuscarArtPedido.Text)
                                           || (i.Descripcion != null
                                                ? i.Descripcion
                                                : "").Contains(txtBuscarArtPedido.Text))
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

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            pnlBuscarSocio.Visible = false;
            pnlBuscarSocio.BringToFront();
        }

        private void btnAgregarBuscarSocio_Click(object sender, EventArgs e)
        {
            string codigo = dgBuscarClientes.SelectedRows[0].Cells[0].Value.ToString();
            txtCliente.Text = codigo;
            pnlBuscarSocio.Visible = false;
            dgBuscarClientes.Rows.Clear();
        }

        private void btnCobrarCotizacion_Click(object sender, EventArgs e)
        {

            lblCobrarTotalNumero.Text = importeTotal.ToString("N2");
            pnlPagos.Visible = true;

        }

        private void btnGenerarCotizacion_Click(object sender, EventArgs e)
        {

            try
            {
                DatosPedido pedido = new DatosPedido();
                pedido.NoCotizacionRelacionada = docEntryCot; //Cotizacion relacionada
                pedido.Cliente = txtCliente.Text;
                pedido.FechaContabilizacion = DateTime.Now;
                pedido.FechaVencimiento = DateTime.Now.AddDays(3);
                pedido.Moneda = "MXP";
                pedido.Comentarios = "Pedido generado desde DRtail";

                foreach (DataGridViewRow dRow in dgvProductosPed.Rows)
                {
                    ArticulosPedido articulosPed = new ArticulosPedido();
                    articulosPed.Articulo = dRow.Cells[0].Value.ToString();
                    articulosPed.Cantidad = double.Parse(dRow.Cells[5].Value.ToString());
                    pedido.articulosPedidos.Add(articulosPed);
                }

                if (CrearPedido(pedido))
                {
                    btnCobrarCotizacion.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Generar Pedido: " + ex.Message);
            }

        }

        private void btnCobrarCancelar_Click(object sender, EventArgs e)
        {
            pnlPagos.Visible = false;
        }

        private void btnCobrarPEfectivo_Click(object sender, EventArgs e)
        {
            flagPago = "efectivo";
            txtbCobrarPago.Enabled = true;
        }

        private void btnCobrarPCredito_Click(object sender, EventArgs e)
        {
            flagPago = "credito";
            txtbCobrarPago.Enabled = true;
        }

        private void btnCobrarPTDC_Click(object sender, EventArgs e)
        {
            flagPago = "tdc";
            txtbCobrarPago.Enabled = true;
        }

        private void btnCobrarPTDD_Click(object sender, EventArgs e)
        {
            flagPago = "tdd";
            txtbCobrarPago.Enabled = true;
        }

        private void btnCobrarAgregarPago_Click(object sender, EventArgs e)
        {

            double cantidad = 0;

            if (!double.TryParse(txtbCobrarPago.Text, out cantidad))
            {
                return;
            }
            double cambio = double.Parse(lblCobrarCambioNum.Text);
            switch (flagPago)
            {
                case "credito":

                    double totalCredito = double.Parse(lblCobrarEfectivoNum.Text);
                    cambio = cambio + totalCredito;
                    lblCobrarEfectivoNum.Text = (cantidad + totalCredito).ToString("N2");
                    txtbCobrarPago.Text = "";
                    pnlCobrarCredito.Visible = true;
                    break;
                case "tdc":

                    double totalTdc = double.Parse(lblCobrarEfectivoNum.Text);
                    cambio = cambio + totalTdc;
                    lblCobrarTDCNum.Text = (cantidad + totalTdc).ToString("N2");
                    txtbCobrarPago.Text = "";
                    pnlCobrarTDC.Visible = true;
                    break;
                case "tdd":

                    double totalTdd = double.Parse(lblCobrarEfectivoNum.Text);
                    cambio = cambio + totalTdd;
                    lblCobrarTDDNum.Text = (cantidad + totalTdd).ToString("N2");
                    txtbCobrarPago.Text = "";
                    pnlCobrarTDD.Visible = true;
                    break;
                case "efectivo":

                    double totalEfectivo = double.Parse(lblCobrarEfectivoNum.Text);
                    cambio = cambio + totalEfectivo;
                    lblCobrarEfectivoNum.Text = (cantidad + totalEfectivo).ToString("N2");
                    txtbCobrarPago.Text = "";
                    pnlCobrarEfectivo.Visible = true;
                    break;

            }
            double cTotal = cambio - importeTotal;

            if (cTotal > 0)
            {
                lblCobrarCambioNum.Text = cTotal.ToString("N2");
                pnlCobrarCambio.Visible = true;
            }


        }

        private void btnCobrarFacturar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha facturado correctamente");
            pnlPagos.Visible = false;
        }

        private void btnCobrarCobrareIticket_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha mandado a imprimir correctamente");
            pnlPagos.Visible = false;
        }

        private void bdgPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                pnlPOAcciones.Visible = true;
                pnlPOAcciones.BringToFront();

                lblNCliente.Text = bdgPedidos.Rows[e.RowIndex].Cells[1].Value.ToString();
                lblNombre.Text = bdgPedidos.Rows[e.RowIndex].Cells[2].Value.ToString();
                lblMontoAcciones.Text = bdgPedidos.Rows[e.RowIndex].Cells[4].Value.ToString();
                lblNPedido.Text = bdgPedidos.Rows[e.RowIndex].Cells[0].Value.ToString();

            }
        }

        private void btnCerrarPOAcciones_Click(object sender, EventArgs e)
        {
            pnlPOAcciones.Visible = false;
        }

        private void btnAccionReenviar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha reenviado correctamente");
        }

        private void btnAccionesReimp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha reimpreso correctamente");
        }

        private void btnAccionesGPedido_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha generado correctamente");
        }

        public Boolean CrearPedido(DatosPedido pedido)
        {
            Boolean generado = false;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.RutaApi + "crearPedido");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = JsonConvert.SerializeObject(pedido);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var j = JsonConvert.DeserializeObject<RespuestaAPI>(result);
                    string email = "";
                    var socio = dtosSocios.Where(i => (i.CodigoCliente.Contains(txtCliente.Text)));

                    foreach (DatosSocios s in socio)
                    {
                        email = s.Email;
                    }

                    if (j.Error == "false")
                    {
                        if (Utilidades.ReporteCotizacion(j.docEntryGenerado, email, "Pedido"))
                        {
                            MessageBox.Show("Correo enviado");
                        }
                        MessageBox.Show(j.Message);
                        generado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Crear Cotización:" + ex.Message);
            }
            return generado;
        }

    }
}
