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

}
