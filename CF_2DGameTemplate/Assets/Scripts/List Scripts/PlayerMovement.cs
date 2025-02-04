using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    public GameObject player;
    public float speed = 0.5f;

    public List<string> myInventory;

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

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
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
        if (collision.gameObject.tag == "Enemy"){
            Destroy(player);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered Trigger");
    }

    public void addItem(string item)
    {
        myInventory.Add(item);
    }
}
