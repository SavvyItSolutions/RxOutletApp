using RxOutlet.Common;
using Xamarin.Forms;

namespace RxOutlet.CustomControls
{
    public class CustomEditor : Editor
    {
        public static readonly BindableProperty BorderTypeProperty =
            BindableProperty.Create<CustomEditor, BorderTypeEnum>(p => p.BorderType, BorderTypeEnum.All);

        public BorderTypeEnum BorderType
        {
            get { return (BorderTypeEnum)GetValue(BorderTypeProperty); }
            set { SetValue(BorderTypeProperty, value); }
        }
    }
}
