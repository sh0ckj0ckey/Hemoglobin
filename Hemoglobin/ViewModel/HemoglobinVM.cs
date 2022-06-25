using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

namespace Hemoglobin.ViewModel
{
    public partial class HemoglobinVM : VMBase
    {
        private static Lazy<HemoglobinVM> lazyVM = new Lazy<HemoglobinVM>(() => new HemoglobinVM());
        public static HemoglobinVM Instance => lazyVM.Value;

        // 主窗口是否折叠
        private WindowCompactType _eCompactType = WindowCompactType.Expand;
        public WindowCompactType eCompactType
        {
            get { return _eCompactType; }
            private set { Set("eCompactType", ref _eCompactType, value); }
        }

        private Thickness _OuterBorderThickness = ExpandBorderThickness;
        public Thickness OuterBorderThickness
        {
            get { return _OuterBorderThickness; }
            set { Set("OuterBorderThickness", ref _OuterBorderThickness, value); }
        }

        private Thickness _InnerMargin = ExpandInnerMargin;
        public Thickness InnerMargin
        {
            get { return _InnerMargin; }
            set { Set("InnerMargin", ref _InnerMargin, value); }
        }

        private CornerRadius _OuterCornerRadius = ExpandCornerRadius;
        public CornerRadius OuterCornerRadius
        {
            get { return _OuterCornerRadius; }
            set { Set("OuterCornerRadius", ref _OuterCornerRadius, value); }
        }

        private CornerRadius _InnerCornerRadius = ExpandInnerCornerRadius;
        public CornerRadius InnerCornerRadius
        {
            get { return _InnerCornerRadius; }
            set { Set("InnerCornerRadius", ref _InnerCornerRadius, value); }
        }

        public void SetWindowCompact(WindowCompactType type)
        {
            try
            {
                this.eCompactType = type;
                switch (this.eCompactType)
                {
                    case WindowCompactType.Expand:
                        this.OuterBorderThickness = ExpandBorderThickness;
                        this.InnerMargin = ExpandInnerMargin;
                        this.OuterCornerRadius = ExpandCornerRadius;
                        this.InnerCornerRadius = ExpandInnerCornerRadius;
                        break;
                    case WindowCompactType.TopCompact:
                        this.OuterBorderThickness = TopCompactBorderThickness;
                        this.InnerMargin = TopCompactInnerMargin;
                        this.OuterCornerRadius = TopCompactCornerRadius;
                        this.InnerCornerRadius = TopCompactInnerCornerRadius;
                        break;
                    case WindowCompactType.LeftCompact:
                        this.OuterBorderThickness = LeftCompactBorderThickness;
                        this.InnerMargin = LeftCompactInnerMargin;
                        this.OuterCornerRadius = LeftCompactCornerRadius;
                        this.InnerCornerRadius = LeftCompactInnerCornerRadius;
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }
    }
}
