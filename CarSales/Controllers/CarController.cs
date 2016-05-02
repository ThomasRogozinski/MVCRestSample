using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using Newtonsoft.Json;

using CarSales.Models;
using CarSales.Services;

namespace CarSales.Controllers
{
    public class CarController : Controller {

        private CarRepository carRepository;

        public CarController() {
            this.carRepository = new CarRepository();
        }
        
        public ActionResult Index() {
            try {
                Car[] cars = carRepository.GetCars();
                return View(cars);
            } catch (Exception ex) {
                ViewBag.Message = "Exception: " + ex.Message;
                return View("Error");
            }
        }

        public ActionResult Details(int id) {
            try {
                //find a car with given id
                Car displayedCar = null;

                // Get the list of cars
                Car[] cars = carRepository.GetCars();

                // Search cars for id
                foreach (Car car in cars) {
                    // If the car's Id matches
                    if (car.Id == id) {
                        displayedCar = car;
                        // No need to further run the loop
                        break;
                    }
                }
                if (displayedCar != null) {
                    if (HttpContext.Request.RequestType == "POST") {
                        // Request is Post type; Enquiry Submit
                        return RecordEnquiry(displayedCar);
                    } else {
                        return View(displayedCar);
                    }
                } else {
                    throw new Exception("Missing car #" + id);
                }
            } catch (Exception ex) {
                ViewBag.Message = "Exception: " + ex.Message;
                return View("Error");
            }
        }

        private ActionResult RecordEnquiry(Car car) {
            // Save client details to the disk
            EnquiryRecorder er = new EnquiryRecorder();
            er.Name = Request.Form["name"];
            er.Email = Request.Form["email"];
            er.SelectedCar = car;

            if (er.Name != "" && er.Email != "") {
                er.Record();

                // Add the details to the View
                Response.Redirect("~/Car/Thanks");
                return View(car);
            } else {
                ViewBag.Message = "Missing Information";
                return View(car);
            }
        }

        public ActionResult Thanks() {
            return View("");
        }
    }
}