using UnityEngine;
using System.Collections;

public class CityBlock : MonoBehaviour
{
    float rotVal;

    public Color originalEmissionColor;
    public Color newEmissionColor;

    public bool colorRand = false;

    // Use this for initialization
    void Start()
    {
        rotVal = Random.Range(-2.5f, 2.5f);

        originalEmissionColor = this.GetComponent<Renderer>().materials[1].GetColor("_EmissionColor");

        StartCoroutine(changeColor(Random.Range(0, 6)));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotVal * Time.deltaTime, 0);

        if (colorRand)
        {
            originalEmissionColor = Color.Lerp(originalEmissionColor, newEmissionColor, Time.deltaTime * 0.5f);

            this.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", originalEmissionColor);
        }
    }

    IEnumerator changeColor(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            newEmissionColor = new Color(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
        }
    }

}
