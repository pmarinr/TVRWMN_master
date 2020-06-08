using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using VRTK.Examples;
using Photon.Realtime;

public class Fantasma : MonoBehaviour
{

    public LookToPlayer looktoplayer;
    public HandToObject lefthand, righthand;
    public static bool apuntar = false;
    Animator anim;
    AudioSource audioSource;
    bool active = false;
    Vector3 pos_original;
    Quaternion rot_original;
    

 

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        GameEvents.current.fantasma += Activar;
        pos_original =  transform.position;
        rot_original = transform.rotation;
    }



    public void LeftHandTo(Transform target)
    {
        lefthand.target = target;
        apuntar = true;
    }

    public void RightHandTo(Transform target)
    {
        righthand.target = target;
        apuntar = true;
    }

    private void OnDisable()
    {
       apuntar = false;
    }

    void Activar()
    {
        StartCoroutine(MuestraFantasma());
    }

    IEnumerator MuestraFantasma()
    {
        if (!active)
        {
            looktoplayer.player = GameController.Player;
            active = true;
            audioSource.Play();
            transform.DOLocalMoveY(transform.position.y + 3, 2);
            //transform.position = GameController.Player.position + GameController.Player.forward*3;
            yield return new WaitForSeconds(10f);
            transform.DOLookAt(GameController.Player.position , 1,AxisConstraint.Y);
            yield return new WaitForSeconds(1f);
            transform.DOMove(new Vector3(GameController.Player.position.x,0, GameController.Player.position.z),1);
            
            yield return new WaitForSeconds(1f);
            transform.position = pos_original;
            transform.rotation = rot_original;
            active = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MuestraFantasma());
        }
    }
}
