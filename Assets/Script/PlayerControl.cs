using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Vector2 input;
    public float moveSpeed;
    private bool isMoving;
    public LayerMask solidObjectLayer;
    public LayerMask solidLayer;
    public bool canAttack;
    private Animator anim;
    private Rigidbody2D myrb;
    private float attTime = 0.25f;
    private float attCounter = 0.25f;
    private bool isAtt;
    private void Awake()
    {
        myrb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    public void HandleUpdate()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;
            if (input != Vector2.zero)
            {
                anim.SetFloat("moveX", input.x);
                anim.SetFloat("moveY", input.y);
                anim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                anim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if(isWalkable(targetPos))
                StartCoroutine(Move(targetPos));
            }
        }
        anim.SetBool("isMoving", isMoving);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            interact();
        }
        if (isAtt)
        {
            myrb.velocity = Vector2.zero;
            attCounter -= Time.deltaTime;
            if(attCounter <= 0)
            {
                anim.SetBool("isAttack", false);
                isAtt = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.T) && canAttack)
        {
            attCounter = attTime;
            anim.SetBool("isAttack", true);
            isAtt = true;
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    private bool isWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.3f, solidObjectLayer | solidLayer)!= null)
        {
            return false;
        }

        return true;
    }

    void interact()
    {
        var facingDir = new Vector3(anim.GetFloat("moveX"), anim.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;
        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, solidObjectLayer);
        if(collider != null)
        {
            collider.GetComponent<Interactable>()?.interact();
        }
    }
}
