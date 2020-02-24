using intra_models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Gestionnaire_Clients
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Customer selectedCustomer;
        private CustomerDataService CustomerDataService;
        private ObservableCollection<Customer> customers;

        public ObservableCollection<Customer> Customers
        {
            get => customers;
            set
            {
                customers = value;
                OnPropertyChanged();
            }
        }

        public Customer SelectedCustomers
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();

            InitValues();
        }

        private void InitValues()//important initialise value
        {
            CustomerDataService = new CustomerDataService();
            Customers = new ObservableCollection<Customer>(CustomerDataService.All);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")//juste le propertychanged
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void boutonadd_Click(object sender, RoutedEventArgs e)
        {
            var emp = new Customer() { Name = prenom.Text.ToString(), LastName = nom.Text.ToString(), Address = adresse.Text.ToString(), City = ville.Text.ToString(), Province = province.Text.ToString(), PostalCode = code.Text.ToString(), PicturePath = "images/user.png", ContactInfo = contact.Text.ToString() };
            Customers.Add(emp);
            SelectedCustomers = emp;
            Debug.WriteLine(Customers.Count);
        }

        private void boutonsup_Click(object sender, RoutedEventArgs e)
        {
            int pos = Customers.IndexOf(SelectedCustomers);
            Customer temp;
            if (SelectedCustomers != null)
            {
                if (pos == 0)
                {
                    temp = Customers.ElementAt(pos + 1);
                }
                else
                {
                    temp = Customers.ElementAt(pos - 1);
                }
                Customers.Remove(SelectedCustomers);
                SelectedCustomers = temp;
            }
        }
    }
}
