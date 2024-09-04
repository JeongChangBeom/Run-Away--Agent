using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject player;
    private Animator anim;

    public int Health = 5;
    private PlayerController playerController;

    void Start()
    {
        player.layer = 3;
        playerController = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }
    public void onDamage()
    {
        Health -= 1;

        if (Health <= 0)
        {
            SoundManager.instance.Die_Play();
        }
        else
        {
            SoundManager.instance.Damage_Play();
        }
    }

    public void Die()
    {
        player.layer = 6;
        playerController.activeMoveSpeed = 0;
        anim.SetBool("isDie", true);
        Invoke("ChangeScript",2);
    }

    public void ChangeScript()
    {
        GameManager.instance.EndGame();
    }
}
