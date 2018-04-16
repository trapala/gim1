using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {
    public float speed;
    private int count;
    public Text countText;
    public Text winText;

    // Use this for initialization
    void Start () {
        count = 0;
        SetCountText();
        winText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime); 
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pickup")
        {
            count = count + 1;
            other.gameObject.SetActive(false);
            SetCountText();
        }
        if (other.gameObject.tag == "sphere")
        {
            count = count + 2;
            other.gameObject.SetActive(false);
            SetCountText();
        }

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 10)
        {
            winText.text = "You Win!";
        }
    }
    }
