using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject goPart;

    [SerializeField]
    GameObject goParent;

    [SerializeField]
    GameObject goWB;

    [SerializeField]
    [Range(1, 50)]
    int intLength = 3;

    [SerializeField]
    float flPartDistance = 0.21f;

    [SerializeField]
    bool boolReset;

    [SerializeField]
    bool boolSpawn;

    [SerializeField]
    bool boolSnapFirst;

    [SerializeField]
    bool boolSnapLast;

    void Start()
    {
        Spawn();
    }


    // Update is called once per frame
    void Update()
    {
        if (boolReset)
        {
            foreach (GameObject _GOTmp in GameObject.FindGameObjectsWithTag("Platform"))
            {
                Destroy(_GOTmp);
            }
        }

/*        if (boolSpawn)
        {
            Spawn();
            boolSpawn = false;
        }*/
        
    }

    public void Spawn()
    {
        int _intCount = (int)(intLength / flPartDistance);

        for (int x = 0; x < _intCount; x++)
        {
            GameObject _GOTmp;

            if (x == 0)
            {
                _GOTmp = Instantiate(goWB, new Vector3(transform.position.x, transform.position.y + flPartDistance * (x + 1), transform.position.z), Quaternion.identity, goParent.transform);
                _GOTmp.transform.eulerAngles = new Vector3(180, 0, 0);

                _GOTmp.name = goParent.transform.childCount.ToString();
            }

            else
            {
                _GOTmp = Instantiate(goPart, new Vector3(transform.position.x, transform.position.y + flPartDistance * (x + 1), transform.position.z), Quaternion.identity, goParent.transform);
                _GOTmp.transform.eulerAngles = new Vector3(180, 0, 0);

                _GOTmp.name = goParent.transform.childCount.ToString();
            }

            if (x == 0)
            {
                Destroy(_GOTmp.GetComponent<CharacterJoint>());
                if (boolSnapFirst)
                {
                    _GOTmp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                }

            }

            else
            {
                _GOTmp.GetComponent<CharacterJoint>().connectedBody = goParent.transform.Find((goParent.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }

        }

        if (boolSnapLast)
        {
            goParent.transform.Find((goParent.transform.childCount).ToString()).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
