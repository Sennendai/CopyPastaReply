using CPR.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Utilities.Clases.XML;

namespace CPR.Utilidades
{
    public class UtilidadesGenerales
    {
        public static void GuardarDocumento(List<SerializableMenuItem> elementos)
        {
            string elementosXML = SerializerXML.getObjectSerialized(elementos);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(elementosXML);
            doc.Save(Resources.archivoElementos);
        }

        public static List<SerializableMenuItem> CargarDocumento(List<SerializableMenuItem> elementos)
        {
            if (ExisteArchivo())
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Path.Combine(Environment.CurrentDirectory, Resources.archivoElementos));
                string resultado = doc.InnerXml;

                if (resultado != null)
                {
                    var elementosXML = SerializerXML.Deserialize_Opcion1<List<SerializableMenuItem>>(resultado);
                    if (elementosXML.Count() != 0)
                    {
                        elementos = elementosXML;
                    }
                }
            }
            else
            {
               GuardarDocumento(elementos);
            }

            return elementos;
        }

        private static bool ExisteArchivo()
        {
            return File.Exists(Path.Combine(Environment.CurrentDirectory, Resources.archivoElementos));
        }

    }
}
