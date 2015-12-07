using UnityEngine;
using System.Collections;

public class EvasiveMovement : MonoBehaviour
{
    public float dodge;
    public float smoothing;
    public float tilt;
    public Vector2 startDelay;
    public Vector2 movementTime;
    public Vector2 movementWait;
    public Boundary boundary;

    private float targetX;
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startDelay.x, startDelay.y));
        while (true)
        {
            // tend them to move towards the centre
            targetX = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(movementTime.x, movementTime.y));
            targetX = 0;
            yield return new WaitForSeconds(Random.Range(movementWait.x, movementWait.y));
        }
    }

    void FixedUpdate()
    {
        float newMovement = Mathf.MoveTowards(rigidBody.velocity.x, targetX, Time.deltaTime * smoothing);
        rigidBody.velocity = new Vector3(newMovement, 0.0f, rigidBody.velocity.z);
        rigidBody.position = new Vector3
            (
                Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rigidBody.position.z, boundary.zMin, boundary.zMax)
            );
        rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x * -tilt);
    }
}
