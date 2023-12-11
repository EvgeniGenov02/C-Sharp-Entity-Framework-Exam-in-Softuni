using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ExportDtos
{
    public class ExportedProperty
    {
        [XmlAttribute("postal-code")]
        public string PostalCode { get; set; }
        public string PropertyIdentifier { get; set; }
        public int Area { get; set; }
        public string DateOfAcquisition { get; set; }
    }
}
