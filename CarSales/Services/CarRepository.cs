using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CarSales.Models;

namespace CarSales.Services {

    public class CarRepository {

        private const string CacheKey = "CarRepository";

        public CarRepository() {
            HttpContext curContext = HttpContext.Current;

            if (curContext != null && curContext.Cache[CacheKey] == null) {
                Car[] cars = new Car[] {
                    new Car {
                        Id = 1,
                        Make = "Toyota",
                        Model = "Landcruiser",
                        Year = 2000,
                        PriceType = Car.CarPriceType.DAP,
                        Price = 2000,
                        Owner = new Car.Dealer{
                            Email = "dealer@dealer.com",
                            Comments = "Toyota Dealer Comments",
                            ABN = "ABN Number XXX",
                        },
                    },
                    new Car {
                        Id = 2,
                        Make = "Nissan",
                        Model = "Pathfinder",
                        Year = 2005,
                        PriceType = Car.CarPriceType.EGC,
                        Price = 1000,
                        Owner = new Car.PrivateOwner {
                            Email = "privateNissan@private.com",
                            Comments = "Private Nissan Owner Comments",
                            ContactName = "Nissan Owner Name",
                            Phone = "Nissan Owner Phone: XXXXXXX",
                        },
                    },
                    new Car {
                        Id = 3,
                        Make = "Mitsubishi",
                        Model = "Pajero",
                        Year = 2010,
                        PriceType = Car.CarPriceType.POA,
                        Price = 0,
                        Owner = new Car.PrivateOwner {
                            Email = "privateMitsubishi@private.com",
                            Comments = "Private Mitsubishi Owner Comments",
                            ContactName = "Mitsubishi Owner Name",
                            Phone = "Mitsubishi Owner Phone: YYYYYYYY",
                        },
                    },
                    new Car {
                        Id = 4,
                        Make = "Ford",
                        Model = "Territory",
                        Year = 2009,
                        PriceType = Car.CarPriceType.DAP,
                        Price = 2500,
                        Owner = new Car.PrivateOwner {
                            Email = "privateFord@private.com",
                            Comments = "Private Ford Owner Comments",
                            ContactName = "Ford Owner Name",
                            Phone = "Ford Owner Phone: ZZZZZZZ",
                        },
                    }
                };
                curContext.Cache[CacheKey] = cars;
            }
        }
        
        public Car[] GetCars() {
            HttpContext curContext = HttpContext.Current;

            if (curContext != null) {
                return (Car[])curContext.Cache[CacheKey];
            }

            return null;
        }
        
        public bool SaveCar(Car car) {
            var curContext = HttpContext.Current;

            if (curContext != null) {
                try {
                    var currentData = ((Car[])curContext.Cache[CacheKey]).ToList();
                    currentData.Add(car);
                    curContext.Cache[CacheKey] = currentData.ToArray();

                    return true;
                } catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}