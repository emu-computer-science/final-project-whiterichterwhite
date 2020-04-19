using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("Things to change in the UI")]
    [SerializeField] private TextMeshProUGUI itemNum;
    [SerializeField] private Image itemImage;

    [Header("Variables from the item")]
    public InventoryItem thisItem;
    public InventoryManager thisManager;

    public void Setup(InventoryItem item, InventoryManager manager) {

        thisItem = item;
        thisManager = manager;

        if (thisItem) {
            itemImage.sprite = thisItem.itemImage;
            itemNum.text = "" + thisItem.numberHeld;
        }

    }

    public void ClickedItem() {
        if (thisItem) {
            thisManager.SetTandB(thisItem.itemDescription, thisItem.usable, thisItem);
        }
    }
}
