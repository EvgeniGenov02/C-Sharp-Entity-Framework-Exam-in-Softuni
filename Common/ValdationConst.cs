using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.Common
{
    public class ValdationConst
    {
        //District 
        public const int DistrictNameMinLenght = 2;
        public const int DistrictNameMaxLenght = 80;
        public const string DistrictRegxForPostalCode = @"^[A-Z]{2}-\d{5}$";
       

        //Property
        public const int PropertyIdentifierMinLenght = 16;
        public const int PropertyIdentifierMaxLenght = 20;

        public const int PropertyDetailsMaxLenght = 500;
        public const int PropertyDetailsMinLenght = 5;

        public const int PropertyAddressMaxLenght = 200;
        public const int PropertyAddressMinLenght = 5;

        public const int PropertyAreaMinLenght = 0;
        public const int PropertyAreaMaxLenght = int.MaxValue;

        public const string PropertyRegxForDateOfAcquisition = @"^\d{2}/\d{2}/\d{4}$";


        //Citizen 
        public const int CitizenFirstNameMinLenght = 2;
        public const int CitizenFirstNameMaxLenght = 30;


        public const int CitizenLastNameMinLenght = 2;
        public const int CitizenLastNameMaxLenght = 30;

        public const string RegexForBirthDateValidation = @"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-\d{4}$";





    }
}
