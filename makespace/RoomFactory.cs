using System;
using System.Collections.Generic;
using System.Linq;
using static makespace.MakeSpaceConstant;

namespace makespace
{
    public class RoomFactory
    {
        private List<Room> _allRooms;
        private string[] _args;
        private TimeSpan _startTime;
        private TimeSpan _endTime;
        private const string VACANCY = "vacancy";
        private const string BOOK = "book";
        private string _message;

        public RoomFactory()
        {
            _allRooms = GetRooms();
        }

        /// <summary>
        /// Method to get all the available rooms
        /// </summary>
        /// <returns></returns>
        List<Room> GetRooms()
        {
            var gMansion = new GMansionRoom();
            var cCave = new CCaveRoom();
            var dTower = new DTowerRoom();

            var rooms = new List<Room> { gMansion, cCave, dTower };
            rooms = rooms.OrderBy(x => x.GetCapacity()).ToList();

            return rooms;
        }

        /// <summary>
        /// Method to start the execution flow
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public string Execute(string[] args)
        {
            _args = args;

            var canContinue = CheckRequiredInput(3) &&
            CheckTimeFormat() && CheckBufferTimeOverlap();

            if (!canContinue)
            {
                return _message;
            }

            var requestType = _args[0].ToLower().Trim();

            var response = requestType switch
            {
                VACANCY => GetVacantRooms(),
                BOOK => BookAvailableRoom(),
                _ => InCorrectInput
            };

            return response;
        }

        /// <summary>
        /// Method to check if all the required arguments are given
        /// </summary>
        /// <returns></returns>
        private bool CheckRequiredInput(int requiredLength)
        {
            // return if not all arguments are passed
            if (_args.Length < requiredLength)
            {
                _message = InCorrectInput;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method to check for the formats and time values
        /// </summary>
        /// <returns></returns>
        private bool CheckTimeFormat()
        {
            var requestType = _args[0].ToLower().Trim();
            TimeSpan.TryParse(_args[1], out _startTime);
            TimeSpan.TryParse(_args[2], out _endTime);

            if (_startTime == InCorrectTimeSpan
            || _endTime == InCorrectTimeSpan
            || _startTime > _endTime
            || _startTime.TotalMinutes % 15 != 0
            || _endTime.TotalMinutes % 15 != 0)
            {
                _message = InCorrectInput;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if there is any overlap between the buffer time and requested time
        /// </summary>
        /// <returns></returns>
        private bool CheckBufferTimeOverlap()
        {
            foreach (var bufferTime in BufferTimes)
            {
                if (_startTime < bufferTime.Item2 && bufferTime.Item1 < _endTime)
                {
                    _message = NoVacantRoom;
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Books the available room
        /// </summary>
        /// <returns></returns>
        private string BookAvailableRoom()
        {
            if (!CheckRequiredInput(4))
            {
                return _message;
            }

            int.TryParse(_args[3], out int persons);

            if (persons < MinRoomCapacity || persons > MaxRoomCapacity)
            {
                return InCorrectInput;
            }

            foreach (var room in _allRooms)
            {
                if (room.GetCapacity() >= persons)
                {
                    var isBooked = room.BookRoom(_startTime, _endTime);

                    if (isBooked)
                    {
                        return room.GetRoomName();
                    }
                }
            }

            return NoVacantRoom;
        }

        /// <summary>
        /// Get all the vacant rooms for the given time
        /// </summary>
        /// <returns></returns>
        private string GetVacantRooms()
        {
            List<string> vacantRooms = new();

            foreach (var room in _allRooms)
            {
                var isVacant = room.IsRoomAvailableForGivenRange(_startTime, _endTime);

                if (isVacant)
                {
                    vacantRooms.Add(room.GetRoomName());
                }
            }

            if (vacantRooms.Count == 0)
            {
                return NoVacantRoom;
            }
            else
            {
                return string.Join(" ", vacantRooms);
            }
        }
    }
}