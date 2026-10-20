using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace CloudMusic.WPF.Views.Components
{
    public partial class DailyRecommendationCard : UserControl
    {
        private static readonly TimeSpan HoverDuration = TimeSpan.FromMilliseconds(180);
        private const double DetailsSlideDistance = 12;

        public DailyRecommendationCard()
        {
            InitializeComponent();
        }

        private void CardSurface_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CardClip.Rect = new Rect(0, 0, e.NewSize.Width, e.NewSize.Height);
        }

        private void CardSurface_MouseEnter(object sender, MouseEventArgs e)
        {
            SetHoverState(true);
        }

        private void CardSurface_MouseLeave(object sender, MouseEventArgs e)
        {
            SetHoverState(false);
        }

        private void SetHoverState(bool isHovered)
        {
            // 透明度为零时也可能接收点击，所以同步控制命中测试。
            HoverDetails.IsHitTestVisible = isHovered;

            HoverShade.BeginAnimation(OpacityProperty, CreateAnimation(isHovered ? 1 : 0));
            NormalDescription.BeginAnimation(OpacityProperty, CreateAnimation(isHovered ? 0 : 1));
            HoverDetails.BeginAnimation(OpacityProperty, CreateAnimation(isHovered ? 1 : 0));
            DetailsOffset.BeginAnimation(
                TranslateTransform.YProperty,
                CreateAnimation(isHovered ? 0 : DetailsSlideDistance));
        }

        private static DoubleAnimation CreateAnimation(double target)
        {
            // 不指定 From：快速移入移出时，从当前动画值继续过渡。
            return new DoubleAnimation
            {
                To = target,
                Duration = new Duration(HoverDuration),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };
        }
    }
}
