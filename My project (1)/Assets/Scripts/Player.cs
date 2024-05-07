using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float PaddleSpeed;
    public KeyCode KeyUp;
    public KeyCode KeyDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isPressingUp = Input.GetKey(KeyUp);
        bool isPressingDown = Input.GetKey(KeyDown);

        if (isPressingUp)
            transform.Translate(Vector2.up * Time.deltaTime * PaddleSpeed);
        if (isPressingDown)
            transform.Translate(Vector2.down * Time.deltaTime * PaddleSpeed);
    }
}
