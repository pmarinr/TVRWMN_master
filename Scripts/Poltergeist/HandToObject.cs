using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandToObject : MonoBehaviour
{
    public Transform target;
    public Transform hand;
    public float speed = 1.0f;

    Transform originalPose;

    private void Start()
    {
        originalPose = hand;
    }

    private void OnDisable()
    {
        hand = originalPose;
        target = null;
    }
    void Update()
    {
        if (Fantasma.apuntar && target!=null)
        {
            Vector3 targetDirection = target.position - hand.transform.position;
            float singleStep = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(hand.transform.up, targetDirection, singleStep, 0.0f);
            hand.transform.up = newDirection;
        }
        
    }
}
