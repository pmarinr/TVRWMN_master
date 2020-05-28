using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielagos : MonoBehaviour
{
    public Transform bats;
    public Transform entrada, centro;
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
        yield return new WaitForSeconds(5f);
        bats.transform.DOMove(entrada.position, 1);
        yield return new WaitForSeconds(1f);
        //centro.transform.DORotate(new Vector3(0, 360*vueltas, 0), tiempo, RotateMode.FastBeyond360);
        bats.transform.transform.DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 0.5f, 5);

        yield return new WaitForSeconds(tiempo);
        bats.transform.DOMove(inicio.position, 1);

    }
}
