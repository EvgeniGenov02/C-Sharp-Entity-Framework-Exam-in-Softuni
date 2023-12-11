using Cadastre.Data;
using Cadastre.DataProcessor.ExportDtos;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Xml;
using Cadastre.Data.Enumerations;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            var propertiesWithOwners = dbContext.Properties
          .Where(p => p.DateOfAcquisition >= new DateTime(2000, 1, 1))
          .OrderByDescending(p => p.DateOfAcquisition)
          .ThenBy(p => p.PropertyIdentifier)
          .Select(p => new
          {
              PropertyIdentifier = p.PropertyIdentifier,
              Area = p.Area,
              Address = p.Address,
              DateOfAcquisition = p.DateOfAcquisition,
              Owners = p.PropertiesCitizens
                  .Select(pc => new
                  {
                      LastName = pc.Citizen.LastName,
                      MaritalStatus = ((MaritalStatus)pc.Citizen.MaritalStatus).ToString()
                  })
                  .OrderBy(owner => owner.LastName) 
                  .ToList()
          })
          .ToList();

            var formattedProperties = propertiesWithOwners
                .Select(p => new
                {
                    p.PropertyIdentifier,
                    p.Area,
                    p.Address,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                    Owners = p.Owners
                })
                .ToList();

            var json = JsonConvert.SerializeObject(formattedProperties, Newtonsoft.Json.Formatting.Indented);

            return json;
        
    }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            var result = dbContext.Properties
        .Where(p => p.Area >= 100)
        .OrderByDescending(p => p.Area)
        .ThenBy(p => p.DateOfAcquisition)
        .Select(p => new ExportedProperty
        {
            PostalCode = p.District.PostalCode,
            PropertyIdentifier = p.PropertyIdentifier,
            Area = p.Area,
            DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy")
        })
        .ToList();

            var exportedProperties = new ExportedProperties
            {
                Properties = result
            };

            var xmlSerializer = new XmlSerializer(typeof(ExportedProperties));

            
            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true }))
                {
                    xmlSerializer.Serialize(xmlWriter, exportedProperties, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));
                }
                return stringWriter.ToString();
            }
        }
    }
}
