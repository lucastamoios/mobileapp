using System.Collections.Generic;
using Foundation;
using ImageIO;
using UIKit;
using CGImageProperties = ImageIO.CGImageProperties;

namespace Toggl.iOS.Extensions
{
    public static class ImageViewExtensions
    {
        public static void SetTemplateColor(this UIImageView imageView, UIColor color)
        {
            imageView.Image = imageView.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            imageView.TintColor = color;
        }

        public static void SetAnimatedImage(this UIImageView imageView, string name)
        {
            var url = NSBundle.MainBundle.GetUrlForResource(name, "gif");
            var data = NSData.FromUrl(url);

            var source = CGImageSource.FromData(data);
            var frameCount = (int)source.ImageCount;
            var frames = new List<UIImage>();
            double totalDuration = 0;

            for (int i = 0; i < frameCount; i++)
            {
                var frame = source.CreateImage(i, null);
                var image = new UIImage(frame);

                frames.Add(image);

                var properties = source.GetProperties(i, null);
                var durationProperty = properties.Dictionary[CGImageProperties.GIFDictionary];
                var delayTime = durationProperty.ValueForKey(CGImageProperties.GIFDelayTime);
                durationProperty.Dispose ();

                var duration = double.Parse(delayTime.ToString());
                totalDuration += duration;
                frame.Dispose ();
            }

            var animatedImage = UIImage.CreateAnimatedImage(frames.ToArray(), totalDuration);
            imageView.Image = animatedImage;
        }
    }
}
