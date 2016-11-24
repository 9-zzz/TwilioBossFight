using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement S;

    // Set mass to 100. Set gravity scale to 3. Freeze rotation along Z-axis.
    Rigidbody rb;

    public float speed = 5.0f;
    public float jumpSpeed = 12.0f;

    public bool canJump = false;
    public bool canMove = true;

    ParticleSystem dust;

    void Awake()
    {
        S = this;
        rb = GetComponent<Rigidbody>();
        dust = transform.GetChild(1).GetComponent<ParticleSystem>();
    }

    // Explains 'FixedUpdate' -> http://unity3d.com/learn/tutorials/topics/scripting/update-and-fixedupdate
    void FixedUpdate()
    {
        // Explains 'GetAxis' -> https://unity3d.com/learn/tutorials/topics/scripting/getaxis
        float xinput = Input.GetAxis("Horizontal");

        if (canMove)
            rb.velocity = new Vector2(xinput * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            canJump = false;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
            transform.localScale = Vector3.one;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            transform.localScale = new Vector3(-1, 1, 1);

        if (rb.velocity != Vector3.zero)
            dust.enableEmission = true;
        else
            dust.enableEmission = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ground")
            canJump = true;
    }

}
