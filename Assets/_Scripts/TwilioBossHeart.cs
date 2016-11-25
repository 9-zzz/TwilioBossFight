using UnityEngine;
using System.Collections;

public class TwilioBossHeart : MonoBehaviour
{
    public GameObject heartDeathPS;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "playerBullet")
        {
            Destroy(col.gameObject);

            Instantiate(heartDeathPS, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }

}
