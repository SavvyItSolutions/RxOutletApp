using RxOutlet.Common;
using System;
using Xamarin.Forms;

namespace RxOutlet.CustomControls
{
    public class CustomEntry : Entry
    {
        public new event EventHandler Completed;

        #region BorderType

        public static readonly BindableProperty BorderTypeProperty =
            BindableProperty.Create<CustomEntry, BorderTypeEnum>(p => p.BorderType, BorderTypeEnum.Default);

        public BorderTypeEnum BorderType
        {
            get { return (BorderTypeEnum)GetValue(BorderTypeProperty); }
            set { SetValue(BorderTypeProperty, value); }
        }

        #endregion

        #region EntryButtonType

        public static readonly BindableProperty EntryButtonTypeProperty = 
            BindableProperty.Create<CustomEntry, EntryButtonTypeEnum>(p => p.EntryButtonType, EntryButtonTypeEnum.None);

        public EntryButtonTypeEnum EntryButtonType
        {
            get { return (EntryButtonTypeEnum)GetValue(EntryButtonTypeProperty); }
            set { SetValue(EntryButtonTypeProperty, value); }
        }

        #endregion

        #region NextFocusToControl

        public static readonly BindableProperty NextFocusControlProperty =
            BindableProperty.Create("NextFocusToControl", typeof(View), typeof(CustomEntry));

        public View NextFocusToControl
        {
            get { return (View)GetValue(NextFocusControlProperty); }
            set { SetValue(NextFocusControlProperty, value); }
        }

        public void OnNextFocus()
        {
            NextFocusToControl?.Focus();
        }

        public void OnInvokeCompleted()
        {
            this.Completed?.Invoke(this, null);
        }

        #endregion
    }
}
