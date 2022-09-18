namespace FranzBot
{
    /// <summary>
    /// Klasse Message
    /// </summary>
    public class Message
    {

        /// <summary>
        /// Properties 
        /// </summary>
         public string keyword { get; set; }
         public string answer { get; set; }

        /// <summary>
        /// Standart Konstruktor
        /// </summary>
        public Message()
        {
            keyword = string.Empty;
            answer = string.Empty;
        }

        /// <summary>
        /// Konstruktor welcher die Argumente: Keyword und die Antwort annimt
        /// </summary>
        /// <param name="key"></param>
        /// <param name="_answer"></param>
        public Message(string key, string _answer)
        {
            keyword = key;
            answer = _answer;
        }

        /// <summary>
        /// Methode um den Inhalt von Objekten der KLasse Message zu einem String zu konvertieren
        /// </summary>
        /// <returns>Die Antwort als String</returns>
        public override string ToString()
        {
            return $"{answer}";
        }
    }
}
