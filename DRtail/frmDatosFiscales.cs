using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DRtail
{
    public partial class frmDatosFiscales : Form
    {
        public Facturacion fac;

        public frmDatosFiscales()
        {
            InitializeComponent();
        }

        public frmDatosFiscales(Facturacion menu)
        {
            InitializeComponent();
            fac = menu;
        }


        private void frmDatosFiscales_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> uso = new Dictionary<string, string>();
            uso.Add("G01", "G01 - Adquisición de mercancías");
            uso.Add("G02", "G02 - Devoluciones, descuentos o bonificaciones");
            uso.Add("G03", "G03 - Gastos en general");
            uso.Add("I08", "I08 - Otra maquinaria y equipo");
            uso.Add("P01", "P01 - Por definir");
            cmbxUso.DataSource = new BindingSource(uso, null);
            cmbxUso.DisplayMember = "Value";
            cmbxUso.ValueMember = "Key";

            Dictionary<string, string> metodo = new Dictionary<string, string>();
            metodo.Add("PUE", "PUE - Pago en Parcialidades o Diferido");
            metodo.Add("PPD", "PPD - Pago en Una sola Exhibición");
            metodo.Add("99", "99 - Por Definir");
            cmbxMetodo.DataSource = new BindingSource(metodo, null);
            cmbxMetodo.DisplayMember = "Value";
            cmbxMetodo.ValueMember = "Key";

            Dictionary<string, string> forma = new Dictionary<string, string>();
            forma.Add("01", "Efectivo");
            forma.Add("02", "Cheque nominativo");
            forma.Add("03", "Transferencia electrónica de fondos");
            forma.Add("04", "Tarjeta de crédito");
            forma.Add("05", "Monedero electrónico");
            forma.Add("06", "Dinero electrónico");
            forma.Add("08", "Vales de despensa");
            forma.Add("12", "Dación en pago");
            forma.Add("13", "Pago por subrogación");
            forma.Add("14", "Pago por consignación");
            forma.Add("15", "Condonación");
            forma.Add("17", "Compensación");
            forma.Add("23", "Novación");
            forma.Add("24", "Confusión");
            forma.Add("25", "Remisión de deuda");
            forma.Add("26", "Prescripción o caducidad");
            forma.Add("27", "A satisfacción del acreedor");
            forma.Add("28", "Tarjeta de débito");
            forma.Add("29", "Tarjeta de servicios");
            forma.Add("30", "Aplicación de anticipos");
            forma.Add("99", "Por definir");
            cmbxForma.DataSource = new BindingSource(forma, null);
            cmbxForma.DisplayMember = "Value";
            cmbxForma.ValueMember = "Key";


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            fac.usoCFDI = cmbxUso.SelectedValue.ToString();
            fac.metodoPag = cmbxMetodo.SelectedValue.ToString();
            fac.formaPag = cmbxForma.SelectedValue.ToString();

            this.Dispose();
        }
    }
}
