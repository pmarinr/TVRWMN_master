using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentaculos : MonoBehaviour
{
    Animator anim;
    AudioSource audio;
    bool active = false;
    // Start is called before the first frame update
    private void Awake()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        audio= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MuestraTentaculos());
        }
    }

    IEnumerator MuestraTentaculos()
    {
        if (!active) {
            active = true;
            foreach (Transform child in transform)
                child.gameObject.SetActive(true);

            audio.Play();
            anim.SetTrigger("switch");
            yield return new WaitForSeconds(1.5f);
            anim.SetTrigger("switch");
            yield return new WaitForSeconds(0.2f);
            foreach (Transform child in transform)
                child.gameObject.SetActive(false);
            active = false;
        }
    }
 }
