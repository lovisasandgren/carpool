using Carpooling;
using System;
using System.Collections.Generic;

class Program
{
    // Skapar globala listor och variabler för att lagra data om turer och passagerare.
    public static List<string> outPutStr = new List<string>();
    public static int turns;
    public static int rounds;
    public static List<Passenger> passengersList = new List<Passenger>
            {
                // Skapar en lista med passagerare och deras arbetsplatser.
                new Passenger("Lovisa", "Umeå"),
                new Passenger("Johan", "Umeå"),
                new Passenger("Anna", "Karlstad"),
                new Passenger("Rickard", "Karlstad"),
                new Passenger("Mats", "Karlstad"),
                new Passenger("Stefan", "Karlstad"),
                new Passenger("Lena", "Karlstad"),
                new Passenger("Benny", "Norrköping"),
                new Passenger("Kenneth", "Norrköping"),
                new Passenger("Jessica", "Norrköping"),
                new Passenger("Jerker", "Göteborg"),
                new Passenger("Ralf", "Halmstad"),
                new Passenger("Christer", "Borlänge"),
                new Passenger("Niklas", "Stockholm")
            };

    public static List<Car> carsList = new List<Car> {
                // Skapar en lista med bilar.
                new Car("Alfa Romeo"),
                new Car("Austin Healey"),
                new Car("Ford Mustang"),
                new Car("Jaguar E-Type"),
                new Car("Mercedes 190SL"),
                new Car("Morris MG-C"),
                new Car("Triumph TR4")
            };
    static void Main(string[] args)
    {
        Random rnd = new Random();


        // Utför samåkningsturer tills en kombination hittas där alla passagerare blir samåkade.
        while (outPutStr.Count != 24) //24 är antalet strängar som ska finnas i arrayen outPutStr när koden kört klart rätt
        {
            // Återställer data för alla passagerare innan varje runda.
            foreach (Passenger pass in passengersList)
            {
                pass.WipePassenger();
            }

            // Skapar kopior av passagerarlistan för varje samåkningstur.
            List<Passenger> Trip1Passengers = new List<Passenger>(passengersList);
            List<Passenger> Trip2Passengers = new List<Passenger>(passengersList);
            List<Passenger> Trip3Passengers = new List<Passenger>(passengersList);

            outPutStr.Clear(); // Återställer utdata innan varje runda.
            turns = 0;

            // Utför varje samåkningstur och lagrar resultatet om alla passagerare blir samåkade.
            PerformTrip(rnd, Trip1Passengers, "Första");
            PerformTrip(rnd, Trip2Passengers, "Andra");
            PerformTrip(rnd, Trip3Passengers, "Tredje");

            if (outPutStr.Count == 24) // Om alla passagerare blir samåkade.
            {
                foreach (string str in outPutStr)
                {
                    Console.WriteLine(str + "\n"); // Skriver ut informationen om samåkningen.
                }
            }

        }

    }

    // Utför en samåkningstur med en viss bil och en lista med passagerare.
    public static void PerformTrip(Random rnd, List<Passenger> passengersList, string tripStr)
    {
        outPutStr.Add("--------- " + tripStr + " turen---------");

        foreach (Car car in carsList)
        {

            drawCar(rnd, car, passengersList); // Ska välja vilka passagerare som hamnar i bilen
        }

        return;
    }
    // Tar in listan med passagerare för att koma fram till vilka som hamnar i bilen
    public static void drawCar(Random rnd, Car car, List<Passenger> passengersList)
    {
        bool success = false;
        bool validPassenger1 = false;
        bool validPassenger2 = false;
        while (validPassenger1 == false)
        {
            Passenger chosenPassanger1 = drawPassengers(rnd, passengersList);

            validPassenger1 = CheckPassenger1(car, chosenPassanger1, passengersList);

            if (validPassenger1 == false)
            {
                continue;
            }
            while (success == false && turns < 100)
            {
                Passenger chosenPassanger2 = drawPassengers(rnd, passengersList);

                validPassenger2 = CheckPassenger2(car, chosenPassanger1, chosenPassanger2, passengersList);

                if (validPassenger2 == true)
                {
                    success = true;
                }
            }

        }

    }
    // Kontrollerar om en passagerare kan sätta sig i en viss bil som första passagerare.
    public static Boolean CheckPassenger1(Car car, Passenger passanger, List<Passenger> passengersList)
    {

        if (!passanger.Cars.Contains(car.Name))
        {
            passanger.AddCar(car.Name);
            passengersList.Remove(passanger); // Tar bort passageraren från listan eftersom denne har hittat en bil.
            return true;
        }
        else
        {
            return false;
        }

    }

    // Kontrollerar om en passagerare kan sätta sig i en viss bil som andra passagerare.
    public static Boolean CheckPassenger2(Car car, Passenger passanger1, Passenger passanger2, List<Passenger> passengersList)
    {
        turns++;

        if (passanger1.Office != passanger2.Office)
        {
            if (!passanger1.RidePartners.Contains(passanger2.Name) && !passanger2.RidePartners.Contains(passanger1.Name))
            {
                if (!passanger2.Cars.Contains(car.Name))
                {
                    passanger2.AddCar(car.Name);
                    passengersList.Remove(passanger2); // Tar bort passageraren från listan eftersom denne har hittat en bil.
                    passanger1.AddRidePartner(passanger2.Name); //Passagerarna läggs till i varandras listor för att de inte ska kunna åka med varandra igen.
                    passanger2.AddRidePartner(passanger1.Name);
                    PrintTrip(car.Name, passanger1.Name, passanger1.Office, passanger2.Name, passanger2.Office);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }
        else
        {
            return false;
        }

    }

    // Slumpmässigt väljer en passagerare från listan av passagerare.
    public static Passenger drawPassengers(Random rnd, List<Passenger> passengersList)
    {

        int num = rnd.Next(0, passengersList.Count);

        return passengersList[num];
    }
    // Skriver ut information om en samåkningstur.
    public static void PrintTrip(string car, string passenger1, string passenger1Office, string passenger2, string passenger2Office)
    {
        string passengersInCar = car + ": " + passenger1 + " (" + passenger1Office + ") och " + passenger2 + " (" + passenger2Office + ")";
        outPutStr.Add(passengersInCar);
    }

}

