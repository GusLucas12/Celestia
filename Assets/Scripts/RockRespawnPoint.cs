using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRespawnPoint : MonoBehaviour
{
    public GameController gm;
    public RockSliding rock;
    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<GameController>();
        gm.rock = rock;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            gm.deathRespawn = gameObject;
        }
    }
}
