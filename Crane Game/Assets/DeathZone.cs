using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameManager GM;
    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            other.gameObject.transform.position = new Vector3(0, 1, 0);
            other.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
        }

        else if (other.gameObject.tag == "Target")
        {
            GM.AddPoints();
            Destroy(other.gameObject);
        }
    }
}
