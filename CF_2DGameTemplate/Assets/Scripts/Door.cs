using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public PlayerMovementDict myPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myPlayer.myInventoryDict["key"] >= 3)
        {
            Destroy(gameObject);
        }
    }
}
