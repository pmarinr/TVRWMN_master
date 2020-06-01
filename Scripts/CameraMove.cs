using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    public Transform[] PositionList;
    public Transform CameraMapPos;
    public Transform CameraOuijaPos;
    public int pos = 0;
    Camera cam;
   
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        this.transform.DOMove(PositionList[pos].position, 1);
        this.transform.DORotate(PositionList[pos].rotation.eulerAngles, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextCam();

        }
    }

    public void nextCam()
    {
        cam.orthographic = false;
        pos = (pos >= PositionList.Length-1) ? 0 : pos + 1;
        ChangePos(PositionList[pos]);
       
        
    }

    public void previewCam()
    {
        cam.orthographic = false;
     
        pos = (pos > 0 ) ? pos - 1: PositionList.Length - 1;
        ChangePos(PositionList[pos]);

    }

    public void CameraMap()
    {
       
        cam.orthographic = true;
        ChangePos(CameraMapPos);
    }

    public void CameraOuija()
    {
        cam.orthographic = false;
        ChangePos(CameraOuijaPos);
       
    }

    void ChangePos(Transform newPos)
    {
        this.transform.DOMove(newPos.position, 1);
        this.transform.DORotate(newPos.rotation.eulerAngles, 1);
    }
}
