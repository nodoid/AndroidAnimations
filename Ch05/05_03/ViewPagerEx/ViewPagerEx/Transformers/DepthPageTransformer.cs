
using System;
using Android.Views;
using Android.Support.V4.View;
using Android.Runtime;

namespace ViewPagerEx.Transformers
{
    public class DepthPageTransformer : Java.Lang.Object, ViewPager.IPageTransformer
    {
        float MIN_SCALE = .75f;
        string TAG = "PageTransformer";

        public IntPtr Handle => throw new NotImplementedException();

        public void Dispose()
        {

        }

        public DepthPageTransformer(IntPtr intPtr, JniHandleOwnership jni) { }

        public DepthPageTransformer() { }

        public void TransformPage(View page, float position)
        {
            var pageWidth = page.Width;
            if (position < -1)
                page.Alpha = 0;
            else
            {
                if (position <= 0)
                {
                    page.Alpha = 1;
                    page.TranslationX = 0;
                    page.ScaleX = 1;
                    page.ScaleY = 1;
                }
                else if (position <= 1)
                {
                    page.Alpha = 1 - position;
                    page.TranslationX = pageWidth * -position;
                    var scaleFactor = MIN_SCALE + (1 - MIN_SCALE) * (1 - Math.Abs(position));
                    page.ScaleX = scaleFactor;
                    page.ScaleY = scaleFactor;
                }
                else
                    page.Alpha = 0;
            }
        }
    }
}
