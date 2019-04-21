using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SpiritIslandCompanion
{
    /// <summary>
    /// Interaction logic for frmNewGame.xaml
    /// </summary>
    public partial class FrmNewGame : Window, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implimentation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion INotifyPropertyChanged Implimentation

        private ObservableCollection<AdversaryCard> _adversaries = new ObservableCollection<AdversaryCard>();
        private AdversaryCard _selectedAdversary;

        #region Properties

        public int PlayerCount { get { return (int)slPlayers.Value; } }

        public AdversaryCard ChosenAdversary { get { return SelectedAdversary; } }

        public int AdversaryLevel { get { return (int)slAdversaryLevel.Value; } }

        public ObservableCollection<AdversaryCard> MyAdversaryList
        {
            get { return _adversaries; }
            set { _adversaries = value; }
        }

        public AdversaryCard SelectedAdversary
        {
            get { return _selectedAdversary; }
            set { _selectedAdversary = value; NotifyPropertyChanged(); }
        }

        #endregion Properties

        public FrmNewGame()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void PopulateAdversaryList()
        {
            foreach (AdversaryCard ac in MyAdversaryList)
            {
                lbAdversaries.Items.Add(ac.Kingdom);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void lbAdversaries_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lbAdversaries.SelectedIndex >= 0 && lbAdversaries.SelectedIndex < MyAdversaryList.Count)
            {
                SelectedAdversary = MyAdversaryList[lbAdversaries.SelectedIndex];

                if (lbAdversaries.SelectedIndex == 0)
                {
                    slAdversaryLevel.IsEnabled = false;
                }
                else
                {
                    slAdversaryLevel.IsEnabled = true;
                }
            }
        }

        private void Image_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2 && SelectedAdversary != null)
            {
                FrmCardView frmCardView = new FrmCardView();
                frmCardView.ShowCard = SelectedAdversary.Source;
                frmCardView.ShowDialog();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateAdversaryList();
            lbAdversaries.SelectedIndex = 0;
        }
    }
}