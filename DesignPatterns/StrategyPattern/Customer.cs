using System;
using System.Collections.Generic;

namespace DesignPatterns.StrategyPattern
{
    public class Customer
    {
        private IList<double> drinks;

        // Get/Set Strategy
        public IBillingStrategy Strategy { get; set; }

        public Customer(IBillingStrategy strategy)
        {
            this.drinks = new List<double>();
            this.Strategy = strategy;
        }

        public void Add(double price, int quantity)
        {
            drinks.Add(Strategy.GetActPrice(price * quantity));
        }

        public double GetCurrentBill()
        {
            double sum = 0;
            foreach (double i in drinks)
            {
                sum += i;
            }
            return sum;
        }

        // Payment of bill
        public void PrintBill()
        {
            double sum = GetCurrentBill();
            Console.WriteLine("Total due: " + sum);
            drinks.Clear();
        }
    }
}
