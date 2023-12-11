using Cadastre.Common;
using Cadastre.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.Data.Models
{
    public class District
    {
        public District()
        {
        this.Properties = new List<Property>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValdationConst.DistrictNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public Region Region { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
