using System;
using System.Collections.Generic;

namespace makespace
{
    public abstract class Room
    {
        protected int Capacity;
        protected List<(TimeSpan, TimeSpan)> BookedTimes;
        protected string RoomName;

        public Room()
        {
            BookedTimes = new();
        }

        /// <summary>
        /// Checks if the room is available for the given time range
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool IsRoomAvailableForGivenRange(TimeSpan start, TimeSpan end)
        {
            foreach (var booked in BookedTimes)
            {
                if (start < booked.Item2 && booked.Item1 < end)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Books the rooms if the room is available for the requested time 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool BookRoom(TimeSpan start, TimeSpan end)
        {
            var isRoomAvailale = IsRoomAvailableForGivenRange(start, end);

            if (!isRoomAvailale)
            {
                return false;
            }

            BookedTimes.Add((start, end));
            return true;
        }

        /// <summary>
        /// Gets the room capacity
        /// </summary>
        /// <returns></returns>
        public int GetCapacity()
        {
            return Capacity;
        }

        /// <summary>
        /// Gets the room name
        /// </summary>
        /// <returns></returns>
        public string GetRoomName()
        {
            return RoomName;
        }
    }
}