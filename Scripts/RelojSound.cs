using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RelojSound : MonoBehaviour
{
    public AudioClip Tic;
    public AudioClip Toc;
    public AudioClip Dong;
    public float nextDong = 10f;
    public AudioSource TicTocAudioSource;
    public AudioSource DongAudioSource;
    public Transform ManecillaHoras;
    public Transform ManecillaMinutero;
    int minutes = 0;
    int hours = 0;

    // Start is called before the first frame update
 

    public void PlayTic()
    {
       TicTocAudioSource.clip = Tic;
       NewMinute();
    }

    public void PlayToc()
    {
        TicTocAudioSource.clip = Toc;
        NewMinute();
    }

    public void PlayDong()
    {
        
        DongAudioSource.Play();

    }

    void NewMinute()
    {
        TicTocAudioSource.Play();
        ManecillaMinutero.Rotate(0, 0, 6);
        minutes++;
        if(minutes == 60)
        {
            NewHour();
        }
    }

    void NewHour()
    {
        minutes = 0;
        hours++;
        for (int i = 0; i < hours; i++)
        {
            Invoke("PlayDong", i * 6);
        }
        ManecillaHoras.Rotate(0, 0, 30);
    }

}
