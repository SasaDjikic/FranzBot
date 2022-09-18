using System.Xml;

namespace FranzBot
{
    public class Storage
    {
        /// <summary>
        /// Liste um Keywords und Antworten zu speichern
        /// </summary>
        public List<Message> message { get; set; } = new List<Message>();
        public string FileToRead { get; set; } = string.Empty;

        public Storage()
        {



        }

        public Storage(string filetoread)
        {
            FileToRead = filetoread;
        }

        /// <summary>
        /// Methode um die Keyword-Liste inzulesen und um die Keywords mit dem Input des Users zu vergleichen
        /// </summary>
        /// <param name="_input"></param>
        /// <returns>Die Antwort als String oder das kein Keyword eingegebn wurde</returns>
        public string Load1(string _input, string end)
        {
            try
            {
                var reader = new StreamReader(end);
                string keyword = "0";

                string Answer = string.Empty;
                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    if (line == null)
                    { continue; }

                    var data = line.Split(";");

                    keyword = data[0];
                    string answer = data[1];

                    message.Add(new Message(keyword, answer));

                    foreach (Message e in message)
                    {
                        if (_input.Contains(e.keyword, StringComparison.OrdinalIgnoreCase))
                        {
                            Answer = e.answer;
                        }
                    }
                }

                if (Answer == string.Empty)
                {
                    Answer = "Ich habe dich leider nicht verstanden";
                }
                return Answer;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Load(string _input, string end)
        {
            string keyword = string.Empty;
            string Answer = string.Empty;
            string answer = string.Empty;

            using (XmlReader reader = XmlReader.Create(end))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        //return only when you have START tag  
                        switch (reader.Name.ToString())
                        {
                            case "Frage":
                                keyword = reader.ReadString();
                                break;
                            case "Antwort":
                                answer = reader.ReadString();
                                break;
                        }
                    }
                    message.Add(new Message(keyword, answer));

                    foreach (Message e in message)
                    {
                        if (_input.Contains(e.keyword, StringComparison.OrdinalIgnoreCase))
                        {
                            Answer = e.answer;
                        }
                    }
                }

                if (Answer == string.Empty)
                {
                    Answer = "Ich habe dich leider nicht verstanden";
                }
            }
            return Answer;
        }
        public string Load2(string _input, string end)
        {
            var reader = new StreamReader(@$"{end}");
            string keyword = "0";

            string Answer = string.Empty;
            while (!reader.EndOfStream)
            {

                var line = reader.ReadLine();

                if (line == null)
                { continue; }

                var data = line.Split(";");

                keyword = data[0];
                string answer = data[1];

                message.Add(new Message(keyword, answer));

                foreach (Message e in message)
                {
                    if (_input.Contains(e.keyword, StringComparison.OrdinalIgnoreCase))
                    {
                        Answer = e.answer;
                    }
                }
            }

            if (Answer == string.Empty)
            {
                Answer = "Ich habe dich leider nicht verstanden";
            }
            return Answer;
        }
    }
}