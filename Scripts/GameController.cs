using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Necesitamos crear variables estaticas para poder hacer referencias a objetos entre escenas
 * 
 * 
 * */
public class GameController : MonoBehaviour
{
    public static Transform Player;
    public static Transform LeftHand;
    public static Transform RightHand;

    public static void  UpdatePlayer()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    public static void UpdateLeftHand()
    {
        Player = GameObject.FindWithTag("PlayerManoIzq").transform;
    }

    public static void UpdateRightHand()
    {
        Player = GameObject.FindWithTag("PlayerManoDch").transform;
    }
}
