using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
public class GameEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameEvents current;
    void Awake()
    {
        current = this;
    }

    public event System.Action onLightOff;
    public event System.Action<string> onLightOn;

    [PunRPC]
    public void ApagarLuces()
    {
        Debug.Log("Apagando todas las luces");
        onLightOff();
    }

    [PunRPC]
    public void EncenderLuz(string nombre)
    {
        Debug.Log("Encendiendo " + nombre);
        onLightOn(nombre);
    }

    

    public void EncenderLuzRPC(string nombre)
    {
        Debug.Log("Enviando evento luces a todos los conectados");
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("EncenderLuz", RpcTarget.All, nombre);
    }

}
