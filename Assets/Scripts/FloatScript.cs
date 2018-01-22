using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatScript : MonoBehaviour
{

    public float force;
    private bool elevator;
    private bool xRotation;
    private bool zRotation;
    private float zforce = 1.3f;
    private Rigidbody myRigidbody;
    public Transform playerDirection;

    // Update is called once per frame
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }
}