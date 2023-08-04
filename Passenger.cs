using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpooling
{
    internal class Passenger
    {

        public string Name { get; set; }
        public string Office { get; set; }
        public List<string> RidePartners = new List<string>();
        public List<string> Cars = new List<string>();

        public Passenger() { }
        public Passenger(string name, string office)
        {
            this.Name = name;
            this.Office = office;
        }

        public void AddRidePartner(string name)
        {
            RidePartners.Add(name);
            
        }


        public void AddCar(string carName)
        {
            Cars.Add(carName);

        }

        public void WipePassenger()
        {
            RidePartners.Clear();
            Cars.Clear();
        }
    }
}
