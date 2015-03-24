using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System.Globalization;

public class HexRGB : MonoBehaviour {


	public InputField textColor; 

	public HSVPicker hsvpicker; 

	public void ManipulateViaRGB2Hex(){
		Color color = hsvpicker.currentColor;
		string hex = ColorToHex (color);
		textColor.text = hex;
	}

	public static string ColorToHex(Color color){
		int r = Mathf.RoundToInt(color.r * 255);
		int g = Mathf.RoundToInt(color.g * 255);
		int b = Mathf.RoundToInt(color.b * 255);
		return string.Format ("#{0:X2}{1:X2}{2:X2}", r, g, b);
	}

	public void ManipulateViaHex2RGB(){
		string hex = textColor.text;

		Color rgb = Hex2RGB (hex);
		//Color color = NormalizeVector4 (rgb,255f,1f); print (rgb);

		hsvpicker.AssignColor (rgb);
	}

	static Color NormalizeVector4(Vector3 v,float r,float a){
		float red = v.x / r;
		float green = v.y / r;
		float blue = v.z / r;
		return new Color (red,green,blue,a);
	}

	Color Hex2RGB(string hexColor){
		//Remove # if present
		if (hexColor.IndexOf('#') != -1)
			hexColor = hexColor.Replace("#", "");
		
		int red = 0;
		int green = 0;
		int blue = 0;
		
		if (hexColor.Length == 6)
		{
			//#RRGGBB
			red = int.Parse(hexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier);
			green = int.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier);
			blue = int.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier);
			
			
		}
		else if (hexColor.Length == 3)
		{
			//#RGB
			red = int.Parse(hexColor[0].ToString() + hexColor[0].ToString(), NumberStyles.AllowHexSpecifier);
			green = int.Parse(hexColor[1].ToString() + hexColor[1].ToString(), NumberStyles.AllowHexSpecifier);
			blue = int.Parse(hexColor[2].ToString() + hexColor[2].ToString(), NumberStyles.AllowHexSpecifier);
		}

        var color = new Color32((byte)red, (byte)green, (byte)blue, 255);
        return color;
		//return new Vector3 (red, green, blue);
	
	}

}
