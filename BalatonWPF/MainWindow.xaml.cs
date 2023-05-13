using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace BalatonWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Epitmeny> epitmenylist = new List<Epitmeny>();
        public MainWindow()
        {
            InitializeComponent();
            Dictionary<string, int> Adosav = new Dictionary<string, int>();

            StreamReader r = new StreamReader("utca.txt");
            string line = r.ReadLine();
            string[] splitted = line.Split(' ');
            Adosav.Add("A", int.Parse(splitted[0]));
            Adosav.Add("B", int.Parse(splitted[1]));
            Adosav.Add("C", int.Parse(splitted[2]));
            while (!r.EndOfStream)
            {
                epitmenylist.Add(new Epitmeny(r.ReadLine()));
            }
            r.Close();
            Datagrid.ItemsSource = epitmenylist;
            Kategoria.Items.Add("A");
            Kategoria.Items.Add("B");
            Kategoria.Items.Add("C");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            epitmenylist[Datagrid.SelectedIndex].adosav = Kategoria.Text;
            Datagrid.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
StreamWriter w = new StreamWriter("modositottadok.txt");
            for (int i = 0; i < epitmenylist.Count; i++)
            {
                w.WriteLine($"{epitmenylist[i].adoszam} {epitmenylist[i].utca} {epitmenylist[i].hazszam} {epitmenylist[i].adosav} {epitmenylist[i].alapterulet}");
            }
            w.Close();
                MessageBox.Show("Sikeres mentés!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
