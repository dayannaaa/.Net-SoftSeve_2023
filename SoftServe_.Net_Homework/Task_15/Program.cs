using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Xml.Linq;

namespace Task_15
{

    class Exchange
    {
        public decimal CurrentRate { get; private set; }
        public decimal MaxRate { get; private set; }
        public decimal MinRate { get; private set; }

        public event EventHandler RateReachedMax;
        public event EventHandler RateReachedMin;

        public Exchange(decimal initialRate)
        {
            CurrentRate = initialRate;
            MaxRate = initialRate;
            MinRate = initialRate;
        }

        public void SimulateRateChange(decimal rateChange)
        {
            CurrentRate += rateChange;

            if (CurrentRate > MaxRate)
            {
                MaxRate = CurrentRate;
                RateReachedMax?.Invoke(this, EventArgs.Empty);
            }
            else if (CurrentRate < MinRate)
            {
                MinRate = CurrentRate;
                RateReachedMin?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    class Trader
    {
        private decimal _currencyAmount;

        public Trader(decimal initialCurrencyAmount)
        {
            _currencyAmount = initialCurrencyAmount;
        }

        public void HandleRateChange(object sender, EventArgs e)
        {
            var exchange = (Exchange)sender;
            var newRate = exchange.CurrentRate;

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var exchange = new Exchange(7);

            var trader1 = new Trader(250);
            var trader2 = new Trader(500);

            exchange.RateReachedMax += trader1.HandleRateChange;
            exchange.RateReachedMax += trader2.HandleRateChange;

            exchange.SimulateRateChange(0.1m);
            exchange.SimulateRateChange(-0.05m);
            exchange.SimulateRateChange(0.2m);

            Console.WriteLine($"Current rate: {exchange.CurrentRate}");
            Console.WriteLine($"Max rate: {exchange.MaxRate}");
            Console.WriteLine($"Min rate: {exchange.MinRate}");
        }
    
    }
}