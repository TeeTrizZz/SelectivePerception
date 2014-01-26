using UnityEngine;
using System.Collections;

public class NetworkSkript : MonoBehaviour {

    private const string typeName = "UniqueGameName";
    private const string gameName = "RoomName";

    public HostData[] hostList;

    public GameObject MainCam;

	public bool startGame = false;
	int playerCount = 1;
	string chosenLevel;


    void Awake()
    {
        DontDestroyOnLoad(this);
    }


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
	}

    void OnGUI()
    {
        /*if (!Network.isClient && !Network.isServer)
        {
            if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
                StartServer();

            if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts"))
                RefreshHostList(); 

            if (hostList != null)
            {
                for (int i = 0; i < hostList.Length; i++)
                {
                    if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName))
                        JoinServer(hostList[i]);
                }
            }
        }*/
    }

    public void StartServer()
    {
        Debug.Log("Start Server");
        Network.InitializeServer(4, 25000, !Network.HavePublicAddress());
        MasterServer.RegisterHost(typeName, gameName);
    }

	void OnServerInitialized()
    {
        Debug.Log("Server Initializied");
        //SpawnPlayer();
    }

	void OnPlayerConnected (NetworkPlayer player) {
		playerCount++;
    }

    public void RefreshHostList()
    {
        MasterServer.RequestHostList(typeName);
    }

    void OnMasterServerEvent(MasterServerEvent msEvent)
    {
        if (msEvent == MasterServerEvent.HostListReceived)
            hostList = MasterServer.PollHostList();
    }

    public void JoinServer(HostData hostData)
    {
        Network.Connect(hostData);
    }
	
    public void OnDestroy()
    {
        Network.Disconnect();
        MasterServer.UnregisterHost();
    }

	public void setPlayer(string temp) {
		GameData.playerChar = temp;
		Application.LoadLevel ("MainScene");
	}

	public void setLevel(string temp) {
		GameData.levelID = temp;
	}
}
