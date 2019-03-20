using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float timeChange = 0;
    private float MovementX;
    private float MovementY;


    private float moveSpeed = 1f;
    public Rigidbody2D rb;

    public float ChaseRadius;
    public float AttackRadius;
    public Animator animator;
    private GameObject target;
    public bool canAttack = true;
    public int health;
    private int damagedlt;
    public int dodamage = 2;

    public bool Moving = false;

    Vector3 movement;
    Vector3 temp;

    void Start()
    {
        target = GameObject.Find("Player");
        Moving = false;
    }

    void Update()
    {
        CheckDistance();
        
    }   
    

    private void Move()
    {
        if (Time.time >= timeChange)
        {
            rb.velocity = new Vector2(0, 0);
            MovementX = Random.Range(1, -2);
            MovementY = Random.Range(1, -2);      
            movement = new Vector3(MovementX, MovementY, 0f);
            rb.velocity += new Vector2(MovementX, MovementY) * moveSpeed;
            timeChange = Time.time + 2;
        }
        
        
    }


    private void Animations()
    {
        animator.SetFloat("ZomX", rb.velocity.x);
        animator.SetFloat("ZomY", rb.velocity.y);
        animator.SetFloat("ZomMagnitude", rb.velocity.magnitude);

    }

    private void Attack()
    {
        rb.velocity = new Vector2(0, 0);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8588235f, 0.1019608f, 0.1019608f);
        Debug.Log("Enumerator about to run.");
        StartCoroutine(waitForAttack());
        

    }

    private IEnumerator waitForAttack()
    {
        Debug.Log("Enumerator running");
        yield return new WaitForSecondsRealtime(1f);
        Debug.Log("time waited");
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.1019608f, 0.8588235f, 0.1019608f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        if (Vector3.Distance(target.transform.position, transform.position) <= AttackRadius)
        {
            target.GetComponent<PlayerHealth>().health -= dodamage;
            Debug.Log("Damage dealt");
        }
        canAttack = false;
        StartCoroutine(waitForReset());
    }

    private IEnumerator waitForReset()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        yield return new WaitForSecondsRealtime(1f);
        canAttack = true;    
    }


    private void CheckDistance()
    {
        if (canAttack == true && Vector3.Distance(target.transform.position, transform.position) <= AttackRadius)
        {
            Attack();
        }


        else if(Vector3.Distance(target.transform.position, transform.position) <= ChaseRadius)
        {
            Moving = target.GetComponentInChildren<Attack>().knocked;

            if(Moving == false)
            {
                rb.velocity = new Vector2(0f, 0f);
            }
            temp = target.transform.position - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            animator.SetFloat("ZomX", temp.x);
            animator.SetFloat("ZomY", temp.y);
            animator.SetFloat("ZomMagnitude", temp.magnitude);

        }
        

        else
        {
            Move();
            Animations();
        }
        


    }
}
