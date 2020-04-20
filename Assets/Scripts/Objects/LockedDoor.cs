using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedDoor : InteractWithDialog
{
    public GameObject lockedDoor;
    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                if (!key.activeInHierarchy)
                {
                    lockedDoor.SetActive(false);
                    dialog = "You have used the key to pass through the door!";
                }
                dialogText.text = dialog;
            }
        }
    }

}
