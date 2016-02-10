using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;



#region ColorUtilities

public static class HSVUtil
{

    public static HsvColor ConvertRgbToHsv(Color color)
    {
        return ConvertRgbToHsv((int)(color.r * 255), (int)(color.g * 255), (int)(color.b * 255));
    }

    //Converts an RGB color to an HSV color.
    public static HsvColor ConvertRgbToHsv(double r, double b, double g)
    {
        double delta, min;
        double h = 0, s, v;

        min = Math.Min(Math.Min(r, g), b);
        v = Math.Max(Math.Max(r, g), b);
        delta = v - min;

        if (v == 0.0)
            s = 0;
        else
            s = delta / v;

        if (s == 0)
            h = 360;
        else
        {
            if (r == v)
                h = (g - b) / delta;
            else if (g == v)
                h = 2 + (b - r) / delta;
            else if (b == v)
                h = 4 + (r - g) / delta;

            h *= 60;
            if (h <= 0.0)
                h += 360;
        }

        HsvColor hsvColor = new HsvColor();
        hsvColor.H = 360 - h;
        hsvColor.S = s;
        hsvColor.V = v / 255;

        return hsvColor;

    }

    // Converts an HSV color to an RGB color.
    public static Color ConvertHsvToRgb(double h, double s, double v, float alpha)
    {

        double r = 0, g = 0, b = 0;

        if (s == 0)
        {
            r = v;
            g = v;
            b = v;
        }
<<<<<<< HEAD

        // Generates a list of colors with hues ranging from 0 360
        // and a saturation and value of 1. 
        public static List<Color> GenerateHsvSpectrum(int minHue = 0, int maxHue = 360)
=======
        else
>>>>>>> ae93a66b32119e349371256cb1a74aeb4c250e53
        {
            int i;
            double f, p, q, t;


            if (h == 360)
                h = 0;
            else
                h = h / 60;

            i = (int)(h);
            f = h - i;

            p = v * (1.0 - s);
            q = v * (1.0 - (s * f));
            t = v * (1.0 - (s * (1.0f - f)));

<<<<<<< HEAD
            for (int i = minHue; i < (maxHue - 1); i++)
=======
            switch (i)
>>>>>>> ae93a66b32119e349371256cb1a74aeb4c250e53
            {
                case 0:
                    r = v;
                    g = t;
                    b = p;
                    break;

                case 1:
                    r = q;
                    g = v;
                    b = p;
                    break;

                case 2:
                    r = p;
                    g = v;
                    b = t;
                    break;

                case 3:
                    r = p;
                    g = q;
                    b = v;
                    break;

                case 4:
                    r = t;
                    g = p;
                    b = v;
                    break;

                default:
                    r = v;
                    g = p;
                    b = q;
                    break;
            }
<<<<<<< HEAD

			colorsList.Add(ConvertHsvToRgb(maxHue, 1, 1));

            return colorsList;

        }

        public static Texture2D GenerateHSVTexture(int width, int height, int minHue = 0, int maxHue = 360)
        {
            var list = GenerateHsvSpectrum(minHue, maxHue);

            float interval = (float)list.Count / height;
=======

        }

        return new Color((float)r, (float)g, (float)b, alpha);

    }
}
>>>>>>> ae93a66b32119e349371256cb1a74aeb4c250e53

#endregion ColorUtilities


// Describes a color in terms of
// Hue, Saturation, and Value (brightness)
#region HsvColor
public struct HsvColor
{
    /// <summary>
    /// The Hue, ranges between 0 and 360
    /// </summary>
    public double H;

    /// <summary>
    /// The saturation, ranges between 0 and 1
    /// </summary>
    public double S;

    // The value (brightness), ranges between 0 and 1
    public double V;

    public float normalizedH
    {
        get
        {
            return (float)H / 360f;
        }

        set
        {
            H = (double)value * 360;
        }
    }

    public float normalizedS
    {
        get
        {
            return (float)S;
        }
        set
        {
            S = (double)value;
        }
    }

    public float normalizedV
    {
        get
        {
            return (float)V;
        }
        set
        {
            V = (double)value;
        }
    }

    public HsvColor(double h, double s, double v)
    {
        this.H = h;
        this.S = s;
        this.V = v;
    }

    public override string ToString()
    {
        return "{" + H.ToString("f2") + "," + S.ToString("f2") + "," + V.ToString("f2") + "}";
    }
}
#endregion HsvColor




