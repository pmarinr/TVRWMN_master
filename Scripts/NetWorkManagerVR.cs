using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

namespace TVRWMN
{
	public class NetWorkManagerVR : MonoBehaviourPunCallbacks
	{


		[SerializeField]
		private Text feedbackText;

		[SerializeField]
		private byte maxPlayersPerRoom = 4;

		[SerializeField]
		private GameObject loaderAnime;

		[SerializeField]
		private GameObject escenarioMultiplayer;

		[SerializeField]
		private GameObject salas;

		[SerializeField]
		private GameObject head;

		[SerializeField]
		private GameObject handR;

		[SerializeField]
		private GameObject handL;

		[SerializeField]
		bool isConnecting;

		string gameVersion = "1";

		private TypedLobby customLobby = new TypedLobby("TVRWMN", LobbyType.Default);

		private Dictionary<string, RoomInfo> cachedRoomList = new Dictionary<string, RoomInfo>();
		void Awake()
		{
			PhotonNetwork.AutomaticallySyncScene = false;
		}

		private void Start()
		{
			PlayerPrefs.DeleteAll();
			feedbackText.text = "";
			loaderAnime.SetActive(false);
			salas.SetActive(false);
			ConnectToPhoton();
		}

		public void ConnectToPhoton()
		{
			Debug.Log("Connecting to Photon Network");
			LogFeedback("Conectando...");

			loaderAnime.SetActive(true);
			PhotonNetwork.GameVersion = gameVersion; //1
			PhotonNetwork.ConnectUsingSettings(); //2
		}

		void LogFeedback(string message)
		{
			// we do not assume there is a feedbackText defined.
			if (feedbackText == null)
			{
				return;
			}

			// add new messages as a new line and at the bottom of the log.
			feedbackText.text += System.Environment.NewLine + message;
		}
		public override void OnConnectedToMaster()
		{
			// we don't want to do anything if we are not attempting to join a room. 
			// this case where isConnecting is false is typically when you lost or quit the game, when this level is loaded, OnConnectedToMaster will be called, in that case

			LogFeedback("Conectado al mas alla");
			loaderAnime.SetActive(false);
			salas.SetActive(true);
			Debug.Log("Conectado al servidor... Intentamos conectar con una sala");
			PhotonNetwork.JoinLobby();
			
		}

		public void OnJoinedLobbyCallBack()
		{
			LogFeedback("Elija un crimen para investigar...");
			Debug.Log("Entrando en el lobby");
		}

		public override void OnDisconnected(DisconnectCause cause)
		{
			LogFeedback("<Color=Red>Desconectado</Color> " + cause);
			Debug.LogError("PUN Basics Tutorial/Launcher:Disconnected");

			// #Critical: we failed to connect or got disconnected. There is not much we can do. Typically, a UI system should be in place to let the user attemp to connect again.
			loaderAnime.SetActive(false);
			isConnecting = false;
		}

		public override void OnConnected()
		{
			// 1
			base.OnConnected();
			// 2
			LogFeedback("Contacto establecido...");
			loaderAnime.SetActive(false);

		}

		public override void OnJoinedRoom()
		{
			LogFeedback("<Color=Green>Sala encontrada:</Color> with " + PhotonNetwork.CurrentRoom.Name);
			LogFeedback("Partida encontrada");
			escenarioMultiplayer.SetActive(false);
			SceneManager.LoadScene("Escenario1", LoadSceneMode.Additive);
			GameObject cabezaOnline = PhotonNetwork.Instantiate("Cabeza", head.transform.position, head.transform.rotation, 0);
			cabezaOnline.transform.parent = head.transform;
			
			GameObject ManoDOnline = PhotonNetwork.Instantiate("Linterna", handR.transform.position, handR.transform.rotation, 0);
			ManoDOnline.transform.parent = handR.transform;
			
			GameObject ManoIOnline = PhotonNetwork.Instantiate("Mano", handL.transform.position, handL.transform.rotation, 0);
			ManoIOnline.transform.parent = handL.transform;
			
		}

		public override void OnJoinRandomFailed(short returnCode, string message)
		{
			LogFeedback("<Color=Red>No se encuenta ninguna sala</Color>");
			Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

		
		}




	

		public void JoinRoom()
		{

			// keep track of the will to join a room, because when we come back from the game we will get a callback that we are connected, so we need to know what to do then
			isConnecting = true;

			// hide the Play button for visual consistency


			// start the loader animation for visual effect.
			if (loaderAnime != null)
			{
				loaderAnime.SetActive(true);
			}

			// we check if we are connected or not, we join if we are , else we initiate the connection to the server.
			if (PhotonNetwork.IsConnected)
			{
				LogFeedback("Creating Room...");

				PhotonNetwork.LocalPlayer.NickName = "Quest";
				Debug.Log("PhotonNetwork.IsConnected! | Trying to Create/Join Room " + "666");
				RoomOptions roomOptions = new RoomOptions();
				roomOptions.MaxPlayers = 2;

				TypedLobby typedLobby = new TypedLobby("TVRWMN", LobbyType.Default); //3
				//PhotonNetwork.JoinOrCreateRoom("666", roomOptions, typedLobby); //4
				PhotonNetwork.JoinRoom("666");

				
			}
			else
			{

				ConnectToPhoton();
			}
		}

		
	}
}

