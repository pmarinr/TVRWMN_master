using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Fantasma : MonoBehaviour
{

    public LookToPlayer looktoplayer;
    public HandToObject lefthand, righthand;
    public static bool apuntar = false;
    Animator anim;
    AudioSource audioSource;
    bool active = false;
    Transform player;

    // Start is called before the first frame update
    private void OnEnable()
    {
        Debug.LogError("Fantasma.cs Enable:Accediendo a Player");
        looktoplayer.player = GameController.Player;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        GameEvents.current.fantasma += Activar;
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
            active = true;
            audioSource.Play();
            transform.DOLocalMoveY(transform.position.y + 3, 2);
            //transform.position = GameController.Player.position + GameController.Player.forward*3;
            yield return new WaitForSeconds(3f);
            transform.DOLookAt(GameController.Player, 1,AxisConstraint.X);
            yield return new WaitForSeconds(1f);
            transform.DOLocalMoveZ(transform.position.z - 2, 1);
            
            
            active = false;
        }
    }
}
