using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRespawnPoint : MonoBehaviour
{
    public GameController gm;
    public SpecialBox box;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameController>();
        gm.box = box;
    }


    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Inrectable"))
        {
            gm.boxRespawn = gameObject;
        }
    }
}
