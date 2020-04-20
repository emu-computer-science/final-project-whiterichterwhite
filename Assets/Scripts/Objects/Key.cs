using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : InteractWithDialog
{
    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            if(!dialogBox.activeInHierarchy && key.GetComponent<SpriteRenderer>().enabled)
            {
                key.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(dialogBoxCo());
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }

    }

    private IEnumerator dialogBoxCo()
    {
        yield return new WaitForSeconds(4f);
        dialogBox.SetActive(false);
        key.SetActive(false);
    }

}
