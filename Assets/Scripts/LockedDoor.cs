using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedDoor : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;
    public GameObject lockedDoor;
    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {
            if (!key.activeInHierarchy)
            {
                lockedDoor.SetActive(false);
                dialog = "You have used the key to pass through the door! You win!";
                StartCoroutine(dialogBoxCo());
            }
            else { StartCoroutine(dialogBoxCo()); }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
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
    }

}
