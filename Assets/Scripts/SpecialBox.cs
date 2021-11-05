using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBox : MonoBehaviour
{

    public BoxCollider2D collider;
    public Transform left;
    public Transform right;
    public Transform top;
    public Transform bot;
    public Transform mid;
    public float speed;
    private Rigidbody2D rig;
    private Animator anim;
    private bool collidingLeft;
    private bool collidingRight;
    private bool collidingTop;
    private bool collidingBot;
    public LayerMask layer;
    public bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        collidingLeft = Physics2D.Linecast(mid.position, left.position, layer);
        collidingRight = Physics2D.Linecast(mid.position, right.position, layer);
        collidingBot = Physics2D.Linecast(mid.position, bot.position, layer);
        collidingTop = Physics2D.Linecast(mid.position, top.position, layer);
     
            if (collidingLeft && Input.GetKey(KeyCode.C))
            {
                anim.SetBool("left", false);
                anim.SetBool("down", false);
                anim.SetBool("up", false);
                rig.velocity = new Vector2(speed, 0f);
                anim.SetBool("right", true);
            }
            else if (collidingRight && Input.GetKey(KeyCode.C))
            {
                anim.SetBool("right", false);
                anim.SetBool("down", false);
                anim.SetBool("up", false);
                rig.velocity = new Vector2(-speed, 0f);
                anim.SetBool("left", true);
            }
            else if (collidingTop && Input.GetKey(KeyCode.C))
            {
                anim.SetBool("left", false);
                anim.SetBool("right", false);
                anim.SetBool("up", false);
                rig.velocity = new Vector2(0f, -speed);
                anim.SetBool("down", true);
            }
            else if (collidingBot && Input.GetKey(KeyCode.C))
            {
                anim.SetBool("left", false);
                anim.SetBool("right", false);
                anim.SetBool("down", false);
                rig.velocity = new Vector2(0f, speed);
                anim.SetBool("up", true);
            }
        
    }
    public void Stop()
    {
        rig.velocity = new Vector2(0f, 0f);
        anim.SetBool("left", false);
        anim.SetBool("right", false);
        anim.SetBool("down", false);
        anim.SetBool("up", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer==6|| collision.gameObject.layer == 7)
        {
            rig.velocity = new Vector2(0f, 0f);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("down", false);
            anim.SetBool("up", false);
        }
    }
}
