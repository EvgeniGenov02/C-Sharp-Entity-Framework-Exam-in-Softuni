using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.Data.Models
{
    public class PropertyCitizen
    {
        [ForeignKey(nameof(PropertyId))]
        [Required]
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }

        [ForeignKey(nameof(CitizenId))]
        [Required]
        public int CitizenId { get; set; }
        public virtual Citizen Citizen { get; set; }
    }
}
