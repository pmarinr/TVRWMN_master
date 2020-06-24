using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class MultiplayerFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Mouse down");
            ApagaLuz(2);
        }
    }

    [PunRPC]
    public void Apaga(int luz)
    {
        Debug.Log("Funcion APAGA: " + luz);

    }

    public void ApagaLuz(int luz)
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("Apaga", RpcTarget.All, luz);
    }


}
