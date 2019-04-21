using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SpiritIslandCompanion
{
    public class Invasion : INotifyPropertyChanged, INotifyCollectionChanged
    {
        #region INotify...Changed Implimentation

        public event PropertyChangedEventHandler PropertyChanged;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void NotifyCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        #endregion INotify...Changed Implimentation

        #region Invasion as a Singleton Implimentation (needs review)

        private static Invasion instance = null;
        private static readonly object padlock = new object();

        public static Invasion Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Invasion();
                    }
                    return instance;
                }
            }
        }

        #endregion Invasion as a Singleton Implimentation (needs review)

        #region Private Members

        private int _fear = 0;
        private int _playerCount = 1;
        private int _blightCount = 2;
        private int _terrorOne = 3;
        private int _terrorTwo = 3;
        private int _terrorThree = 3;
        private AdversaryCard _adversary;
        private bool _highImmigration = false;
        private bool _terrorCardOut = false;

        private ObservableCollection<FearCard> _fearDeck;
        private ObservableCollection<FearCard> _fearEarnedDeck;
        private ObservableCollection<FearCard> _fearDiscardDeck;
        private ObservableCollection<FearCard> _fearBox;

        private ObservableCollection<EventCard> _eventDeck;
        private ObservableCollection<EventCard> _eventDiscardDeck;
        private ObservableCollection<EventCard> _eventBox;

        private ObservableCollection<InvaderCard> _invaderDeck;
        private ObservableCollection<InvaderCard> _invaderHighImmigrationDeck;
        private ObservableCollection<InvaderCard> _invaderRavageDeck;
        private ObservableCollection<InvaderCard> _invaderBuildDeck;
        private ObservableCollection<InvaderCard> _invaderDiscardDeck;
        private ObservableCollection<InvaderCard> _invaderBox;

        private ObservableCollection<BlightCard> _blightCard;
        private ObservableCollection<BlightCard> _blightBox;

        private ObservableCollection<TerrorCard> _terrorCard;

        private ObservableCollection<AdversaryCard> _adversaryDeck;
        // private ObservableCollection<AdversaryCard> _adversaryBox;

        #endregion Private Members

        #region Properties

        public AdversaryCard MyAdversary
        {
            get { return _adversary; }
            set { _adversary = value; NotifyPropertyChanged(); }
        }

        public int Fear
        {
            get { return _fear; }
            set { _fear = value; NotifyPropertyChanged(); NotifyPropertyChanged("FearUntilNextCard"); }
        }

        public int FearUntilNextCard
        {
            get
            {
                if (MyAdversary != null)
                {
                    if (MyAdversary.Id == 2 && MyAdversary.Level == 6)
                    {
                        // England Level 6
                        return ((PlayerCount * 5) - Fear);
                    }
                    else
                    {
                        return ((PlayerCount * 4) - Fear);
                    }
                }
                else
                {
                    return ((PlayerCount * 4) - Fear);
                }
            }
        }

        public int PlayerCount
        {
            get { return _playerCount; }
            set { _playerCount = value; NotifyPropertyChanged(); }
        }

        public int Blight
        {
            get { return _blightCount; }
            set { _blightCount = value; NotifyPropertyChanged(); }
        }

        public int TotalFearCardsNeededToWin
        {
            get { return _terrorOne + _terrorTwo + _terrorThree; }
        }

        public int FirstTerrorThreshold
        {
            get { return _terrorOne; }
        }

        public int SecondTerrorThreshold
        {
            get { return _terrorOne + _terrorTwo; }
        }

        public bool HighImmigration
        {
            get { return _highImmigration; }
            set { _highImmigration = value; NotifyPropertyChanged(); }
        }

        public bool TerrorCardOut
        {
            get { return _terrorCardOut; }
            set { _terrorCardOut = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<FearCard> FearDeck
        {
            get { return _fearDeck; }
            set { _fearDeck = value; NotifyPropertyChanged(); NotifyPropertyChanged("TopFearCard"); }
        }

        public ObservableCollection<FearCard> FearEarnedDeck
        {
            get { return _fearEarnedDeck; }
            set { _fearEarnedDeck = value; NotifyPropertyChanged(); NotifyPropertyChanged("TopFearEarnedCard"); }
        }

        public ObservableCollection<FearCard> FearDiscardDeck
        {
            get { return _fearDiscardDeck; }
            set { _fearDiscardDeck = value; NotifyPropertyChanged(); NotifyPropertyChanged("TopFearDisCard"); }
        }

        public ObservableCollection<EventCard> EventDeck
        {
            get { return _eventDeck; }
            set { _eventDeck = value; NotifyPropertyChanged(); NotifyPropertyChanged("TopEventCard"); }
        }

        public ObservableCollection<EventCard> EventDiscardDeck
        {
            get { return _eventDiscardDeck; }
            set { _eventDiscardDeck = value; NotifyPropertyChanged(); NotifyPropertyChanged("TopEventDisCard"); }
        }

        public ObservableCollection<InvaderCard> InvaderDeck
        {
            get { return _invaderDeck; }
            set { _invaderDeck = value; NotifyPropertyChanged(); NotifyPropertyChanged("TopInvaderCard"); }
        }

        public ObservableCollection<InvaderCard> InvaderHighImmigrationDeck
        {
            get { return _invaderHighImmigrationDeck; }
            set { _invaderHighImmigrationDeck = value; NotifyPropertyChanged(); NotifyPropertyChanged("TopInvaderCard"); }
        }

        public ObservableCollection<InvaderCard> InvaderRavageDeck
        {
            get { return _invaderRavageDeck; }
            set { _invaderRavageDeck = value; NotifyPropertyChanged(); NotifyPropertyChanged("TopInvaderCard"); }
        }

        public ObservableCollection<InvaderCard> InvaderBuildDeck
        {
            get { return _invaderBuildDeck; }
            set { _invaderBuildDeck = value; NotifyPropertyChanged(); NotifyPropertyChanged("TopInvaderCard"); }
        }

        public ObservableCollection<InvaderCard> InvaderDiscardDeck
        {
            get { return _invaderDiscardDeck; }
            set { _invaderDiscardDeck = value; NotifyPropertyChanged(); NotifyPropertyChanged("TopInvaderCard"); }
        }

        public ObservableCollection<BlightCard> BlightDeck
        {
            get { return _blightCard; }
            set { _blightCard = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<TerrorCard> TerrorDeck
        {
            get { return _terrorCard; }
            set { _terrorCard = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<AdversaryCard> AdversaryDeck
        {
            get { return _adversaryDeck; }
            set { _adversaryDeck = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<FearCard> FearBox
        {
            get { return _fearBox; }
            set { _fearBox = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<InvaderCard> InvaderBox
        {
            get { return _invaderBox; }
            set { _invaderBox = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<BlightCard> BlightBox
        {
            get { return _blightBox; }
            set { _blightBox = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<EventCard> EventBox
        {
            get { return _eventBox; }
            set { _eventBox = value; NotifyPropertyChanged(); }
        }

        //public ObservableCollection<AdversaryCard> AdversaryBox
        //{
        //    get { return _adversaryBox; }
        //    set { _adversaryBox = value; NotifyPropertyChanged(); }
        //}

        #endregion Properties

        #region Ctor

        public Invasion(int players = 1)
        {
            Reset();
            PlayerCount = players;
            Fear = 0;
            Blight = players * 2;
            HighImmigration = false;

            CreateAdversaryDeck();
            CreateTerrorCard();
            CreateBlightCard();
            CreateFearDeck();
            CreateEventDeck();
            CreateInvaderDeck();
        }

        public Invasion(AdversaryCard adv, int advLevel = 0, int players = 1) : this(players)
        {
            MyAdversary = adv;
            MyAdversary.Level = advLevel;

            if (MyAdversary.Id == 0)
            {
                SetUpDefaultAdversary();
            }
            else if (MyAdversary.Id == 1)
            {
                SetUpBrandenburgPrussia(advLevel);
            }
            else if (MyAdversary.Id == 2)
            {
                SetUpEngland(advLevel);
            }
            else if (MyAdversary.Id == 3)
            {
                SetUpFrance(advLevel);
            }
            else if (MyAdversary.Id == 4)
            {
                SetUpSweden(advLevel);
            }
            else { MessageBox.Show("Error"); }
        }

        #endregion Ctor

        #region Other Methods

        private void SetUpFearCards(int first, int second, int third)
        {
            _terrorOne = first;
            _terrorTwo = second;
            _terrorThree = third;
        }

        private void Reset()
        {
            FearDeck = new ObservableCollection<FearCard>();
            FearEarnedDeck = new ObservableCollection<FearCard>();
            FearDiscardDeck = new ObservableCollection<FearCard>();
            FearBox = new ObservableCollection<FearCard>();

            EventDeck = new ObservableCollection<EventCard>();
            EventDiscardDeck = new ObservableCollection<EventCard>();
            EventBox = new ObservableCollection<EventCard>();

            InvaderDeck = new ObservableCollection<InvaderCard>();
            InvaderHighImmigrationDeck = new ObservableCollection<InvaderCard>();
            InvaderRavageDeck = new ObservableCollection<InvaderCard>();
            InvaderBuildDeck = new ObservableCollection<InvaderCard>();
            InvaderDiscardDeck = new ObservableCollection<InvaderCard>();
            InvaderBox = new ObservableCollection<InvaderCard>();

            BlightDeck = new ObservableCollection<BlightCard>();
            BlightBox = new ObservableCollection<BlightCard>();

            TerrorDeck = new ObservableCollection<TerrorCard>();

            AdversaryDeck = new ObservableCollection<AdversaryCard>();
            //AdversaryBox = new ObservableCollection<AdversaryCard>();
        }

        #endregion Other Methods

        #region Set Up Adversaries

        private void SetUpDefaultAdversary()
        {
            CreateFearDeck();
            SetUpFearCards(3, 3, 3);
        }

        private void SetUpBrandenburgPrussia(int level)
        {
            if (level == 0 || level == 1 || level == 2)
            {
                CreateFearDeck();
                SetUpFearCards(3, 3, 3);
            }

            if (level == 2)
            {
                InvaderDeck.Move(InvaderDeck.Count - 1, 3);
            }
            else if (level == 3)
            {
                CreateFearDeck(10);
                SetUpFearCards(3, 4, 3);

                InvaderDeck.Move(InvaderDeck.Count - 1, 3);
                InvaderBox.Add(InvaderDeck[0]);
                InvaderDeck.RemoveAt(0);
            }
            else if (level == 4)
            {
                CreateFearDeck(11);
                SetUpFearCards(4, 4, 3);

                InvaderDeck.Move(InvaderDeck.Count - 1, 3);
                InvaderBox.Add(InvaderDeck[0]);
                InvaderDeck.RemoveAt(0);
                InvaderBox.Add(InvaderDeck[3]);
                InvaderDeck.RemoveAt(3);
            }
            else if (level == 5)
            {
                CreateFearDeck(11);
                SetUpFearCards(4, 4, 3);

                InvaderDeck.Move(InvaderDeck.Count - 1, 3);
                InvaderBox.Add(InvaderDeck[0]);
                InvaderDeck.RemoveAt(0);
                InvaderBox.Add(InvaderDeck[3]);
                InvaderDeck.RemoveAt(3);
                InvaderBox.Add(InvaderDeck[0]);
                InvaderDeck.RemoveAt(0);
            }
            else if (level == 6)
            {
                CreateFearDeck(12);
                SetUpFearCards(4, 4, 4);

                InvaderDeck.Move(InvaderDeck.Count - 1, 3);
                InvaderBox.Add(InvaderDeck[0]);
                InvaderDeck.RemoveAt(0);
                InvaderBox.Add(InvaderDeck[3]);
                InvaderDeck.RemoveAt(3);
                InvaderBox.Add(InvaderDeck[0]);
                InvaderDeck.RemoveAt(0);
                InvaderBox.Add(InvaderDeck[0]);
                InvaderDeck.RemoveAt(0);
            }
        }

        private void SetUpEngland(int level)
        {
            if (level == 0)
            {
                CreateFearDeck();
                SetUpFearCards(3, 3, 3);
            }
            else if (level == 1)
            {
                CreateFearDeck(10);
                SetUpFearCards(3, 4, 3);
            }
            else if (level == 2)
            {
                CreateFearDeck(11);
                SetUpFearCards(4, 4, 3);
            }
            else if (level == 3)
            {
                CreateFearDeck(13);
                SetUpFearCards(4, 5, 4);
            }
            else if (level == 4)
            {
                CreateFearDeck(14);
                SetUpFearCards(4, 5, 5);
            }
            else if (level == 5)
            {
                CreateFearDeck(14);
                SetUpFearCards(4, 5, 5);
            }
            else if (level == 6)
            {
                CreateFearDeck(13);
                SetUpFearCards(4, 5, 4);
            }

            if (level >= 3)
            {
                HighImmigration = true;
            }
        }

        private void SetUpFrance(int level)
        {
            if (level == 0 || level == 1)
            {
                CreateFearDeck();
                SetUpFearCards(3, 3, 3);
            }
            else if (level == 2)
            {
                CreateFearDeck(10);
                SetUpFearCards(3, 4, 3);
            }
            else if (level == 3)
            {
                CreateFearDeck(11);
                SetUpFearCards(4, 4, 3);
            }
            else if (level == 4)
            {
                CreateFearDeck(12);
                SetUpFearCards(4, 4, 4);
            }
            else if (level == 5)
            {
                CreateFearDeck(13);
                SetUpFearCards(4, 5, 4);
            }
            else if (level == 6)
            {
                CreateFearDeck(14);
                SetUpFearCards(4, 5, 5);
            }

            if (level >= 2)
            {
                EventDeck.Insert(3, EventBox[0]);
            }
        }

        private void SetUpSweden(int level)
        {
            if (level == 0 || level == 1)
            {
                CreateFearDeck();
                SetUpFearCards(3, 3, 3);
            }
            else if (level == 2)
            {
                CreateFearDeck(10);
                SetUpFearCards(3, 4, 3);
            }
            else if (level == 3)
            {
                CreateFearDeck(10);
                SetUpFearCards(3, 4, 3);
            }
            else if (level == 4)
            {
                CreateFearDeck(11);
                SetUpFearCards(3, 4, 4);
            }
            else if (level == 5)
            {
                CreateFearDeck(12);
                SetUpFearCards(4, 4, 4);
            }
            else if (level == 6)
            {
                CreateFearDeck(13);
                SetUpFearCards(4, 4, 5);
            }

            if (level >= 4)
            {
                InvaderBox.Add(InvaderDeck[0]);
                InvaderDeck.RemoveAt(0);
            }
        }

        #endregion Set Up Adversaries

        #region Create All the Decks

        private void CreateTerrorCard()
        {
            TerrorDeck.Clear();
            // construct and initialize all 'board cards'
            String backPath = "assets/other/board/board-terror-level2.png";
            ImageSource back = new BitmapImage(new Uri(backPath, UriKind.Relative));
            String frontPath = "assets/other/board/board-terror-level3.png";
            ImageSource front = new BitmapImage(new Uri(frontPath, UriKind.Relative));
            TerrorCard bc = new TerrorCard(0, front, back);
            TerrorDeck.Add(bc);
        }

        private void CreateFearDeck(int deckSize = 9)
        {
            FearDeck.Clear();
            FearBox.Clear();

            // construct and initialize all 30 Fear cards
            for (int i = 1; i <= 30; i++)
            {
                String backPath = "assets/cards/fear/cards-fear-00.png";
                ImageSource back = new BitmapImage(new Uri(backPath, UriKind.Relative));

                String s = "";
                if (i < 10)
                {
                    s = "0" + i.ToString();
                }
                else
                {
                    s = i.ToString();
                }
                String frontPath = "assets/cards/fear/cards-fear-" + s + ".png";
                ImageSource front = new BitmapImage(new Uri(frontPath, UriKind.Relative));

                FearCard fc = new FearCard(i, front, back);
                FearDeck.Add(fc);
            }
            FearDeck.Shuffle();

            while (FearDeck.Count > deckSize)
            {
                FearBox.Add(FearDeck[0]);
                FearDeck.RemoveAt(0);
            }
            FearDeck.Shuffle();
        }

        private void CreateEventDeck(int deckSize = 26)
        {
            EventBox.Clear();
            EventDeck.Clear();

            // construct and initialize all 26 Event cards
            for (int i = 1; i <= 26; i++)
            {
                String backPath = "assets/cards/event/cards-event-00.png";
                ImageSource back = new BitmapImage(new Uri(backPath, UriKind.Relative));

                String s = "";
                if (i < 10)
                {
                    s = "0" + i.ToString();
                }
                else
                {
                    s = i.ToString();
                }
                String frontPath = "assets/cards/event/cards-event-" + s + ".png";
                ImageSource front = new BitmapImage(new Uri(frontPath, UriKind.Relative));

                EventCard ec = new EventCard(i, front, back);
                EventDeck.Add(ec);
            }

            EventBox.Add(EventDeck[0]);
            EventDeck.RemoveAt(0);
            EventDeck.Shuffle();
        }

        private void CreateInvaderDeck()
        {
            InvaderBox.Clear();
            InvaderDeck.Clear();

            // construct and initialize all Invader cards by Phase
            for (int i = 1; i <= 4; i++)
            {
                String backPath = "assets/cards/invader/cards-invader-00.png";
                ImageSource back = new BitmapImage(new Uri(backPath, UriKind.Relative));

                String s = "0" + i.ToString();
                String frontPath = "assets/cards/invader/cards-invader-" + s + ".png";
                ImageSource front = new BitmapImage(new Uri(frontPath, UriKind.Relative));

                InvaderCard ic = new InvaderCard(i, 1, front, back);
                InvaderDeck.Add(ic);
            }
            InvaderDeck.Shuffle();

            InvaderBox.Add(InvaderDeck[0]);
            InvaderDeck.RemoveAt(0);

            ObservableCollection<InvaderCard> phase2 = new ObservableCollection<InvaderCard>();
            for (int i = 6; i <= 10; i++)
            {
                String backPath = "assets/cards/invader/cards-invader-05.png";
                ImageSource back = new BitmapImage(new Uri(backPath, UriKind.Relative));

                String s = "";
                if (i < 10)
                {
                    s = "0" + i.ToString();
                }
                else
                {
                    s = i.ToString();
                }
                String frontPath = "assets/cards/invader/cards-invader-" + s + ".png";
                ImageSource front = new BitmapImage(new Uri(frontPath, UriKind.Relative));

                InvaderCard ic = new InvaderCard(i, 2, front, back);
                phase2.Add(ic);
            }
            phase2.Shuffle();

            InvaderBox.Add(phase2[0]);
            phase2.RemoveAt(0);

            foreach (InvaderCard c in phase2)
            {
                InvaderDeck.Add(c);
            }

            ObservableCollection<InvaderCard> phase3 = new ObservableCollection<InvaderCard>();
            for (int i = 12; i <= 17; i++)
            {
                String backPath = "assets/cards/invader/cards-invader-11.png";
                ImageSource back = new BitmapImage(new Uri(backPath, UriKind.Relative));

                String s = i.ToString();
                String frontPath = "assets/cards/invader/cards-invader-" + s + ".png";
                ImageSource front = new BitmapImage(new Uri(frontPath, UriKind.Relative));

                InvaderCard ic = new InvaderCard(i, 3, front, back);
                phase3.Add(ic);
            }
            phase3.Shuffle();

            InvaderBox.Add(phase3[0]);
            phase3.RemoveAt(0);

            foreach (InvaderCard c in phase3)
            {
                InvaderDeck.Add(c);
            }
        }

        private void CreateBlightCard(int deckSize = 1)
        {
            BlightDeck.Clear();
            BlightBox.Clear();

            // construct and initialize all 9 Blight cards
            for (int i = 1; i <= 9; i++)
            {
                String backPath = "assets/cards/blight/cards-blight-00.png";
                ImageSource back = new BitmapImage(new Uri(backPath, UriKind.Relative));

                String s = "";
                if (i < 10)
                {
                    s = "0" + i.ToString();
                }
                else
                {
                    s = i.ToString();
                }
                String frontPath = "assets/cards/blight/cards-blight-" + s + ".png";
                ImageSource front = new BitmapImage(new Uri(frontPath, UriKind.Relative));

                BlightCard bc = new BlightCard(i, front, back);
                BlightDeck.Add(bc);
            }
            BlightDeck.Shuffle();

            while (BlightDeck.Count > deckSize)
            {
                BlightBox.Add(BlightDeck[0]);
                BlightDeck.RemoveAt(0);
            }
        }

        private void CreateAdversaryDeck()
        {
            AdversaryDeck.Clear();

            // Generic Difficulty Zero
            String frontPath = "assets/other/adversaries/adversary-brand-prussia-2.png";
            ImageSource front = new BitmapImage(new Uri(frontPath, UriKind.Relative));
            String backPath = "assets/other/adversaries/adversary-brand-prussia-2.png";
            ImageSource back = new BitmapImage(new Uri(backPath, UriKind.Relative));
            AdversaryCard a = new AdversaryCard(0, "Derp", 0, front, back);
            AdversaryDeck.Add(a);

            // Brandenburg Prussia
            frontPath = "assets/other/adversaries/adversary-brand-prussia-1.png";
            front = new BitmapImage(new Uri(frontPath, UriKind.Relative));
            backPath = "assets/other/adversaries/adversary-brand-prussia-2.png";
            back = new BitmapImage(new Uri(backPath, UriKind.Relative));
            a = new AdversaryCard(1, "Brandenburg-Prussia", 0, front, back);
            AdversaryDeck.Add(a);

            // England
            frontPath = "assets/other/adversaries/adversary-england-1.png";
            front = new BitmapImage(new Uri(frontPath, UriKind.Relative));
            backPath = "assets/other/adversaries/adversary-england-2.png";
            back = new BitmapImage(new Uri(backPath, UriKind.Relative));
            a = new AdversaryCard(2, "England", 0, front, back);
            AdversaryDeck.Add(a);

            // France
            frontPath = "assets/other/adversaries/adversary-france-1.png";
            front = new BitmapImage(new Uri(frontPath, UriKind.Relative));
            backPath = "assets/other/adversaries/adversary-france-2.png";
            back = new BitmapImage(new Uri(backPath, UriKind.Relative));
            a = new AdversaryCard(3, "France", 0, front, back);
            AdversaryDeck.Add(a);

            // Sweden
            frontPath = "assets/other/adversaries/adversary-sweden-1.png";
            front = new BitmapImage(new Uri(frontPath, UriKind.Relative));
            backPath = "assets/other/adversaries/adversary-sweden-2.png";
            back = new BitmapImage(new Uri(backPath, UriKind.Relative));
            a = new AdversaryCard(4, "Sweden", 0, front, back);
            AdversaryDeck.Add(a);
        }

        #endregion Create All the Decks
    }

    #region Shuffle Extension Classes

    public static class ThreadSafeRandom
    {
        [ThreadStatic] private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }

    internal static class MyExtensions
    {
        public static void Shuffle<T>(this ObservableCollection<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    #endregion Shuffle Extension Classes
}