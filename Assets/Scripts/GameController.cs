using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject currentCheckpoint;
    public GameObject boxRespawn;
    public GameObject deathRespawn;
    private Player player;
    public SpecialBox box;
    public RockSliding rock;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RespawnPlayer()
    {
        Vector3 currentCheckPo = currentCheckpoint.transform.position;
        player.transform.position = new Vector3(currentCheckPo.x,currentCheckPo.y,player.transform.position.z);
        RespawnBox();
        RespawnDeath();
    }
    public void RespawnDeath()
    {
        rock.isSliding = false;
        Vector3 respawnDeath = deathRespawn.transform.position;
        rock.transform.position = new Vector3(respawnDeath.x, respawnDeath.y, rock.transform.position.z);
    }
    public void RespawnBox()
    {
        Vector3 respawnBox = boxRespawn.transform.position;
        box.transform.position = new Vector3(respawnBox.x, respawnBox.y, box.transform.position.z);
        box.Stop();
    }
}
