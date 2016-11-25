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

    public Vector3 twBulletStartingPos;
    public Quaternion twBulletStartingRot;

    public AudioClip shootSound;
    public AudioClip regenSound;

    void Awake()
    {
        S = this;
    }

   // Use this for initialization
    void Start()
    {
        outerRing = transform.GetChild(4).gameObject;
        twBullet = outerRing.transform.GetChild(0).gameObject;
        twBulletRend = twBullet.GetComponent<MeshRenderer>();

        StartCoroutine(ShootWait(3));

        originalEmissionColor = twBulletRend.materials[0].GetColor("_EmissionColor");

        twBulletStartingPos = twBullet.transform.localPosition;
        twBulletStartingRot = twBullet.transform.localRotation;
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

    IEnumerator ShootWait(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time * 2);
            RingLooker.S.homing = true;
            chargeBullet = true;

            yield return new WaitForSeconds(time);

            AudioSource.PlayClipAtPoint(shootSound, transform.position);
            yield return new WaitForSeconds(0.9f);

            twBullet.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            twBullet.transform.GetChild(0).GetComponent<ParticleSystemRenderer>().material = twBulletRend.material;

            twBullet.transform.parent = null;
            twBullet.GetComponent<Rigidbody>().isKinematic = false;
            twBullet.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 13, ForceMode.Impulse);
            RingLooker.S.homing = false;

            yield return new WaitForSeconds(time);
            yield return new WaitForSeconds(time);
            twBullet.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
            print("sdfds");
            chargeBullet = false;
            originalEmissionColor = outerRing.GetComponent<Renderer>().materials[0].GetColor("_EmissionColor");

            twBullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
            twBullet.GetComponent<Rigidbody>().isKinematic = true;

            twBulletRend.materials[0].SetColor("_EmissionColor", outerRing.GetComponent<Renderer>().materials[0].GetColor("_EmissionColor"));

            twBullet.transform.parent = outerRing.transform;
            twBullet.transform.localPosition = twBulletStartingPos;
            twBullet.transform.localRotation = twBulletStartingRot;

            float flickerTime = 0.25f;

            for (int i = 1; i < 30; i++)
            {
            AudioSource.PlayClipAtPoint(regenSound, transform.position);
                yield return new WaitForSeconds(flickerTime);
                twBullet.SetActive(false);
                yield return new WaitForSeconds(flickerTime);
                twBullet.SetActive(true);

                flickerTime /= i;
            }

            yield return new WaitForSeconds(time);

        }
    }
 
}
