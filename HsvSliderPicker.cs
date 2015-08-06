using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HsvSliderPicker : MonoBehaviour, IDragHandler, IPointerDownHandler
{

    public HSVPicker picker;
    public Slider slider;

    void PlacePointer(PointerEventData eventData)
    {
        
        var pos = new Vector2(eventData.position.x - picker.hsvSlider.rectTransform.position.x, picker.hsvSlider.rectTransform.position.y - eventData.position.y);

        pos.y /= picker.hsvSlider.rectTransform.rect.height * picker.hsvSlider.canvas.transform.lossyScale.y;
        
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