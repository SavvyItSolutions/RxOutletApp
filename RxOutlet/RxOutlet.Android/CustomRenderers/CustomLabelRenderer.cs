using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using RxOutlet.CustomControls;
using RxOutlet.Droid.CustomRenderers;
using System;
using Android.Graphics;
using Android.Widget;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace RxOutlet.Droid.CustomRenderers
{
    public class CustomLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            try
            {
                base.OnElementChanged(e);

                if (Element == null || Control == null) return;

                var view = (CustomLabel)Element;

                SetUnderLine(view, Control);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void SetUnderLine(CustomLabel view, TextView control)
        {
            try
            {
                if (view == null || Control == null || Element == null) return;

                if (view.IsUnderLine)
                    control.PaintFlags = PaintFlags.UnderlineText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}