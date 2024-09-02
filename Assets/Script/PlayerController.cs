using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    AudioSource moveSound;
    public AudioSource slidingSound;
    public AudioSource attackSound;

    private Animator anim;
    public Animator attackanimator_up;
    public Animator attackanimator_down;
    public Animator attackanimator_side;
    public Transform attackleft;

    public ParticleSystem dashUp;
    public ParticleSystem dashDown;
    public ParticleSystem dashLeft;
    public ParticleSystem dashRight;

    public GameObject player;
    public float moveSpeed;
    public Rigidbody2D rig;
    private Vector2 moveInput;

    public float activeMoveSpeed;
    public float dashSpeed;
    
    public float dashLength, dashCooldown;

    private float dashCounter;
    public float dashCoolCounter;

    private PlayerHealth playerhealth;

    private Wall Wall;

    Color c;

    void Start()
    {
        moveSound = GetComponent<AudioSource>();
        playerhealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        activeMoveSpeed = moveSpeed;
        c = player.GetComponent<SpriteRenderer>().color;
    }
    void Update()
    {
        Move();
        Dash();
        Attack();
    }

    private void Move()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("inputX", moveInput.x);
        anim.SetFloat("inputY", moveInput.y);

        moveInput.Normalize();

        if ((moveInput.x != 0 || moveInput.y != 0) && playerhealth.Health > 0)
        {
            if (!moveSound.isPlaying)
            {
                moveSound.Play();
            }

            anim.SetBool("isMove", true);
        }
        else
        {
            moveSound.Stop();

            anim.SetBool("isMove", false);
        }

        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }

    private void Dash()
    {
        rig.velocity = moveInput * activeMoveSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && playerhealth.Health > 0)
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                anim.SetBool("isDash", true);

                player.layer = 6;
                Invoke("noDamage", 1);
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;


                if (moveInput.y < 0)
                {
                    slidingSound.Play();
                    dashDown.Play();
                }
                if (moveInput.y > 0)
                {
                    slidingSound.Play();
                    dashUp.Play();
                }
                if (moveInput.x < 0)
                {
                    slidingSound.Play();
                    dashLeft.Play();
                }
                if (moveInput.x > 0)
                {
                    slidingSound.Play();
                    dashRight.Play();
                }
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
                slidingSound.Stop();
                dashUp.Stop();
                dashDown.Stop();
                dashLeft.Stop();
                dashRight.Stop();
                anim.SetBool("isDash", false);
            }
        }
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        if (Input.GetKey(KeyCode.A) && playerhealth.Health > 0)
        {
            if (!attackSound.isPlaying)
            {
                attackSound.Play();
            }
            moveSound.Stop();
        }
        else
        {
            attackSound.Stop();
        }

        if (Input.GetKey(KeyCode.A) && playerhealth.Health > 0)
        {
            rig.velocity = new Vector2(0, 0);
            c.a = 0;
            player.GetComponent<SpriteRenderer>().color = c;

            GameObject.Find("Player").transform.Find("Attack_down").gameObject.SetActive(true);
            anim.SetBool("isAttack", true);
            attackanimator_down.SetTrigger("isAttack");

            if (moveInput.y > 0)
            {
                Debug.DrawRay(transform.position, new Vector3(0, 1, 0) * 4, new Color(1, 0, 0));
                RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(0, 1, 0), 4.0f, 1 << LayerMask.NameToLayer("wall"));

                if (hit.collider)
                {
                    Wall = GameObject.Find(hit.collider.name).GetComponent<Wall>();
                    Wall.GetComponent<Wall>().onDamage();
                }

                GameObject.Find("Player").transform.Find("Attack_down").gameObject.SetActive(false);
                GameObject.Find("Player").transform.Find("Attack_side").gameObject.SetActive(false);

                GameObject.Find("Player").transform.Find("Attack_up").gameObject.SetActive(true);

                attackanimator_up.SetTrigger("isAttack");
            }
            else if (moveInput.y < 0)
            {
                Debug.DrawRay(transform.position, new Vector3(0, -1, 0) * 4, new Color(1, 0, 0));
                RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(0, -1, 0), 4.0f, 1 << LayerMask.NameToLayer("wall"));

                if (hit.collider)
                {
                    Wall = GameObject.Find(hit.collider.name).GetComponent<Wall>();
                    Wall.GetComponent<Wall>().onDamage();
                }

                GameObject.Find("Player").transform.Find("Attack_up").gameObject.SetActive(false);
                GameObject.Find("Player").transform.Find("Attack_side").gameObject.SetActive(false);

                GameObject.Find("Player").transform.Find("Attack_down").gameObject.SetActive(true);

                attackanimator_down.SetTrigger("isAttack");
            }
            else if (moveInput.x < 0)
            {
                Debug.DrawRay(transform.position, new Vector3(-1, 0, 0) * 4, new Color(1, 0, 0));
                RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(-1, 0, 0), 4.0f, 1 << LayerMask.NameToLayer("wall"));

                if (hit.collider)
                {
                    Wall = GameObject.Find(hit.collider.name).GetComponent<Wall>();
                    Wall.GetComponent<Wall>().onDamage();
                }

                GameObject.Find("Player").transform.Find("Attack_up").gameObject.SetActive(false);
                GameObject.Find("Player").transform.Find("Attack_down").gameObject.SetActive(false);

                GameObject.Find("Player").transform.Find("Attack_side").gameObject.SetActive(true);

                attackanimator_side.SetTrigger("isAttack");
                attackleft.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            else if (moveInput.x > 0)
            {
                Debug.DrawRay(transform.position, new Vector3(1, 0, 0) * 4, new Color(1, 0, 0));
                RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(1, 0, 0), 4.0f, 1 << LayerMask.NameToLayer("wall"));

                if (hit.collider)
                {
                    Wall = GameObject.Find(hit.collider.name).GetComponent<Wall>();
                    Wall.GetComponent<Wall>().onDamage();
                }

                GameObject.Find("Player").transform.Find("Attack_up").gameObject.SetActive(false);
                GameObject.Find("Player").transform.Find("Attack_down").gameObject.SetActive(false);

                GameObject.Find("Player").transform.Find("Attack_side").gameObject.SetActive(true);

                attackanimator_side.SetTrigger("isAttack");
            }
        }
        else
        {
            rig.velocity = moveInput * activeMoveSpeed;
            c.a = 1;
            player.GetComponent<SpriteRenderer>().color = c;
            anim.SetBool("isAttack", false);
            GameObject.Find("Player").transform.Find("Attack_up").gameObject.SetActive(false);
            GameObject.Find("Player").transform.Find("Attack_down").gameObject.SetActive(false);
            GameObject.Find("Player").transform.Find("Attack_side").gameObject.SetActive(false);
        }
    }

    public void noDamage()
    {
        player.layer = 3;
    }
}
