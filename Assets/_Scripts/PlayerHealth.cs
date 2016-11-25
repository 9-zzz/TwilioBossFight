using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public Slider healthBar;

    AudioSource aud;

    public static PlayerHealth S;

    public bool hurting = false;

    MeshRenderer mrend;

    void Awake()
    {
        S = this;
        mrend = GetComponent<MeshRenderer>();
    }

    public void hurt()
    {
        if (!hurting)
        {
            aud.Play();
            healthBar.value--;
            StartCoroutine(hurt(0.01f));
        }
    }

    IEnumerator hurt(float time)
    {
        hurting = true;
        for (int i = 0; i < 15; i++)
        {
            print("started");
            yield return new WaitForSeconds(time);
            mrend.enabled = false;
            yield return new WaitForSeconds(time);
            mrend.enabled = true;
        }
        hurting = false;
    }

    // Use this for initialization
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

}
