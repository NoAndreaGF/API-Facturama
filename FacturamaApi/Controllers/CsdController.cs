using Facturama.Models.Complements;
using Facturama.Models.Request;
using Facturama;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FacturamaApi.Controllers
{
    public class CsdController : ApiController
    {
        public dynamic Post(string id)
        {
            var facturama = new FacturamaApiMultiemisor("Usuario54332", "Facturama123456");

            var cssd = new Csd
            {
                Rfc = "GAGG851016SV5",
                Certificate = "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",
                PrivateKey = "MIIFDjBABgkqhkiG9w0BBQ0wMzAbBgkqhkiG9w0BBQwwDgQIAgEAAoIBAQACAggAMBQGCCqGSIb3DQMHBAgwggS8AgEAMASCBMhPVNhByJXyjTkTTN/M9dax2DRHZs6BkZFPcOrcBW2ihWbXPjc0PcMswdW1uT0pWL9ZKmd9YHhSqKnJmRn625NptbwvcPTm5kesru6ou38nMs9/kL4gpfd0SxCJY4BzZsNxbIMMzRDq7c8Z2gx9PYt+TRdF53WywevhSVU2cmGKSFkCftCUu7Xw3ZKySF1PlPBT9P7iXGEbx6ZAnK92sbbsqNSbqtn5/7I1rpjhVV91Ar3lry+6/S/w6iLmDyzqNhIWXjFuarXLYEp1arQsRYSTXWJBl8V2/ezh8jF5ogbN5RvauORwXBUQ1zAUfw19ZQvgtt5zN3E5BUXbtZJWV1eltXvs80BTLMoW0Awr3d+htRypbGImEEC8e5pZnZCVFMMCMobJUzWyb2miYYwNf2P80XS7MoM3tbtwBZs0IIFZPCbeUu6nvAXl7GXCdJXmmnmcPbQUL0FXWHda9C17LrkdlYXJ7IZrel7OqssfqC1VfxFggBcljDvr2Gz6GjZIKOp2la0qkuvTJ/dolB+CNC0ZUYkG5RItM13xWgAvRlFNbaBodbwv8gyZIZvvuzNZWj/fK3mrkv+pXbnUebwqA2XFljDkhMhZ+VWfd5tXb40V8/KgGjGntITWrg6GdPFmvXsW504pZp6lbH7c8NTIRDzrTOcLlKK+GB4BNdKyzT6b1I0YHMZwZrPMH18nuzagAWUSsQ5rcBKGlu6Ccf8nquyDl2sn36+dV6o5Uyr1+s2Wdh74Ry6HSZwbr6EABoBJb1ETSdu11IPpyswYsem6xOtpGlqkS9dRln7pZOysgT5vAm6EMZYzHEVwWyHmzzA2B9eRUirtZVsmK+TUz2VS1rcr6PDW0g2BGIEgu/SJ3uD3j1vITqeJoDHMrje8gEXDF7FmAePURw1O1IEw2lfEcJdDMy4nVTM3+jpGIjOwrDRyIZEPCBW6ZlzhH+fqqG9Gr41Ja/U2Z5Qm0yNfBKHJXPL+idNSA61slS1Oj0+JNI74jJ4kjw4yzF+o7ky+3lwMJkc5kaD1idEnS6ksx9Lw7aG2JUks//h7iiSbTyI7xz/xmKF1pD5ta3CxRv2ZuiXOl+eWEZfovZV6EUvEfqqilSFsJI1CI2QpeetibfQV5K5CgoU0HaaOtgkUCJLw9w+gpCePHhqobKDeHyEAlyuFFybIssnHqrpgMETtu3+Kx5wOJoR1K83OiUGIdhaF4Moq98L9CnQt2a8Cu4iGBsOFIyOQS3INEgvJ8i+4dNyXGGw7x0MsMz9Qbs3S7YiaNSjJ1jxy2HEodn8TkZd5XkBzCNPWGkbz/VHKdJplukOkwbNzNj2dXJT2+vcNf2rjOKU7OTyMDUzYk8ptV7zBkYj4oJ5fGcLWQRCjvARts0Kf4Le59WqIOEd0jWxUE2Z4LvCLrtIoNvSWJWgHrnbCI8VBItPrQJ88mp1+TorUaLTda/B1WmIp18VdroJIm9tKEkgWAhsbRR2dNNVnKyVch958NBH8vBbsEA98/BT0OiUMmCBF0JGKQqlnKS/OHVVksgpyFIjp+5NEI/xa2T39TdskEojjBgV4lhxJYq9b6o9EzmxCchHnAIOe+M7g5QY/ebp645KxhyisUuP7EtNukFAVOcNnwyvqLTuqq3Q=",
                PrivateKeyPassword = "03080100",
            };

            try
            {
                var csdc = facturama.Csds.Create(cssd);
                return csdc;
            }
            catch (FacturamaException ex)
            {
                Console.WriteLine(ex.Message);
                return (ex.Message);

            }
            catch (Exception ex)
            {
                return ($"Error inesperado: ", ex.Message);
            }
        }
    }
}
