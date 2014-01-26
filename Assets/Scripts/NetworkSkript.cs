using UnityEngine;
using System.Collections;

public class NetworkSkript : MonoBehaviour {

    private const string typeName = "UniqueGameName";
    private const string gameName = "RoomName";

    public HostData[] hostList;

    public GameObject TrapSpark;
	public GameObject JumpingSpark;
	public GameObject NightSpark;
	public GameObject UVSpark;
	public GameObject WallhackSpark;
	private GameObject player;

    public GameObject Cam;



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
        if (!Network.isClient && !Network.isServer)
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
        }
    }

    public void StartServer()
    {
        Network.InitializeServer(4, 25000, !Network.HavePublicAddress());
        MasterServer.RegisterHost(typeName, gameName);
    }

    void OnServerInitialized()
    {
        Debug.Log("Server Initializied");
        SpawnPlayer();
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

    void OnConnectedToServer()
    {
        SpawnPlayer();
        Debug.Log("Server Joined");
    }

    private void SpawnPlayer()
    {
        Debug.Log(gameObject);

        var go = (GameObject) Network.Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity, 0);
        var cam = (GameObject) Instantiate(Cam, new Vector3(0, 0, 0), Quaternion.identity);

        cam.GetComponent<LevelGen>().SetChar(go);
        cam.GetComponent<LevelGen>().Init();
        cam.GetComponent<FollowPlayer>().SetTarget(go);
    }

    public void OnDestroy()
    {
        Network.Disconnect();
        MasterServer.UnregisterHost();
    }

	public void setPlayer(string temp) {
		switch (temp) {
				case "nightspark":
						player = NightSpark;
						break;
				case "trapspark":
						player = TrapSpark;
						break;

				case "jumpingspark":
						player = JumpingSpark;
						break;
				case "nightspark":
						player = NightSpark;
						break;
				case "uvspark":
						player = UVSpark;
						break;
				case "wallhackspark":
						player = WallhackSpark;
						break;
	
				}
	}

	public void setLevel(string temp) {
	}
}
