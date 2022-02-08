using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shotPoint;
    public GameObject bullet;
    private float reloadTime;
    public float startReloadTime;

    void Update()
    {
        if (reloadTime <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, shotPoint.position, transform.rotation);
                reloadTime = startReloadTime;
            }
        }
        else
        {
            reloadTime -= Time.deltaTime;
        }
    }
}
