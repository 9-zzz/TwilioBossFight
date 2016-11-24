using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public KeyCode shootKey;

    public GameObject playerBullet;

    public float shootSpeed;

    ParticleSystem spps;

    // Use this for initialization
    void Start()
    {
        spps = transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            spps.Play();

            var pb = Instantiate(playerBullet, transform.position, transform.rotation) as GameObject;

            pb.GetComponent<Rigidbody>().AddRelativeForce(0, 0, shootSpeed, ForceMode.Impulse);

            Destroy(pb, 3.0f);
        }
    }

}
