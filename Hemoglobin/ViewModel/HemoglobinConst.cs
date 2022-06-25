using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hemoglobin.ViewModel
{
    partial class HemoglobinVM
    {
        // 窗口外边框宽度
        private static readonly Thickness ExpandBorderThickness = new Thickness(1, 1, 1, 1);
        private static readonly Thickness TopCompactBorderThickness = new Thickness(1, 0, 1, 1);
        private static readonly Thickness LeftCompactBorderThickness = new Thickness(0, 1, 1, 1);

        // 窗口内部边距
        private static readonly Thickness ExpandInnerMargin = new Thickness(6, 6, 6, 6);
        private static readonly Thickness TopCompactInnerMargin = new Thickness(6, 0, 6, 6);
        private static readonly Thickness LeftCompactInnerMargin = new Thickness(0, 6, 6, 6);

        // 窗口外圆角
        private static readonly CornerRadius ExpandCornerRadius = new CornerRadius(8, 8, 8, 8);
        private static readonly CornerRadius TopCompactCornerRadius = new CornerRadius(0, 0, 8, 8);
        private static readonly CornerRadius LeftCompactCornerRadius = new CornerRadius(0, 8, 8, 0);

        // 窗口内圆角
        private static readonly CornerRadius ExpandInnerCornerRadius = new CornerRadius(4, 4, 4, 4);
        private static readonly CornerRadius TopCompactInnerCornerRadius = new CornerRadius(0, 0, 4, 4);
        private static readonly CornerRadius LeftCompactInnerCornerRadius = new CornerRadius(0, 4, 4, 0);
    }

    public enum WindowCompactType
    {
        Expand = 0,
        TopCompact = 1,
        LeftCompact = 2
    }
}
