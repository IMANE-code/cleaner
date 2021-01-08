using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows;



namespace antivurus
{
    public partial class MainWindow : Window
    {
     
        public MainWindow()
        {
            InitializeComponent();

            WebClient webClient = new WebClient();

            try
            {
                if (!webClient.DownloadString("yourpastebinlink").Contains("1.5.0"))
                {
                    if (MessageBox.Show("Looks like there is an update! Do you want to download it?", "Demo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        using (var client = new WebClient())
                        {
                            Process.Start("UpdaterDemo.exe");
                            this.Close();
                        }
                }
            }
            catch
            {

            }
        }

        /*button Annalyse*/

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            progresse1.Value = 0;
            string myPath = $@"C:\Users\Youcode\Desktop\Nouveau dossier";
            DirectoryInfo dirInfo = new DirectoryInfo(myPath);
            var fichier = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);

            progresse1.Maximum = fichier.Length;
            long size = 0;


            foreach (FileInfo fi in fichier)
            {
                size += fi.Length;
                progresse1.Value = fichier.Length;
            }
            DateTime LastScan = DateTime.Now;
            label5.Content = LastScan.ToString();
            espace.Content = "";
            espace.Content = $"{ size / 1000 }KO";

            string fich = @"C:\Users\Youcode\Desktop\Nouveau dossier (2)\text.txt";
            using (StreamWriter writer = new StreamWriter(fich))
            {
                writer.Write(LastScan);
            }
            MessageBox.Show("hry");

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            listview1.Items.Clear();

            string myPath = $@"C:\Users\Youcode\Desktop\Nouveau dossier";
            DirectoryInfo dirInfo = new DirectoryInfo(myPath);
            var fichier = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);



            long size = 0;
            DateTime LastScan = DateTime.Now;
            LastScan.ToString();

            foreach (FileInfo fi in fichier)
            {

                size = (fi.Length) / 1000;



                string str = $"* { size } ko   date annalyse{LastScan}  la date de mise à jour{LastScan}";
                listview1.Items.Add(str);

                //listview1.Items.Add(new InfosFile(size, "hhh", "hhh"));

            }


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
              
        }

       

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string fich = @"C:\Users\Youcode\Desktop\Nouveau dossier (2)\text.txt";
            using (StreamWriter writer = new StreamWriter(fich))
            {
                DateTime LastScan = DateTime.Now;
                writer.Write(LastScan);
               
            }
            MessageBox.Show("hry");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
        }
    }
}


