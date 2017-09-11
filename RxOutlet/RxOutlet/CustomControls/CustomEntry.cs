using RxOutlet.Common;
using Xamarin.Forms;

namespace RxOutlet.CustomControls
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty BorderTypeProperty =
            BindableProperty.Create<CustomEntry, BorderTypeEnum>(p => p.BorderType, BorderTypeEnum.No);

        public BorderTypeEnum BorderType
        {
            get { return (BorderTypeEnum)GetValue(BorderTypeProperty); }
            set { SetValue(BorderTypeProperty, value); }
        }
    }
}
