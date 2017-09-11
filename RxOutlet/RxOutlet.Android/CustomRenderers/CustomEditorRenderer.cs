using RxOutlet.CustomControls;
using RxOutlet.Droid.CustomRenderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace RxOutlet.Droid.CustomRenderers
{
    public class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            try
            {
                base.OnElementChanged(e);

                var view = (CustomEditor)Element;
                SetBorder(view);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetBorder(CustomEditor view)
        {
            try
            {
                if (view == null || Element == null || Control == null) return;

                switch (view.BorderType)
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