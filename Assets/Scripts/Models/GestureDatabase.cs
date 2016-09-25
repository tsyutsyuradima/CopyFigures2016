using System.Xml;
using System.Xml.Serialization;
using CopyFigure2016.Models;
using System.Collections.Generic;
using System.IO;

namespace Assets.Scripts.Models
{
    [XmlRoot("GestureDatabase")]
    public class GestureDatabase
    {
        [XmlArray("GestureObjects"), XmlArrayItem("GestureObject")]
        public List<GestureObject> Templates = new List<GestureObject>();

        public void Save(string path)
        {
            var serializer = new XmlSerializer(typeof(GestureDatabase));
            using (var stream = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(stream, this);
            }
        }

        public static GestureDatabase Load(string path)
        {
            var serializer = new XmlSerializer(typeof(GestureDatabase));
            using (var stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                return serializer.Deserialize(stream) as GestureDatabase;
            }
        }
    }
}
