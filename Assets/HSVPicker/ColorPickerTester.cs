using UnityEngine;
using System.Collections;

public class ColorPickerTester : MonoBehaviour 
{

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
}
