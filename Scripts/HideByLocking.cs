using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HideByLocking : MonoBehaviour
{

    public LayerMask layer;
    public float interactionRayLength = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SensorRaycast();    
    }

    void SensorRaycast()
    {
        Vector3 fowardDirection = transform.forward;

        Ray interactionRay = new Ray(transform.position, fowardDirection);
        RaycastHit interactionRayHit;
        

        bool hitFound = Physics.Raycast(interactionRay, out interactionRayHit, interactionRayLength,layer);
        if (hitFound)
        {
            Debug.LogWarning(transform.name + "detect " + interactionRayHit.transform.name, interactionRayHit.transform.gameObject);
            Debug.DrawLine(transform.position, fowardDirection * interactionRayLength, Color.green);
            Ghost ghostScript = interactionRayHit.transform.gameObject.GetComponent<Ghost>();
            if (ghostScript)
            {
                ghostScript.Ocultar();
            }
        }
        else
        {
            Debug.DrawLine(transform.position, fowardDirection * interactionRayLength, Color.red);
        }
        
    }
}
