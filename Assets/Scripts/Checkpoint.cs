using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public GameController gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameController>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gm.currentCheckpoint = gameObject;
        }
        if (collision.gameObject.CompareTag("Inrectable"))
        {
            gm.boxRespawn = gameObject;
        }
    }
}
