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
    public class Citizen
    {
        public Citizen()
        {
            this.PropertiesCitizens  = new List<PropertyCitizen>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValdationConst.CitizenFirstNameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(ValdationConst.CitizenLastNameMaxLenght)]
        public string LastName  { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public MaritalStatus MaritalStatus { get; set; }

        public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; }
    }
}
