using UnityEngine;
using System.Collections;

public class CityBackground : MonoBehaviour
{
    public bool special = false;
    public bool starter = false;

    public int blockCtr = 10;
    public GameObject cityBlock;

    // Use this for initialization
    void Start()
    {
        if (starter)
        {
            for (int i = 1; i < blockCtr; i++)
            {

                GameObject cb = Instantiate(cityBlock, transform.position + new Vector3(i * 2, 0, 0), transform.rotation) as GameObject;

                cb.GetComponent<CityBackground>().starter = false;
                cb.GetComponent<CityBackground>().special = true;
                cb.GetComponent<CityBackground>().blockCtr = Random.Range(1, 20);
            }
        }
 
        if (special)
        {
            for (int i = 1; i < blockCtr; i++)
            {
                Instantiate(cityBlock, transform.position + new Vector3(0, i * 2, 0), transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
