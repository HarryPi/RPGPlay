using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D Rigidbody2D;
    public float MoveSpeed;
    public Animator Animator;
    public static PlayerController instance;
    public string areaTransitionName;
    
    private static readonly int MoveX = Animator.StringToHash("moveX");
    private static readonly int MoveY = Animator.StringToHash("moveY");
    private static readonly int LastMoveX = Animator.StringToHash("lastMoveX");
    private static readonly int LastMoveY = Animator.StringToHash("lastMoveY");
    
    // Start is called before the first frame update
    void Start() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update() {
        Rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * MoveSpeed;

        Animator.SetFloat(MoveX, Rigidbody2D.velocity.x);
        Animator.SetFloat(MoveY, Rigidbody2D.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||
            Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1) {
            Animator.SetFloat(LastMoveX, Input.GetAxisRaw("Horizontal"));
            Animator.SetFloat(LastMoveY, Input.GetAxisRaw("Vertical"));
        }
    }
}