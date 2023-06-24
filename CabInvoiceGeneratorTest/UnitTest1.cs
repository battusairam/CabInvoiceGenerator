using CabInvoiceGenerator;

namespace CabInvoiceGeneratorTest
{
  //  [TestClass]
    public class UnitTest1
    {
        //[TestMethod]

        InvoiceGenerator invoiceGenerator = null;

        public void GivenDistanceAndTimeSouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            double fare=invoiceGenerator.CalculateFare(distance, time);
            double Expected = 25;
            Assert.AreEqual(Expected, fare);
        }
    }
}