using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public int wallHealth = 10;

    public Animator anim;

    private bool damageColldown = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void onDamage()
    {
        if (!damageColldown)
        {
            damageColldown = true;
            anim.SetBool("isDamage", true);
            wallHealth -= 1;
            Invoke("DamageStop", 1f);
            if (wallHealth <= 0)
            {
                onBroken();
            }
        }
    }

    public void onBroken()
    {
        anim.SetBool("isBroken", true);
        Destroy(gameObject, 2.3f);
    }

    public void DamageStop()
    {
        damageColldown = false;
        anim.SetBool("isDamage", false);
    }
}