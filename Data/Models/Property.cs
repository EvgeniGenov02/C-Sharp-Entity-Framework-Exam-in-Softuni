using Cadastre.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cadastre.Data.Models
{
    public class Property
    {
        public Property()
        {
            this.PropertiesCitizens = new List<PropertyCitizen>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValdationConst.PropertyIdentifierMaxLenght)]
        public string PropertyIdentifier { get; set; }

        [Required]
        public int Area { get; set; }


        [MaxLength(ValdationConst.PropertyDetailsMaxLenght)]
        public string Details { get; set; }


        [Required]
        [MaxLength(ValdationConst.PropertyAddressMaxLenght)]
        public string Address { get; set; }

        [Required]
        public DateTime DateOfAcquisition { get; set; }



        [Required]
        [ForeignKey(nameof(DistrictId))]
        public int DistrictId { get; set; }

        public District District { get; set; }

        public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; }


    }
}
