namespace tameofthrones
{
    public class FireKingdom : Kingdom
    {
        private static readonly string name = "FIRE";
        private static readonly string emblem = "DRAGON";

        public FireKingdom(string message) : base(emblem, name, message)
        {
        }
    }
}