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
        onLightOff();
    }

    [PunRPC]
    public void EncenderLuz(string nombre)
    {
        onLightOn(nombre);
    }

    

    public void EncenderLuzRPC(string nombre)
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("EncenderLuz", RpcTarget.All, nombre);
    }

}
