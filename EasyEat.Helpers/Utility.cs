using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Mail;
using System.Reflection;

namespace EasyEat.Helpers
{
    public static class Utility
    {

        #region DataToList

        public static List<T> DataToList<T>(Type t, DataTable oDt)
        {
            BindingFlags flags = BindingFlags.Instance
            | BindingFlags.Public
            ///| BindingFlags.DeclaredOnly
            | BindingFlags.Static;

            List<T> olist = new List<T>();

            PropertyInfo[] pi = t.GetProperties(flags); // Obtenemos Los PropertyInfo Desde El Array.

            T instancia; // Creamos Una Instancia T
            try
            {
                foreach (DataRow oRow in oDt.Rows) // Por Cada Row En El DataTable, Activamos La Instancia Y La Guardamos En Otra Lista.
                {
                    instancia = (T)Activator.CreateInstance(t, true);
                    OrganizeDataToList<T>(oDt, pi, instancia, oRow); // Este Metodo Convierte Los Objetos En Una Lista.
                    olist.Add(instancia); // Guardamos La Instancia En El Modelo De Lista.
                }
            }
            catch (Exception)
            {
                throw;
            }

            return olist;
        }

        public static string GetConexionStringEvent(string eventId)
        {
            string stringConexion = System.Configuration.ConfigurationManager.ConnectionStrings["EventManager"].ToString();

            if (!string.IsNullOrEmpty(eventId))
            {
                if (eventId != "-1")
                    stringConexion = stringConexion.Replace("EventManager", string.Format("EventManager_{0}", eventId));
            }

            return stringConexion;
        }

        /// <summary>
        /// Organiza DataToList En El DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oDt"></param>
        /// <param name="pi"></param>
        /// <param name="instancia"></param>
        /// <param name="oRow"></param>
        private static void OrganizeDataToList<T>(DataTable oDt, PropertyInfo[] pi, T instancia, DataRow oRow)
        {
            foreach (PropertyInfo m in pi)
            {
                ValidateTypeOfData<T>(oDt, instancia, oRow, m); // Validamos El Tipo De Dato En Este Metodo.
            }
        }

        private static void ValidateTypeOfData<T>(DataTable oDt, T instancia, DataRow oRow, PropertyInfo m)
        {

            ///Basicamente Comparamos El Tipo Que Recibe, Buscamos El Tipo De Dato Para Poder Almacenarlo En la Lista.
            if (oDt.Columns.Contains(m.Name))
            {
                if (!oRow.IsNull(m.Name))
                {
                    if (m.PropertyType == typeof(double))
                    {
                        m.SetValue(instancia, Convert.ToDouble(oRow[m.Name], new System.Globalization.CultureInfo("").NumberFormat), null);
                    }
                    else if (m.PropertyType == typeof(Int64) || m.PropertyType == typeof(Int64?))
                        m.SetValue(instancia, Convert.ToInt64(oRow[m.Name]), null);
                    else if (m.PropertyType == typeof(Int32) || m.PropertyType == typeof(Int32?))
                        m.SetValue(instancia, Convert.ToInt32(oRow[m.Name]), null);
                    else if (m.PropertyType == typeof(int))
                        m.SetValue(instancia, Convert.ToInt16(oRow[m.Name]), null);
                    else if (m.PropertyType == typeof(DateTime))
                        m.SetValue(instancia, Convert.ToDateTime(oRow[m.Name]), null);
                    else if (m.PropertyType == typeof(bool))
                        m.SetValue(instancia, Convert.ToBoolean(oRow[m.Name]), null);
                    else if (m.PropertyType == typeof(byte[]))
                        m.SetValue(instancia, (Byte[])(oRow[m.Name]), null);
                    else if (m.PropertyType == typeof(String))
                        m.SetValue(instancia, Convert.ToString(oRow[m.Name]), null);
                }
            }
        }

        #endregion
    

        public static string GetExecutionPath()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory;
        }

        public static bool ValidateDateToSQL(DateTime date)
        {
            bool res = false;
            int result = DateTime.Compare(date, new DateTime(1900, 1, 1));
            if (result > 0)
                res = true;
            return res;
        }

        public static bool SendMail(string from, string to, string cc,
                             string bcc, string subject, string body,

                             string displayName = ""
                             )
        {

            string server = System.Configuration.ConfigurationManager.AppSettings["server"];
            string smtpUser = System.Configuration.ConfigurationManager.AppSettings["smtpUser"];
            string smtpPass = System.Configuration.ConfigurationManager.AppSettings["smtpPass"];

            bool sended = true;
            try
            {
                if (string.IsNullOrEmpty(displayName))
                    displayName = from;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);

                foreach (string remitente in to.Split(';'))
                {
                    mail.To.Add(remitente);
                }


                if (cc != null && cc.Length > 0)
                    mail.CC.Add(cc);
                if (bcc != null && bcc.Length > 0)
                    mail.Bcc.Add(bcc);
                mail.Subject = subject;


                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;


                SmtpClient smtpMail = new SmtpClient(server);

                System.Net.NetworkCredential SMTPUserInfo =
                    new System.Net.NetworkCredential(smtpUser, smtpPass);
                smtpMail.Credentials = SMTPUserInfo;
                smtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpMail.Send(mail);

            }
            catch (Exception)
            {
                return sended = false;

            }
            return sended;
        }
    }
}
