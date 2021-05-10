using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float jump = 8f;
    public Rigidbody2D rb;
    public string currentColour;
    public SpriteRenderer sr;

    public Color colourB;
    public Color colourY;
    public Color colourPu;
    public Color colourPi;
    private int colIndex = -1;
    private int index = -1;

    private Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomColour();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                rb.velocity = Vector2.up * jump;
            }
        }

        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jump;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "ColourChanger")
        {
            SetRandomColour();
            Destroy(col.gameObject);
            return;
        }

        if(col.tag != currentColour && col.tag != "Victory")
        {
            GameManager.gm.gameReset = true;
        }

        if(col.tag == "Victory")
        {
            Destroy(col.gameObject);
            GameManager.gm.gameOver = true;
        }
    }

    void SetRandomColour()
    {
        while(colIndex == index)
        {
            index = Random.Range(0, 4);
        }
        
        switch(index)
        {
            case 0:
                currentColour = "Blue";
                sr.color = colourB;
                break;
            case 1:
                currentColour = "Yellow";
                sr.color = colourY;
                break;
            case 2:
                currentColour = "Purple";
                sr.color = colourPu;
                break;
            case 3:
                currentColour = "Pink";
                sr.color = colourPi;
                break;
        }

        colIndex = index;
    }
}
