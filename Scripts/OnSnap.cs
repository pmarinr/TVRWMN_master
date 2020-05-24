using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSnap : MonoBehaviour
{
    private bool _inSnap = false;

    private Rigidbody _rb;
  
    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
    }

    public void ChangeKinematic(bool iskine)
    {
        _rb.isKinematic = _inSnap;
    }

    public void InSnap(bool insnap)
    {
        _inSnap = insnap;
    }
}
