using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject goTarget;

    public int intPoints;

    public Text txtPointText;

    public bool boolGameStarted = false;

    public float flTimeLeft = 5;

    public int intNoOfCubes = 5;

    public Text txtStartText;

    void Start()
    {
        InvokeRepeating("SpawnTargets", 5f, 6f);
    }
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

    void SpawnTargets ()
    {
        GameObject[] _goNoOfTargets = GameObject.FindGameObjectsWithTag("Target");

        if (_goNoOfTargets.Length < intNoOfCubes)
        {
            Vector3 _v3SpawnPoint = new Vector3(Random.Range(-7.5f, 7.5f), 6, Random.Range(-7.5f, 7.5f));
            Instantiate(goTarget, _v3SpawnPoint, Quaternion.Euler(0, 0, 0));
        }
    }

    public void AddPoints() {
        intPoints++;
        txtPointText.text = intPoints.ToString();
    }
}