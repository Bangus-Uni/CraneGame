using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool boolGameStarted = false;

    public float flTimeLeft = 5;

    public Text txtStartText;
    // Update is called once per frame
    void Update()
    {
        if (boolGameStarted == false)
        {
            flTimeLeft -= Time.deltaTime;
            txtStartText.text = (flTimeLeft).ToString("0");
            if (flTimeLeft < 0)
            {
                boolGameStarted = true;
                Destroy(txtStartText);
            }
        }
    }
}
