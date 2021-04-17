using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D Rigidbody2D;
    public float MoveSpeed;
    public Animator Animator;
    public static PlayerController instance;
    public string areaTransitionName;
    public bool canMove = true;
    
    private Vector3 _bottomLeftLimit;
    private Vector3 _topRightLimit;
    
    private static readonly int MoveX = Animator.StringToHash("moveX");
    private static readonly int MoveY = Animator.StringToHash("moveY");
    private static readonly int LastMoveX = Animator.StringToHash("lastMoveX");
    private static readonly int LastMoveY = Animator.StringToHash("lastMoveY");
    
    // Start is called before the first frame update
    void Start() {
        if (instance == null) {
            instance = this;
        } else {
            if (instance != this) {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update() {

        if (canMove) {
            Rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * MoveSpeed;
            Animator.SetFloat(MoveX, Rigidbody2D.velocity.x);
            Animator.SetFloat(MoveY, Rigidbody2D.velocity.y);
            
        } else {
            Rigidbody2D.velocity = Vector2.zero;
        }

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||
            Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1) {
            Animator.SetFloat(LastMoveX, Input.GetAxisRaw("Horizontal"));
            Animator.SetFloat(LastMoveY, Input.GetAxisRaw("Vertical"));
        }
        Vector3 position = transform.position;
        
        transform.position = new Vector3(
            Mathf.Clamp(position.x, _bottomLeftLimit.x, _topRightLimit.x),
            Mathf.Clamp(position.y, _bottomLeftLimit.y, _topRightLimit.y), position.z);
    }

    public void SetBounds(Vector3 botLeft, Vector3 topRight) {
        _bottomLeftLimit = botLeft + new Vector3(0.5f, 0.5f, 0f);
        _topRightLimit = topRight - new Vector3(0.5f, 0.5f, 0f);
    }
}