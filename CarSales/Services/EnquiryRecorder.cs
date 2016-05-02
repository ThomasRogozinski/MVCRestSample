using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using CarSales.Models;

namespace CarSales.Services {

    public class EnquiryRecorder {

        private static string filePath = HttpContext.Current.Server.MapPath("~/App_Data/EnquiryRecorder.txt");
        private static object _locker = new object();

        public string Name { get; set; }
        public string Email { get; set; }
        public Car SelectedCar { get; set; }

        public bool Record() {
            //synchronize access to the file
            lock (_locker) {
                File.AppendAllText(filePath, String.Format("client: {0, -30} email: {1, -30} car id: {2, -5} timestamp: {3, -30:MM/dd/yy H:mm:ss}" + Environment.NewLine,
                        Name, Email, SelectedCar.Id, DateTime.Now));
            }
            return true;
        }
    }
}