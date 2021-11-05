using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                FindObjectOfType<AudioManager>().Pause("Elder");
                dialogBox.SetActive(false);
                anim.SetBool("talking", false);
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Elder");
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                anim.SetBool("talking", true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Pause("Elder");
            playerInRange = false;
            dialogBox.SetActive(false);
            anim.SetBool("talking", false);
        }
    }
}
