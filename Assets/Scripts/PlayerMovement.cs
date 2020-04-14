using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}


public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D playerBody;
    private Vector3 change;
    private Animator animator;
    // Start is cal led before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if(currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
        //log our change so we know it's moving and help trace errors
        Debug.Log(change);
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }


    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            CharacterMove();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void CharacterMove() {
        change.Normalize();
        playerBody.MovePosition(
            transform.position + change * speed * Time.deltaTime);
    }

    public void Knock(float knockTime)
    {
        StartCoroutine(KnockCo(knockTime));
    }


    private IEnumerator KnockCo(float knockTime)
    {
        if (playerBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            playerBody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            playerBody.velocity = Vector2.zero;
        }
    }

}
