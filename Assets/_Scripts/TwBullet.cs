using UnityEngine;
using System.Collections;

public class TwBullet : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Physics.IgnoreCollision(transform.GetComponent<Collider>(), transform.parent.GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "playerBullet")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            PlayerHealth.S.hurt();
        }
    }

}
