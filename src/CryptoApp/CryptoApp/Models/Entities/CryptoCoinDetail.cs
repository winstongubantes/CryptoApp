using System;
using System.Collections.Generic;
using System.Text;
using CryptoApp.Models.Entities.Base;

namespace CryptoApp.Models.Entities
{
    public class CryptoCoinDetail : EntityRecord
    {
        public string Name { get; set; }
        public string LargeImage { get; set; }
        public string Symbol { get; set; }
        public double CurrentPrice { get; set; }
        public string Description { get; set; }
    }
}
