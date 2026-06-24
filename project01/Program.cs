using project01.Models;
using System.Net.NetworkInformation;

namespace project01
{
    public class Program
    {

        public static FlightContext flightContext = new FlightContext
        {
            Flights = new List<Models.Flight>(),
            Pilots = new List<Models.Pilot>(),
            Aircrafts = new List<Models.Aircraft>(),
            Bookings = new List<Models.Booking>(),
            Passengers = new List<Models.Passenger>()
        };

        public static void RegisterPassenger()
        {
            Console.WriteLine("\n Register New Passenger");

            Console.WriteLine("Enter passenger name:");
            string passengerName = Console.ReadLine();

            Console.WriteLine("Enter passenger email:");
            string passengerEmail = Console.ReadLine();

            Console.WriteLine("Enter passenger phone:");
            string passengerPhone = Console.ReadLine();

            Console.WriteLine("Enter passport number:");
            string passportNumber = Console.ReadLine();

            Console.WriteLine("Enter nationality:");
            string nationality = Console.ReadLine();

            int passengerId = flightContext.Passengers.Count + 1;

            flightContext.Passengers.Add(new Passenger
            {
                passengerId = passengerId,
                passengerName = passengerName,
                passengerEmail = passengerEmail,
                passengerPhone = passengerPhone,
                passportNumber = passportNumber,
                nationality = nationality
            }
            );
            Console.WriteLine($"Passenger registered successfully. Assigned ID: {passengerId}");
        }

        public static void AddAircraft()
        {
            Console.WriteLine("\n Add New Aircraft");

            Console.WriteLine("Enter aircraft model:");
            string aircraftModel = Console.ReadLine();

            Console.WriteLine("Enter total seats:");
            int totalSeats = int.Parse(Console.ReadLine());

            int aircraftId = flightContext.Aircrafts.Count + 1;

            flightContext.Aircrafts.Add(new Aircraft
            {
                aircraftId = aircraftId,
                model = aircraftModel,
                totalSeats = totalSeats,
                isOperational = false // default value
            }
            );

            Console.WriteLine($"Aircraft added successfully. Assigned ID: {aircraftId}");
        }
        public static void RegisterPilot()
        {
            Console.WriteLine("\n Register New Pilot");

            Console.WriteLine("Enter pilot name:");
            string pilotName = Console.ReadLine();

            Console.WriteLine("Enter pilot license number:");
            string licenseNumber = Console.ReadLine();

            Console.WriteLine("Enter pilot phone number:");
            string pilotPhone = Console.ReadLine();

            int pilotId = flightContext.Pilots.Count + 1;

            flightContext.Pilots.Add(new Pilot
            {
                pilotId = pilotId,
                pilotName = pilotName,
                licenseNumber = licenseNumber,
                pilotPhone = pilotPhone
            }
             );

            Console.WriteLine($"Pilot registered successfully. Assigned ID: {pilotId}");
        }

        public static void ViewAllFlights()
        {
            Console.WriteLine("\n All Flights:");
            foreach (Flight f in flightContext.Flights)
            {
                Console.WriteLine($"Flight ID: {f.flightId} | flightCode: {f.flightCode} | aircraftId: {f.aircraftId} | pilotId: {f.pilotId} | origin: {f.origin} | destination: {f.destination} " +
                    $"| departureTime: {f.departureTime} | departureDate: {f.departureDate} | ticketPrice: {f.ticketPrice} | availableSeats: {f.availableSeats} | status: {f.status}");
            }
        }

        public static void ScheduleFlight()
        {
            Console.WriteLine("Available Aircraft ");

            foreach (Aircraft aircraft in flightContext.Aircrafts)
            {
                Console.WriteLine($"Aircraft ID: {aircraft.aircraftId} | Model: {aircraft.model} | Total Seats: {aircraft.totalSeats} | Is Operational: {aircraft.isOperational}");
            }

            Console.WriteLine("Enter aircraft ID:");
            int aircraftId = int.Parse(Console.ReadLine());

            Aircraft selectedAircraft = flightContext.Aircrafts.FirstOrDefault(a => a.aircraftId == aircraftId && a.isOperational == true);

            if (selectedAircraft == null)
            {
                Console.WriteLine("Invalid aircraft ID.");
                return;
            }

            foreach (Pilot pilot in flightContext.Pilots)
            {
                Console.WriteLine($"Pilot ID: {pilot.pilotId} | Name: {pilot.pilotName} | License Number: {pilot.licenseNumber} | Phone: {pilot.pilotPhone}");
            }
            Console.WriteLine("Enter pilot ID:");
            int pilotId = int.Parse(Console.ReadLine());

            bool pilotExists = flightContext.Pilots.Any(p => p.pilotId == pilotId);

            if (pilotExists == false) 
            {
                Console.WriteLine(" pilot Not Found.");
                return;
            }

            Console.WriteLine("Enter the origin :");
            string origin = Console.ReadLine();

            Console.WriteLine("Enter the destination :");
            string destination = Console.ReadLine();

            Console.WriteLine("Enter the departure Date :");
            string departureDate = Console.ReadLine();

            Console.WriteLine("Enter the departure Time :");
            string departureTime = Console.ReadLine();

            Console.WriteLine("Enter the ticket price :");
            decimal ticketPrice = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter Flight Duration:");
            string flightDuration = Console.ReadLine();

            int flightId = flightContext.Flights.Count + 1;

            flightContext.Flights.Add(new Flight
            {
                flightId = flightId, //sys generate 
                flightCode = $"FL{flightId:D4}", //sys generate
                aircraftId = aircraftId,
                pilotId = pilotId,
                origin = origin,
                destination = destination,
                departureDate = departureDate,
                departureTime = departureTime,
                ticketPrice = ticketPrice,
                flightDuration = flightDuration,

                availableSeats = selectedAircraft.totalSeats,

                status = "Scheduled"
                
            }
            );

           

            Console.WriteLine("Flight scheduled successfully.");


        }

        public static void BookFlight()
        {
            Console.WriteLine("\n=== Book a Flight ===");

            Console.Write("Enter Passenger ID: ");
            int passengerId = int.Parse(Console.ReadLine());

            bool passengerExists = flightContext.Passengers.Any(p => p.passengerId == passengerId);

            if (passengerExists == false)
            {
                Console.WriteLine("Passenger not found.");
                return;
            }

            Console.Write("Enter Destination: ");
            string destination = Console.ReadLine();

            List<Flight> availableFlights = flightContext.Flights
                .Where(f => f.destination.ToLower() == destination.ToLower()
                         && f.status == "Scheduled"
                         && f.availableSeats > 0)
                .ToList();

            if (availableFlights.Count == 0)
            {
                Console.WriteLine("No available flights found.");
                return;
            }

            Console.WriteLine("\nAvailable Flights:");

            foreach (Flight f in availableFlights)
            {
                Console.WriteLine($"Flight ID: {f.flightId} | Code: {f.flightCode} | " +
                                  $"Date: {f.departureDate} | Time: {f.departureTime} | " +
                                  $"Price: {f.ticketPrice}");
            }

            Console.Write("Enter Flight ID: ");
            int flightId = int.Parse(Console.ReadLine());

            Flight selectedFlight = availableFlights
                .FirstOrDefault(f => f.flightId == flightId);

            if (selectedFlight == null)
            {
                Console.WriteLine("Flight not found.");
                return;
            }

            int bookingId = flightContext.Bookings.Count + 1;

            string seatLabel = $"S{selectedFlight.availableSeats}";

            flightContext.Bookings.Add(new Booking
            {
                bookingId = bookingId,                     // System generated
                passengerId = passengerId,                // User selected
                flightId = flightId,                      // User selected
                availableSeats = selectedFlight.availableSeats,                    // System assigned
                totalPrice = selectedFlight.ticketPrice   // System calculated
            });

            selectedFlight.availableSeats--;

            Console.WriteLine($"Booking created successfully.");
            Console.WriteLine($"Booking ID: {bookingId}");
            Console.WriteLine($"Seat Number: {seatLabel}");
            Console.WriteLine($"Total Price: {selectedFlight.ticketPrice}");
        }

        public static void CancelBooking()
        {
            Console.WriteLine("\n Cancel Booking");

            Console.WriteLine("Enter booking ID:");
            int bookingId = int.Parse(Console.ReadLine());

            Booking booking = flightContext.Bookings.FirstOrDefault(b => b.bookingId == bookingId);

            if (booking == null)
            {
                Console.WriteLine("Booking not found.");
                return;
            }


            if (booking.status == "Cancelled")
            {
                Console.WriteLine("This booking is already cancelled.");
                return;
            }

            if (booking.status == "Completed")
            {
                Console.WriteLine("Cannot cancel a completed booking.");
                return;
            }
            Flight flight = flightContext.Flights.FirstOrDefault(b => b.flightId == booking.flightId);

            if (flight == null) 
            {
            Console.WriteLine("Associated flight not found.");
                return;
            }


            flightContext.Flights.FirstOrDefault(f => f.flightId == booking.flightId).availableSeats++;

            booking.status = "Cancelled";

            Console.WriteLine("Booking cancelled successfully.");
           


        }

        public static void DepartFlight()
        {
            Console.WriteLine("\n Depart Flight");

            List<Flight> scheduledFlights = flightContext.Flights.Where(f => f.status == "Scheduled").ToList();

            foreach (Flight f in scheduledFlights)
            {
                Console.WriteLine($"Flight ID: {f.flightId} | Code: {f.flightCode} | " +
                                  $"Date: {f.departureDate} | Time: {f.departureTime} | " +
                                  $"Available Seats: {f.availableSeats}");
            }

            Console.WriteLine("Enter flight ID to depart:");
            int flightId = int.Parse(Console.ReadLine());

            Flight selectedFlight = flightContext.Flights.FirstOrDefault(f => f.flightId == flightId);

            if (selectedFlight == null) {
                Console.WriteLine("Flight not found.");
                return;
            }

            if (selectedFlight.status != "Scheduled")
            {
                Console.WriteLine("Only scheduled flights can be departed.");
                return;
            }

            selectedFlight.status = "Departed";

        }
        public static void CancelFlight()
        {
            Console.WriteLine("\n Cancel Flight");

            Console.WriteLine("Enter flight ID:");
            int flightId = int.Parse(Console.ReadLine());


        }

        public static void PassengerBookingHistory()
        {
            Console.WriteLine("\n Passenger Booking History");
        }

        public static void FlightRevenueAndLoadFactor()
        {
            Console.WriteLine("\n Flight Revenue and Load Factor");
        }


        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n Airline Management System");
                Console.WriteLine("1. Register Passenger");
                Console.WriteLine("2. Add Aircraft");
                Console.WriteLine("3. Register Pilot");
                Console.WriteLine("4. View All Flights");
                Console.WriteLine("5. Schedule Flight");
                Console.WriteLine("6. Book Flight");
                Console.WriteLine("7. Cancel Booking");
                Console.WriteLine("8. Depart Flight");
                Console.WriteLine("9. Cancel Flight");
                Console.WriteLine("10. Passenger Booking History");
                Console.WriteLine("11. Flight Revenue and Load Factor");
                Console.WriteLine("12. Exit");
                Console.WriteLine("\n Enter your choice:");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        RegisterPassenger();
                        break;
                    case "2":
                        AddAircraft();
                        break;
                    case "3":
                        RegisterPilot();
                        break;
                    case "4":
                        ViewAllFlights();
                        break;
                    case "5":
                        ScheduleFlight();
                        break;
                    case "6":
                        BookFlight();
                        break;
                    case "7":
                        CancelBooking();
                        break;
                    case "8":
                        DepartFlight();
                        break;
                    case "9":
                        CancelFlight();
                        break;
                    case "10":
                        PassengerBookingHistory();
                        break;
                    case "11":
                        FlightRevenueAndLoadFactor();
                        break;
                    case "12":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
}
