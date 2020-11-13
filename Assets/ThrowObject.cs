using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public GameObject Flashbang;
    public float force = 10;

    private GameObject flash;
    private Transform trans;


    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            flash = Instantiate(Flashbang, transform.position + transform.forward, Quaternion.identity) as GameObject;
            flash.AddComponent<Rigidbody>();
            flash.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
            flash.AddComponent<Flashbang>();
            flash.GetComponent<Flashbang>().Player = transform;
        }
    }
}
