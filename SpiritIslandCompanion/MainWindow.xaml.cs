using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SpiritIslandCompanion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables etc

        private Invasion invasion = new Invasion();
        private Card _draggedImage;
        private Point _mousePosition;

        #endregion Variables etc

        #region Main Window and Game Set-up & Initialization

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = invasion;
        }

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            tbTurnOrder.Text = "Growth > Gain Energy > Choose Powers\n\n" +
                "Fast Effects\n\n" +
                "Blighted Island Effect > Event Card > Fear Card\n\n" +
                "Ravage > Build > Explore > (Adv. Inv. Cards)\n\n" +
                "Slow Effects\n\n" +
                "Time Passes";
            StartNewGame();
        }

        private void SetUpGameBoardDecks()
        {
            for (int i = 0; i < invasion.FearDeck.Count; i++)
            {
                FearCard c = invasion.FearDeck[i];
                DealCardToNewDeck(c);
                Canvas.SetZIndex(c, invasion.FearDeck.Count - i);
                mainCanvas.Children.Add(c);
            }

            for (int i = 0; i < invasion.EventDeck.Count; i++)
            {
                EventCard c = invasion.EventDeck[i];
                DealCardToNewDeck(c);
                Canvas.SetZIndex(c, invasion.EventDeck.Count - i);
                mainCanvas.Children.Add(c);
            }

            for (int i = 0; i < invasion.InvaderDeck.Count; i++)
            {
                InvaderCard c = invasion.InvaderDeck[i];
                DealCardToNewDeck(c);
                Canvas.SetZIndex(c, invasion.InvaderDeck.Count - i);
                mainCanvas.Children.Add(c);
            }

            foreach (BlightCard c in invasion.BlightDeck)
            {
                DealCardToNewDeck(c);
                mainCanvas.Children.Add(c);
            }

            foreach (AdversaryCard c in invasion.AdversaryDeck)
            {
                if (invasion.MyAdversary.Id == c.Id)
                {
                    DealCardToNewDeck(c);
                    Canvas.SetZIndex(c, 1);
                    mainCanvas.Children.Add(c);
                }
            }

            // Check for Adversary == England Level 3+
            if (invasion.HighImmigration == true)
            {
                SetBoardForEngland();
            }
            else
            {
                RemoveHighImmigrationTile();
            }
        }

        #endregion Main Window and Game Set-up & Initialization

        #region Game Logic Methods

        private void StartNewGame()
        {
            FrmNewGame frmNewGameDialog = new FrmNewGame();
            frmNewGameDialog.MyAdversaryList = invasion.AdversaryDeck;

            if (frmNewGameDialog.ShowDialog() == true)
            {
                ClearGameBoard();
                invasion = new Invasion(frmNewGameDialog.ChosenAdversary, frmNewGameDialog.AdversaryLevel, frmNewGameDialog.PlayerCount);
                SetUpGameBoardDecks();
                this.DataContext = invasion;
            }
        }

        private void ClearGameBoard()
        {
            invasion.TerrorCardOut = false;

            List<UIElement> itemstoremove = new List<UIElement>();

            foreach (UIElement ui in mainCanvas.Children)
            {
                if (ui.GetType() == typeof(FearCard) || ui.GetType() == typeof(EventCard) ||
                    ui.GetType() == typeof(InvaderCard) || ui.GetType() == typeof(BlightCard) ||
                    ui.GetType() == typeof(TerrorCard) || ui.GetType() == typeof(Card))
                {
                    itemstoremove.Add(ui);
                }
            }

            foreach (UIElement ui in itemstoremove)
            {
                mainCanvas.Children.Remove(ui);
            }
        }

        private void CheckForWinOrLose()
        {
            if (invasion.FearDeck.Count == 0)
            {
                MessageBox.Show("You Win! =)");
            }
            else if (invasion.InvaderDeck.Count == 0)
            {
                MessageBox.Show("You've been Colonized! =(");
            }
            else if (invasion.Blight == 0)
            {
                MessageBox.Show("You lose! =(");
            }
        }

        private void GainOneFearCard()
        {
            invasion.FearEarnedDeck.Insert(0, invasion.FearDeck[0]);
            MoveCardToNextLocation(invasion.FearEarnedDeck[0]);
            invasion.FearDeck.RemoveAt(0);
        }

        private void SetBoardForEngland()
        {
            imgHighImmigrationTile.Visibility = Visibility.Visible;
            imgInvaderHighImmigration.Visibility = Visibility.Visible;
        }

        private void RemoveHighImmigrationTile()
        {
            imgHighImmigrationTile.Visibility = Visibility.Collapsed;
            imgInvaderHighImmigration.Visibility = Visibility.Collapsed;
        }

        #endregion Game Logic Methods

        #region Use Top Card of Deck<T> Methods

        private void UseTopFearCard()
        {
            invasion.FearEarnedDeck[0].FlipCard();
            ShowCardZoom(invasion.FearEarnedDeck[0]);

            invasion.FearDiscardDeck.Insert(0, invasion.FearEarnedDeck[0]);
            MoveCardToNextLocation(invasion.FearDiscardDeck[0]);
            invasion.FearEarnedDeck.RemoveAt(0);
        }

        private void UseTopEventCard()
        {
            invasion.EventDeck[0].FlipCard();
            ShowCardZoom(invasion.EventDeck[0]);

            invasion.EventDiscardDeck.Insert(0, invasion.EventDeck[0]);
            MoveCardToNextLocation(invasion.EventDiscardDeck[0]);
            invasion.EventDeck.RemoveAt(0);
        }

        private void UseTopInvaderCard()
        {
            invasion.InvaderDeck[0].FlipCard();
            ShowCardZoom(invasion.InvaderDeck[0]);

            if (invasion.InvaderHighImmigrationDeck.Count > 0)
            {
                invasion.InvaderDiscardDeck.Insert(0, invasion.InvaderHighImmigrationDeck[0]);
                MoveCardToNextLocation(invasion.InvaderDiscardDeck[0]);
                invasion.InvaderHighImmigrationDeck.RemoveAt(0);
            }

            if (invasion.InvaderRavageDeck.Count > 0 && invasion.HighImmigration == true)
            {
                invasion.InvaderHighImmigrationDeck.Insert(0, invasion.InvaderRavageDeck[0]);
                MoveCardToNextLocation(invasion.InvaderHighImmigrationDeck[0]);
                invasion.InvaderRavageDeck.RemoveAt(0);
            }

            if (invasion.InvaderRavageDeck.Count > 0 && invasion.HighImmigration == false)
            {
                invasion.InvaderDiscardDeck.Insert(0, invasion.InvaderRavageDeck[0]);
                MoveCardToNextLocation(invasion.InvaderDiscardDeck[0]);
                invasion.InvaderRavageDeck.RemoveAt(0);
            }

            if (invasion.InvaderBuildDeck.Count > 0)
            {
                invasion.InvaderRavageDeck.Insert(0, invasion.InvaderBuildDeck[0]);
                MoveCardToNextLocation(invasion.InvaderRavageDeck[0]);
                invasion.InvaderBuildDeck.RemoveAt(0);
            }

            if (invasion.InvaderDeck.Count > 0)
            {
                invasion.InvaderBuildDeck.Insert(0, invasion.InvaderDeck[0]);
                MoveCardToNextLocation(invasion.InvaderBuildDeck[0]);
                invasion.InvaderDeck.RemoveAt(0);
            }

            if (invasion.HighImmigration == true && invasion.MyAdversary.Level == 3 && invasion.InvaderDiscardDeck.Count == 3)
            {
                invasion.HighImmigration = false;
                if (invasion.InvaderHighImmigrationDeck.Count > 0)
                {
                    invasion.InvaderDiscardDeck.Insert(0, invasion.InvaderHighImmigrationDeck[0]);
                    MoveCardToNextLocation(invasion.InvaderDiscardDeck[0]);
                    invasion.InvaderHighImmigrationDeck.RemoveAt(0);
                }
                RemoveHighImmigrationTile();
            }
        }

        #endregion Use Top Card of Deck<T> Methods

        #region Create/Move Cards between Deck/Canvas Locations

        private void DealCardToNewDeck(Card card)
        {
            if (card.GetType() == typeof(FearCard))
            {
                Canvas.SetLeft(card, Canvas.GetLeft(imgFearDeck));
                Canvas.SetTop(card, Canvas.GetTop(imgFearDeck));
            }
            else if (card.GetType() == typeof(EventCard))
            {
                Canvas.SetLeft(card, Canvas.GetLeft(imgEventDeck));
                Canvas.SetTop(card, Canvas.GetTop(imgEventDeck));
            }
            else if (card.GetType() == typeof(InvaderCard))
            {
                Canvas.SetLeft(card, Canvas.GetLeft(imgInvaderDeck));
                Canvas.SetTop(card, Canvas.GetTop(imgInvaderDeck));
            }
            else if (card.GetType() == typeof(BlightCard))
            {
                Canvas.SetLeft(card, Canvas.GetLeft(imgBlightCard));
                Canvas.SetTop(card, Canvas.GetTop(imgBlightCard));
            }
            else if (card.GetType() == typeof(TerrorCard))
            {
                Canvas.SetLeft(card, Canvas.GetLeft(imgTerrorCard));
                Canvas.SetTop(card, Canvas.GetTop(imgTerrorCard));
            }
            else if (card.GetType() == typeof(AdversaryCard))
            {
                Canvas.SetLeft(card, Canvas.GetLeft(imgMyAdversaryCard));
                Canvas.SetTop(card, Canvas.GetTop(imgMyAdversaryCard));
            }
        }

        private void MoveCardToNextLocation(Card card)
        {
            if (card.GetType() == typeof(EventCard))
            {
                Canvas.SetLeft(card, Canvas.GetLeft(imgEventDiscard));
                Canvas.SetTop(card, Canvas.GetTop(imgEventDiscard));
                BringToFront(card);
            }
            else if (card.GetType() == typeof(FearCard))
            {
                if (invasion.FearDeck.Contains(card))
                {
                    Canvas.SetLeft(card, Canvas.GetLeft(imgFearEarnedDeck));
                    Canvas.SetTop(card, Canvas.GetTop(imgFearEarnedDeck));
                    BringToFront(card);
                }
                else if (invasion.FearEarnedDeck.Contains(card))
                {
                    Canvas.SetLeft(card, Canvas.GetLeft(imgFearDiscard));
                    Canvas.SetTop(card, Canvas.GetTop(imgFearDiscard));
                    BringToFront(card);
                }
            }
            else if (card.GetType() == typeof(InvaderCard))
            {
                if (invasion.InvaderDeck.Contains(card))
                {
                    Canvas.SetLeft(card, Canvas.GetLeft(imgInvaderBuildDeck));
                    Canvas.SetTop(card, Canvas.GetTop(imgInvaderBuildDeck));
                    BringToFront(card);
                }
                else if (invasion.InvaderBuildDeck.Contains(card))
                {
                    Canvas.SetLeft(card, Canvas.GetLeft(imgInvaderRavageDeck));
                    Canvas.SetTop(card, Canvas.GetTop(imgInvaderRavageDeck));
                    BringToFront(card);
                }
                else if (invasion.InvaderRavageDeck.Contains(card) && invasion.HighImmigration == true)
                {
                    Canvas.SetLeft(card, Canvas.GetLeft(imgInvaderHighImmigration));
                    Canvas.SetTop(card, Canvas.GetTop(imgInvaderHighImmigration));
                    BringToFront(card);
                }
                else if (invasion.InvaderRavageDeck.Contains(card) && invasion.HighImmigration == false)
                {
                    Canvas.SetLeft(card, Canvas.GetLeft(imgInvaderDiscard));
                    Canvas.SetTop(card, Canvas.GetTop(imgInvaderDiscard));
                    BringToFront(card);
                }
                else if (invasion.InvaderHighImmigrationDeck.Contains(card))
                {
                    Canvas.SetLeft(card, Canvas.GetLeft(imgInvaderDiscard));
                    Canvas.SetTop(card, Canvas.GetTop(imgInvaderDiscard));
                    BringToFront(card);
                }
            }
        }

        #endregion Create/Move Cards between Deck/Canvas Locations

        #region Button Click Events

        private void btnFear_Click(object sender, RoutedEventArgs e)
        {
            invasion.Fear++;
            if (invasion.FearUntilNextCard == 0 && invasion.FearDeck.Count > 0)
            {
                GainOneFearCard();
                invasion.Fear = 0;
                CheckForWinOrLose();
            }

            if ((invasion.FearDeck.Count == (invasion.TotalFearCardsNeededToWin - invasion.FirstTerrorThreshold)) && invasion.TerrorCardOut == false)
            {
                DealCardToNewDeck(invasion.TerrorDeck[0]);
                mainCanvas.Children.Add(invasion.TerrorDeck[0]);
                invasion.TerrorCardOut = true;
            }
            else if ((invasion.FearDeck.Count == (invasion.TotalFearCardsNeededToWin - invasion.SecondTerrorThreshold))
                && invasion.TerrorDeck[0].Source != invasion.TerrorDeck[0].FrontSide)
            {
                invasion.TerrorDeck[0].FlipCard();
            }
        }

        private void btnRemoveOneFear_Click(object sender, RoutedEventArgs e)
        {
            invasion.Fear--;
        }

        private void btnAddBlight_Click(object sender, RoutedEventArgs e)
        {
            invasion.Blight++;
        }

        private void btnRemoveBlight_Click(object sender, RoutedEventArgs e)
        {
            invasion.Blight--;

            if (invasion.Blight == 0 && invasion.BlightDeck[0].IsFaceUp() == false)
            {
                invasion.BlightDeck[0].FlipCard();
                invasion.Blight = invasion.PlayerCount * 5;
                FrmCardView frmCardView = new FrmCardView();
                frmCardView.ShowCard = invasion.BlightDeck[0].Source;
                frmCardView.ShowDialog();
                MessageBox.Show("Please remove the appropriate amount of Blight.");
            }
            else if (invasion.Blight == 0 && invasion.BlightDeck[0].IsFaceUp() == true)
            {
                MessageBox.Show("You lose! =(");
            }
        }

        #endregion Button Click Events

        #region General Menu Click Events

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            StartNewGame();
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            FrmAbout frmAboutDialog = new FrmAbout();
            frmAboutDialog.ShowDialog();
        }

        #endregion General Menu Click Events

        #region Event Card Menu Click Events

        private void eventIgnoreTheCuriosity_Click(object sender, RoutedEventArgs e)
        {
            if (invasion.InvaderDeck.Count > 0)
            {
                invasion.InvaderBox.Insert(0, invasion.InvaderDeck[0]);
                invasion.InvaderDeck[0].Visibility = Visibility.Hidden;
                invasion.InvaderDeck.RemoveAt(0);
            }
        }

        private void eventNewSpeciesSpread_Click(object sender, RoutedEventArgs e)
        {
            if (invasion.EventDiscardDeck.Count > 0)
            {
                invasion.EventDeck.Insert(2, invasion.EventDiscardDeck[0]);
                invasion.EventDiscardDeck[0].Visibility = Visibility.Hidden;
                invasion.EventDiscardDeck.RemoveAt(0);
            }
        }

        private void eventSlaveRebellion_Click(object sender, RoutedEventArgs e)
        {
            if (invasion.EventDiscardDeck.Count > 0)
            {
                if (invasion.MyAdversary.Id == 3 && invasion.MyAdversary.Level >= 2)
                {
                    invasion.EventDeck.Insert(3, invasion.EventDiscardDeck[0]);
                    invasion.EventDiscardDeck[0].Visibility = Visibility.Hidden;
                    invasion.EventDiscardDeck.RemoveAt(0);
                }
            }
        }

        private void eventWarTouchesTheIslandsShores_Click(object sender, RoutedEventArgs e)
        {
            invasion.FearDeck.Insert(0, invasion.FearBox[0]);

            DealCardToNewDeck(invasion.FearDeck[0]);
            mainCanvas.Children.Add(invasion.FearDeck[0]);
            BringToFront(invasion.FearDeck[0]);

            invasion.FearBox.RemoveAt(0);
        }

        private void eventWeaveLiesInTheirMinds_Click(object sender, RoutedEventArgs e)
        {
            if (invasion.FearDeck.Count > 0)
            {
                invasion.FearBox.Insert(0, invasion.FearDeck[0]);
                invasion.FearDeck[0].Visibility = Visibility.Hidden;
                invasion.FearDeck.RemoveAt(0);
            }
        }

        #endregion Event Card Menu Click Events

        #region Special Powers Menu Click Events

        private void showTopFear_Click(object sender, RoutedEventArgs e)
        {
            if (invasion.FearDeck.Count > 0)
            {
                invasion.FearDeck[0].FlipCard();
            }
        }

        #endregion Special Powers Menu Click Events

        #region React to Mouse Clicks and Drags on Canvas

        private void DoDoubleClickCardAction(Card card)
        {
            if (card.GetType() == typeof(FearCard) && invasion.FearEarnedDeck.Contains(card))
            {
                UseTopFearCard();
            }
            else if (card.GetType() == typeof(EventCard) && invasion.EventDeck.Contains(card))
            {
                UseTopEventCard();
            }
            else if (card.GetType() == typeof(InvaderCard) && invasion.InvaderDeck.Contains(card))
            {
                UseTopInvaderCard();
            }
            else
            {
                ShowCardZoom(card);
            }
        }

        private void ShowCardZoom(Card card)
        {
            FrmCardView frmCardView = new FrmCardView();
            frmCardView.ShowCard = card.Source;
            frmCardView.Owner = Application.Current.MainWindow;
            frmCardView.ShowDialog();
        }

        private void mainCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var card = e.Source as Card;

            // Code for being able to drag and drop cards on the canvas
            //if (card != null && mainCanvas.CaptureMouse())
            //{
            //    e.Handled = true;
            //    mousePosition = e.GetPosition(mainCanvas);
            //    draggedImage = card;
            //    BringToFront(draggedImage as UIElement);
            //}

            // Code for showing a card zoomed in on double click
            if (card != null && e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                _draggedImage = null;
                DoDoubleClickCardAction(card);
            }
        }

        private void mainCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_draggedImage != null)
            {
                mainCanvas.ReleaseMouseCapture();
                _draggedImage = null;
            }
        }

        private void mainCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_draggedImage != null)
            {
                var position = e.GetPosition(mainCanvas);
                var offset = position - _mousePosition;
                _mousePosition = position;
                Canvas.SetLeft(_draggedImage, Canvas.GetLeft(_draggedImage) + offset.X);
                Canvas.SetTop(_draggedImage, Canvas.GetTop(_draggedImage) + offset.Y);
            }
        }

        #endregion React to Mouse Clicks and Drags on Canvas

        #region Changing ZOrder of Dragged Items

        public void BringToFront(UIElement element)
        {
            UpdateZOrder(element, true);
        }

        public void SendToBack(UIElement element)
        {
            UpdateZOrder(element, false);
        }

        private void UpdateZOrder(UIElement element, bool bringToFront)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            if (!mainCanvas.Children.Contains(element))
                throw new ArgumentException("Must be a child element of the Canvas.", "element");

            // Determine the Z-Index for the target UIElement.
            int elementNewZIndex = -1;
            if (bringToFront)
            {
                foreach (UIElement elem in mainCanvas.Children)
                {
                    if (elem.Visibility != Visibility.Collapsed)
                    {
                        ++elementNewZIndex;
                    }
                }
            }
            else
            {
                elementNewZIndex = 0;
            }

            // Determine if the other UIElements' Z-Index
            // should be raised or lowered by one.
            int offset = (elementNewZIndex == 0) ? +1 : -1;

            int elementCurrentZIndex = Canvas.GetZIndex(element);

            // Update the Z-Index of every UIElement in the Canvas.
            foreach (UIElement childElement in mainCanvas.Children)
            {
                if (childElement == element)
                {
                    Canvas.SetZIndex(element, elementNewZIndex);
                }
                else
                {
                    int zIndex = Canvas.GetZIndex(childElement);

                    // Only modify the z-index of an element if it is
                    // in between the target element's old and new z-index.
                    if (bringToFront && elementCurrentZIndex < zIndex || !bringToFront && zIndex < elementCurrentZIndex)
                    {
                        Canvas.SetZIndex(childElement, zIndex + offset);
                    }
                }
            }

            // Keep these always on top
            Canvas.SetZIndex(lblBlight, 99);
            Canvas.SetZIndex(lblFear, 99);
            Canvas.SetZIndex(lblFearCardsEarned, 99);
            Canvas.SetZIndex(lblFearDeckCount, 99);
            Canvas.SetZIndex(lblFearUntilNext, 99);
            Canvas.SetZIndex(lblInvaderDeck, 99);
        }

        #endregion Changing ZOrder of Dragged Items

        #region ScaleValue Depdency Property

        public static readonly DependencyProperty ScaleValueProperty = DependencyProperty.Register("ScaleValue", typeof(double), typeof(MainWindow), new UIPropertyMetadata(1.0, new PropertyChangedCallback(OnScaleValueChanged), new CoerceValueCallback(OnCoerceScaleValue)));

        private static object OnCoerceScaleValue(DependencyObject o, object value)
        {
            MainWindow mainWindow = o as MainWindow;
            if (mainWindow != null)
                return mainWindow.OnCoerceScaleValue((double)value);
            else
                return value;
        }

        private static void OnScaleValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            MainWindow mainWindow = o as MainWindow;
            if (mainWindow != null)
                mainWindow.OnScaleValueChanged((double)e.OldValue, (double)e.NewValue);
        }

        protected virtual double OnCoerceScaleValue(double value)
        {
            if (double.IsNaN(value))
                return 1.0f;

            value = Math.Max(0.1, value);
            return value;
        }

        protected virtual void OnScaleValueChanged(double oldValue, double newValue)
        {
        }

        public double ScaleValue
        {
            get
            {
                return (double)GetValue(ScaleValueProperty);
            }
            set
            {
                SetValue(ScaleValueProperty, value);
            }
        }

        private void MainGrid_SizeChanged(object sender, EventArgs e)
        {
            CalculateScale();
        }

        private void CalculateScale()
        {
            double yScale = ActualHeight / (frmMain.MinHeight * 1.9);    // 635f ... 605
            double xScale = ActualWidth / (frmMain.MinWidth * 2);     // 870f
            double value = Math.Min(xScale, yScale);
            ScaleValue = (double)OnCoerceScaleValue(frmMain, value);
        }

        #endregion ScaleValue Depdency Property
    }
}