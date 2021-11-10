using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private Vector2 Velocity;
    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Velocity = new Vector2(-20, 0);
        rigidBody.velocity = Velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < -40)
        {
            Destroy(gameObject);
        }
    }
}
