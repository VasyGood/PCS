namespace Product
{
    class Reservation
    {
        public int ID;
        public string? ClientName;
        public string? Number;
        public int StartTime;
        public int EndTime;
        public Table Table;
        public string? Comment;

        public Reservation(int id, string? clientName, string? number, int startTime, int endTime, Table table, string? comment = "")
        {
            ID = id;
            ClientName = clientName;
            Number = number;
            StartTime = startTime;
            EndTime = endTime;
            Table = table;
            Comment = comment;
        }

        public Reservation ChangeInfo(int id, string clientName, string number, int startTime, int endTime, ref Table table, string comment = "")
        {

            if (table.IsReserved(startTime, endTime, this)) 
            {
                Console.WriteLine("This table is reserved in this time. Choose another table or another time");
                return this;
            }

            ID = id;
            ClientName = clientName;
            Number = number;
            Comment = comment;
            return this;
        }

        public void Cancel()
        {
            for (int i = StartTime; i < EndTime; i++)
            {
                Table.Timetable[i - 9] = new Reserved();
            }
        }

        public void PrintLineInfo()
        {
            Console.WriteLine($"ID {ID}, {ClientName}, {Number}");
        }

        public void PrintInfo()
        {
            Console.WriteLine($"ID {ID}, Client name {ClientName}, Number {Number}");
            Console.WriteLine($"Start time {StartTime}, End time {EndTime}");
            Console.WriteLine($"Table id {Table.ID}");
        }
    }
}