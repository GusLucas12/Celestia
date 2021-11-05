using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rig;
    public float jumpForce;
    public float dashForce;
    public bool isJumping;
    public bool canDash;
    public bool canClimb;
    public bool isClimbing;
    private bool isDashing
;    public GameObject button;
    [SerializeField] private float wallJumpForce;
    public Animator anim;
    private Timer timer;
    private bool isDead;
    private bool isFalling;
    [SerializeField] private float maxTime;
    GameController gm;
   
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gm = FindObjectOfType<GameController>();
        timer = new Timer(maxTime);
      
    }

    // Update is called once per frame
    void Update()
    {
       
        Move();
        Jump();
        Dash();
        DashTime();
        Climb();
    }
    void Move()
    {
        if (isDead)
        {
           
            return;
        }
        if (isClimbing)
        {
           
            return;
        }
        if (isFalling)
        {
           
            return;
        }
        if (isDashing)
        {
           
            return;
        }
       
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
       
        if (Input.GetAxis("Horizontal") > 0f)
        {
         
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (Input.GetAxis("Horizontal") == 0f)
        {
         
            anim.SetBool("walk", false);
        }
        
    }
    void Jump()
    {
        if (isDead)
        {
            return;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                
                rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                anim.SetBool("jump", true);
                FindObjectOfType<AudioManager>().Play("PlayerJump");
                isJumping = true;
             
            }

        }
        

    }
    void Dash()
    {
        if (isDead)
        {
            return;
        }
        if (Input.GetKey(KeyCode.Z) && Input.GetAxis("Horizontal") > 0f && Input.GetKey(KeyCode.UpArrow))
        {

            if (canDash)
            {
                isDashing=true;
                rig.velocity = new Vector2(dashForce, dashForce);
                FindObjectOfType<AudioManager>().Play("Dash");
                anim.SetBool("dash", true);
                canDash = false;

            }
        }
        else if (Input.GetKey(KeyCode.Z) && Input.GetAxis("Horizontal") > 0f && Input.GetKey(KeyCode.DownArrow))
        {
            if (canDash)
            {
                isDashing = true;
                rig.velocity = new Vector2(dashForce, -dashForce);
                FindObjectOfType<AudioManager>().Play("Dash");
                anim.SetBool("dash", true);
                canDash = false;

            }
        }
        else if (Input.GetKey(KeyCode.Z) && Input.GetAxis("Horizontal") < 0f && Input.GetKey(KeyCode.DownArrow))
        {
            if (canDash)
            {
                isDashing = true;
                rig.velocity = new Vector2(-dashForce, -dashForce);
                FindObjectOfType<AudioManager>().Play("Dash");
                anim.SetBool("dash", true);
                canDash = false;

            }
        }
        else if (Input.GetKey(KeyCode.Z) && Input.GetAxis("Horizontal") < 0f && Input.GetKey(KeyCode.UpArrow))
        {
            if (canDash)
            {
                isDashing = true;
                rig.velocity = new Vector2(-dashForce, dashForce);
                FindObjectOfType<AudioManager>().Play("Dash");
                anim.SetBool("dash", true);
                canDash = false;

            }
        }
        else if (Input.GetKey(KeyCode.Z) && Input.GetAxis("Horizontal") < 0f)
        {
            if (canDash)
            {
                isDashing = true;
                rig.velocity = new Vector2(-dashForce,0f);
                FindObjectOfType<AudioManager>().Play("Dash");
                anim.SetBool("dash", true);
                canDash = false;

            }
        }
        else if (Input.GetKey(KeyCode.Z) && Input.GetAxis("Vertical") > 0f)
        {
            if (canDash)
            {
                isDashing = true;
                rig.velocity = new Vector2(0f, dashForce);
                FindObjectOfType<AudioManager>().Play("Dash");
                anim.SetBool("dashUp", true);

                canDash = false;

            }
        }
        else if (Input.GetKey(KeyCode.Z) && Input.GetAxis("Vertical") < 0f)
        {
            if (canDash) {
                isDashing = true;
                rig.velocity = new Vector2(0f, -dashForce);
                FindObjectOfType<AudioManager>().Play("Dash");
                anim.SetBool("dashUp", true);

                canDash = false;

            }
        } else if (Input.GetKeyDown(KeyCode.Z))
        {
            if (canDash)
            {
                isDashing = true;
                rig.velocity=new Vector2(dashForce,0f);
                FindObjectOfType<AudioManager>().Play("Dash");
                anim.SetBool("dash", true);

                canDash = false;

            }
        }
    }
    void GravityCancel()
    {
        rig.gravityScale = 0;
     
    }
    void DashAnimation()
    {
        rig.gravityScale = 4;
        isDashing = false;
        anim.SetBool("dash", false);
        anim.SetBool("dashUp", false);
    }
    void DashTime()
    {
        if (!canDash && timer.RepeatCountTimer())
        {
            canDash = true;
         
        }
    }
    void Climb()
    {
        if (isDead)
        {
            return;
        }

        if (canClimb)
        {
            if (Input.GetKey(KeyCode.X))
            {
                if (Input.GetButton("Jump") && (Input.GetAxis("Horizontal") < 0f))
                {
                    Vector2 dir = Vector2.up + Vector2.left;
                    rig.velocity = new Vector2(-5,10);
                    rig.velocity += dir * wallJumpForce;
                    anim.SetBool("climb", false);
              
                    isClimbing = false;

                }
                else if (Input.GetButton("Jump") && (Input.GetAxis("Horizontal") > 0f))
                {
                    Vector2 dir = Vector2.up + Vector2.right;
                    rig.velocity = new Vector2(5, 10);
                    rig.velocity += dir * wallJumpForce;
                    anim.SetBool("climb", false);
                   
                    isClimbing = false;
                }else if(Input.GetButton("Jump") && (Input.GetAxis("Horizontal") == 0f))
                {
                    Vector2 dir = Vector2.up;
                    rig.velocity = new Vector2(0, 10);
                    rig.velocity += dir * wallJumpForce;
                    anim.SetBool("climb", false);
      
                    isClimbing = false;
                }
                else
                {

                    rig.gravityScale = 0;
                    rig.velocity = new Vector2(rig.velocity.x,0);
                    anim.SetBool("climb", true);
                    Vector3 movement = new Vector3(0f, Input.GetAxis("Vertical"), 0f);
                    transform.position += movement * Time.deltaTime * speed;
                    isClimbing = true;
                }

                
            }
            else
            {
                anim.SetBool("climb", false);
                rig.gravityScale = 4;
                isClimbing = false;
            }
        }
    }
    void Respawn()
    {
       
        anim.SetBool("Respawn", true);

        FindObjectOfType<AudioManager>().Play("Respawn");
        gm.RespawnPlayer();
        
    }
    void RespawnFake()
    {

        anim.SetBool("Respawn", false);
        anim.SetBool("dies", false);
        isDead = false;
        rig.gravityScale = 4;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool("jump", false);
            anim.SetBool("dash", false);
            anim.SetBool("dashUp", false);
            anim.SetBool("fall", false);
            isFalling = false;
            canDash = true;
           
        }
        if (collision.gameObject.CompareTag("Death"))
        {
            FindObjectOfType<AudioManager>().Play("Death");
            isDead = true;
            anim.SetBool("dies", true);
            rig.gravityScale = 0;
            rig.velocity = new Vector2(0, 0);
            FindObjectOfType<AudioManager>().Play("DeathPart2");
        }

        if (collision.gameObject.layer == 7)
        {
            isJumping = false;
            canClimb = true;
        }
       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interectable"))
        {
            button.SetActive(true);
            if (Input.GetKey(KeyCode.C))
            {
                button.SetActive(false);
            }
        }
      
        if (collision.gameObject.layer == 8)
        {
            anim.SetBool("fall", true);
            isFalling = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool("jump", false);
            

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interectable"))
        {
            button.SetActive(false);
           
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = true;
        }
        if (collision.gameObject.layer == 7)
        {
         
            anim.SetBool("climb", false);
            canClimb = false;
            isClimbing = false;
            rig.gravityScale = 4;
        }
        
    }
}
