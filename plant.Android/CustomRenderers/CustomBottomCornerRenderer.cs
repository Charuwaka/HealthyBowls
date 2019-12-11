using System;
using Android.Content;
using Android.Graphics.Drawables;
using plant.CustomControls;
using plant.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundBottomCornerFrame), typeof(CustomBottomCornerRenderer))]
namespace plant.Droid.CustomRenderers
{
    public class CustomBottomCornerRenderer : FrameRenderer
    {
        public CustomBottomCornerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null && e.OldElement == null)
            {
                this.SetBackgroundResource(Resource.Drawable.FrameRoundBottom);
                GradientDrawable drawable = (GradientDrawable)this.Background;
                drawable.SetColor(Android.Graphics.Color.ParseColor("#F0F0F0"));
            }
        }
    }
}
