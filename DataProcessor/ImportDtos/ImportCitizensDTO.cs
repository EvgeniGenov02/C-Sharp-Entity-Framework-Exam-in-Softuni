using Cadastre.Common;
using Cadastre.Data.Enumerations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.DataProcessor.ImportDtos
{
    public class ImportCitizensDTO
    {
        [JsonProperty("FirstName")]
        [Required]
        [StringLength(ValdationConst.CitizenFirstNameMaxLenght, MinimumLength = ValdationConst.CitizenFirstNameMinLenght)]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        [Required]
        [StringLength(ValdationConst.CitizenLastNameMaxLenght, MinimumLength = ValdationConst.CitizenLastNameMinLenght)]
        public string LastName { get; set; }

        [JsonProperty("BirthDate")]
        [Required]
        [RegularExpression(ValdationConst.RegexForBirthDateValidation)]
        public string BirthDate { get; set; }

        [JsonProperty("MaritalStatus")]
        [EnumDataType(typeof(MaritalStatus))]
        [Required]
        public string MaritalStatus { get; set; }

        [JsonProperty("Properties")]
        public int[] Properties { get; set; }
    }
}
