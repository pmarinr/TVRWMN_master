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
    public event System.Action bats;
    public event System.Action cthulhu;
    public event System.Action<string> onLightOn;
    public event System.Action<Vector3> moveToOuija;
    public event System.Action<bool> activaOuija;

    [PunRPC]
    private void ApagarLuces()
    {
        Debug.Log("Apagando todas las luces");
        onLightOff();
    }

    [PunRPC]
    private void EncenderLuz(string nombre)
    {
        Debug.Log("Encendiendo " + nombre);
        onLightOn(nombre);
    }

    [PunRPC]
    private void MueveOuija(Vector3 posicion)
    {
        moveToOuija(posicion);
    }

    [PunRPC]
    private void SetOuija(bool activado)
    {
        Debug.Log("PunRPC setOuija " + activado);
        activaOuija(activado);
    }

    [PunRPC]
    private void ActivaMurcielagos()
    {
        Debug.Log("Murcielagos");
        bats();
    }

    [PunRPC]
    private void ActivaCthulhu()
    {
        Debug.Log("Cthulhu");
        cthulhu();
    }


    public void EncenderLuzRPC(string nombre)
    {
        Debug.Log("Enviando evento luces a todos los conectados");
        //EncenderLuz(nombre);
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("EncenderLuz", RpcTarget.All, nombre);
    }


    public void ActivarOuijaRPC(bool activado)
    {
        Debug.Log("Activando Ouija");
        //SetOuija(activado);
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("SetOuija", RpcTarget.All, activado);
    }

    public void MurcielagosRPC()
    {
        Debug.Log("Activando Murtcielagos");
        //ActivaMurcielagos();
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("ActivaMurcielagos", RpcTarget.All);
    }

    public void CthulhuRPC()
    {
        Debug.Log("Activando Cthulhu");
        //ActivaCthulhu();
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("ActivaCthulhu", RpcTarget.All);
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
                //MueveOuija(destino);
                photonView.RPC("MueveOuija", RpcTarget.All, destino);
            }
        }
    }

}
