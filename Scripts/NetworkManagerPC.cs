
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

namespace TVRWMN
{
	public class NetworkManagerPC : MonoBehaviourPunCallbacks
	{

		[SerializeField]
		private GameObject buttonConect;
		[SerializeField]
		private GameObject buttonCreateRoom;
		[SerializeField]
		private GameObject canvasNetwork;

		[SerializeField]
		private Text feedbackText;

		[SerializeField]
		private byte maxPlayersPerRoom = 2;

		[SerializeField]
		private GameObject loaderAnime;


		
		
		[Space(10)]
		[Header("Custom Variables")]
		public InputField roomNameField;



		[SerializeField]
		bool isConnecting;

		string gameVersion = "1";
		string nombreSala = "";

		private TypedLobby customLobby = new TypedLobby("TVRWMN", LobbyType.Default);


		void Awake()
		{
			PhotonNetwork.AutomaticallySyncScene = false;
		}

		private void Start()
		{
			PlayerPrefs.DeleteAll();

			
			feedbackText.text = "";

			loaderAnime.SetActive(false);
			buttonConect.SetActive(true);
			buttonCreateRoom.SetActive(false);

			//ConnectToPhoton();
		}

		public void ConnectToPhoton()
		{
			Debug.Log("Connecting to Photon Network");
			feedbackText.text = "Conectando...";
			buttonConect.SetActive(false);
			loaderAnime.SetActive(true);
			PhotonNetwork.GameVersion = gameVersion; //1
			PhotonNetwork.ConnectUsingSettings(); //2
		}


		/// <summary>
		/// Start the connection process. 
		/// - If already connected, we attempt joining a random room
		/// - if not yet connected, Connect this application instance to Photon Cloud Network
		/// </summary>
		public void CreateRoom()
		{
			
			// keep track of the will to join a room, because when we come back from the game we will get a callback that we are connected, so we need to know what to do then
			isConnecting = true;

			// hide the Play button for visual consistency
			buttonCreateRoom.SetActive(false);

			// start the loader animation for visual effect.
			if (loaderAnime != null)
			{
				loaderAnime.SetActive(true);
			}

			// we check if we are connected or not, we join if we are , else we initiate the connection to the server.
			if (PhotonNetwork.IsConnected)
			{
				LogFeedback("Creating Room...");
				
				PhotonNetwork.LocalPlayer.NickName = "PC"; 
				Debug.Log("PhotonNetwork.IsConnected! | Trying to Create/Join Room " + "666");
				RoomOptions roomOptions = new RoomOptions();
				roomOptions.MaxPlayers = 2;
				nombreSala = roomNameField.text;
				TypedLobby typedLobby = new TypedLobby("TVRWMN", LobbyType.Default); //3
				PhotonNetwork.JoinOrCreateRoom("666", roomOptions, typedLobby); //4

			}
			else
			{
				
				ConnectToPhoton();
			}
		}

		/// <summary>
		/// Logs the feedback in the UI view for the player, as opposed to inside the Unity Editor for the developer.
		/// </summary>
		/// <param name="message">Message.</param>
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


		// below, we implement some callbacks of PUN
		// you can find PUN's callbacks in the class MonoBehaviourPunCallbacks


				/// <summary>
		/// Called after disconnecting from the Photon server.
		/// </summary>
		public override void OnDisconnected(DisconnectCause cause)
		{
			LogFeedback("<Color=Red>Se ha desconectado</Color> " + cause);
			Debug.LogError("PUN Basics Tutorial/Launcher:Disconnected");

			// #Critical: we failed to connect or got disconnected. There is not much we can do. Typically, a UI system should be in place to let the user attemp to connect again.
			loaderAnime.SetActive(false);
			buttonCreateRoom.SetActive(false);

			isConnecting = false;
			buttonConect.SetActive(true);

		}

		public override void OnConnected()
		{
			// 1
			base.OnConnected();
			// 2
			feedbackText.text = "Contacto establecido...";

			buttonConect.SetActive(false);
			buttonCreateRoom.SetActive(true);
			loaderAnime.SetActive(false);
		}

		/// <summary>
		/// Called when entering a room (by creating or joining it). Called on all clients (including the Master Client).
		/// </summary>
		/// <remarks>
		/// This method is commonly used to instantiate player characters.
		/// If a match has to be started "actively", you can call an [PunRPC](@ref PhotonView.RPC) triggered by a user's button-press or a timer.
		///
		/// When this is called, you can usually already access the existing players in the room via PhotonNetwork.PlayerList.
		/// Also, all custom properties should be already available as Room.customProperties. Check Room..PlayerCount to find out if
		/// enough players are in the room to start playing.
		/// </remarks>
		public override void OnJoinedRoom()
		{
			LogFeedback("<Color=Green>Sala " + nombreSala + " creada con éxito.</Color> "); // + PhotonNetwork.CurrentRoom.Name);
			Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.\nFrom here on, your game would be running.");

			// #Critical: We only load if we are the first player, else we rely on  PhotonNetwork.AutomaticallySyncScene to sync our instance scene.
			if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
			{
				Debug.Log("Sala Creada ");
				
				LogFeedback("Esperando al investigador...");

			}
			
			
		}

		public override void OnPlayerEnteredRoom(Player newPlayer)
		{

			LogFeedback("Ya estamos todos!!");
			canvasNetwork.SetActive(false);
			SceneManager.LoadScene("PC", LoadSceneMode.Additive);
			//PhotonNetwork.InstantiateSceneObject("Cabeza", new Vector3(0, 0, 0), Quaternion.identity, 0);

		}
	}
}
