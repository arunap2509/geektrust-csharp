namespace tameofthrones
{
    public class WaterKingdom : Kingdom
    {
        private static readonly string name = "WATER";
        private static readonly string emblem = "OCTOPUS";

        public WaterKingdom(string message) : base(emblem, name, message)
        {
        }
    }
}