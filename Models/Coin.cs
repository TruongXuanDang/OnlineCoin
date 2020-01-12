using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCoin.Models
{
    public class Coin
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public double LastPrice { get; set; }
        public double DailyChange { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Volume { get; set; }
        public ExchangeName Exchange { get; set; }

        public enum ExchangeName { 
            Bitfinex = 1,
            Bitstamp = 2,
            Coinbase = 3
        }
    }
}