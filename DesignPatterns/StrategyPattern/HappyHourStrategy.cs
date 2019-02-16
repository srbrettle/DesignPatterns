namespace DesignPatterns.StrategyPattern
{
    // Strategy for Happy hour (50% discount)
    public class HappyHourStrategy : IBillingStrategy
    {
        public double GetActPrice(double rawPrice)
        {
            return rawPrice * 0.5;
        }
    }
}
