using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject fireBlastPrefab;
    // Mega Death Rocket


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Shooting Logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
