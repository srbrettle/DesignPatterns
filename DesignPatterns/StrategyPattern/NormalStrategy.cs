namespace DesignPatterns.StrategyPattern
{
    // Normal billing strategy (unchanged price)
    public class NormalStrategy : IBillingStrategy
    {
        public double GetActPrice(double rawPrice)
        {
            return rawPrice;
        }
    }
}
