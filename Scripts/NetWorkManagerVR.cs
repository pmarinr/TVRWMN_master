using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class NetWorkManagerVR : MonoBehaviourPunCallbacks
{
	

	[SerializeField]
	private Text feedbackText;

	[SerializeField]
	private byte maxPlayersPerRoom = 4;

	[SerializeField]
	private GameObject loaderAnime;

	[SerializeField]
	bool isConnecting;

	string gameVersion = "1";

	private TypedLobby customLobby = new TypedLobby("TVRWMN", LobbyType.Default);

	private Dictionary<string, RoomInfo> cachedRoomList = new Dictionary<string, RoomInfo>();
	void Awake()
	{
		PhotonNetwork.AutomaticallySyncScene = true;
	}

	private void Start()
	{
		PlayerPrefs.DeleteAll();


		feedbackText.text = "";

		loaderAnime.SetActive(false);
		

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
		
			LogFeedback("Conectado al mas alla, buscando un crimen...");
			Debug.Log("Conectado al servidor... Intentamos conectar con una sala");

		// #Critical: The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnJoinRandomFailed()
		//PhotonNetwork.LocalPlayer.NickName = "VR"; //1

		//RoomOptions roomOptions = new RoomOptions();
		//roomOptions.MaxPlayers = 2;

		//PhotonNetwork.JoinRoom("666", roomOptions,  customLobby); //4
		//PhotonNetwork.JoinRandomRoom();
		//PhotonNetwork.JoinRoom("666");
		//LogFeedback("<Color=Red"+ game.Name + "</Color> " + game.PlayerCount);
		//JoinLobby();
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
		LogFeedback("<Color=Green>Sala encontrada:</Color> with " + PhotonNetwork.CurrentRoom.Name );
		LogFeedback("Partida encontrada");
		//PhotonNetwork.LoadLevel(1);

		
	}

	public override void OnJoinRandomFailed(short returnCode, string message)
	{
		LogFeedback("<Color=Red>No se encuenta ninguna sala</Color>");
		Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

		// #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
		//PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = this.maxPlayersPerRoom });
	}

	

	public void JoinLobby()
	{
		PhotonNetwork.JoinLobby(customLobby);
	}

	private void UpdateCachedRoomList(List<RoomInfo> roomList)
	{
		
		for (int i = 0; i < roomList.Count; i++)
		{
			RoomInfo info = roomList[i];
			if (info.RemovedFromList)
			{
				cachedRoomList.Remove(info.Name);
			}
			else
			{
				cachedRoomList[info.Name] = info;
			}
		}

		foreach (RoomInfo room in roomList)
		{
			LogFeedback("Partida:" + room.Name);
		}
	}

	public override void OnRoomListUpdate(List<RoomInfo> roomList)
	{
		Debug.LogWarning("Actualizando partidas:"+ roomList.Count);
		LogFeedback("Listando Partidas...");
		UpdateCachedRoomList(roomList);
		
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
			PhotonNetwork.JoinOrCreateRoom("666", roomOptions, typedLobby); //4
			
			//PhotonNetwork.CreateRoom(roomNameField.text, roomOptions, customLobby); 
			//PhotonNetwork.CreateRoom(roomNameField.text, roomOptions);
		}
		else
		{

			ConnectToPhoton();
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			JoinRoom();
		}
	}
}

