HSV-Color-Picker-Unity
======================

HSV color picker using  Unity UI

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
