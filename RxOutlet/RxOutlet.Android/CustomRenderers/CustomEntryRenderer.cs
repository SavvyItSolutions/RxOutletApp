using System;
using Xamarin.Forms;
using RxOutlet.Droid.CustomRenderers;
using RxOutlet.CustomControls;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(CustomEntry),typeof(CustomEntryRenderer))]
namespace RxOutlet.Droid.CustomRenderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            try
            {
                base.OnElementChanged(e);

                var view = (CustomEntry) Element;
                SetBorder(view);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetBorder(CustomEntry view)
        {
            try
            {
                if (view == null || Element == null || Control == null) return;

                switch(view.BorderType)
                {
                    case Common.BorderTypeEnum.No:
                        Control.Background = this.Resources.GetDrawable(Resource.Drawable.NoBorder);
                        break;

                    case Common.BorderTypeEnum.All:
                        Control.Background = this.Resources.GetDrawable(Resource.Drawable.AllBorder);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}