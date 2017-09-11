using Xamarin.Forms;

namespace RxOutlet.CustomControls
{
    public class CustomLabel : Label
    {
        public static readonly BindableProperty IsUnderLineProperty =
            BindableProperty.Create<CustomLabel, bool>(p => p.IsUnderLine, false);

        public bool IsUnderLine
        {
            get { return (bool)GetValue(IsUnderLineProperty); }
            set { SetValue(IsUnderLineProperty, value); }
        }
    }
}
