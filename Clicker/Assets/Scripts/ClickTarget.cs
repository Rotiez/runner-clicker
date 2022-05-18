using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTarget : MonoBehaviour
{
    private Vector2 normalScale;
    private Vector2 clickedScale;

    private void Awake()
    {
        normalScale = transform.localScale;
        clickedScale = new Vector2(normalScale.x - .05f, normalScale.y - .05f);
    }

    private void OnMouseDown()
    {
        transform.localScale = clickedScale;
    }

    private void OnMouseUp()
    {
        transform.localScale = normalScale;
        //Clicker.Instance.ClickerScore();
    }
    
}
