using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private CircleCollider2D circle;
    private Animator anim;
    public int points;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        circle = GetComponent<CircleCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Collect");
            anim.SetBool("catch",true);
            circle.enabled = false;
         
            Destroy(gameObject, 1f);
           
        }
    }
}
