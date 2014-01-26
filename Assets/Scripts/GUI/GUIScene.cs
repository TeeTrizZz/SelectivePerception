using UnityEngine;
using System.Collections;

public class GUIScene : MonoBehaviour
{

    //toggle state of the skill button
    public static bool toggleState = false;

    public static bool doAbility = false;

    float startTime;
    int dif;

    public Texture skill;

	public Texture nightSkill;
	public Texture trapSkill;
	public Texture jumpSkill;
	public Texture uvSkill;
	public Texture wallSkill;


    private int coolDown = 30;

    public GUIStyle style;
	public GUIStyle hostStyle;
	public GUIStyle skillStyle;

	private int min = 0;
	private int sec = 0;
    private int oldSec = -1;
	private int overallStartTime;

    // Use this for initialization
    void Start()
    {
		startTime = Time.time;
		string characterType = GameData.playerChar;
		switch (characterType) {
			case ("nightspark"):
				skill = nightSkill;
				break;
			case ("trapspark"):
				skill = trapSkill;
				break;
			case ("jumpingspark"):
				skill = jumpSkill;
				break;
			case ("uvspark"):
				skill = uvSkill;
				break;
			case ("wallhackspark"):
				skill = wallSkill;
				break;
				}
		hostStyle.normal.textColor = Color.white;
		hostStyle.fontSize = 20;
		skillStyle.normal.textColor = Color.black;
		skillStyle.fontSize = 17;
		style.normal.textColor = Color.white;
        style.fontSize = 30;
        style.alignment = TextAnchor.MiddleCenter; //aligns the text to middle
    }

    // Update is called once per frame
    void Update()
    {
        if (Network.isServer)
        {
            GameData.time = (int)Mathf.Round((Time.time - overallStartTime));
            sec = (GameData.time) - (min * 60);

            if (sec == 60)
            {
                min++;
                sec = 0;
            }

            if (sec != oldSec)
            {
                networkView.RPC("SyncTime", RPCMode.Others, GameData.time);
                oldSec = sec;
            }
        }
        else
        {
            sec = (GameData.time) - (min * 60);

            if (sec == 60)
            {
                min++;
                sec = 0;
            }
        }
    }

    [RPC]
    void SyncTime(int time)
    {
        GameData.time = time;
    }

    void OnGUI()
    {

		//show time
		GUI.Label (new Rect (Screen.width / 2, 5, 100, 60), min.ToString () + " min " + sec.ToString() + " sec", style);

		//show which room
		GUI.Label (new Rect (5, Screen.height - 30, 50, 29), "Hostname: " + GameData.serverID, hostStyle);
        
		if (GUI.Button(new Rect(5, 5, 105, 105), skill) || Input.GetKey("f"))
        {
            if (!toggleState)
            {
                toggleState = true;
                doAbility = true;
                startTime = Time.time; //save start time after clicking the button
            }
        }
		GUI.Label (new Rect (86, 80, 40, 40), "F", skillStyle);

        //show cooldown time
        if (toggleState)
        {

            dif = Mathf.RoundToInt(coolDown - (Time.time - startTime));
            GUI.Label(new Rect(5, 5, 105, 105), dif.ToString(), style);
            if (dif <= coolDown - 1)
            {
                doAbility = false;
            }
            if (dif < 0)
            {
                toggleState = false;
            }


        }
    }
}
