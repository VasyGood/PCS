
namespace Product
{
    class Manager
    {
        public Table[] Tables = {};
        public Reservation[] Reservations = {};

        public void CreateTables(int n)
        {
            Tables = new Table[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Choose parameters for {i} table");

                Console.WriteLine("Enter a place(Window - 0, Pass - 1, Exit - 2, Deep - 3)");
                Place place = (Place)Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter seats number");
                int seatsNumber = Convert.ToByte(Console.ReadLine());

                Tables[i] = new Table(i, place, seatsNumber);
            }
        }

        public void CreateReservations(int n)
        {
            Reservations = new Reservation[n];
            for (int i = 0; i < n;)
            {
                Console.WriteLine($"Choose parameters for {i} reservation");

                Console.WriteLine("Enter a client name");
                string? clientName = Console.ReadLine();

                Console.WriteLine("Enter a client number");
                string? number = Console.ReadLine();

                Console.WriteLine("Enter a table id");
                int j = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter a start time");
                int startTime = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter a end time");
                int endTime = Convert.ToInt32(Console.ReadLine());

                if (Tables[j].IsReserved(startTime, endTime)) 
                {
                    Console.WriteLine("This table is reserved in this time. Choose another table or another time");
                    continue;
                }

                Console.WriteLine("Enter a comment(optional)");
                string? comment = Console.ReadLine();

                Reservations[i] = new Reservation(i, clientName, number, startTime, endTime, Tables[j], comment);
                
                Tables[j].SetReservation(Reservations[i]);

                i++;
            }
        }

        public void PrintTables()
        {
            foreach (var i in Tables) 
            {
                i.PrintInfo();
            }
        }

        public void PrintTablesBySeats(int seatsNumber) 
        {
            foreach (var i in Tables) 
            {
                if (i.SeatsNumber == seatsNumber)
                    i.PrintInfo();
            }
        }

        public void PrintTablesByPlace(Place place) 
        {
            foreach (var i in Tables) 
            {
                if (i.Place == place)
                    i.PrintInfo();
            }
        }

        public void PrintReservations()
        {
            foreach (var i in Reservations) 
            {
                i.PrintInfo();
            }
        }

        public void FindReservationByNumber(string last4)
        {
            foreach(var i in Reservations)
            {
                if (i.Number.EndsWith(last4))
                {
                    i.PrintInfo();
                    return;
                }
            }
            Console.WriteLine("No such reservation");
        }

        public void FindReservationByName(string name)
        {
            foreach(var i in Reservations)
            {
                if (i.ClientName == name)
                {
                    i.PrintInfo();
                    return;
                }
            }
            Console.WriteLine("No such reservation");
        }
    }
}