using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Facturama;
using Facturama.Models;
using Facturama.Models.Complements;
using Facturama.Models.Request;

namespace APIFacturama.Controllers
{
    public class CfdiController : ApiController
    {
        /*
         * Obtener todos los registros.
         */
        public List<string> Get()
        {
            var facturama = new FacturamaApiMultiemisor("pruebas", "pruebas2011");

            var cfdDontknow = facturama.Cfdis.List();

            List<string> lines = new List<string>();


            foreach (Facturama.Models.Response.CfdiSearchResults element in cfdDontknow)
            {
                lines.Add(element.ToString());
                lines.Add("{" + "Id:" + element.Id + ", Rfc:" + element.Rfc + ", Folio:" + element.Folio + ", Fecha:" + element.Date + ", Activo:" + element.Id + ", Impuesto:" + element.TaxName + "}");
            }

            return lines;
        }

        /*
         * Obtener registro por Id.
         */
        public string Get(string id)
        {
            var facturama = new FacturamaApiMultiemisor("pruebas", "pruebas2011");

            var cfdDontknow = facturama.Cfdis.List();
            

            foreach (Facturama.Models.Response.CfdiSearchResults element in cfdDontknow)
            {

                if (element.Id.Equals(id))
                {
                    return "{" + "Id:" + element.Id + ", Rfc:" + element.Rfc + ", Folio:" + element.Folio + ", Fecha:" + element.Date + ", Activo:" + element.Id + ", Impuesto:" + element.TaxName + "}";
                }
            }
            return "No existe Cfdi con este Id";

        }

    }
}
