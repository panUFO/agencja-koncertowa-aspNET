using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace agencja.Validators
{
    public class isPesel : ValidationAttribute
    {
        public string Plec { get; private set; }

        public isPesel()
        {
            Plec = null;
        }

        public isPesel(string plec)
        {
            Plec = plec;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string errorMessage;
            string pesel;

            if (validationContext.DisplayName == null)
                errorMessage = "Numer pesel niepoprawny!";
            else
                errorMessage = FormatErrorMessage(validationContext.DisplayName);

            if (value == null)
                return ValidationResult.Success;

            if (value is string)
                pesel = value.ToString();
            else
                return new ValidationResult("Podaj cyfry!");

            if (pesel.Length != 11)
                return new ValidationResult(errorMessage);

            int[] weight = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int k = 0;

            for (int i = 0; i < pesel.Length; i++)
            {
                int temp;
                if (!Int32.TryParse(pesel[i].ToString(), out temp))
                    return new ValidationResult(errorMessage);
                if (i + 1 == pesel.Length)
                {
                    if ((10 - k % 10) % 10 != temp)
                        return new ValidationResult(errorMessage);
                }
                else
                    k += temp * weight[i];
            }

            if (Plec != null)
            {
                int n = Convert.ToInt32(pesel[9].ToString());
                switch (Plec)
                {
                    case "k":
                        if (n % 2 != 0)
                            return new ValidationResult("Nie jesteś kobietą.");
                        break;

                    case "m":
                        if (n % 2 != 1)
                            return new ValidationResult("Nie jesteś mężczyzną.");
                        break;

                    default:
                        var plecInfo = validationContext.ObjectType.GetProperty(Plec);
                        var plecValue = (string)plecInfo.GetValue(validationContext.ObjectInstance, null);

                        switch (plecValue)
                        {
                            case "k":
                                if (n % 2 != 0)
                                    return new ValidationResult("Nie jesteś kobietą.");
                                break;

                            case "m":
                                if (n % 2 != 1)
                                    return new ValidationResult("Nie jesteś mężczyzną.");
                                break;
                        }
                        break;
                }
            }
            return ValidationResult.Success;
        }
    }

}
