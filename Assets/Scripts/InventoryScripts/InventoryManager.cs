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
    public InventoryItem currentItem;

    public void SetTandB(string desc, bool buttonActive, InventoryItem newItem) {

        currentItem = newItem;
        descText.text = desc;
        useButton.SetActive(buttonActive);
        
    }
    

    public void MakeInventorySlots() {
        //check if player inventory exsists, then set up a slot for each item in the list
        if (playerInv) {

            for (int i = 0 ; i < playerInv.playerInv.Count; i++) {
                if (playerInv.playerInv[i].numberHeld > 0) {
                    GameObject temp = Instantiate(blankSlot, invPanel.transform.position, Quaternion.identity);
                    temp.transform.SetParent(invPanel.transform);
                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                    if (newSlot) {
                        newSlot.Setup(playerInv.playerInv[i], this);
                    }                    
                }
            }
        }
    }

    void ClearInventory() {
        for (int i = 0; i < invPanel.transform.childCount; i++) {
            Destroy(invPanel.transform.GetChild(i).gameObject);
        }
    }
    public void UseButtonPressed() {
        if (currentItem) {
            currentItem.UseItem();

            //clear inventory slots
            ClearInventory();
            //refill all slots
            MakeInventorySlots();
            
        }
    }


    // Start is called before the first frame update
    void OnEnable()
    {
        MakeInventorySlots();
        SetTandB("", false, currentItem);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
