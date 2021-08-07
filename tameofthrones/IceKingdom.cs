namespace tameofthrones
{
    public class IceKingdom : Kingdom
    {
        private static readonly string name = "ICE";
        private static readonly string emblem = "MAMMOTH";

        public IceKingdom(string message) : base(emblem, name, message) { }
    }
}