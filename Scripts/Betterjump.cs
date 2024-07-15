using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Betterjump : MonoBehaviour
{
    public float Falljumpspeed = 2.5f;
    public float lowjumpspeed = 2;
    public Rigidbody2D rb;
    int isGround;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (Falljumpspeed - 1) * Time.deltaTime;
        }else if(rb.velocity.y >0 && !Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowjumpspeed - 1) * Time.deltaTime;
        }
    }
}
