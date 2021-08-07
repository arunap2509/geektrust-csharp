using System.Collections.Generic;

namespace tameofthrones
{
    public abstract class Kingdom
    {
        private string _emblem { get; set; }
        private string _name { get; set; }
        private Dictionary<char, int> _secretWordCount { get; set; }
        private string _message { get; set; }

        public Kingdom(string emblem, string name, string message)
        {
            _emblem = emblem;
            _name = name;
            _message = message;
            _secretWordCount = GetSecretWordCount(emblem);
        }

        public virtual string AcceptAlliance()
        {
            var messageCharCount = new Dictionary<char, int>();

            foreach (var ch in _message.ToLower())
            {
                if (messageCharCount.ContainsKey(ch))
                {
                    messageCharCount[ch] += 1;
                }
                else
                {
                    messageCharCount.Add(ch, 1);
                }
            }

            foreach (var item in _secretWordCount)
            {
                if (!messageCharCount.ContainsKey(item.Key) || messageCharCount[item.Key] < item.Value)
                {
                    return null;
                }
            }

            return _name;
        }

        private Dictionary<char, int> GetSecretWordCount(string emblem)
        {
            var wordCount = new Dictionary<char, int>();

            foreach (var ch in emblem.ToLower())
            {
                int b = ch - 'a';
                int newPosition = (b + emblem.Length) % 26;
                char c = (char)('a' + newPosition);

                if (wordCount.ContainsKey(c))
                {
                    wordCount[c]++;
                }
                else
                {
                    wordCount.Add(c, 1);
                }
            }

            return wordCount;
        }
    }
}