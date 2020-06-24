using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractableObjectNetwork : MonoBehaviour
{
    VRTK_InteractableObject io;
    // Start is called before the first frame update
    void Start()
    {
        io = GetComponent<VRTK_InteractableObject>();
     
        io.InteractableObjectGrabbed += OnGrab;
        io.InteractableObjectUngrabbed += OnUnGrab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGrab(object o, InteractableObjectEventArgs e)
    {
        Debug.Log("Grab Interactable", this);
        GameEvents.current.GrabRPC(transform.name);
    }

    public void OnUnGrab(object o, InteractableObjectEventArgs e)
    {
        Debug.Log("UnGrab Interactable", this);
        GameEvents.current.UnGrabRPC(transform.name);
    }
}
