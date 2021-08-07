namespace tameofthrones
{
    public class LandKingdom : Kingdom
    {
        private static readonly string name = "LAND";
        private static readonly string emblem = "PANDA";

        public LandKingdom(string message) : base(emblem, name, message)
        {
        }
    }
}