using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chirridos : MonoBehaviour
{
    public AudioClip[] chirridos;
    // Start is called before the first frame update
    public GameObject source;
    AudioSource audio;
    public float ancho,largo,alto;
    public bool activo = true;
    void Start()
    {
        audio = source.GetComponent<AudioSource>();
        StartCoroutine(SonidoCasa());
        
    }

    // Update is called once per frame
    IEnumerator SonidoCasa()
    {
        while (activo) { 
            yield return new WaitForSeconds(Random.Range(10,40));
            Chirrido();
        }
    }

    void Chirrido() {
        source.transform.position = new Vector3(Random.Range(-ancho/2,ancho / 2), Random.Range(-largo / 2, largo / 2), Random.Range(-alto / 2, alto / 2));
        audio.clip = chirridos[Random.Range(0, chirridos.Length)];
        audio.Play();
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireCube(transform.position, new Vector3(ancho, alto, largo));
    }
}
