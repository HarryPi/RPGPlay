using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public Rigidbody2D Rigidbody2D;
    public float MoveSpeed;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() {
        Rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * MoveSpeed;
    }
}