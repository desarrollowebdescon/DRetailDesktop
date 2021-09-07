using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRtail
{
    class Ticket
    {
        int SPACE = 130;
        public void ImprimirTicket()
        {
            PrintDocument pd = new PrintDocument();
            PaperSize ps = new PaperSize("", 420, 540);
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

           

        }

        public void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawRectangle(Pens.Black, 5, 5, 410, 530);

            //Agregamos el logo
            string pathImg = "CBT_Title.png";
            g.DrawImage(Image.FromFile(pathImg), 50, 7);

            Font fBody = new Font("Lucida Console", 15, FontStyle.Bold);
            SolidBrush sb = new SolidBrush(Color.Black);

            g.DrawString("------------------------------", fBody, sb, 10, 120);
            g.DrawString("Fecha :", fBody, sb, 10, SPACE);
            g.DrawString(DateTime.Now.ToShortDateString(), fBody, sb, 90, SPACE);
            g.DrawString("Hora :", fBody, sb, 10, SPACE + 30);
            g.DrawString(DateTime.Now.ToShortTimeString(), fBody, sb, 90, SPACE + 30);

            Random RandomNumber = new Random();
            int no = RandomNumber.Next(1000, 9999);
           // Image imgBarcode = BarcodeLib.Barcode.DoEncode(BarcodeLib.TYPE.CODE128, no.ToString(), true, Color.Black, Color.White, 200, 60);
            //g.DrawImage(imgBarcode, 10, SPACE + 240);

            g.DrawString("No. ticket.:", fBody, sb, 10, SPACE + 60);
            g.DrawString(no.ToString(), fBody, sb, 150, SPACE + 60);
            
            g.DrawString("BusNo.:", fBody, sb, 10, SPACE + 90);
            //g.DrawString(txtBusNo.Text, fBody, sb, 100, SPACE + 90);
            
            
            
            //int price = Convert.ToInt32(txtMember.Text) * Convert.ToInt32(txtPrice.Text);
            //string price1 = txtMember.Text + " X " + txtPrice.Text + " = " + price.ToString();

            //g.DrawString("Full:", fBody, sb, 10, SPACE + 150);
            //g.DrawString(price1, fBody1, sb, 80, SPACE + 150);
            //g.DrawString("Rs." + price.ToString() + ".00", rs, sb, 10, SPACE + 180);
            //g.DrawString(TType, fTType, sb, 230, 120);
            //g.DrawString("HelplineNo.: +91 9999999999", fBody2, sb, 15, 465);
            //g.DrawString("* NOT TRANSFERABLE", fBody2, sb, 15, 485);

            
            g.Dispose();

        }
    }
}
