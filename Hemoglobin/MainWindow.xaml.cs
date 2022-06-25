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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hemoglobin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Storyboard _showCloseButtonStoryboard = null;
        private Storyboard _hideCloseButtonStoryboard = null;
        private Storyboard _compactWndTopStoryboard = null;
        private Storyboard _compactWndLeftStoryboard = null;
        private Storyboard _expandWndTopStoryboard = null;
        private Storyboard _expandWndLeftStoryboard = null;

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                this.DataContext = Hemoglobin.ViewModel.HemoglobinVM.Instance;
            }
            catch { }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ButtonState == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            }
            catch { }
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                if (_showCloseButtonStoryboard == null && Resources["ShowCloseButtonStoryBoard"] is Storyboard sb)
                {
                    _showCloseButtonStoryboard = sb;
                }
                _showCloseButtonStoryboard?.Begin();
            }
            catch { }
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                if (_hideCloseButtonStoryboard == null && Resources["HideCloseButtonStoryBoard"] is Storyboard sb)
                {
                    _hideCloseButtonStoryboard = sb;
                }
                _hideCloseButtonStoryboard?.Begin();
            }
            catch { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch { }
        }

        private void OnWindowAreaMouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                AdjustExpandWindow();
            }
            catch { }
        }

        private void OnWindowAreaMouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                AdjustCompactWindow();
            }
            catch { }
        }

        private void OnWindowAreaDragEnter(object sender, DragEventArgs e)
        {
            try
            {
                AdjustExpandWindow();
            }
            catch { }
        }

        private void OnWindowAreaDragLeave(object sender, DragEventArgs e)
        {
            try
            {
                AdjustCompactWindow();
            }
            catch { }
        }

        private void AdjustCompactWindow()
        {
            try
            {
                double x = this.Left;
                double y = this.Top;
                bool? compactSide = null;    // true-top false-left null-no
                if (y <= 10 && x > 10)
                    compactSide = true;
                else if (y <= 10 && x <= 10)
                    compactSide = y <= x;
                else if (y > 10 && x <= 10)
                    compactSide = false;
                else
                    compactSide = null;

                if (compactSide == true)
                {
                    this.Top = 0;
                    Hemoglobin.ViewModel.HemoglobinVM.Instance.SetWindowCompact(ViewModel.WindowCompactType.TopCompact);

                    if (_compactWndTopStoryboard == null && Resources["CompactWndTopStoryBoard"] is Storyboard sb)
                    {
                        _compactWndTopStoryboard = sb;
                    }
                    _compactWndTopStoryboard?.Begin();
                }
                else if (compactSide == false)
                {
                    this.Left = 0;
                    Hemoglobin.ViewModel.HemoglobinVM.Instance.SetWindowCompact(ViewModel.WindowCompactType.LeftCompact);

                    if (_compactWndLeftStoryboard == null && Resources["CompactWndLeftStoryBoard"] is Storyboard sb)
                    {
                        _compactWndLeftStoryboard = sb;
                    }
                    _compactWndLeftStoryboard?.Begin();
                }
                else
                {
                    Hemoglobin.ViewModel.HemoglobinVM.Instance.SetWindowCompact(ViewModel.WindowCompactType.Expand);
                }
            }
            catch { }
        }

        private void AdjustExpandWindow()
        {
            try
            {
                var oldType = ViewModel.HemoglobinVM.Instance.eCompactType;
                Hemoglobin.ViewModel.HemoglobinVM.Instance.SetWindowCompact(ViewModel.WindowCompactType.Expand);

                if (oldType == ViewModel.WindowCompactType.TopCompact)
                {
                    if (_expandWndTopStoryboard == null && Resources["ExpandWndTopStoryBoard"] is Storyboard sb)
                    {
                        _expandWndTopStoryboard = sb;
                    }
                    _expandWndTopStoryboard?.Begin();
                }
                else if (oldType == ViewModel.WindowCompactType.LeftCompact)
                {
                    if (_expandWndLeftStoryboard == null && Resources["ExpandWndLeftStoryBoard"] is Storyboard sb)
                    {
                        _expandWndLeftStoryboard = sb;
                    }
                    _expandWndLeftStoryboard?.Begin();
                }
            }
            catch { }
        }


    }
}
