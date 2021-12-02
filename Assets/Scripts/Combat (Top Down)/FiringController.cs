using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringController : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    public float fireRate = 1f;
    float nextFire;
    // Start is called before the first frame update

    public bool canFire = true;

    public static FiringController instance;

    void Start()
    {
        // Create instance
        if(instance == null)
        {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(canFire)
        {
            CheckIfTimeToFire();
        }
    }

    public void CheckIfTimeToFire()
    {
        if(Time.time > nextFire)
        {
            Instantiate (bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
