using System.Collections.Generic;

namespace tameofthrones
{
    public class SpaceKingdom
    {
        private readonly IList<Kingdom> _messages;
        private bool _isKingOfSoutheros = false;
        private List<string> _allies = new List<string>();

        public SpaceKingdom(List<Kingdom> messages)
        {
            _messages = messages;
            SearchForAllies();
        }

        public bool IsRulerOfSixKingdoms()
        {
            return _isKingOfSoutheros;
        }

        public string GetAllies()
        {
            return string.Join(" ", _allies);
        }

        private void SearchForAllies()
        {
            foreach (var secretMessage in _messages)
            {
                var allies = secretMessage.AcceptAlliance();

                if (allies != null && !_allies.Contains(allies))
                {
                    _allies.Add(allies);
                }
            }

            if (_allies.Count >= 3)
            {
                _isKingOfSoutheros = true;
            }
        }
    }
}