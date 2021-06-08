using System;
using System.Collections.Generic;
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

namespace prjProg6112_ICE_Task_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.DeleteTextFile();
        }

        //Instantiating Object of Read_WriteDetails class
        Read_WriteDetails Main = new Read_WriteDetails();

        public string Name, Surname, Email;

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            //Parameters
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter a player name!");
            }
            if (txtSurname.Text == "")
            {
                MessageBox.Show("Please enter a player surname!");
            }
            if (txtEmail.Text == "" || IsValidEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("Please enter a valid player email!");
            }
            else
            {
                Main.SetName(Name = txtName.Text);
                Main.SetSurName(Surname = txtSurname.Text);
                Main.SetEmail(Email = txtEmail.Text);
                Main.PushToListDetails(Name, Surname, Email);
                Main.SaveToTextFile();

                Window1 Event = new Window1();
                Event.Show();

                this.Close();
            }

            bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }

        }
    }
}
