using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed; //this will show up in the inspector as speed
    public Text countText;
    public Text winText;
    public int countfix;


    public Vector3 LastVelocity = Vector3.zero;

    private Rigidbody rb;
    private int count;
   // private int winCount;
    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        count = 0;
        SetCountText();
        winText.text = "";
       // winCount = GameObject.FindGameObjectWithTag("Pick Up").Length;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce (movement * speed);
        LastVelocity = rb.velocity;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
 
        if (count == countfix) // count >= winCount
        {
            winText.text = "You Win!";
        }
    }
}