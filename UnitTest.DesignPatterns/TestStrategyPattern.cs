using DesignPatterns.StrategyPattern;
using Xunit;

namespace UnitTest.DesignPatterns
{
    public class TestStrategyPattern
    {
        [Fact]
        public void Test_Execute()
        {
            // Prepare strategies
            IBillingStrategy normalStrategy = new NormalStrategy();
            IBillingStrategy happyHourStrategy = new HappyHourStrategy();

            Customer firstCustomer = new Customer(normalStrategy);

            // Normal billing
            firstCustomer.Add(1.0, 1);

            // Start Happy Hour
            firstCustomer.Strategy = happyHourStrategy;
            firstCustomer.Add(1.0, 2);

            // New Customer
            Customer secondCustomer = new Customer(happyHourStrategy);
            secondCustomer.Add(0.8, 1);            

            // End Happy Hour
            secondCustomer.Strategy = normalStrategy;
            secondCustomer.Add(1.3, 2);
            secondCustomer.Add(2.5, 1);

            // Check calculated bill
            Assert.Equal(2.0, firstCustomer.GetCurrentBill());
            Assert.Equal(5.5, secondCustomer.GetCurrentBill());

            // The Customers pay, clear bill
            firstCustomer.PrintBill();
            secondCustomer.PrintBill();

            // Check bill cleared
            Assert.Equal(0, firstCustomer.GetCurrentBill());
            Assert.Equal(0, secondCustomer.GetCurrentBill());
        }
    }
}
