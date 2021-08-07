using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace tameofthrones
{
    public class Southeros
    {
        private readonly string _path;
        private readonly List<Kingdom> _messageToKingdoms;

        public Southeros(string path)
        {
            _path = path;
            _messageToKingdoms = GetMessage();
        }

        private List<Kingdom> GetMessage()
        {
            List<Kingdom> messageToKingdoms = new List<Kingdom>();

            try
            {
                string[] messages = File.ReadAllLines(_path);

                foreach (string line in messages)
                {
                    var splitted = line.Split(" ");

                    if (splitted[0].ToLower() == "land")
                    {
                        messageToKingdoms.Add(new LandKingdom(string.Join("", splitted.Skip(1))));
                    }
                    else if (splitted[0].ToLower() == "ice")
                    {
                        messageToKingdoms.Add(new IceKingdom(string.Join("", splitted.Skip(1))));
                    }
                    else if (splitted[0].ToLower() == "air")
                    {
                        messageToKingdoms.Add(new AirKingdom(string.Join("", splitted.Skip(1))));
                    }
                    else if (splitted[0].ToLower() == "water")
                    {
                        messageToKingdoms.Add(new WaterKingdom(string.Join("", splitted.Skip(1))));
                    }
                    else if (splitted[0].ToLower() == "fire")
                    {
                        messageToKingdoms.Add(new FireKingdom(string.Join("", splitted.Skip(1))));
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("The path or data you mentioned is not valid");
            }

            return messageToKingdoms;
        }

        public string GetRulerAndAllies()
        {
            SpaceKingdom spaceKingdom = new SpaceKingdom(_messageToKingdoms);

            if (!spaceKingdom.IsRulerOfSixKingdoms())
            {
                Console.WriteLine("None");
                return "None";
            }

            var rulerAndAllies = "SPACE";

            rulerAndAllies += $" {spaceKingdom.GetAllies()}";

            Console.WriteLine(rulerAndAllies);

            return rulerAndAllies;
        }
    }
}