using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentaculo : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    public int start = 1;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("Start", Random.Range(1, 5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
