using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    [System.Serializable]
    public enum Cursor { Default, Aim, VisionCone, RotateCamera, Punch }
    [SerializeField]
    public Cursor cursor;
    // Start is called before the first frame update
    void Start()
    {
        cursor = Cursor.Aim;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cursor = Cursor.Punch;
        }
    }
}
