using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{

    public float flSpeed;
    public float flRotRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0) {
            float speed = Input.GetAxisRaw("Horizontal") * Time.deltaTime * flRotRate;
            transform.Rotate(0, speed, 0); 
        }
    }
}
