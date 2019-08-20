using UnityEngine;

public class ColorPickerTester : MonoBehaviour 
{

    public new Renderer renderer;
    public ColorPicker picker;

    public Color Color = Color.red;

	// Use this for initialization
	void Start () 
    {
        picker.onValueChanged.AddListener(color =>
        {
            renderer.material.color = color;
            Color = color;
        });

		renderer.material.color = picker.CurrentColor;
        Debug.Log($"Color: {Color} {ToColor32(Color)}");

        picker.AssignColor(Color);

        Debug.Log($"Picker Color: {picker.CurrentColor} {ToColor32(picker.CurrentColor)}");
    }

    Color32 ToColor32(Color color)
    {
        return new Color32((byte)(color.r * 255), (byte)(color.g * 255), (byte)(color.b * 255), (byte)(color.a * 255));
    }

	// Update is called once per frame
	void Update () {
	
	}
}
