using UnityEngine;
using System.Collections;

public class CityBlock : MonoBehaviour
{
    float rotVal;

    // Use this for initialization
    void Start()
    {
        rotVal = Random.Range(-2.5f, 2.5f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotVal * Time.deltaTime, 0);
    }

}
