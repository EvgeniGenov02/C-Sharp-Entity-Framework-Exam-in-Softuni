using Cadastre.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("Property")]
    public class InportPropertiesDTO
    {
        [XmlElement("PropertyIdentifier")]
        [Required]
        [StringLength(ValdationConst.PropertyIdentifierMaxLenght, MinimumLength = ValdationConst.PropertyIdentifierMinLenght)]
        public string PropertyIdentifier { get; set; }

        [XmlElement("Area")]
        [Required]
        [Range(ValdationConst.PropertyAreaMinLenght, ValdationConst.PropertyAreaMaxLenght)]
        public int Area { get; set; }

        [XmlElement("Details")]
        [StringLength(ValdationConst.PropertyDetailsMaxLenght, MinimumLength = ValdationConst.PropertyDetailsMinLenght)]
        public string Details { get; set; }

        [XmlElement("Address")]
        [Required]
        [StringLength(ValdationConst.PropertyAddressMaxLenght, MinimumLength = ValdationConst.PropertyAddressMinLenght)]
        public string Address { get; set; }

        [XmlElement("DateOfAcquisition")]
        [Required]
        [RegularExpression(ValdationConst.PropertyRegxForDateOfAcquisition)]
        public string DateOfAcquisition { get; set; }
    }
}
