using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using Facturama;
using Facturama.Models;
using Facturama.Models.Request;
using Facturama.Models.Complements;
using Facturama.Services;
using Microsoft.Ajax.Utilities;
using Facturama.Models.Complements.Waybill;
using Facturama.Models.Response;

namespace FacturamaApi.Controllers
{
    public class CfdiController : ApiController
    {
        FacturamaApiMultiemisor facturama = new FacturamaApiMultiemisor("pruebas", "pruebas2011");

        /*
         * Obtener todos los registros.
         */
        public dynamic Get()
        {
            var facturama = new FacturamaApiMultiemisor("Usuario54332", "Facturama123456");

            var cdfis = facturama.Cfdis.List();

            return cdfis;

        }


        /*
         * Obtener registro por Id.
         */
        public dynamic Get(string id)
        {
            var facturama = new FacturamaApiMultiemisor("Usuario54332", "Facturama123456");

            var cfdDontknow = facturama.Cfdis.Retrieve(id);

            return cfdDontknow;
        }


        public dynamic Post()
        {
            var facturama = new FacturamaApiMultiemisor("Usuario54332", "Facturama123456");

            var cfdi3 = new CfdiMulti
            {
                Serie = "R",
                Currency = "MXN",
                ExpeditionPlace = "78116",
                PaymentConditions = "CREDITO A SIETE DIASss",
                Folio = "100",
                CfdiType = CfdiType.Ingreso,
                PaymentForm = "03",
                PaymentMethod = "PUE",
                Issuer = new Facturama.Models.Request.Issuer
                {
                    FiscalRegime = "606",
                    Rfc = "GAGG851016SV5",
                    Name = "MARIA WATEMBER TORRES"
                },
                Receiver = new Facturama.Models.Request.Receiver
                {
                    FiscalRegime = "606",
                    Rfc = "FUNK671228PH6",
                    Name = "KARLA FUENTE NOLASCO",
                    CfdiUse = "P01",
                    TaxZipCode = "45435"
                },
                Items = new List<Facturama.Models.Request.Item> 
                {
                    new Facturama.Models.Request.Item {
                        ProductCode = "10101504",
                        IdentificationNumber = "EDL",
                        Description = "Estudios de viabilidad",
                        Unit = "NO APLICA",
                        UnitCode = "MTS",
                        UnitPrice = 50.0m,
                        Quantity = 2.0m,
                        Subtotal = 100.0m,
                        TaxObject = "02",
                        Taxes = new List<Facturama.Models.Request.Tax>
                        {
                            new Facturama.Models.Request.Tax
                            {
                                Total = 16.0m,
                                Name = "IVA",
                                Base = 100.0m,
                                Rate = 0.16m,
                                IsRetention = false
                            }
                        },
                        Total = 116.0m
                    },
                    new Facturama.Models.Request.Item {
                        ProductCode = "10101504",
                        IdentificationNumber = "001",
                        Description = "SERVICIO DE COLOCACION",
                        Unit = "NO APLICA",
                        UnitCode = "E49",
                        UnitPrice = 100.0m,
                        Quantity = 15.0m,
                        Subtotal = 1500.0m,
                        Discount = 0.0m,
                        TaxObject = "02",
                        Taxes = new List<Facturama.Models.Request.Tax>
                        {
                            new Facturama.Models.Request.Tax
                            {
                                Total = 240.0m,
                                Name = "IVA",
                                Base = 1500.0m,
                                Rate = 0.16m,
                                IsRetention = false
                            }
                        },
                        Total = 1740.0m
                    }
                }
            };

            try
            {
                var cfdiCreate = facturama.Cfdis.Create(cfdi3);

                return cfdiCreate;
            }
            catch (FacturamaException ex)
            {
                Console.WriteLine(ex.Message);
                return ("Estas aquí",ex.Message);

            }
            catch (Exception ex)
            {
                return ($"Error inesperado: ", ex.Message);
            }
        }
    }
}
