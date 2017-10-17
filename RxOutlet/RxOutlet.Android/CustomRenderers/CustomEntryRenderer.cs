using System;
using Xamarin.Forms;
using RxOutlet.Droid.CustomRenderers;
using RxOutlet.CustomControls;
using Xamarin.Forms.Platform.Android;
using RxOutlet.Common;
using System.ComponentModel;
using Android.Graphics;
using Android.Runtime;
using Android.Views;

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

                if (Element == null || Control == null) return;

                var view = (CustomEntry) Element;
                SetBorder(view);
                SetNextFocusToControl(view);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                        
        /// <summary>
        /// SetBorder
        /// </summary>
        /// <param name="view"></param>
        private void SetBorder(CustomEntry view)
        {
            try
            {
                if (view == null || Element == null || Control == null) return;

                switch(view.BorderType)
                {
                    case BorderTypeEnum.Default:
                        break;

                    case BorderTypeEnum.No:
                        Control.Background = this.Resources.GetDrawable(Resource.Drawable.NoBorder);
                        break;

                    case BorderTypeEnum.All:
                        Control.Background = this.Resources.GetDrawable(Resource.Drawable.AllBorder);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// SetNextFocusToControl
        /// </summary>
        /// <param name="view"></param>
        private void SetNextFocusToControl(CustomEntry view)
        {
            try
            {
                if (view == null || Element == null || Control == null) return;

                if(view.EntryButtonType == EntryButtonTypeEnum.Next)
                {
                    Control.ImeOptions = Android.Views.InputMethods.ImeAction.Next;

                    Control.EditorAction += (sender, args) =>
                    {
                        view.OnNextFocus();
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}