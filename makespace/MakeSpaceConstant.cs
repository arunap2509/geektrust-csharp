using System;
using System.Collections.Generic;

namespace makespace
{
    public static class MakeSpaceConstant
    {
        public static int BookingInterval = 15;
        public static List<(TimeSpan, TimeSpan)> BufferTimes = new()
        {
            (new TimeSpan(09, 00, 00), new TimeSpan(09, 15, 00)),
            (new TimeSpan(13, 15, 00), new TimeSpan(13, 45, 00)),
            (new TimeSpan(18, 45, 00), new TimeSpan(19, 00, 00))
        };
        public static string InCorrectInput = "INCORRECT_INPUT";
        public static string NoVacantRoom = "NO_VACANT_ROOM";
        public static TimeSpan InCorrectTimeSpan = new TimeSpan(0, 0, 0);
        public static short MinRoomCapacity = 2;
        public static short MaxRoomCapacity = 20;
    }
}