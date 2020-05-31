using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

namespace TVRWMN
{
    public class RoomList : MonoBehaviourPunCallbacks
    {
        public static Dictionary<string, RoomInfo> roomsCache = new Dictionary<string, RoomInfo>();
        Dictionary<string, GameObject> rooms3D = new Dictionary<string, GameObject>();
        

        public GameObject room3D;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            Debug.Log("Actualizando listado");

            if (roomList.Count == 0 && !PhotonNetwork.InLobby)
            {
                // Mensaje de esperando salas
            }

            foreach (RoomInfo entry in roomList)
            {
                if (roomsCache.ContainsKey(entry.Name))
                {
                    if (entry.RemovedFromList)
                    {
                        // we delete the cell
                        Debug.Log("Borrando " + entry.Name);
                        roomsCache.Remove(entry.Name);
                        Destroy(rooms3D[entry.Name]);
                        rooms3D.Remove(entry.Name);
                    }
                }
                else
                {
                    if (!entry.RemovedFromList)
                    {
                        // we create the cell
                        Debug.Log("Agregando "+ entry.Name);
                        roomsCache[entry.Name] = entry;
                        rooms3D[entry.Name] = Instantiate(room3D);
                        rooms3D[entry.Name].transform.parent = this.transform;

                    }
                }
            }
            UpdateRooms3D();
        }
        
        public void UpdateRooms3D()
        {
            float posx = 0;
            float inc = 0.2f;
            foreach(KeyValuePair<string, GameObject> room3d in rooms3D)
            {
                room3d.Value.transform.position= new Vector3(posx, 0, 0);
                posx += inc;
                
            }
        }
    }
  }
