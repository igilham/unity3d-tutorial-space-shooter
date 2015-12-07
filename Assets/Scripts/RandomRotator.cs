using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{

    public float tumble;

    // Use this for initialization
    void Start()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
