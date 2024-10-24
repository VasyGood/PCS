namespace Product
{

    enum Place : byte
    {
        Window = 0,
        Pass = 1,
        Exit = 2,
        Deep = 3
    }

    struct Reserved
    {
        public Reservation? Reservation;
        public bool IsReserved;

        public Reserved() 
        {
            Reservation = null;
            IsReserved = false;
        }

        public Reserved(Reservation reservation)
        {
            Reservation = reservation;
            IsReserved = true;
        }
    }

    class Table
    {
        public int ID;
        public Place Place;
        public int SeatsNumber;
        public Reserved[] Timetable;
        public bool active;

        public Table(int id, Place place, int seatsNumber)
        {
            ID = id;
            Place = place;
            SeatsNumber = seatsNumber;
            Timetable = new Reserved[9];
            active = false;
        }

        public void SetTableInfo(Place place, int seatsNumber)
        {
            Place = place;
            SeatsNumber = seatsNumber;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Placement: {Place}");
            Console.WriteLine($"seatsNumber: {SeatsNumber}");

            for (int i = 0; i < 9; i++)
            {
                Console.Write($"{i + 9}:00-{i + 10}:00 ");
                if (Timetable[i].IsReserved)
                {
                    Timetable[i].Reservation?.PrintLineInfo();
                }
            }
        }

        public bool IsReserved(int start, int end) {
            bool flag = false; 

            for (int i = start; i < end; i++) 
            {
                if (Timetable[i - 9].IsReserved) 
                {
                    Console.WriteLine($"This table is reserved for this time {i}:00-{i + 1}:00");
                    flag = true;
                }
            }

            return flag;
        }

        public void SetReservation(Reservation reservation)
        {
            for (int i = reservation.StartTime; i < reservation.EndTime; i++) {
                Timetable[i - 9] = new Reserved(reservation);
            }
            active = true;
        }
    }

}