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
using System.Windows.Threading;

namespace BrandonButton
{
    /// <summary>
    /// Interaction logic for TeaCup.xaml
    /// </summary>
    public partial class TeaCup : UserControl
    {
        private int teaLevel;
        private List<Image> teaImages = new List<Image>();

        private DispatcherTimer _timer = new DispatcherTimer();
        private Random rand = new Random();

        private const int maxTeaLevel = 3;
        public int TeaLevel
        {
            get { return this.teaLevel; }
            set {
                if (value < maxTeaLevel + 1)
                {
                    this.teaLevel = value;
                    Debug.Write("New tea: " + this.teaLevel);

                    for (int i = 0; i < teaImages.Count; i++)
                    {
                        if (this.teaLevel == i)
                        {
                            teaImages[i].Visibility = Visibility.Visible;

                        }
                        else
                        {
                            teaImages[i].Visibility = Visibility.Hidden;
                        }
                    }
                }
            }
        }

        public TeaCup()
        {
            InitializeComponent();

            setupTea();
            InitAndStartTimer();

            Messenger.AddListener("BrandonButton_Clicked", OnBrandonButtonClicked);
        }

        private void setupTea()
        {
            teaImages.Add(this.Tea0);
            teaImages.Add(this.Tea1);
            teaImages.Add(this.Tea2);
            teaImages.Add(this.Tea3);
            this.TeaLevel = 3;
        }

        public void Fill()
        {
            TeaLevel = maxTeaLevel;
        }

        private void OnBrandonButtonClicked()
        {
            Debug.Write("Tea heard brandon was clicked");
        }

        public void InitAndStartTimer()
        {
            _timer.Tick += dispatcherTimer_Tick;
            _timer.Interval = TimeSpan.FromSeconds(rand.Next(3, 9)); // From 1 s to 10 s
            Debug.Write("interval: " + _timer.Interval);
            _timer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            _timer.Interval = TimeSpan.FromSeconds(rand.Next(3, 9)); // From 1 s to 10 s
            Debug.Write("new interval: " + _timer.Interval);

            if (this.TeaLevel > 0)
            {
                this.TeaLevel = this.TeaLevel - 1;
            }
            else
            {

            }
        }
    }
}
