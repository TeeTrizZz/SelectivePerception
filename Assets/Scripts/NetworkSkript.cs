using UnityEngine;
using System.Collections;

public class NetworkSkript : MonoBehaviour {

    private const string typeName = "VisualMaze";
    private const string gameName = "Room";

    public HostData[] hostList;

    public GameObject MainCam;

	public bool startGame = false;
	int playerCount = 1;
	string chosenLevel;


    void Awake()
    {
 
    }


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
	}

    public void StartServer()
    {
        Debug.Log("Start Server");
        Network.InitializeServer(4, 25000, !Network.HavePublicAddress());

        int id = Random.Range(0, 1000);
        GameData.serverID = gameName + id;

        MasterServer.RegisterHost(typeName, GameData.serverID);
    }

	void OnServerInitialized()
    {
        //Debug.Log("Server Initializied");
        //SpawnPlayer();
    }

	void OnPlayerConnected (NetworkPlayer player) {
		playerCount++;
        networkView.RPC("ReceiveInfoFromServer", player, GameData.levelID);
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

    void OnConnectedToServer()
    {
        GameData.menuType = 5;
    }

    public void JoinServer(HostData hostData)
    {
        GameData.serverID = hostData.gameName;
        Network.Connect(hostData);
    }
	
    public void OnDestroy()
    {
        Network.Disconnect();
        MasterServer.UnregisterHost();
    }

	public void setPlayer(string temp) {
		GameData.playerChar = temp;
        Destroy(MainCam);
        this.GetComponent<InitScene>().InitGame();
	}

	public void setLevel(string temp) {
		GameData.levelID = temp;
	}
    
    [RPC]
    void ReceiveInfoFromServer(string someInfo)
    {
        GameData.levelID = someInfo;
    }
}
