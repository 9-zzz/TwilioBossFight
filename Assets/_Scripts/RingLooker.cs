using UnityEngine;
using System.Collections;

public class RingLooker : MonoBehaviour
{
    public GameObject target;
    public bool homing = false;

    public static RingLooker S;

    public AudioClip deflectSound;

    void Awake()
    {
        S = this;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Look at including x and z leaning
        if (homing)
            transform.LookAt(target.transform.position);

        // Euler angles are easier to deal with. You could use Quaternions here also
        // C# requires you to set the entire rotation variable. You can't set the individual x and z (UnityScript can), so you make a temp Vec3 and set it back
        Vector3 eulerAngles = transform.localEulerAngles;
        eulerAngles.x = 0;
        eulerAngles.z = 0;

        // Set the altered rotation back
        transform.localRotation = Quaternion.Euler(eulerAngles);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "playerBullet")
        {
            AudioSource.PlayClipAtPoint(deflectSound, transform.position);

            col.gameObject.GetComponent<Rigidbody>().AddForce((col.gameObject.transform.position - transform.position) * 7, ForceMode.Impulse);
        }

        if (col.gameObject.tag == "Player")
        {
            PlayerHealth.S.hurt();

            col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            col.gameObject.GetComponent<Rigidbody>().AddForce((col.gameObject.transform.position - transform.position) * 10, ForceMode.Impulse);
        }
    }

}
