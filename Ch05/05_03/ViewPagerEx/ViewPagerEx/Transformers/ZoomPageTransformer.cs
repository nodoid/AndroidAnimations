
using System;
using Android.Views;
using Android.Support.V4.View;
using Android.Runtime;

namespace ViewPagerEx.Transformers
{
    public class ZoomPageTransformer : Java.Lang.Object, ViewPager.IPageTransformer
    {
        float MIN_SCALE = .85f;
        float MIN_ALPHA = .5f;

        public IntPtr Handle => IntPtr.Zero;

        public void Dispose()
        {

        }

        public ZoomPageTransformer(IntPtr intPtr, JniHandleOwnership jni) { }

        public ZoomPageTransformer() { }

        public void TransformPage(View page, float position)
        {
            var pageWidth = page.Width;
            var pageHeight = page.Height;

            if (position < -1)
                page.Alpha = 0;
            else if (position <= 1)
            {
                var scaleFactor = Math.Max(MIN_SCALE, 1 - Math.Abs(position));
                var vertMargin = pageHeight * (1 - scaleFactor) / 2;
                var horzMargin = pageWidth * (1 - scaleFactor) / 2;
                page.TranslationX = position < 0 ? horzMargin - vertMargin / 2 : -horzMargin + vertMargin / 2;

                page.ScaleX = page.ScaleY = scaleFactor;
                page.Alpha = (MIN_ALPHA + (scaleFactor - MIN_SCALE) * (1 - MIN_ALPHA));
            }
            else
                page.Alpha = 0;
        }
    }
}
