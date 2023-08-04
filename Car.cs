using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpooling
{
    internal class Car
    {
        public string Name { get; set; }
        public string Passagner1 { get; set; }
        public string Passanger2 { get; set; }
        public string Passagner1Office { get; set; }
        public string Passanger2Office { get; set; }

        public Car(string name) 
        { 
            Name = name;
        }
        public Car (string name, string passagner1, string passanger2, string passagner1Office, string passanger2Office)
        {
            Name = name;
            Passagner1 = passagner1;
            Passanger2 = passanger2;
            Passagner1Office = passagner1Office;
            Passanger2Office = passanger2Office;
        }

    }
    
}
