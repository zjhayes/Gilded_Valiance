using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D physics;
    public float moveSpeed;
    public Animator animator;
    public string lastTransition;

    public static PlayerController instance;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    public bool canMove = true;
    
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(canMove)
        {
            physics.velocity = new Vector2(Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")) * moveSpeed;
            
        }
        else
        {
            physics.velocity  = Vector2.zero;
        }

        // Update animations.
        animator.SetFloat("moveX", physics.velocity.x);
        animator.SetFloat("moveY", physics.velocity.y);

        if((Input.GetAxisRaw("Horizontal") >= 1 ||
            Input.GetAxisRaw("Horizontal") <= -1 ||
            Input.GetAxisRaw("Vertical") >= 1 ||
            Input.GetAxisRaw("Vertical") <= -1) && canMove)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

        // Keep camera inside bounds of map.
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), 
            Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    public void SetBounds(Vector3 _bottomLeftLimit, Vector3 _topRightLimit)
    {
        // Adds padding for player dimensions.
        bottomLeftLimit = _bottomLeftLimit + new Vector3(.5f, 1f, 0f);
        topRightLimit = _topRightLimit + new Vector3(-.5f, -1f, 0f);
    }
}