using UnityEngine;
using System.Collections;

public class TwilioBossBrain : MonoBehaviour
{
    public static TwilioBossBrain S;

    public GameObject outerRing;
    public GameObject twBulletSpawnPoint;
    public GameObject twBullet;

    public float ringSpeed = 20.0f;

    MeshRenderer twBulletRend;

    public bool ringHoming =false;

    void Awake()
    {
        S = this;
    }

    IEnumerator ShootWait(float time)
    {
        yield return new WaitForSeconds(time);
        twBulletRend.material.color = Color.yellow;

        yield return new WaitForSeconds(time);
        ringHoming = true;

        yield return new WaitForSeconds(time);
        twBullet.transform.parent = null;
        twBullet.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 10, ForceMode.Impulse);
        ringHoming = false;
    }

    // Use this for initialization
    void Start()
    {
        outerRing = transform.GetChild(4).gameObject;
        twBullet = outerRing.transform.GetChild(0).gameObject;
        twBulletRend = twBullet.GetComponent<MeshRenderer>();

        //StartCoroutine(ShootWait(2));
    }

    // Update is called once per frame
    void Update()
    {
        if (ringHoming)
            outerRing.transform.LookAt(PlayerMovement.S.transform.position);


        outerRing.transform.Rotate(0, Time.deltaTime * ringSpeed, 0);
    }

}
