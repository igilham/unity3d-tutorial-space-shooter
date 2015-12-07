using UnityEngine;
using System.Collections;

public class EnemyWeaponController : MonoBehaviour
{

    public float fireRate;
    public float fireDelay;
    public GameObject shot;
    public Transform shotSpawn;

    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", fireDelay, fireRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play();
    }
}
