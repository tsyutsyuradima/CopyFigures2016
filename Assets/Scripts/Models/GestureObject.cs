using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

namespace CopyFigure2016.Models
{
    public class GestureObject
    {
        [XmlAttribute("name")]
        public string Name;
        [XmlArray("PointArray"), XmlArrayItem("Point")]
        public List<Vector3> PointArray;
    }
}
