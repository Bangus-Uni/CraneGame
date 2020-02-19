using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    public GameManager GM;
    private Rigidbody rbPC;

    [SerializeField]
    [Range(1, 4)]
    public int intPlayerNo;

    public float flSpeed;
    public float flRotRate;
    public float flRotRateTrue;
    public float flSpeedTrue;

    public bool boolThrust = true;
    public bool boolRotEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        rbPC = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.boolGameStarted)
        {
            flRotRateTrue = flRotRate;
            flSpeedTrue = flSpeed;
            boolThrust = true;
            boolRotEnabled = true;

            if (intPlayerNo == 1)
            {
                P1Controls();
            }

            else if (intPlayerNo == 2)
            {
                P2Controls();
            }
        }
    }

    void P1Controls ()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            flRotRateTrue = flRotRate * 5;
            boolThrust = false;
        }

        else if (Input.GetKey(KeyCode.C))
        {
            flSpeedTrue = flSpeed * 5;
            boolRotEnabled = false;
        }

        if (Input.GetAxis("Horizontal") != 0 && boolRotEnabled)
        {
            float _flRotation = Input.GetAxisRaw("Horizontal") * Time.deltaTime * flRotRateTrue;
            transform.Rotate(0, _flRotation, 0);
        }

        if (Input.GetAxis("Vertical") != 0 && boolThrust)
        {
            float _flSpeed = Input.GetAxisRaw("Vertical") * Time.deltaTime * flSpeedTrue;
            rbPC.velocity = transform.forward * _flSpeed;
        }
    }

    void P2Controls()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            flRotRateTrue = flRotRate * 5;
            boolThrust = false;
        }

        else if (Input.GetKey(KeyCode.B))
        {
            flSpeedTrue = flSpeed * 5;
            boolRotEnabled = false;
        }

        if (Input.GetAxis("P2-Horizontal") != 0 && boolRotEnabled)
        {
            float _flRotation = Input.GetAxisRaw("P2-Horizontal") * Time.deltaTime * flRotRateTrue;
            transform.Rotate(0, _flRotation, 0);
        }

        if (Input.GetAxis("P2-Vertical") != 0 && boolThrust)
        {
            float _flSpeed = Input.GetAxisRaw("P2-Vertical") * Time.deltaTime * flSpeedTrue;
            rbPC.velocity = transform.forward * _flSpeed;
        }
    }
}
