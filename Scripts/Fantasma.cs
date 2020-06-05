using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma : MonoBehaviour
{

    public LookToPlayer looktoplayer;
    public HandToObject lefthand, righthand;
    public static bool apuntar = false;

    Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        looktoplayer.player = GameController.Player;   
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
}
