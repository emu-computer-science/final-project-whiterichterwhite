using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalItemInventory : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem thisItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !other.isTrigger) {
            AddItemInventory();
            Destroy(this.gameObject);
        }
    }

    void AddItemInventory() {
        if (playerInventory && thisItem) {
            if (playerInventory.playerInv.Contains(thisItem))
            {
                thisItem.numberHeld += 1;
            }
            else {
                playerInventory.playerInv.Add(thisItem);
                thisItem.numberHeld += 1;
            }
        }
    }

}
