using Product;
class Program
{
    static void Main()
    {
        Manager manager = new Manager();
        string? input = "";
        int n;
        int IntBuf;
        Place PlaceBuf;

        while(input != "exit")
        {
            Console.Clear();

            Console.WriteLine("Choose the operation");
            Console.WriteLine("1 Create n tables");
            Console.WriteLine("2 Create n reservations");
            Console.WriteLine("3 Change table info by id");
            Console.WriteLine("4 View table info by id");
            Console.WriteLine("5 View all tables by filter");
            Console.WriteLine("6 View all reservations");
            Console.WriteLine("7 Find reservation by last 4 numbers");
            Console.WriteLine("8 Find reservation by client name"); 
            Console.WriteLine("9 Change reservation info");
            Console.WriteLine("10 Change table info");
            input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    Console.WriteLine("Enter n");
                    n = Convert.ToInt32(Console.ReadLine());

                    manager.CreateTables(n);

                    Console.WriteLine("Tables created successfully");
                    break;
                case "2":
                    Console.WriteLine("Enter n");
                    n = Convert.ToInt32(Console.ReadLine());

                    manager.CreateReservations(n);

                    Console.WriteLine("Reservations created successfully");
                    break;
                case "3":
                    Console.WriteLine("Enter table id");
                    n = Convert.ToInt32(Console.ReadLine());
                    
                    Console.WriteLine("Enter new seats number");
                    IntBuf = Convert.ToInt32(Console.ReadLine());
                    
                    Console.WriteLine("Enter new place(0 - Window, 1 - Pass, 2 - Exit, 3 - Deep)");
                    PlaceBuf = (Place)Convert.ToInt32(Console.ReadLine());
                    
                    manager.Tables[n].SetTableInfo(PlaceBuf, IntBuf);

                    Console.WriteLine($"Table {n} info changed successfully");
                    break;
                case "4":
                    Console.WriteLine("Enter table id");
                    n = Convert.ToInt32(Console.ReadLine());
                
                    manager.Tables[n].PrintInfo();

                    break;
                case "5":
                    Console.WriteLine("Choose filter(0 - by seats number, 1 - by place)");
                    input = Console.ReadLine();
                    if (input == "0") 
                    {
                        Console.WriteLine("Enter seats number");
                        IntBuf = Convert.ToInt32(Console.ReadLine());
                        manager.PrintTablesBySeats(IntBuf);
                    }
                    else
                    {
                        Console.WriteLine("Enter place(0 - Window, 1 - Pass, 2 - Exit, 3 - Deep)");
                        PlaceBuf = (Place)Convert.ToInt32(Console.ReadLine());
                        manager.PrintTablesByPlace(PlaceBuf);
                    }
                    break;
                case "6":
                    manager.PrintReservations();
                    break;
                case "7":
                    Console.WriteLine("Enter last 4 numbers");
                    input = Console.ReadLine();

                    manager.FindReservationByNumber(input);
                    break;
                case "8":
                    Console.WriteLine("Enter name");
                    input = Console.ReadLine();
                    
                    manager.FindReservationByName(input);
                    break;
                case "9":
                    Console.WriteLine("Enter reservation id");
                    IntBuf = Convert.ToInt32(Console.ReadLine());

                    ref Reservation bufRes = ref manager.Reservations[IntBuf];
                    Console.WriteLine($"Choose new parameters");

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

                    ref Table bufTab = ref manager.Tables[j];

                    if (bufTab.IsReserved(startTime, endTime)) 
                    {
                        Console.WriteLine("This table is reserved in this time. Choose another table or another time");
                        break;
                    }

                    Console.WriteLine("Enter a comment(optional)");
                    string? comment = Console.ReadLine();    

                    bufTab.SetReservation(bufRes.ChangeInfo(IntBuf, clientName, number, startTime, endTime, ref bufTab));
                    
                    break;
                case "10":
                    Console.WriteLine("Enter table id");
                    IntBuf = Convert.ToInt32(Console.ReadLine());

                    bufTab = ref manager.Tables[IntBuf];
                    if (bufTab.IsInRes()) 
                    {
                        Console.WriteLine("This table is in active reservation cannot be changed");
                        break;
                    }

                    Console.WriteLine("Enter a place(Window - 0, Pass - 1, Exit - 2, Deep - 3)");
                    Place place = (Place)Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter seats number");
                    int seatsNumber = Convert.ToByte(Console.ReadLine());

                    bufTab.SetTableInfo(place, seatsNumber);
                    break;
            }
            Console.WriteLine("Enter any key to continue");
            Console.ReadKey();
        }  

    }
}