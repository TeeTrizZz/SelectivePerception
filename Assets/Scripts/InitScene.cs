using UnityEngine;
using System.Collections;

public class InitScene : MonoBehaviour {

    public GameObject TrapSpark;
    public GameObject JumpingSpark;
    public GameObject NightSpark;
    public GameObject UVSpark;
    public GameObject WallhackSpark;
    public GameObject Cam;

    // Use this for initialization
    public void InitGame()
    {
        var player = NightSpark; 

        switch (GameData.playerChar)
        {
            case "nightspark":
                player = NightSpark;
                break;

            case "trapspark":
                player = TrapSpark;
                break;

            case "jumpingspark":
                player = JumpingSpark;
                break;

            case "uvspark":
                player = UVSpark;
                break;

            case "wallhackspark":
                player = WallhackSpark;
                break;
        }

        GameData.levelID = "0";

        Network.isMessageQueueRunning = true;
        Network.SetSendingEnabled(0, true);

        var go = (GameObject)Network.Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity, 0);
        var cam = (GameObject)Instantiate(Cam, new Vector3(0, 0, 0), Quaternion.identity);

        cam.GetComponent<LevelGen>().SetChar(go);
        cam.GetComponent<LevelGen>().Init();
        cam.GetComponent<FollowPlayer>().SetTarget(go);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
