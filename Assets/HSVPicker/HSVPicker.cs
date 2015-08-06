using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class HSVPicker : MonoBehaviour {

	public HexRGB hexrgb;

    public Color32 currentColor;
	byte r;
	byte g;
	byte b;
	
    public Image colorImage;
    public RawImage hsvSlider;
    public RawImage hsvImage;

    public HsvSliderPicker sliderPicker;

	public BoxSlider boxSlider;

    public Slider sliderR;
    public Slider sliderG;
    public Slider sliderB;
    public Text sliderRText;
    public Text sliderGText;
    public Text sliderBText;

    public float pointerPos = 0;

    public float cursorX = 0;
    public float cursorY = 0;

    public HSVSliderEvent onValueChanged = new HSVSliderEvent();

    private bool dontAssignUpdate = false;
	bool isChanging = false;

    void Awake()
    {
        hsvSlider.texture = HSVUtil.GenerateHSVTexture((int)hsvSlider.rectTransform.rect.width, (int)hsvSlider.rectTransform.rect.height);

        sliderR.onValueChanged.AddListener(newValue =>
        {
			if(isChanging) return;
			isChanging = true;
			r = (byte)newValue;
            currentColor.r = r;
			AssignColor(currentColor);
            sliderRText.text = "R:" + r;
			hexrgb.ManipulateViaRGB2Hex();
			isChanging = false;
        });
        sliderG.onValueChanged.AddListener(newValue =>
        {
			if(isChanging) return;
			isChanging = true;
			g = (byte)newValue;
            currentColor.g = g;
            AssignColor(currentColor);
			sliderGText.text = "G:" + g;
			hexrgb.ManipulateViaRGB2Hex();
			isChanging = false;
        });
        sliderB.onValueChanged.AddListener(newValue =>
        {
			if(isChanging) return;
			isChanging = true;
			b = (byte)newValue;
            currentColor.b = b;
            AssignColor(currentColor);
			sliderBText.text = "B:" + b;
			hexrgb.ManipulateViaRGB2Hex();
			isChanging = false;
        });

        
        hsvImage.texture = HSVUtil.GenerateColorTexture((int)hsvImage.rectTransform.rect.width, (int)hsvImage.rectTransform.rect.height, ((Texture2D)hsvSlider.texture).GetPixelBilinear(0, 0));
        MoveCursor(cursorX, cursorY);
	}
	
    public void AssignColor(Color color)
    {
        
        var hsv = HSVUtil.ConvertRgbToHsv(color);

        float hOffset = (float)(hsv.H / 360);

        MovePointer(hOffset, false);
        MoveCursor((float)hsv.S, (float)hsv.V, false);

        currentColor = color;
        colorImage.color = currentColor;

        onValueChanged.Invoke(currentColor);

    }

	public void PlaceCursor(float posX, float posY) {
		MoveCursor(posX, posY);
	}

    public Color MoveCursor(float posX, float posY, bool updateInputs = true)
    {

        dontAssignUpdate = updateInputs;
        if (posX > 1)
        {
            posX %= 1;
        }
        if (posY > 1)
        {
            posY %= 1;
        }

		posY=Mathf.Clamp(posY, 0, 1);
		posX =Mathf.Clamp(posX, 0, 1);
        

        cursorX = posX;
        cursorY = posY;
		boxSlider.normalizedValue = posX;
		boxSlider.normalizedValueY = posY;

		if(isChanging) return currentColor;
		isChanging = true;

        currentColor = GetColor(cursorX, cursorY);
        colorImage.color = currentColor;
		r = currentColor.r;
		g = currentColor.g;
		b = currentColor.b;

        if (updateInputs)
        {
            UpdateInputs();
            onValueChanged.Invoke(currentColor);
        }
        dontAssignUpdate = false;
		isChanging = false;
        return currentColor;
    }

    public Color GetColor(float posX, float posY)
	{
		var color = HSVUtil.ConvertHsvToRgb(pointerPos * -360 + 360, posX, posY);

		return color;
	}

    public Color MovePointer(float newPos, bool updateInputs = true)
    {

        dontAssignUpdate = updateInputs;
        if (newPos > 1)
        {
            newPos %= 1f;
        }
        pointerPos = newPos;

        var mainColor =((Texture2D)hsvSlider.texture).GetPixelBilinear(0, pointerPos);
        if (hsvImage.texture != null)
        {
            if ((int)hsvImage.rectTransform.rect.width != hsvImage.texture.width || (int)hsvImage.rectTransform.rect.height != hsvImage.texture.height)
            {
                Destroy(hsvImage.texture);
                hsvImage.texture = null;

                hsvImage.texture = HSVUtil.GenerateColorTexture((int)hsvImage.rectTransform.rect.width, (int)hsvImage.rectTransform.rect.height, mainColor);
            }
            else
            {
                HSVUtil.GenerateColorTexture(mainColor, (Texture2D)hsvImage.texture);
            }
        }
        else
        {

            hsvImage.texture = HSVUtil.GenerateColorTexture((int)hsvImage.rectTransform.rect.width, (int)hsvImage.rectTransform.rect.height, mainColor);
        }
        sliderPicker.SetSliderPosition(pointerPos);

		if(isChanging) return currentColor;
		isChanging = true;

        currentColor = GetColor(cursorX, cursorY);
        colorImage.color = currentColor;
		r = currentColor.r;
		g = currentColor.g;
		b = currentColor.b;

        if (updateInputs)
        {
            UpdateInputs();
            onValueChanged.Invoke(currentColor);
        }
        dontAssignUpdate = false;
		isChanging = false;
        return currentColor;

    }

    public void UpdateInputs()
    {

        sliderR.value = r;
        sliderG.value = g;
        sliderB.value = b;

		sliderRText.text = "R:"+ r;
		sliderGText.text = "G:" + g;
		sliderBText.text = "B:" + b;
    }

     void OnDestroy()
    {
        if (hsvSlider.texture != null)
        {
            Destroy(hsvSlider.texture);
        }

        if (hsvImage.texture != null)
        {
            Destroy(hsvImage.texture);
        }
    }
}
