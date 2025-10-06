using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchFollow : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            transform.position = Vector2.Lerp(transform.position, touchPosition, speed * Time.deltaTime);
        }
    }
}
