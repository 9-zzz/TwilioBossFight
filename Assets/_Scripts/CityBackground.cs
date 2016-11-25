using UnityEngine;
using System.Collections;

public class CityBackground : MonoBehaviour
{
    public bool special = false;
    public bool starter = false;

    public int blockCtr = 10;
    public GameObject cityBlock;

    public int min = 0;
    public int max = 0;

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
                cb.GetComponent<CityBackground>().blockCtr = Random.Range(min, max);
            }
        }
 
        if (special)
        {
            for (int i = 1; i < blockCtr; i++)
            {
                GameObject cb2 = Instantiate(cityBlock, transform.position + new Vector3(0, i * 2, 0), transform.rotation) as GameObject;

                if (Random.Range(0, 12) == 2)
                    cb2.GetComponent<CityBlock>().colorRand = true;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
