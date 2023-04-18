using UnityEngine;

public class ButtonLayoutScript : MonoBehaviour
{
    private RectTransform button1Rect, button2Rect, button3Rect;

    private void Awake()
    {
        button1Rect = GameObject.Find("Answer1").GetComponent<RectTransform>();
        button2Rect = GameObject.Find("Answer2").GetComponent<RectTransform>();
        button3Rect = GameObject.Find("Answer3").GetComponent<RectTransform>();
        // Button 4 never changes it's shape: it only gets toggled on or off.
    }

    // These functions transform answer buttons to the desired layouts
    public void LayoutFor2()
    {
        button1Rect.anchoredPosition = new Vector2(0f, 129.65f);
        button2Rect.anchoredPosition = new Vector2(0f, -129.65f);
        button1Rect.sizeDelta = new Vector2(1486, 238);
        button2Rect.sizeDelta = new Vector2(1486, 238);
    }

    public void LayoutFor3()
    {
        button1Rect.anchoredPosition = new Vector2(0f, 171f);
        button2Rect.anchoredPosition = new Vector2(0f, 0f);
        button3Rect.anchoredPosition = new Vector2(0f, -171f);
        button1Rect.sizeDelta = new Vector2(1486, 155);
        button2Rect.sizeDelta = new Vector2(1486, 155);
        button3Rect.sizeDelta = new Vector2(1486, 155);
    }

    public void LayoutFor4()
    {
        button1Rect.anchoredPosition = new Vector2(-375.9f, 129.65f);
        button2Rect.anchoredPosition = new Vector2(375.9f, 129.65f);
        button3Rect.anchoredPosition = new Vector2(-375.9f, -129.65f);
        button1Rect.sizeDelta = new Vector2(735, 238);
        button2Rect.sizeDelta = new Vector2(735, 238);
        button3Rect.sizeDelta = new Vector2(735, 238);
    }

}
