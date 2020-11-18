using System;
using System.Collections.Generic;
using System.Text;
using CryptoApp.Models.Entities.Base;

namespace CryptoApp.Models.Entities
{
    public class CryptoCoin : EntityRecord
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double CurrentPrice { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
