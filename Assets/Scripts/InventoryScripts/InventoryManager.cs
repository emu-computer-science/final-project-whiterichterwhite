using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    [Header("Inventory Info")]
    public PlayerInventory playerInv;
    [SerializeField] private GameObject blankSlot;
    [SerializeField] private GameObject invPanel;
    [SerializeField] private TextMeshProUGUI descText;
    [SerializeField] private GameObject useButton;

    public void SetTandB(string desc, bool buttonActive) {

        descText.text = desc;

        if (buttonActive) {
            useButton.SetActive(true);
        }
        else{
            useButton.SetActive(false);
        }
    }


    public void MakeInventorySlots() {

        if (playerInv) {
            for (int i = 0 ; i < playerInv.playerInv.Count; i++) {
                GameObject temp = Instantiate(blankSlot,invPanel.transform.position,Quaternion.identity);
                temp.transform.SetParent(invPanel.transform);
                InventorySlot newSlot = temp.GetComponent<InventorySlot>();

                
                newSlot.Setup(playerInv.playerInv[i], this);


            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MakeInventorySlots();
        SetTandB("", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
