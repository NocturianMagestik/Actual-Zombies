using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScaler : MonoBehaviour
{
    // Start is called before the first frame update
    public float targetWidth;
    public float targetHeight;
    private Vector2 centre;

    void Start()
    {
        RectTransform rt = (RectTransform)gameObject.transform;
        centre = new Vector2(Screen.width - rt.rect.width, Screen.height - rt.rect.height);
        
        transform.position = centre;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
