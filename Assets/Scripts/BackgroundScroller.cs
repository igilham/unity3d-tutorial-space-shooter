using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileLength;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        var newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileLength);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}
