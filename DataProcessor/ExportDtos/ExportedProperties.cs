using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ExportDtos
{
    [XmlRoot("Properties")]
    public class ExportedProperties
    {
        [XmlElement("Property")]
        public List<ExportedProperty> Properties { get; set; }
    }
}
