using Exceptions.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.Entities
{
    internal class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation() { }
        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            if (checkIn > checkOut)
            {
                throw new DomainException("The check-out date must be after check-in date.");
            }

            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration()
        {
            return CheckOut.Subtract(CheckIn).Days;
        }

        public void UpdateDates(DateTime checkin, DateTime checkout)
        {
            try
            {
                if(checkin > checkout)
                {
                    throw new DomainException("The check-out date must be after check-in date.");
                }

                CheckIn = checkin;
                CheckOut = checkout;

                Console.WriteLine("Dates updated successfully.");
            }
            catch(Exception e) 
            {
                Console.WriteLine("Erro! " + e.Message);
            }
        }

        public override string ToString()
        {
            return "Room " + RoomNumber + ", " + "check-in: " + CheckIn.ToString("dd/MM/yyyy") + ", " + "check-out: " + CheckOut.ToString("dd/MM/yyyy") + ", " + Duration() + " nights.";
        }
    }
}
