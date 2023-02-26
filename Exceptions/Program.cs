using Exceptions.Entities;
using Exceptions.Entities.Exceptions;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                Console.WriteLine("Room Reservation Program");
                Console.Write("Insert the room number: ");
                int room = int.Parse(Console.ReadLine());
                Console.Write("Checkin (DD/MM/YYYY): ");
                DateTime checkin = DateTime.Parse(Console.ReadLine());
                Console.Write("Checkout (DD/MM/YYYY): ");
                DateTime checkout = DateTime.Parse(Console.ReadLine());

                Reservation reservation = new(room, checkin, checkout);

                Console.WriteLine("Would you like to update? (y/n)");
                char choice = char.Parse(Console.ReadLine());

                if (choice == 'y')
                {
                    Console.Write("Please insert the new checkin date (DD/MM/YYYY): ");
                    checkin = DateTime.Parse(Console.ReadLine());
                    Console.Write("Please insert the new checkout date (DD/MM/YYYY): ");
                    checkout = DateTime.Parse(Console.ReadLine());

                    reservation.UpdateDates(checkin, checkout);
                }

                Console.WriteLine("\nReservation Details");
                Console.WriteLine("-------------------");
                Console.WriteLine(reservation.ToString());

            }
			catch (DomainException e)
			{
                Console.WriteLine("Error in reservation: " + e.Message); ;
			}
        }
    }
}