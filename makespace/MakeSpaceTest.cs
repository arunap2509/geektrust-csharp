using System.Collections.Generic;
using Xunit;
using static makespace.MakeSpaceConstant;

namespace makespace
{
    public class MakeSpaceTests
    {
        [Fact]
        public void ShouldReturn_InCorrectInput_WhenAllInputsAreNotGiven()
        {
            List<string[]> inputs = new()
            {
                new string[] { "BOOK", "10:45" },
            };

            var expectedResponse = new List<string> { InCorrectInput };
            var room = new RoomFactory();
            List<string> response = new();

            foreach (var item in inputs)
            {
                response.Add(room.Execute(item));
            }

            Assert.Equal(expectedResponse, response);
        }

        [Fact]
        public void ShouldReturn_InCorrectInput_WhenTimeFormat_IsInvalid_And_Range_IsInValid()
        {
            List<string[]> inputs = new()
            {
                new string[] { "VACANCY", "10:45", "he" },
                new string[] { "VACANCY", "start", "12:00" },
                new string[] { "VACANCY", "12:45", "12:00" },
                new string[] { "VACANCY", "10:00", "10:33" },
                new string[] { "BOOK", "15:01", "15:33" }
            };

            var expectedResponse = new List<string> { InCorrectInput, InCorrectInput, InCorrectInput, InCorrectInput, InCorrectInput };
            var room = new RoomFactory();
            List<string> response = new();

            foreach (var item in inputs)
            {
                response.Add(room.Execute(item));
            }

            Assert.Equal(expectedResponse, response);
        }

        [Fact]
        public void ShouldReturn_NoVacantRoom_WhenTimeOverlapsWith_BufferTime()
        {
            List<string[]> inputs = new()
            {
                new string[] { "VACANCY", "08:45", "09:30" }
            };

            var expectedResponse = new List<string> { NoVacantRoom };
            var room = new RoomFactory();
            List<string> response = new();

            foreach (var item in inputs)
            {
                response.Add(room.Execute(item));
            }

            Assert.Equal(expectedResponse, response);
        }

        [Fact]
        public void ShouldReturnExpectedResponse_WhenTryingToBook_Or_GetVacantRoom()
        {
            List<string[]> inputs = new()
            {
                new string[] { "BOOK", "10:45", "11:00" },
                new string[] { "BOOK", "10:45", "11:00", "3" },
                new string[] { "VACANCY", "10:45", "11:00" },
                new string[] { "VACANCY", "16:00", "16:15" },
                new string[] { "BOOK", "18:00", "18:15", "1" },
                new string[] { "BOOK", "18:00", "18:15", "21" },
                new string[] { "BOOK", "10:45", "11:00", "19" },
                new string[] { "BOOK", "10:45", "12:00", "15" },
            };

            var expectedResponse = new List<string> { InCorrectInput, "C-Cave", "D-Tower G-Mansion", "C-Cave D-Tower G-Mansion", InCorrectInput, InCorrectInput, "G-Mansion",
            NoVacantRoom };

            var room = new RoomFactory();
            List<string> response = new();

            foreach (var item in inputs)
            {
                response.Add(room.Execute(item));
            }

            Assert.Equal(expectedResponse, response);
        }
    }
}