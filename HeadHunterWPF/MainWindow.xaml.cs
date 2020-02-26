using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using HHLibrary;

namespace HeadHunterWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
       

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            HHModel hhmodel = new HHModel();
            List<Vacancy> vacancies = hhmodel.JsonParceString(hhmodel.RequestGet("https://api.hh.ru/vacancies?text=" + SearchTextBox.Text));
            DataJson.ItemsSource = vacancies;
            foreach (Vacancy vacancy in vacancies)
            {
                
                DataJson.Tag = vacancy.Link;
            }
                

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               // Vacancy vacancy = (HHLibrary)DataJson.SelectedItem;
              

               
                //ListBoxItem listBoxItem = (ListBoxItem)ResultListBox.SelectedItem;
               Process.Start(DataJson.SelectedCells.ToString());
            }

            catch (Exception eq)
            {
                MessageBox.Show(eq.ToString());
            }
        }

        private void DataJson_TouchDown(object sender, TouchEventArgs e)
        {
            MessageBox.Show("TouchDown");
        }

        private void DataJson_TouchEnter(object sender, TouchEventArgs e)
        {
            MessageBox.Show("TouchEnter");
        }

        private void DataJson_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("MouseDoubleClick");
        }

        private void DataJson_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            string RowData = "";
            RowData = DataJson.Items.ToString();
            LabelData.Content = RowData;
        }
    }
}
