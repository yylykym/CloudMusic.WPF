using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CloudMusic.WPF.Controls
{
    /// <summary>
    /// BannerCardControl.xaml 的交互逻辑
    /// </summary>
    public partial class BannerCardControl : UserControl
    {
        public BannerCardControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 定义 CardTitle (卡片标题) 依赖属性
        /// </summary>
        public static readonly DependencyProperty CardTitleProperty =
                    DependencyProperty.Register(
                        nameof(CardTitle),                // 1. 属性名称
                        typeof(string),                   // 2. 属性的类型
                        typeof(BannerCardControl),        // 3. 拥有该属性的类（当前 UserControl）
                        new PropertyMetadata("默认标题")   // 4. 元数据（可设置默认值，或属性改变时的回调事件）
                    );

        /// <summary>
        /// CLR 包装器（让外部可以通过 .CardTitle = "xxx" 正常调用）
        /// </summary>
        public string CardTitle
        {
            get { return (string)GetValue(CardTitleProperty); }
            set { SetValue(CardTitleProperty, value); }
        }

        /// <summary>
        /// 定义 CoverImage (背景图) 依赖属性
        /// </summary>
        public static readonly DependencyProperty CoverImageProperty =
                    DependencyProperty.Register(
                        nameof(CoverImage),
                        typeof(ImageSource),              // 图片类型通常用 ImageSource
                        typeof(BannerCardControl),
                        new PropertyMetadata(null)
                    );

        public ImageSource CoverImage
        {
            get { return (ImageSource)GetValue(CoverImageProperty); }
            set { SetValue(CoverImageProperty, value); }
        }

    }
}
