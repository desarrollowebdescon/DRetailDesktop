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
            this.Dock = DockStyle.Fill;
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
                bfgSocios.Rows.Add(ds.CodigoCliente, ds.NombreCliente, ds.RFC, ds.Telefono, ds.Email,"...","...","...");
            }
        }

       

        private void btnProspectos_Click(object sender, EventArgs e)
        {

        }

        

        private void btnCreaCrearCliente_Click(object sender, EventArgs e)
        {
            
        }

        public Boolean CrearSocio()
        {
            Boolean generado = false;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://54.39.26.9:62436/api/crearSocio");
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

        private void btnCreaCrearCliente_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show("Se ha creado el usuario correctamente");

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
                Servicios.menuLateral.pnlMain.Controls.Add(new Pedidos(bfgSocios.Rows[bfgSocios.CurrentRow.Index].Cells[0].Value.ToString()));
                Servicios.menuLateral.SelectedLineMenu();
                Servicios.menuLateral.pnlLinePedidos.Visible = true;
                Servicios.menuLateral.LblTitle.Text = "COTIZACIONES";

            }
        }
    }
}
