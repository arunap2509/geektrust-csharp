using System;
using System.Collections.Generic;
using System.Linq;
using static makespace.MakeSpaceConstant;

namespace makespace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> inputs = new()
            {
                new string[] { "BOOK", "10:45", "12:00", "20" },
                new string[] { "BOOK", "10:", "12:00", "20" },
                new string[] { "BOOK", "10:45", "12:00", "20" },
                new string[] { "BOOK", "10:00", "10:30", "1" },
                new string[] { "BOOK", "15:00", "15:33", "10" },
                new string[] { "BOOK", "15:45", "15:40", "10" },
                new string[] { "VACANCY", "11:00", "11:30", "3" },
                new string[] { "BOOK", "10:45", "12:00", "5" },
                new string[] { "VACANCY", "10:45", "12:00" },
            };

            RoomFactory room = new();

            foreach (var item in inputs)
            {
                var response = room.Execute(item);
                Console.WriteLine(response);
            }
        }
    }
}
