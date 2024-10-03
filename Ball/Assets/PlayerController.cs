using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private int score;
    public float speed = 0;
    public TextMeshProUGUI countText;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public GameObject winTextObject;

    // Start is called before the first frame update
    void Start()
    {
        score=0;
        SetCountText();
        winTextObject.SetActive(false);

    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        rb = GetComponent<Rigidbody>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        score++;
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            SetCountText();
        }

    }

    void SetCountText() 
   {
       countText.text =  "Score: " + score.ToString();
       if (score >= 8)
       {
           winTextObject.SetActive(true);
       }
   }
}
