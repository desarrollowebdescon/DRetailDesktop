using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DRtail
{
    class Utilidades
    {
        public static bool ReporteTicket(string docEntryGenerado, string email, string tipoDoc)
        {
            try
            {
                ReportDocument ocInforme = new ReportDocument();
                string fileName;
                ocInforme.Load(Application.StartupPath + @"\Ticket_" + tipoDoc + ".rpt");

                foreach (Table var in ocInforme.Database.Tables)
                {
                    TableLogOnInfo boTableLogOnInfo = var.LogOnInfo;
                    boTableLogOnInfo.ConnectionInfo.ServerName = Properties.Settings.Default.Servidor;
                    boTableLogOnInfo.ConnectionInfo.UserID = Properties.Settings.Default.Usuario;
                    boTableLogOnInfo.ConnectionInfo.Password = Properties.Settings.Default.Password;
                    boTableLogOnInfo.ConnectionInfo.DatabaseName = Properties.Settings.Default.Empresa;
                    var.ApplyLogOnInfo(boTableLogOnInfo);
                }
                ocInforme.SetParameterValue("DocKey@", docEntryGenerado); // 
                ocInforme.SetDatabaseLogon(Properties.Settings.Default.Usuario, Properties.Settings.Default.Password, Properties.Settings.Default.Servidor, Properties.Settings.Default.Empresa);
                fileName = ExportToPDF(ocInforme, tipoDoc + "_" + docEntryGenerado.ToString() + ".pdf");
                enviarCorreo(email, fileName, tipoDoc);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de impresión: " + ex.Message);
                return false;
            }
        }

        public static string ExportToPDF(ReportDocument rpt, string NombreArchivo)
        {
            string vFileName = null;
            DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();

            try
            {
                rpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                rpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;

                // Este es la ruta donde se guardara tu archivo.
                vFileName = @"c:\Reporte\" + NombreArchivo;
                if (File.Exists(vFileName))
                    File.Delete(vFileName);
                diskOpts.DiskFileName = vFileName;
                rpt.ExportOptions.DestinationOptions = diskOpts;
                rpt.Export();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vFileName;
        }

        public static Boolean enviarCorreo(string U_Correo, string U_Path, string tipoDocumento)
        {
            bool enviado = false;

            try
            {
                string SMTP = "smtp.gmail.com"; // lc_ServidorSMTP
                string Usuario = "testdesarrollosdescon@gmail.com"; // lc_UsuarioCorreo
                string Contraseña = "Descon2020"; // lc_ContraseñaCorreo
                int Puerto = System.Convert.ToInt32(587);
                System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
                correo.From = new System.Net.Mail.MailAddress(Usuario);
                correo.Subject = "Envio de " + tipoDocumento + " de Etrusca";
                correo.Body = "Buen dìa enviamos el siguiente correo como prueba de funcionalidad del mismo, quedando atentos a sus comentarios y agradeciendo su atención";
                correo.To.Add(U_Correo);
                System.Net.Mail.SmtpClient Servidor = new System.Net.Mail.SmtpClient();
                Servidor.Host = SMTP;
                Servidor.Port = Puerto;
                System.Net.Mail.Attachment archivo = new System.Net.Mail.Attachment(U_Path);
                correo.Attachments.Add(archivo);
                if (1 == 1)
                    Servidor.EnableSsl = true;
                else
                    Servidor.EnableSsl = false;
                Servidor.Credentials = new System.Net.NetworkCredential(Usuario, Contraseña);
                Servidor.Send(correo);
                correo.Attachments.Dispose();
                enviado = true;
            }
            catch (Exception ex)
            {
                enviado = false;
            }
            return enviado;
        }
    }
}
