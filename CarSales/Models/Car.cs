using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSales.Models {
    
    public class Car {
        
        public int Id { get; set; }

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public CarPriceType PriceType { get; set; }
        public long Price { get; set; }
        public CarOwner Owner { get; set; }

        public abstract class CarOwner {
            public string Email { get; set; }
            public string Comments { get; set; }
        }

        public class Dealer : CarOwner {
            public string ABN { get; set; }
        }

        public class PrivateOwner : CarOwner {
            public string ContactName { get; set; }
            public string Phone { get; set; }
        }

        public enum CarPriceType {
            POA,
            DAP,
            EGC,
        }
    }
}