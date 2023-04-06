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

namespace YetAnotherFlappyBird
{
    /// <summary>
    /// Interaction logic for PipeObject.xaml
    /// </summary>
    public partial class PipeObject : UserControl
    {
        private double _divisionOffset = 0.5;
        private double _divisionHeight = 200;
        private double _headHeight = 50;
        private double _headWidth = 200;
        private double _neckWidth = 140;

        public double DivisionOffset
        {
            get
            {
                return _divisionOffset;
            }
            set
            {
                _divisionOffset = value;
                this.UpdateGeometry();
            }
        }

        public double DivisionHeight
        {
            get => _divisionHeight;
            set
            {
                _divisionHeight = value;
                this.UpdateGeometry();
            }
        }

        public double HeadHeight
        {
            get => _headHeight;
            set
            {
                _headHeight = value;
                this.UpdateGeometry();
            }
        }

        public double HeadWidth
        {
            get => _headWidth;
            set
            {
                _headWidth = value;
                this.UpdateGeometry();
            }
        }

        public double NeckWidth
        {
            get => _neckWidth;
            set
            {
                _neckWidth = value;
                this.UpdateGeometry();
            }
        }

        public PipeObject()
        {
            InitializeComponent();
        }

        private void UpdateGeometry()
        {
            double neckLeftPosition = (Width - NeckWidth) / 2;
            double headLeftPosition = (Width - HeadWidth) / 2;
            // Upper part geometry.
            Canvas.SetLeft(UpperNeck, neckLeftPosition);
            Canvas.SetTop(UpperNeck, 0);

            double upperHeadTop = ((Height - HeadHeight) * DivisionOffset) - (DivisionHeight / 2);

            UpperNeck.Height = Math.Max(0, upperHeadTop);

            Canvas.SetLeft(UpperHead, headLeftPosition);
            Canvas.SetTop(UpperHead, upperHeadTop);

            // Lower part geometry.
            double lowerHeadTop = (Height * DivisionOffset) + (DivisionHeight / 2);

            Canvas.SetLeft(LowerNeck, neckLeftPosition);
            Canvas.SetTop(LowerNeck, lowerHeadTop + HeadHeight);

            LowerNeck.Height = Math.Max(0, Height - (lowerHeadTop + HeadHeight));

            Canvas.SetLeft(LowerHead, headLeftPosition);
            Canvas.SetTop(LowerHead, lowerHeadTop);
        }
    }
}
