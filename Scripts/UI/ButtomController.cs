using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtomController : MonoBehaviour
{
    bool active = false;
    public Color colorOn, colorOff;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

   

    public void SwitchButtom()
    {
        active = !active;
        image.color = active ? colorOn : colorOff;
        
    }
}
