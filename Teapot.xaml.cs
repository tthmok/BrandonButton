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

namespace BrandonButton
{
    /// <summary>
    /// Interaction logic for Teapot.xaml
    /// </summary>
    public partial class Teapot : UserControl
    {
        private int teaLevel;
        private List<Image> teaImages = new List<Image>();
        private const int maxTeaLevel = 3;

        public List<TeaCup> emptyCups = new List<TeaCup>();

        public int TeaLevel
        {
            get { return this.teaLevel; }
            set
            {
                if (value < maxTeaLevel + 1)
                {
                    this.teaLevel = value;
                    Debug.Write("New teapot level: " + this.teaLevel);

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
        public Teapot()
        {
            InitializeComponent();

            setupTea();

            Messenger.AddListener("BrandonButton_Clicked", OnBrandonButtonClicked);

            Messenger.AddListener<TeaCup>("TeaCupEmpty", OnTeaCupEmpty);
        }

        private void setupTea()
        {
            teaImages.Add(this.Teapot0);
            teaImages.Add(this.Teapot1);
            teaImages.Add(this.Teapot2);
            teaImages.Add(this.Teapot3);
            this.TeaLevel = 3;
        }

        public void Fill()
        {
            TeaLevel = maxTeaLevel;
        }

        private void OnTeaCupEmpty(TeaCup teacup)
        {
            if (!emptyCups.Contains(teacup))
            {
                emptyCups.Add(teacup);
            }
        }

        private void OnBrandonButtonClicked()
        {
            Debug.Write("Teapot heard brandon was clicked");
            if (TeaLevel > 0 && emptyCups.Count > 0)
            {
                TeaLevel--;
                emptyCups[0].Fill();
                emptyCups.RemoveAt(0);
            } else if (TeaLevel == 0) {
                Fill();
            }
        }
    }
}
