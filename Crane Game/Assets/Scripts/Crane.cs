using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    private Rigidbody rbPC;

    public float flSpeed;
    public float flRotRate;
    public float flRotRateTrue;
    public float flSpeedTrue;

    public bool boolThrust = true;
    public bool boolRotEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        rbPC = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        flRotRateTrue = flRotRate;
        flSpeedTrue = flSpeed;
        boolThrust = true;
        boolRotEnabled = true;

        if (Input.GetKey(KeyCode.LeftShift)) {
            flRotRateTrue = flRotRate * 5;
            boolThrust = false;
        }

        else if (Input.GetKey(KeyCode.Space)) {
            flSpeedTrue = flSpeed * 5;
            boolRotEnabled = false;
        }

        if (Input.GetAxis("Horizontal") != 0 && boolRotEnabled) {
            float _flRotation = Input.GetAxisRaw("Horizontal") * Time.deltaTime * flRotRateTrue;
            transform.Rotate(0, _flRotation, 0); 
        }

        if(Input.GetAxis("Vertical") != 0 && boolThrust) {
            float _flSpeed = Input.GetAxisRaw("Vertical") * Time.deltaTime * flSpeedTrue;
            rbPC.velocity = transform.forward * _flSpeed;
        }
    }
}
