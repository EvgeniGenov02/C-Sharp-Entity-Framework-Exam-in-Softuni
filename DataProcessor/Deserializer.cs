namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ImportDtos;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
  

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportDistrictsDTO[])
            , new XmlRootAttribute("Districts"));

            using var reader = new StringReader(xmlDocument);

            ImportDistrictsDTO[] districtsDTO =
            (ImportDistrictsDTO[])xmlSerializer.Deserialize(reader);

            List<District> validDistricts = new List<District>();

            foreach (var districtDto in districtsDTO)
            {
                if (!IsValid(districtDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                District district = new District()
                {
                    Name = districtDto.Name,
                    PostalCode = districtDto.PostalCode,
                    Region = (Region)Enum.Parse(typeof(Region), districtDto.Region)
                };
                if (validDistricts.Any(d => d.Name == district.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                foreach (var propertie in districtDto.Properties)
                {
                    if (!IsValid(propertie))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Data.Models.Property property = new Data.Models.Property()
                    {
                        PropertyIdentifier = propertie.PropertyIdentifier,
                        Area = propertie.Area,
                        Details = propertie.Details,
                        Address = propertie.Address,
                        DateOfAcquisition = DateTime.ParseExact(propertie.DateOfAcquisition, "dd/MM/yyyy", null)
                    };

                    district.Properties.Add(property);
                }
                validDistricts.Add(district);
                sb.AppendLine(String.Format(SuccessfullyImportedDistrict, districtDto.Name , districtDto.Properties.Length));
            }

            dbContext.AddRange(validDistricts);

            dbContext.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            StringBuilder sb = new StringBuilder();

            ImportCitizensDTO[] CitizensDTO = JsonConvert.DeserializeObject<ImportCitizensDTO[]>(jsonDocument);

            List<Citizen> validCitizens = new List<Citizen>();  

            foreach (var citizenDTO in CitizensDTO)
            {
                if (!IsValid(citizenDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Citizen citizen = new Citizen()
                {
                    FirstName = citizenDTO.FirstName,
                    LastName = citizenDTO.LastName,
                    BirthDate = DateTime.ParseExact(citizenDTO.BirthDate, "dd-MM-yyyy", null),
                    MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), citizenDTO.MaritalStatus) 
                };

                foreach (var property in citizenDTO.Properties)
                {
                    PropertyCitizen propertyCitizen = new PropertyCitizen()
                    {
                        PropertyId = property,
                        Citizen = citizen,
                    };

                    dbContext.Add(propertyCitizen);
                }
                

                sb.AppendLine(String.Format("Succefully imported citizen - {0} {1} with {2} properties."
                  , citizen.FirstName, citizen.LastName, citizenDTO.Properties.Length));

                validCitizens.Add(citizen);
            }

            dbContext.AddRange(validCitizens);

            dbContext.SaveChanges();
            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
