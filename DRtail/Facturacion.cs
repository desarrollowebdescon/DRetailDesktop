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
    public partial class Facturacion : UserControl
    {

        #region "Variables"
        public List<DatosSocios> dtosSocios;
        List<DatosArticulos> items;
        List<DatosFactura> datosFacturas;
        public int ordenDGV = 0;
        public string codClienteSelec = "";
        DataTable dtSocios = new DataTable();
        int numArticulos = 0;
        double importeTotal = 0;
        string tempDescuento = "";
        string tempDescuentoOld = "";
        string docEntrySeleccionado = "";
        public string usoCFDI = "";
        public string metodoPag = "";
        public string formaPag = "";
        string docEntryPed = "";
        string docNumPed = "";
        int tipoFact = 0;
        #endregion

        public Facturacion()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            GetDatos();
            AutoCompletar(txtProducto, "DatosArticulos");
            AutoCompletar(txtCliente, "DatosSocios");
        }

        public Facturacion(string impCliente, string docEntryPedido, string docNumPedido)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            docEntryPed = docEntryPedido;
            docNumPed = docNumPedido;
            GetDatos();
            AutoCompletar(txtProducto, "DatosArticulos");
            AutoCompletar(txtCliente, "DatosSocios");
            if (impCliente == "")
            {
                tabControlFacturacion.SelectedIndex = 0;
                txtCliente.Text = "C-010132";
            }
            else
            {
                tabControlFacturacion.SelectedIndex = 1;
                txtCliente.Text = impCliente;
            }
        }

        private void GetDatos()
        {
            try
            {
                dtosSocios = Servicios.getSocios();
                items = Servicios.GetArticulos();
                datosFacturas = Servicios.getFacturas();

                foreach (DatosFactura df in datosFacturas)
                {
                    bdgFacturas.Rows.Add(df.DocEntryFact, df.NoFactura, df.Cliente, df.Nombre, df.FechaVencimiento, df.TotalFacturado, df.Estatus, "...");
                }
            }
            catch
            {

            }
        }

        private void txtBuscarFactura_KeyUp(object sender, KeyEventArgs e)
        {

            List<DatosFactura> dfList = datosFacturas;
            bdgFacturas.Rows.Clear();
            dfList = dfList.Where(df =>
                                    (df.Cliente.Contains(txtBuscarFactura.Text) ||
                                     df.NoFactura.Contains(txtBuscarFactura.Text) ||
                                     df.Nombre.ToString().Contains(txtBuscarFactura.Text)
                                    )
                                ).ToList();
            foreach (DatosFactura df in dfList)
            {
                bdgFacturas.Rows.Add(df.NoFactura, df.Cliente, df.Nombre, df.FechaVencimiento, df.TotalFacturado, df.Estatus, "...");
            }
        }



        private void btnAccionesGPedido_Click(object sender, EventArgs e)
        {
            pnlPOAccion.Visible = false;
            pnlFGenerarFactura.Visible = true;
        }

        private void btnAccionesReimp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha mandado a imprimir correctamente");
        }

        private void btnFGenerarFacturaPago_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha generado correctamente su factura");
            pnlFGenerarFactura.Visible = false;
            pnlPOAcciones.Visible = false;

        }

        private void btnFpnlAClose_Click(object sender, EventArgs e)
        {
            pnlPOAcciones.Visible = false;
        }

        private void btnFpnlPagosClose_Click(object sender, EventArgs e)
        {
            pnlFGenerarFactura.Visible = false;
        }

        private void bdgFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.ColumnIndex == 5)
            {
                pnlPOAccion.Visible = true;
                pnlPOAcciones.Visible = true;
                lblNPedido.Text = bdgFacturas.Rows[e.RowIndex].Cells[1].Value.ToString();
                lblTotalFacturadoNum.Text = bdgFacturas.Rows[e.RowIndex].Cells[3].Value.ToString();
                lblEstatusNum.Text = bdgFacturas.Rows[e.RowIndex].Cells[4].Value.ToString();

            }
        }

        private void btnCerrarPU_Click(object sender, EventArgs e)
        {

            pnlPOAcciones.Visible = false;
            pnlFGenerarFactura.Visible = false;
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

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            int timbrar = 0;

            try
            {

                if (DialogResult.Yes == MessageBox.Show("La factura será timbrada?", "Timbrar", MessageBoxButtons.YesNo))
                {
                    timbrar = 1;
                    frmDatosFiscales datos = new frmDatosFiscales(this);
                    datos.ShowDialog();
                }
                DatosFactura factura = new DatosFactura();

                if (tipoFact == 0)
                {
                    //Deudores
                    factura.tipo = "DEUDOR";
                }
                else if (tipoFact == 1)
                {
                    //Reserva
                    factura.tipo = "RESERVA";
                }
                else if (tipoFact == 2)
                {
                    //Anticipo
                    factura.tipo = "ANTICIPO";
                }
                factura.NoPedidoRelacionada = docEntryPed; //Pedido relacionado
                factura.Cliente = txtCliente.Text;
                factura.FechaContabilizacion = DateTime.Now;
                factura.FechaVencimiento = DateTime.Now.AddDays(3);
                factura.Moneda = "MXN";
                factura.Comentarios = "Factura generada desde DRtail";
                if (timbrar == 1)
                {
                    factura.DatosFiscales.certificado = "2";
                    factura.DatosFiscales.formaPago = formaPag;
                    factura.DatosFiscales.metodopago = metodoPag;
                    factura.DatosFiscales.usocfdi = usoCFDI;
                }
                else if (timbrar == 0)
                {
                    factura.DatosFiscales.certificado = "6";
                    factura.DatosFiscales.formaPago = "";
                    factura.DatosFiscales.metodopago = "";
                    factura.DatosFiscales.usocfdi = "";
                }
                foreach (DataGridViewRow dRow in dgvProductosFact.Rows)
                {
                    ArticulosFactura articulosFactura = new ArticulosFactura();
                    articulosFactura.Articulo = dRow.Cells[0].Value.ToString();
                    articulosFactura.Precio = double.Parse(dRow.Cells["CantidadVM"].Value.ToString());
                    articulosFactura.Cantidad = 1;//double.Parse(dRow.Cells["cantidad"].Value.ToString());
                    factura.articulosFacturas.Add(articulosFactura);
                }
                string crearFact = CrearFactura(factura);
                if (crearFact == "1")
                {
                    btnCobrarCotizacion.Visible = true;
                }
                else
                    MessageBox.Show(crearFact);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Generar Factura: " + ex.Message);
            }
        }

        public string CrearFactura(DatosFactura factura)
        {
            string generado = "0";
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.RutaApi + "crearFactura");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = JsonConvert.SerializeObject(factura);
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
                        MessageBox.Show(j.Message);
                        Utilidades.ReporteTicket(j.docEntryGenerado, email, "Factura");
                        generado = "1";
                    }
                    else
                        generado = j.Message;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Crear Factura:" + ex.Message);
                generado = "0";
            }
            return generado;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            AgregarArticuloDGV();
        }

        void AgregarArticuloDGV()
        {
            int valid = 0;
            foreach (DatosArticulos i in items)
            {
                if (txtProducto.Text == i.Codigo)
                {
                    if (dgvProductosFact.RowCount > 0)
                    {
                        int rep = 0;
                        foreach (DataGridViewRow r in dgvProductosFact.Rows)
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

                            dgvProductosFact.Rows.Add(i.Codigo, i.Descripcion, i.Costo, "IVA", 0.0, 1, (i.Costo * 0.16), i.Costo, 0, (i.Costo * 0.16), i.TotalStock);
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
                        dgvProductosFact.Rows.Add(i.Codigo, i.Descripcion, i.Costo, "IVA", 0.0, 1, (i.Costo * 0.16), i.Costo, 0, (i.Costo * 0.16), i.TotalStock);

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

        private void lnkLblBuscarCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (DatosSocios da in dtosSocios)
            {
                dgBuscarClientes.Rows.Add(da.CodigoCliente, da.NombreCliente);
            }
            pnlBuscarSocio.Visible = true;
            pnlBuscarSocio.BringToFront();

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

        private void btnAgregarBuscarSocio_Click(object sender, EventArgs e)
        {
            string codigo = dgBuscarClientes.SelectedRows[0].Cells[0].Value.ToString();
            txtCliente.Text = codigo;
            pnlBuscarSocio.Visible = false;
            dgBuscarClientes.Rows.Clear();
        }

        private void btnAgregarBusqueda_Click(object sender, EventArgs e)
        {
            string codigo = dgBuscadorArticulo.SelectedRows[0].Cells[0].Value.ToString();
            txtProducto.Text = codigo;
            pnlbusquedaArticulo.Visible = false;
            dgBuscadorArticulo.Rows.Clear();
        }

        private void bunifuThinButton213_Click(object sender, EventArgs e)
        {
            pnlBuscarSocio.Visible = false;
        }

        private void bunifuThinButton214_Click(object sender, EventArgs e)
        {
            pnlbusquedaArticulo.Visible = false;
        }

        private void rbtnDeudores_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDeudores.Checked == true)
            {
                tipoFact = 0;
            }
        }

        private void rbtnReserva_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnReserva.Checked == true)
            {
                tipoFact = 1;
            }
        }

        private void rbtnAnticipo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAnticipo.Checked == true)
            {
                tipoFact = 2;
            }
        }

        private void btnCobrarCotizacion_Click(object sender, EventArgs e)
        {
            frmCobrar cobrar = new frmCobrar();
            //cobrar.menu2 = this;
            cobrar.totalVenta = importeTotal;
            cobrar.ShowDialog();
        }
    }
}
