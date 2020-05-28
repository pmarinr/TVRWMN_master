using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielagos : MonoBehaviour
{
    public Transform bats;
    public Transform entrada, centro, salida;
    public int vueltas = 4;
    public float tiempo = 10;

    Transform inicio;
    // Start is called before the first frame update
    void Start()
    {
        inicio = bats.transform;
        StartCoroutine(InvokeBats());
    }

    // Update is called once per frame
    

    IEnumerator InvokeBats()
    {
        
        yield return new WaitForSeconds(1f);
        bats.gameObject.SetActive(true);
        Tween myTween = bats.transform.DOMove(entrada.position, 1);
        yield return myTween.WaitForCompletion();
        myTween = centro.transform.DORotate(new Vector3(0, 360, 0), 2, RotateMode.FastBeyond360);
        //bats.transform.transform.DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 0.5f, 5);

        yield return myTween.WaitForCompletion();
        myTween = centro.transform.DORotate(new Vector3(0, 360, 0), 4, RotateMode.FastBeyond360);
        yield return myTween.WaitForCompletion();
        myTween = centro.transform.DORotate(new Vector3(0, 360, 0), 4, RotateMode.FastBeyond360);
        yield return myTween.WaitForCompletion();
        myTween = bats.transform.DOMove(salida.position, 1);
        yield return myTween.WaitForCompletion();
        bats.gameObject.SetActive(false);
    }
}
