﻿using System;

namespace CryptoApp.Models
{
    public class CryptoCoin
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double CurrentPrice { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
