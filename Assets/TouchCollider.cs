using UnityEngine;
using System.Collections;

public class TouchCollider : MonoBehaviour {

    Collider2D thisCollider2D;

    void Start()
    {
        thisCollider2D = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (Input.G))
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPos = new Vector2(wp.x, wp.y);
            if (thisCollider2D == Physics2D.OverlapPoint(touchPos))
            {
                Messenger.Broadcast("BRANDON_BUTTON_CLICK");
            }
        }
    }
}
