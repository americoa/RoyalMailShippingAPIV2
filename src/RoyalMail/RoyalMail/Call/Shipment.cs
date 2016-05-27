
using System;

namespace RoyalMail.Call
{
    public sealed class Shipment: Call.Base
    {
        string _soapCallShipment = "createShipment";

        private createShipmentRequest CreateCall() {

            createShipmentRequest req = new createShipmentRequest()
            {
                integrationHeader = new integrationHeader()
                {
                    identification = new identificationStructure()
                    {
                        applicationId = "yourid",
                        transactionId = @"1231354654",
                    }
                },
                requestedShipment = new requestedShipment()
                {
                    shipmentType = new referenceDataType() { code = "Delivery" },
                    serviceOccurrence = "1",
                    serviceType = new referenceDataType() { code = "T" },
                    serviceOffering = new serviceOfferingType() { serviceOfferingCode = new referenceDataType() { code = "TRM" } },
                    shippingDate = DateTime.Now,
                    recipientContact = new contact()
                    {
                        name = "BOB",
                        complementaryName = "Department 98",
                        telephoneNumber = new telephoneNumber()
                        {
                            countryCode = "0044",
                            telephoneNumber1 = "07801123456"
                        },
                        electronicAddress = new digitalAddress()
                        {
                            electronicAddress = "tom.smith@royalmail.com"
                        }

                    },
                    recipientAddress = new address()
                    {
                        addressLine1 = "44-46 Morningside Road",
                        postTown = "Edinburgh",
                        postcode = "EH10 4BF",
                        country = new countryType()
                        {
                            countryCode = new referenceDataType() { code = "GB" }
                        }
                    },
                    items = new item[]
                        {
                           new item()
                           {
                               numberOfItems = "1",
                               weight = new dimension()
                               {
                                   unitOfMeasure = new unitOfMeasureType() {unitOfMeasureCode = new referenceDataType() { code = "g" }  },
                                   value = 100
                               },


                           }
                        },
                    customerReference = "nasldhasig",
                    senderReference = "kjhskjadhasd",
                }
            };

            return req;
        }

        public override string GetSerializedObject()
        {
            return RoyalMail.Common.tools.SerializeObject(CreateCall());
        }

        public override string SoapCall()
        {
            return _soapCallShipment;
        }
    }
}
