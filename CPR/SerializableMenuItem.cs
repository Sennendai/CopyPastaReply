using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CPR
{
    [Serializable]
   public class SerializableMenuItem 
    {
        [XmlElement("copyPasta")]
        public string copyPasta;

        [XmlElement("titulo")]
        public string titulo;

        public SerializableMenuItem()
        {
            
        }

        public SerializableMenuItem(string titulo, string texto)
        {
            this.titulo = titulo;
            this.copyPasta = texto;
        }
    }
}
