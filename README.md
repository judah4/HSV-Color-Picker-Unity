HSV Color Picker
======================
[![ko-fi](https://www.ko-fi.com/img/donate_sm.png)](https://ko-fi.com/Y8Y8MG4Y)

HSV color picker using Unity UI. [Unity Forum Thread](https://forum.unity.com/threads/color-picker.267043/)

## Versions
Unity 2019.4 LTS

## Install

### UPM

```json
{
  "dependencies": {
    "judah4.hsvcolorpickerunity": "https://github.com/judah4/HSV-Color-Picker-Unity.git#upm",
    ...
  }
}
```

For a specific version reference the tag like `https://github.com/judah4/HSV-Color-Picker-Unity.git#v3.1.0`

### Unity Package

<https://github.com/judah4/HSV-Color-Picker-Unity/releases>

![alt tag](https://i.imgur.com/Fn2T6Nu.png)
Should be really easy to use. Just add the prefab to the canvas, hook up an event, and it's good to go.
```csharp

    public Renderer renderer;
	public ColorPicker picker;
     
	// Use this for initialization
	void Start ()
	{
		picker.onValueChanged.AddListener(color =>
		{
			renderer.material.color = color;
		});
		renderer.material.color = picker.CurrentColor;
	}
 
	// Update is called once per frame
	void Update () {
 
	}
  ```

if you want to assign your own color first, just do this call and it sets the slider and picker to the proper selection.

```csharp
    Color color = Color.green;
    picker.CurrentColor = color;
```

![resizable panels](https://raw.githubusercontent.com/judah4/HSV-Color-Picker-Unity/master/Docs/MoreFeatures.PNG)

Can be toggled and sized as needed in settings.

# Setup Settings

![settings inspector](https://raw.githubusercontent.com/judah4/HSV-Color-Picker-Unity/master/Docs/SetupSettings.PNG)

On the color picker setup section.

Show Rgb: Show RGB sliders.

Show Hsv: Show HSV sliders.

Show Alpha: Show the alpha slider.

Show Color Box: Show the larger color selection box and color column.

Show Color Slider Toggle: Show the button to toggle the HSV and RGB sliders.

Show Header: Options to show the top header with color preview and hex code.
* Hide: Hide the top header.  
* Show Color: Show only the color preview in the header.  
* Show Color Code: Show only the color code in the header.  
* Show All: Show the entire top header.  

## Color Presets
The prefabs starts with 4 colors in the color presets. This can be updated in the Setup section of the picker prefab.  
Set the Preset Colors Id for different shared list between color pickers.

