using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;
    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            key.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(dialogBoxCo());
            
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
            playerInRange = false;
        }
    }

    private IEnumerator dialogBoxCo()
    {
        
        dialogBox.SetActive(true);
        dialogText.text = dialog;
        yield return new WaitForSeconds(4f);
        dialogBox.SetActive(false);
        key.SetActive(false);
    }

}
