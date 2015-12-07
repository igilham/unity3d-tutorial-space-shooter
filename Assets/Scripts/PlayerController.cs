using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Boundary
{
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public float fireDelay;
    public GameObject shot;
    public Transform shotSpawn;
    public Boundary boundary;

    private float nextFire = 0.0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireDelay;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;

        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = movement;

        rigidbody.position = new Vector3
                (
                    Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
                    0.0f,
                    Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
                );
        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * (-tilt));
    }
}
