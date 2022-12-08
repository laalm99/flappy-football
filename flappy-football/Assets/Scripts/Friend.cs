

using UnityEngine;


public class Friend : MonoBehaviour
{

    public float speed = 3f;

    private float leftEdge;

    private void Start()
    {
        ///convert screen space coordinates to real world coordinates

        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
        ///-1 so that the enemy only disappears once it's offscreen not when the center hits that left edge

    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}

