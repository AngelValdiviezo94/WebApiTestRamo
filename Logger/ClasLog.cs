using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Logger
{
    public class ClasLog
    {
        public ClasLog() { }

        public void GrabaLogWarn(string textoMensaje)
        {
            try
            {
                if (ConfigurationManager.AppSettings["LogInfo"].Equals("S")) GrabaLog(textoMensaje, "WARN");
            }
            catch (Exception ex)
            {
            }
        }

        public void GrabaLogFatal(string textoMensaje)
        {
            try
            {
                if (ConfigurationManager.AppSettings["LogError"].Equals("S")) GrabaLog(textoMensaje, "FATAL");
            }
            catch (Exception ex)
            {
            }
        }

        public void GrabaLogDebug(string textoMensaje, string identificador = "0")
        {
            try
            {
                if (ConfigurationManager.AppSettings["LogInfo"].Equals("S")) GrabaLog(textoMensaje, "DEBUG");
            }
            catch (Exception ex)
            {
            }
        }

        public void GrabaLogInfo(string textoMensaje)
        {
            try
            {
                if (ConfigurationManager.AppSettings["LogInfo"].Equals("S")) GrabaLog(textoMensaje, "INFO");
            }
            catch (Exception ex)
            {
            }
        }

        public void GrabaLogInfo(string textoMensaje, string identificador = "0")
        {
            try
            {
                if (ConfigurationManager.AppSettings["LogInfo"].Equals("S")) GrabaLog(textoMensaje, "INFO");
            }
            catch (Exception ex)
            {
            }
        }

        public void GrabaLogError(string textoMensaje, string identificador = "0")
        {
            try
            {
                if (ConfigurationManager.AppSettings["LogError"].Equals("S")) GrabaLog(textoMensaje, "ERROR");
            }
            catch (Exception ex)
            {
            }
        }

        public void GrabaLog(string datos, string tipo)
        {
            StreamWriter sw = default(StreamWriter);
            System.IO.DirectoryInfo dir;
            string nombreArchivo = null;
            string archivo = null;
            try
            {

                if (ConfigurationManager.AppSettings["Auditar"].Equals("S"))
                {
                    //Pregunto si el Directorio Existe

                    nombreArchivo = System.Configuration.ConfigurationManager.AppSettings["ArchivoLog"];
                    nombreArchivo = nombreArchivo.Replace("|dd", DateTime.Now.ToString("dd"));
                    nombreArchivo = nombreArchivo.Replace("|MM", DateTime.Now.ToString("MM"));
                    nombreArchivo = nombreArchivo.Replace("|yyyy", DateTime.Now.ToString("yyyy"));
                    nombreArchivo = nombreArchivo.Replace("|HH", DateTime.Now.ToString("HH"));

                    dir = new DirectoryInfo(Path.GetDirectoryName(nombreArchivo));
                    archivo = Path.Combine(dir.FullName, nombreArchivo);

                    if (!(dir.Exists)) dir.Create();

                    FileStream objStream = new FileStream(archivo, FileMode.Append, FileAccess.Write);
                    TextWriterTraceListener objTraceListener = new TextWriterTraceListener(objStream);
                    Trace.Listeners.Add(objTraceListener);
                    Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss:fff") + " " + tipo + " " + datos.ToString());

                    Trace.Flush();
                    Trace.Close();

                    objStream.Close();

                }
            }
            catch (Exception ex)
            {
                //GrabaEventLog("clsError", "Graba_log", -1000, ex.Message);
            }
        }
    }

}