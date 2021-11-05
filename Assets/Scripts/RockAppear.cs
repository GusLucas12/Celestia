using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAppear : MonoBehaviour
{
   [SerializeField] private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
           sprite.enabled=true;
        }
    }
}
