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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BrandonButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Storyboard audioResourceWav;
            audioResourceWav = (Storyboard)this.Resources["Final_Fantasy_7_Philharmonic_Suite_Part_I_OC_ReMix.mp3"];
            audioResourceWav.Begin(this);

            this.KeyUp += OnKeyUp;

            this.BrandonButton.Click += BrandonButton_Click;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Application.Current.Shutdown();
            }
        }

        private void BrandonButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.Write("BrandonButton Click");
            Messenger.Broadcast("BrandonButton_Clicked");
        }
    }
}
