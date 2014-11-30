HSV-Color-Picker-Unity
======================

HSV color picker for Unity's uGUI

![alt tag](http://forum.unity3d.com/attachments/screen-shot-2014-11-30-at-7-25-50-am-png.119972/)
Should be really easy to use. Just add the prefab to the canvas, hook up an event, and it's good to go.
```csharp

    public Renderer renderer;
	public HSVPicker picker;
     
	// Use this for initialization
	void Start ()
	{
		picker.onValueChanged.AddListener(color =>
		{
			renderer.material.color = color;
		});
	}
 
	// Update is called once per frame
	void Update () {
 
	}
  ```

if you want to assign your own color first, just do this call and it sets the slider and picker to the proper selection.

```csharp
    Color color = Color.green;
    picker.AssignColor(color);
```
