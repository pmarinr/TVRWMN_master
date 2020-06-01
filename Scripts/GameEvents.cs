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
    public bool activa = true;
    public LayerMask layerTablero;
    void Awake()
    {
        current = this;
    }

    public event System.Action onLightOff;
    public event System.Action<string> onLightOn;
    public event System.Action<Vector3> moveToOuija;

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

    [PunRPC]
    public void MueveOuija(Vector3 posicion)
    {
        moveToOuija(posicion);
    }


    public void EncenderLuzRPC(string nombre)
    {
        Debug.Log("Enviando evento luces a todos los conectados");
        EncenderLuz(nombre);
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("EncenderLuz", RpcTarget.Others, nombre);
    }

    void Update()
    {
        if (activa && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100,layerTablero))
            {
                Debug.Log("Destino en " + hit.transform.name);
                Vector3 destino = hit.point;
                PhotonView photonView = PhotonView.Get(this);
                MueveOuija(destino);
                photonView.RPC("MueveOuija", RpcTarget.Others, destino);
            }
        }
    }

}
