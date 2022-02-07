using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App2.Controls
{
    public class CustomBoxView : BoxView
    {
        public CustomBoxView()
        {
        }
        public static readonly BindableProperty BorderRadiusProperty = BindableProperty.Create<CustomBoxView, double>(p => p.BorderRadius, 0);

        public double BorderRadius
        {
            get { return (double)GetValue(BorderRadiusProperty); }
            set { SetValue(BorderRadiusProperty, value); }
        }

        public static readonly BindableProperty StrokeProperty =
            BindableProperty.Create<CustomBoxView, Color>(p => p.Stroke, Color.Transparent);

        public Color Stroke
        {
            get { return (Color)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        public static readonly BindableProperty StrokeThicknessProperty =
            BindableProperty.Create<CustomBoxView, double>(p => p.StrokeThickness, 0);

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }
        public static readonly BindableProperty shadowProperty =
        BindableProperty.Create<CustomBoxView, Thickness>(p => p.shadow, 0);

        public Thickness shadow
        { 
            get {return (Thickness)GetValue(shadowProperty); } 
            set { SetValue(CornerRadiusProperty, value); } 
        }
        public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create<CustomBoxView, float>(p => p.test, 0);

        public float test
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
    }
}
