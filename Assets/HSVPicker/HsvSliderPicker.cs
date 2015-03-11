using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HsvSliderPicker : MonoBehaviour, IDragHandler, IPointerDownHandler
{

    public HSVPicker picker;
    public Slider slider;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlacePointer(PointerEventData eventData)
    {
        
        var pos = new Vector2(eventData.position.x - picker.hsvSlider.rectTransform.position.x, picker.hsvSlider.rectTransform.position.y - eventData.position.y);

        pos.y /= picker.hsvSlider.rectTransform.rect.height * picker.hsvSlider.canvas.transform.lossyScale.y;
        
        //Debug.Log(eventData.position.ToString() + " " + picker.hsvSlider.rectTransform.position + " " + picker.hsvSlider.rectTransform.rect.height);
        pos.y = Mathf.Clamp(pos.y, 0, 1f);

        picker.MovePointer(pos.y);
    }


    public void OnDrag(PointerEventData eventData)
    {
        PlacePointer(eventData);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PlacePointer(eventData);
    }

    public void SliderPositionChanged(float sliderValue)
    {
        picker.MovePointer(sliderValue);
    }

    internal void SetSliderPosition(float pointerPos)
    {
        slider.normalizedValue = pointerPos;
    }
}