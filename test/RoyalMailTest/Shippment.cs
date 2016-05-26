

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoyalMailTest
{
    [TestClass]
    public sealed class Shippment
    {

        [TestMethod]
        public void AddShippment() {

            //Arrange
            RoyalMail.Call.Shipment shipmentcall 
                = new RoyalMail.Call.Shipment();

            //Act
            using (RoyalMail.Api api = new RoyalMail.Api())
            {
                api.CreateWebRequest(shipmentcall);

                //Assert
                Assert.IsTrue(api.Status == RoyalMail.Api.StatusType.OK);
            }
        }
    }
}
