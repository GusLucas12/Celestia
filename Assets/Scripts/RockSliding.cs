using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSliding : MonoBehaviour
{
    private Animator anim;
    private Player player;
    private float x;
    private float atuX;
    public bool isSliding;
    [SerializeField] private float speed;
   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        x = gameObject.transform.position.x;
        atuX = x;
    }

    // Update is called once per frame
    void Update()
    {
        Slide();
    }
    void Slide()
    {
        if (isSliding)
        { 
           anim.SetBool("Slide", true);
          
            gameObject.transform.position = new Vector3(atuX, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.tag.Equals("Death");
            atuX+=speed;

        }
        else
        {
            atuX = x;
            anim.SetBool("Slide", false);
            gameObject.transform.position = new Vector3(x, gameObject.transform.position.y, gameObject.transform.position.z);
         
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isSliding = true;
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 4)
        {
            isSliding = false;
            anim.SetBool("Slide", false);
        }
    }

}
