using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;

namespace SpiritIslandCompanion
{
    public abstract class Card : Image, INotifyPropertyChanged
    {
        private int _id;
        private ImageSource _frontImagePath;
        private ImageSource _backImagePath;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public ImageSource FrontSide
        {
            get { return _frontImagePath; }
            set { _frontImagePath = value; }
        }

        public ImageSource BackSide
        {
            get { return _backImagePath; }
            set { _backImagePath = value; }
        }

        public void FlipCard()
        {
            if (Source == BackSide)
            {
                Source = FrontSide;
                NotifyPropertyChanged();
            }
        }

        public bool IsFaceUp()
        {
            if (Source == FrontSide)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Card(int id, ImageSource front, ImageSource back, int height, int width)
        {
            _id = id;
            Height = height;
            Width = width;
            FrontSide = front;
            BackSide = back;
            Source = BackSide;
            Stretch = Stretch.UniformToFill;
        }
    }

    public class FearCard : Card
    {
        public FearCard(int id, ImageSource front, ImageSource back, int height = 176, int width = 126)
            : base(id, front, back, height, width)
        {
        }
    }

    public class EventCard : Card
    {
        public EventCard(int id, ImageSource front, ImageSource back, int height = 176, int width = 126)
            : base(id, front, back, height, width)
        {
        }
    }

    public class BlightCard : Card
    {
        public BlightCard(int id, ImageSource front, ImageSource back, int height = 176, int width = 126)
            : base(id, front, back, height, width)
        {
        }
    }

    public class InvaderCard : Card
    {
        private int _phase;

        public InvaderCard(int id, int phase, ImageSource front, ImageSource back, int height = 134, int width = 88)
            : base(id, front, back, height, width)
        {
            _phase = phase;
        }
    }

    public class TerrorCard : Card
    {
        public TerrorCard(int id, ImageSource front, ImageSource back, int height = 176, int width = 126)
            : base(id, front, back, height, width)
        {
        }
    }

    public class AdversaryCard : Card
    {
        private String _advName = "Derp";
        private int _advLevel = 0;

        public AdversaryCard(int id, String name, int level, ImageSource front, ImageSource back, int height = 176, int width = 264)
            : base(id, front, back, height, width)
        {
            Kingdom = name;
            Level = level;
            Source = FrontSide;
        }

        public String Kingdom
        {
            get { return _advName; }
            set { _advName = value; }
        }

        public int Level
        {
            get { return _advLevel; }
            set { _advLevel = value; }
        }
    }
}