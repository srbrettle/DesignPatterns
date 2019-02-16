namespace DesignPatterns.StrategyPattern
{
    public interface IBillingStrategy
    {
        double GetActPrice(double rawPrice);
    }
}
