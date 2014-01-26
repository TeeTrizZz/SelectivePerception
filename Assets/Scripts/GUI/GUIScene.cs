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

	private int min = 0;
	private int sec = 0;
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
        style.normal.textColor = Color.white;
        style.fontSize = 40;
        style.alignment = TextAnchor.MiddleCenter; //aligns the text to middle
    }

    // Update is called once per frame
    void Update()
    {

		GameData.time = (int) Mathf.Round((Time.time - overallStartTime));
		sec = (GameData.time) - (min * 60);

		if (sec == 60) {
			min++;
			sec = 0;
		}
    }

    void OnGUI()
    {


		GUI.Label (new Rect (Screen.width / 2, 5, 100, 60), min.ToString () + " min " + sec.ToString() + " sec", style);

        if (GUI.Button(new Rect(5, 5, 105, 105), skill) || Input.GetKey("f"))
        {
            if (!toggleState)
            {
                toggleState = true;
                doAbility = true;
                startTime = Time.time; //save start time after clicking the button
            }
        }
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
