﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using UnityEngine.UI;

public class GameEvents : MonoBehaviour
{
    [System.Serializable]
    public enum GEvent
    {
        LighOff,
        Bats,
        Cthulhu,
        OuijaOn,
        OuijaOff,
        Fantasma,
        Zombie
    }

    
    // Start is called before the first frame update
    public static GameEvents current;
    public LayerMask layerTablero;
    public InputField inputTexto;
    void Awake()
    {
        current = this;
    }

    
    public event System.Action onLightOff;
    public event System.Action bats;
    public event System.Action cthulhu;
    public event System.Action fantasma;
    public event System.Action zombie;
    public event System.Action<string> onLightOn;
    public event System.Action<string> demonText;
    public event System.Action<Vector3> moveToOuija;
    public event System.Action<bool> activeOuija;


    #region PunRPC

    [PunRPC]
    private void GetEvent(GEvent e)
    {
        Debug.Log("Send event " + e);
        switch (e)
        {
            case GEvent.LighOff:
                onLightOff();
                break;
            case GEvent.Bats:
                bats();
                break;
            case GEvent.Cthulhu:
                cthulhu();
                break;
            case GEvent.Fantasma:
                fantasma();
                break;
            case GEvent.Zombie:
                zombie();
                break;
            case GEvent.OuijaOn:
                if (!Ouija.activa) {activeOuija(true); }
                    
                break;
            case GEvent.OuijaOff:
                if (Ouija.activa){ activeOuija(false);}
                break;
            default:
                break;
        }

    }

    [PunRPC]
    private void MueveOuija(Vector3 posicion)
    {
        moveToOuija(posicion);
    }

    [PunRPC]
    private void EncenderLuz(string nombre)
    {
        Debug.Log("Encendiendo " + nombre);
        onLightOn(nombre);
    }

    [PunRPC]
    private void TextoDemoniaco(string txt)
    {
        Debug.Log("Enviando texto " + txt);
        demonText(txt);
    }

    [PunRPC]
    private void Grab(string name)
    {
        Debug.Log("Grab PunRPC", this);
        GameObject obj = GameObject.Find(name);
        obj.transform.parent = GameController.RightHand;
        obj.transform.localPosition = Vector3.zero;

    }

    [PunRPC]
    private void UnGrab(string name)
    {
        Debug.Log("UnGrab PunRPC", this);
        GameObject obj = GameObject.Find(name);
        obj.transform.parent = null;
    }

    #endregion 
    public void ApagarLuces()
    {
        SendRPC(GEvent.LighOff);
    }

    public void ActivarOuija() {
        SendRPC(GEvent.OuijaOn);
    }

    public void DesactivarOuija()
    {
        SendRPC(GEvent.OuijaOff);

    }

    public void InvocarMurcielagos()
    {
        SendRPC(GEvent.Bats);
    }

    public void InvocarCthulhu()
    {
        SendRPC(GEvent.Cthulhu);
    }

    public void InvocarFantasma()
    {
        SendRPC(GEvent.Fantasma);
    }

    public void InvocarZombie()
    {
        SendRPC(GEvent.Zombie);
    }

    // Estos eventos se llamarán desde el evento OnClick desde un boton y no aceptan un enum como argumento. 
    // Por eso creamos una función pública para cada boton mas arriba
    private void SendRPC(GEvent e)
    {
        Debug.Log("Enviando Evento "+e);
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("GetEvent", RpcTarget.All,e);
    }

    public void EncenderLuzRPC(string nombre)
    {
        Debug.Log("Enviando evento luces a todos los conectados");
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("EncenderLuz", RpcTarget.All, nombre);
    }


    public void EnviarTextoRPC(string txt)
    {
        Debug.Log("Enviando texto");
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("TextoDemoniaco", RpcTarget.All,txt);
    }

    public void GrabRPC(string name)
    {
        
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("Grab", RpcTarget.Others, name);
    }

    public void UnGrabRPC(string name)
    {

        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("UnGrab", RpcTarget.Others, name);
    }

    public void EnviarTextoDemoniaco()
    {
        if(inputTexto.text.Length > 0) { 
            EnviarTextoRPC(inputTexto.text);
        }
    }
    void Update()
    {
        if (Ouija.activa && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100,layerTablero))
            {
                Debug.Log("Destino en " + hit.transform.name);
                Vector3 destino = hit.point;
                PhotonView photonView = PhotonView.Get(this);
                photonView.RPC("MueveOuija", RpcTarget.All, destino);
            }
        }
    }

}
