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
    public bool chargeBullet = false;

    public Color originalEmissionColor;
    public Color newEmissionColor;

    void Awake()
    {
        S = this;
    }

    IEnumerator ShootWait(float time)
    {
        yield return new WaitForSeconds(time*2);
        RingLooker.S.homing = true;
        chargeBullet = true;

        yield return new WaitForSeconds(time);
        twBullet.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        twBullet.transform.GetChild(0).GetComponent<ParticleSystemRenderer>().material = twBulletRend.material;

        twBullet.transform.parent = null;
        twBullet.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 13, ForceMode.Impulse);
        RingLooker.S.homing = false;
    }

    // Use this for initialization
    void Start()
    {
        outerRing = transform.GetChild(4).gameObject;
        twBullet = outerRing.transform.GetChild(0).gameObject;
        twBulletRend = twBullet.GetComponent<MeshRenderer>();

        StartCoroutine(ShootWait(4));

        originalEmissionColor = twBulletRend.materials[0].GetColor("_EmissionColor");
    }

    // Update is called once per frame
    void Update()
    {
        if (RingLooker.S.homing == false)
            outerRing.transform.Rotate(0, Time.deltaTime * ringSpeed, 0);


        if (chargeBullet)
        {
            //twBulletRend.material.color = Color.Lerp(twBulletRend.material.color, Color.white, Time.deltaTime * 1);

            originalEmissionColor = Color.Lerp(originalEmissionColor, newEmissionColor, Time.deltaTime * 0.25f);

            twBulletRend.materials[0].SetColor("_EmissionColor", originalEmissionColor);
        }
    }

}
