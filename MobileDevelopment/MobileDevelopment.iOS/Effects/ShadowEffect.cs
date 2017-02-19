using System;
using System.Diagnostics;
using System.Linq;
using CoreGraphics;
using MobileDevelopment.iOS.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("MobileDevelopment")]
[assembly: ExportEffect(typeof(ShadowEffect), "ShadowEffect")]
namespace MobileDevelopment.iOS.Effects
{
    public class ShadowEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var effect = (MobileDevelopment.Effects.ShadowEffect)Element.Effects.FirstOrDefault(e => e is MobileDevelopment.Effects.ShadowEffect);
                if (effect != null)
                {
                    Control.Layer.CornerRadius = effect.Radius;
                    Control.Layer.ShadowColor = effect.Color.ToCGColor();
                    Control.Layer.ShadowOffset = new CGSize(effect.DistanceX, effect.DistanceY);
                    Control.Layer.ShadowOpacity = 1.0f;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {

        }
    }
}

