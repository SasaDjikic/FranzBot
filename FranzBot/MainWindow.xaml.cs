using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace FranzBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string pfad;
        public string endung;
        /// <summary>
        /// Initialisiert das Fenster der Applikation 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Instanziiert das Objekt botEngine, ruft die Methode getAnswer mit dem Imput als Paremeter auf.
        /// Ausgabe der Antwort in die TextBox und löschen des Eingabefelds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void send_Click(object sender, RoutedEventArgs e)
        {
            string input = textBox.Text;
            BotEngine botEngine = new BotEngine();
            Message output = new Message();
            string answer;
            switch (endung)
            {
                case "txt":
                    output = botEngine.getAnswer2(input, pfad);
                    answer = output.ToString();
                    break;
                case "xml":
                    output = botEngine.getAnswer(input, pfad);
                    answer = output.ToString();                    
                    break ;
                case "csv":
                    output = botEngine.getAnswer1(input, pfad);
                    answer = output.ToString();
                    break;
                default:
                    pfad = "List.csv";
                    output = botEngine.getAnswer1(input, pfad);
                    answer = output.ToString();
                    break;
                    
            }
            textBox1.Text = $"{textBox1.Text} \n {DateTime.Now} \n User: {input} \n\n {DateTime.Now} \n Bot: {answer} \n";

            textBox1.ScrollToEnd();
            textBox.Clear();
        }

        /// <summary>
        /// Schliesst die Anwendung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //string writefile = @"log.txt";
            //using (StreamWriter writer = new StreamWriter(writefile, append: true, Encoding.Default))
            //{
            //    writer.WriteLine(textBox1.Text);
            //}

            SaveFileDialog Savedlg = new SaveFileDialog();
            Savedlg.Filter = "Text file(*.text)|*.txt|c# file(*.cs)|*.cs|Word file(*.doc)|*.doc";
            if (Savedlg.ShowDialog() == true)
            {
                File.WriteAllText(Savedlg.FileName, textBox1.Text);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            OpenFileDialog Opendlg = new OpenFileDialog();
            Opendlg.DefaultExt = ".xml";
            Opendlg.Filter = "Text file(*.text)|*.txt|XML documents(.xml)|*.xml|CSV file(.csv)|*.csv";


            if (Opendlg.ShowDialog() == true)
            {
                string selectedFile = Opendlg.FileName;
                pfad = selectedFile;
                Endung(selectedFile);
            }
        }
        private void Endung(string input)
        {
           endung = input.Substring(input.Length - 3);
        }
    }
}
