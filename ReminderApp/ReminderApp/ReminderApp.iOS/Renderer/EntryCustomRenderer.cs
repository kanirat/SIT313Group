using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using ReminderApp.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(EntryCustomRenderer))]
namespace ReminderApp.iOS.Renderer
{
    public class EntryCustomRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}