using System;
using System.Xml.Serialization;

namespace CPR
{
    [Serializable]
    public class SerializableMenuItem
    {
        [XmlElement("Identifier")]
        public Guid Identifier { get; set; }
        [XmlElement("copyPasta")]
        public string copyPasta { get; set; }

        [XmlElement("titulo")]
        public string titulo { get; set; }

        public SerializableMenuItem()
        {

        }

        public SerializableMenuItem(Guid guid)
        {
            this.Identifier = guid;
        }

        public SerializableMenuItem(string titulo, string texto)
        {
            this.titulo = titulo;
            this.copyPasta = texto;
        }
    }
}
