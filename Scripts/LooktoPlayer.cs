using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToPlayer : MonoBehaviour
{
    public Transform player;
    public Transform head;
    public float speed = 1.0f;
    
    void Update()
    {
        if(player!= null && head!= null)
        {
            Vector3 targetDirection = head.transform.position - player.position;
            float singleStep = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(head.transform.forward, targetDirection, singleStep, 0.0f);
            Debug.DrawRay(head.transform.position, newDirection, Color.red);
            head.transform.rotation = Quaternion.LookRotation(newDirection);
        }
        
    }
}
