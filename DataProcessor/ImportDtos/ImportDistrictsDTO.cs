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
    [XmlType("District")]
    public class ImportDistrictsDTO
    {
        [XmlAttribute("Region")]
        [Required]
        public string Region { get; set; }

        [XmlElement("Name")]
        [Required]
        [StringLength(ValdationConst.DistrictNameMaxLenght, MinimumLength = ValdationConst.DistrictNameMinLenght)]
        public string Name { get; set; }

        [XmlElement("PostalCode")]
        [Required]
        [RegularExpression(ValdationConst.DistrictRegxForPostalCode)]
        public string PostalCode { get; set; }

        [XmlArray("Properties")]
        [Required]
        public InportPropertiesDTO[] Properties { get; set; }
    }
}
