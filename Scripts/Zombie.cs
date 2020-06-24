using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zombie;
    bool active = false;
    void Start()
    {
        zombie.SetActive(false);
        GameEvents.current.zombie += Activar;
    }

   public void Activar()
    {
        StartCoroutine(MuestraZombie());

    }

    IEnumerator MuestraZombie()
    {
        if (!active)
        {
           
            active = true;
            zombie.SetActive(true);
            yield return new WaitForSeconds(5f);
            zombie.SetActive(false);
            active = false;
        }
    }
}
