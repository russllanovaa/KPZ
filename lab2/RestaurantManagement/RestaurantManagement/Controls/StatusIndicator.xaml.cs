using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace RestaurantManagement.Controls
{
    public partial class StatusIndicator : UserControl
    {
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(string), typeof(StatusIndicator),
                new PropertyMetadata("Pending", OnStatusChanged));

        public string Status
        {
            get => (string)GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }

        public static readonly DependencyProperty StatusColorProperty =
            DependencyProperty.Register("StatusColor", typeof(SolidColorBrush), typeof(StatusIndicator),
                new PropertyMetadata(new SolidColorBrush(Color.FromRgb(33, 150, 243))));

        public SolidColorBrush StatusColor
        {
            get => (SolidColorBrush)GetValue(StatusColorProperty);
            set => SetValue(StatusColorProperty, value);
        }

        public static readonly DependencyProperty StatusTextProperty =
            DependencyProperty.Register("StatusText", typeof(string), typeof(StatusIndicator));

        public string StatusText
        {
            get => (string)GetValue(StatusTextProperty);
            set => SetValue(StatusTextProperty, value);
        }

        public StatusIndicator()
        {
            InitializeComponent();
            StatusBorder.Background = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            UpdateStatusDisplay();
        }

        private static void OnStatusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (StatusIndicator)d;
            control.UpdateStatusDisplay();
        }

        private void UpdateStatusDisplay()
        {
            Color targetColor;
            switch (Status?.ToLower())
            {
                case "completed":
                    targetColor = Color.FromRgb(46, 125, 50);
                    StatusText = "Completed";
                    break;
                case "preparing":
                    targetColor = Color.FromRgb(251, 140, 0);
                    StatusText = "Preparing";
                    break;
                case "pending":
                    targetColor = Color.FromRgb(33, 150, 243);
                    StatusText = "Pending";
                    break;
                case "cancelled":
                    targetColor = Color.FromRgb(244, 67, 54);
                    StatusText = "Cancelled";
                    break;
                default:
                    targetColor = Color.FromRgb(158, 158, 158);
                    StatusText = "Unknown";
                    break;
            }

            AnimateColor(targetColor);
        }

        private void AnimateColor(Color targetColor)
        {
            if (StatusBorder.Background is SolidColorBrush solidColorBrush)
            {
                var colorAnim = new ColorAnimation
                {
                    To = targetColor,
                    Duration = new Duration(TimeSpan.FromMilliseconds(500))
                };

                solidColorBrush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnim);
            }
        }
    }
}
