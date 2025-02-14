using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementDict : MonoBehaviour
{
    public static PlayerMovementDict Instance;
    public GameManager gameManager;

    public GameObject player;
    public float speed = 0.5f;

    public Dictionary<string, int> myInventoryDict = new Dictionary<string, int>();

    public TextMeshProUGUI inventoryDisplay;

    Vector3 originalPos;

    private void Awake()
    {
        // makes sure singleton player object doesnt destroy while loading
        if(Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        // makes sure there's onle one singleton player object
        else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        // myInventoryDict.Add("Sword", 1);
        DisplayInventory();
    }
    void Update()
    {
        // WASD Movement
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position += Vector3.up * speed;
            // Debug.Log("W Pressed");
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += Vector3.left * speed;
            // Debug.Log("A Pressed");
        }

        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position += Vector3.down * speed;
            // Debug.Log("S Pressed");
        }

        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += Vector3.right * speed;
            // Debug.Log("D Pressed");
        }
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {   
            myInventoryDict[""] = 0;
            gameObject.transform.position = originalPos;
            gameManager.DeathScene();
        }
        else if (collision.gameObject.tag == "Transition")
        {
            gameObject.transform.position = originalPos;
            gameManager.EndScene();
        }
    }

    public void DisplayInventory()
    {
        inventoryDisplay.text = "";
        foreach (var item in myInventoryDict)
        {
            inventoryDisplay.text += item.Key + ": " + item.Value + "\n";
        }
    }
}
