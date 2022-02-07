using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App2.Controls;
using App2.Droid.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(CustomBoxView), typeof(CustomRenderer))]
namespace App2.Droid.Control
{
    public class CustomRenderer : VisualElementRenderer<BoxView>
    {
        public CustomRenderer(Context ctx) : base(ctx)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);
            SetWillNotDraw(false);
            Invalidate();
        }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == CustomBoxView.BorderRadiusProperty.PropertyName)
            {
                Invalidate();
            }
        }
        public override void Draw(Canvas canvas)
        {
            var box = Element as CustomBoxView;
            base.Draw(canvas);
            Paint myPaint = new Paint();
            myPaint.SetStyle(Paint.Style.Stroke);
            myPaint.StrokeWidth = (float)box.StrokeThickness;
            myPaint.SetARGB(convertTo255ScaleColor(box.Color.A), convertTo255ScaleColor(box.Color.R), convertTo255ScaleColor(box.Color.G), convertTo255ScaleColor(box.Color.B));
            myPaint.SetShadowLayer(20, (float)box.shadow.VerticalThickness, (float)box.shadow.HorizontalThickness, Android.Graphics.Color.Argb(100, 0, 0, 0));
            SetLayerType(Android.Views.LayerType.Software, myPaint);
            var number = (float)box.StrokeThickness / 2;
            RectF rectF = new RectF(
                        number, // left
                        number, // top
                        canvas.Width - number, // right
                        canvas.Height - number // bottom
                );
            var radius = (float)box.BorderRadius;
            canvas.Skew(radius,radius);
            canvas.DrawRoundRect(rectF, radius, radius,myPaint);
            //canvas.DrawDoubleRoundRect(rectF, radius, radius, new RectF ( Bottom = canvas.Height - (int)number, Top = canvas.Height - (int)number, Right = canvas.Width - (int)number, Left = canvas.Width - (int)number ), box.test, box.test, myPaint);
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private int convertTo255ScaleColor(double color)
        {
            return (int)Math.Ceiling(color * 255);
        }
    }
}