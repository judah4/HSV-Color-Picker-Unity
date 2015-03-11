using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HSVDragger : MonoBehaviour
{

    public RectTransform parentPanel;
    [HideInInspector]
    public RectTransform rectTransform;
    public ScrollRect scrollRect;

    public HSVPicker picker;


	// Use this for initialization
	void Awake () {
        rectTransform = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {

        //var normalized = scrollRect.normalizedPosition;
        //Debug.Log(scrollRect.horizontalNormalizedPosition + " " + scrollRect.verticalNormalizedPosition);

        var position = rectTransform.localPosition;
        position.x = Mathf.Clamp(position.x, -parentPanel.sizeDelta.x / 2, parentPanel.sizeDelta.x / 2);
        position.y = Mathf.Clamp(position.y, -parentPanel.sizeDelta.y / 2, parentPanel.sizeDelta.y / 2);
        rectTransform.localPosition = position;

        //scroll position time
        position.x += parentPanel.sizeDelta.x / 2;
        position.y += parentPanel.sizeDelta.y / 2;
        position.x /= parentPanel.sizeDelta.x;
        position.y /= parentPanel.sizeDelta.y;

        //Debug.Log(position.x + " " + position.y);

        //picker.MoveCursor(position.x, position.y);
        
	}

    public void ScrollValueChanged(Vector2 value)
    {

        //if (scrollRect.Dragging == false)
          //  return;

        var position = rectTransform.localPosition;
        position.x = Mathf.Clamp(position.x, -parentPanel.sizeDelta.x / 2, parentPanel.sizeDelta.x / 2);
        position.y = Mathf.Clamp(position.y, -parentPanel.sizeDelta.y / 2, parentPanel.sizeDelta.y / 2);
        rectTransform.localPosition = position;

        //scroll position time
        position.x += parentPanel.sizeDelta.x / 2;
        position.y += parentPanel.sizeDelta.y / 2;
        position.x /= parentPanel.sizeDelta.x;
        position.y /= parentPanel.sizeDelta.y;

        //Debug.Log(position.x + " " + position.y);

        picker.MoveCursor(position.x, position.y);
        
    }

    public void SetSelectorPosition(float posX, float posY)
    {
        var pos = rectTransform.localPosition;
        var newPos = new Vector3(posX, posY, pos.z);

        newPos.x *= parentPanel.sizeDelta.x;
        newPos.y *= parentPanel.sizeDelta.y;
        newPos.x -= parentPanel.sizeDelta.x / 2;
        newPos.y -= parentPanel.sizeDelta.y / 2;

        rectTransform.localPosition = newPos;

    }

    

}
