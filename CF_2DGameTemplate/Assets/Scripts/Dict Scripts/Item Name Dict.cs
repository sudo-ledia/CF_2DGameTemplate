using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ItemNameDict : MonoBehaviour
{
    public string itemName;
    public int itemIndex;
    public PlayerMovementDict myPlayer;
    public int itemNumber = 1;

    public DialogueManager dialogueManager;

    public GameObject pickup;

    void Start()
    {
        myPlayer = FindObjectOfType<PlayerMovementDict>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        pickup.SetActive(false);
    }
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision){

        pickup.SetActive(true);
        if (Input.GetKey(KeyCode.E))
        {
            Interact();
            AddItem();
            pickup.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void AddItem()
    {
        if(myPlayer.myInventoryDict.ContainsKey(itemName))
        {
            myPlayer.myInventoryDict[itemName]+= itemNumber;
        }
        else
        {
            myPlayer.myInventoryDict.Add(itemName, itemNumber);
        }
        myPlayer.DisplayInventory();
    }

    public void Interact()
    {
        dialogueManager.currentIndex = itemIndex;
    }
}