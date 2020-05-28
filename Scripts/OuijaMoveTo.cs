using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuijaMoveTo : MonoBehaviour
{
    public Transform[] path;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(MoveToRoute(path));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveTo(Vector3 pos)
    {
        transform.DOLookAt(pos, .5f);
        transform.DOMove(pos, 2f);
        audio.pitch = Random.Range(0.9f, 1.1f);
        audio.Play();
    }

    IEnumerator MoveToRoute(Transform[] route)
    {
        yield return new WaitForSeconds(3f);
        foreach (Transform destino in route)
        {
            MoveTo(destino.position);
            
            yield return new WaitForSeconds(3f);

        }
        

    }
}
