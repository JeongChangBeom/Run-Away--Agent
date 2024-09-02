using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explanation_gun : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("isAttack", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
