﻿using CryptoApp.Models.Entities.Base;

namespace CryptoApp.Models
{
    public class CryptoCoinDetail
    {
        public string Name { get; set; }
        public string LargeImage { get; set; }
        public string Symbol { get; set; }
        public double CurrentPrice { get; set; }
        public string Description { get; set; }
    }
}
