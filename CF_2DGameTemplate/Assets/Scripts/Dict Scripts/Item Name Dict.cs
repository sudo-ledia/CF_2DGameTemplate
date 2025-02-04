using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemNameDict : MonoBehaviour
{
    public string itemName;
    public PlayerMovementDict myPlayer;
    public int itemNumber = 1;

    void Start()
    {
        myPlayer = FindObjectOfType<PlayerMovementDict>();

    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        AddItem();
        Destroy(gameObject);
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
}