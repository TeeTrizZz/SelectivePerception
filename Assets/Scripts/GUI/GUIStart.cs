using UnityEngine;
using System.Collections;
using System.IO;

public class GUIStart : MonoBehaviour
{

    //scene to load
    private string levelName = "scene";
    //start scene texture
    public Texture startScreen;
    //intro music
    //public AudioClip intro;
    //GUI Style
    public GUIStyle style;

    public Texture2D txrBackground;

    public Texture2D ggjLogo;
    public Texture2D hfuLogo;
	public Texture nightSparkTex;
	public Texture trapSparkTex;
	public Texture jumpSparkTex;
	public Texture uvSparkTex;
	public Texture wallSparkTex;

    //the ratio
    public float aspectX;
    public float aspectY;
    //sets a value how much screen should be covered (in percent, e.g.: 90% is 0.9)
    public float coverX;
    public float coverY;
	private int counterStopTime = 0;
	private int tempSec;
	private string tempMin;

	public Vector2 scrollPosition = Vector2.zero;

    //button amount
    int buttonAmount = 5;
    //level amount
    int levelAmount = 2;
    //level folder amount
    int countFolders = 0;

    //for the resolution
    public int toolbarInt = 0;
    public string[] toolbarStrings = new string[] { "800x600", "1920x1080" };

    //script for network
    NetworkSkript netSkript;

    // Use this for initialization
    void Start()
    {
        netSkript = this.GetComponent<NetworkSkript>();
        style.normal.textColor = Color.white;

        style.fontSize = 20;
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnGUI()
    {
        var menuType = GameData.menuType;

        if (menuType == 6)
            return;

        //average values
        aspectX = Mathf.Max(1f, aspectX);
        aspectY = Mathf.Max(1f, aspectY);
        coverX = Mathf.Max(0.1f, coverX);
        coverY = Mathf.Max(0.1f, coverY);

        float pxDesiredX = coverX * Screen.width;
        float pxDesiredY = coverY * Screen.height;

        float aspectDesired = 1.0f * aspectX / aspectY;

        if (pxDesiredX / pxDesiredY < aspectDesired)
        {
            pxDesiredY = pxDesiredX / aspectDesired;
        }
        else
        {
            pxDesiredX = pxDesiredY * aspectDesired;
        }

        var pxBorderX = Screen.width - pxDesiredX;
        var pxBorderY = Screen.height - pxDesiredY;

        Rect rectResult = new Rect(pxBorderX / 2, pxBorderY / 2, pxDesiredX, pxDesiredY);


        GUI.BeginGroup(rectResult); //begin group whole menue
        GUI.DrawTexture(new Rect(0, 0, rectResult.width, rectResult.height), txrBackground, ScaleMode.StretchToFill);
        GUI.BeginGroup(new Rect((pxDesiredX / 2) - ((pxDesiredX * 0.76f) / 2), (pxDesiredY / 2) - ((pxDesiredY * 0.76f) / 2), pxDesiredX * 0.76f, pxDesiredY * 0.76f)); //begin group inner menue

        switch (menuType)
        {
            case 0: //show main menue
                if (GUI.Button(new Rect(0, 0, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / buttonAmount), "Start Server"))
                {
                    if (!Network.isClient && !Network.isServer)
                    {
                        netSkript.StartServer(); //starts server
                        menuType = 1; //show level selection
                    }

                }
                if (GUI.Button(new Rect(0, (pxDesiredY * 0.76f) / buttonAmount, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / buttonAmount), "Find Host"))
                {
                    if (!Network.isClient && !Network.isServer)
                    {
                        netSkript.RefreshHostList();
                        menuType = 2; //show host selection
                    }
                }
                if (GUI.Button(new Rect(0, ((buttonAmount - 3) * pxDesiredY * 0.76f) / buttonAmount, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / buttonAmount), "Options"))
                {
                    menuType = 3; // show Options
                }
                if (GUI.Button(new Rect(0, ((buttonAmount - 2) * pxDesiredY * 0.76f) / buttonAmount, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / buttonAmount), "Credits"))
                {
                    menuType = 4; //show credits
                }
                if (GUI.Button(new Rect(0, ((buttonAmount - 1) * pxDesiredY * 0.76f) / buttonAmount, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / buttonAmount), "Exit"))
                {
                    Application.Quit();
                    //is ignored in editor and webplayer
                }
                break;

            case 1: //show level selection
                for (int i = 0; i < levelAmount; i++)
                {
                    if (GUI.Button(new Rect(0, ((pxDesiredY * 0.76f) / (levelAmount + 1)) * i, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / (levelAmount + 1)), "Level " + (i + 1)))
                    {
                        netSkript.setLevel(i.ToString());
                        menuType = 5; //show character selection
                    }
                }
                if (GUI.Button(new Rect(0, ((levelAmount) * pxDesiredY * 0.76f) / (levelAmount + 1), pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / 5), "Back"))
                {
                    netSkript.OnDestroy();
                    menuType = 0;
                }
                break;

            case 2: // show host selection
                if (netSkript.hostList != null)
                {
				scrollPosition = GUI.BeginScrollView(new Rect (0,0,pxDesiredX * 0.76f, (pxDesiredY * 0.76f) - (pxDesiredY * 0.76f) / 5 ), scrollPosition, new Rect (0,0, pxDesiredX * 0.76f, 100 * netSkript.hostList.Length));
					

				for (int i = 0; i < netSkript.hostList.Length; i++)

                    {
					if (GUI.Button(new Rect((pxDesiredY * 0.76f) / 2, 100 + (110 * i), 300, 100), netSkript.hostList[i].gameName))
                        {
                            netSkript.JoinServer(netSkript.hostList[i]);
                        }
                    }
				GUI.EndScrollView();
                }

				
				
                if (GUI.Button(new Rect(0, (4 * pxDesiredY * 0.76f) / 5, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / 5), "Back"))
                {
                    menuType = 0;
                }
                break;

            case 3: // show Options
                GUI.Label(new Rect(20, 20, pxDesiredX * 0.76f, 40), "Set your Screen Resolution:", style);

                GUI.BeginGroup(new Rect(0, 60, pxDesiredX * 0.76f, 100));
                if (GUI.Button(new Rect(0, 0, (pxDesiredX * 0.76f) / 2, 50), "800x600"))
                {
                    Screen.SetResolution(800, 600, true);
                }
                if (GUI.Button(new Rect((pxDesiredX * 0.76f) / 2, 0, (pxDesiredX * 0.76f) / 2, 50), "1920x1080"))
                {
                    Screen.SetResolution(1920, 1080, true);
                }
                GUI.EndGroup();

                if (GUI.Button(new Rect(0, (4 * pxDesiredY * 0.76f) / 5, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / 5), "Back"))
                {
                    menuType = 0;
                }
                break;

            case 4: //show credits
                GUI.Label(new Rect(20, 20, pxDesiredX * 0.76f, 3 * (pxDesiredY * 0.76f) / 5), "Developed for Global Game Jam 2014 \n\nat Games Lab Hochschule Furtwangen University\n\nTopic:\n\nWe don't see things as they are. We see them as we are.\n\nTeam:\nSascha Englert, Fabian Gaertner, Sarah Haefele, Matthias Kaufmann, \nStefanie Mueller, Benjamin Ruoff\nSpecial Thanks to Anke Meiering and Jan Ewald!", style);
                GUI.DrawTexture(new Rect(20, 300, 100, 100), ggjLogo, ScaleMode.StretchToFill);
                GUI.DrawTexture(new Rect(150, 300, 247, 100), hfuLogo, ScaleMode.StretchToFill);
                if (GUI.Button(new Rect(0, (4 * pxDesiredY * 0.76f) / 5, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / 5), "Back"))
                {
                    menuType = 0;
                }
                break;

            case 5: //show character selection
				GUI.DrawTexture(new Rect(0, 0, (pxDesiredY * 0.76f) / 6, (pxDesiredY * 0.76f) / 6 ), nightSparkTex);
				GUI.DrawTexture(new Rect(0, (pxDesiredY * 0.76f) / 6, (pxDesiredY * 0.76f) / 6, (pxDesiredY * 0.76f) / 6), trapSparkTex);
				GUI.DrawTexture(new Rect(0, ((6 - 4) * pxDesiredY * 0.76f) / 6, (pxDesiredY * 0.76f) / 6, (pxDesiredY * 0.76f) / 6), wallSparkTex);
				GUI.DrawTexture(new Rect(0, ((6 - 3) * pxDesiredY * 0.76f) / 6, (pxDesiredY * 0.76f) / 6, (pxDesiredY * 0.76f) / 6), jumpSparkTex);
				GUI.DrawTexture(new Rect(0, ((6 - 2) * pxDesiredY * 0.76f) / 6, (pxDesiredY * 0.76f) / 6, (pxDesiredY * 0.76f) / 6), uvSparkTex);

				GUI.DrawTexture(new Rect(pxDesiredX * 0.76f, 0, -(pxDesiredY * 0.76f) / 6, (pxDesiredY * 0.76f) / 6 ), nightSparkTex);
				GUI.DrawTexture(new Rect(pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / 6, -(pxDesiredY * 0.76f) / 6, (pxDesiredY * 0.76f) / 6), trapSparkTex);
				GUI.DrawTexture(new Rect(pxDesiredX * 0.76f, ((6 - 4) * pxDesiredY * 0.76f) / 6, -(pxDesiredY * 0.76f) / 6, (pxDesiredY * 0.76f) / 6), wallSparkTex);
				GUI.DrawTexture(new Rect(pxDesiredX * 0.76f, ((6 - 3) * pxDesiredY * 0.76f) / 6, -(pxDesiredY * 0.76f) / 6, (pxDesiredY * 0.76f) / 6), jumpSparkTex);
				GUI.DrawTexture(new Rect(pxDesiredX * 0.76f, ((6 - 2) * pxDesiredY * 0.76f) / 6, -(pxDesiredY * 0.76f) / 6, (pxDesiredY * 0.76f) / 6), uvSparkTex);

				 if (GUI.Button(new Rect(0, 0, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / 6), "Nightspark"))
                {
                    netSkript.setPlayer("nightspark");
                    menuType = 6;
                }
                if (GUI.Button(new Rect(0, (pxDesiredY * 0.76f) / 6, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / 6), "Trapspark"))
                {
                    netSkript.setPlayer("trapspark");
                    menuType = 6;
                }
                if (GUI.Button(new Rect(0, ((6 - 4) * pxDesiredY * 0.76f) / 6, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / 6), "Wallhackspark"))
                {
                    netSkript.setPlayer("wallhackspark");
                    menuType = 6;
                }
                if (GUI.Button(new Rect(0, ((6 - 3) * pxDesiredY * 0.76f) / 6, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / 6), "Jumpingspark"))
                {
                    netSkript.setPlayer("jumpingspark");
                    menuType = 6;
                }
                if (GUI.Button(new Rect(0, ((6 - 2) * pxDesiredY * 0.76f) / 6, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / 6), "UVSpark"))
                {
                    netSkript.setPlayer("uvspark");
                    menuType = 6;
                }
                if (GUI.Button(new Rect(0, ((6 - 1) * pxDesiredY * 0.76f) / 6, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / 6), "Back"))
                {
                    menuType = 0;
                }
                break;

		case 7: //end screen
			if(counterStopTime == 0)
			{
				tempSec = GameData.time % 60;
				tempMin = (GameData.time/60).ToString();
				counterStopTime++;
			}

			string endMessage = "Congratulations, you've reached the end!\n\nTime elapsed: " + tempMin + " min " + tempSec + "sec";
			GUI.Label (new Rect(5, 5, 400, (pxDesiredY * 0.76f) / 6), endMessage, style);
			break;

        } //end switch




        GUI.EndGroup(); //end inner menue group


        GUI.EndGroup(); //end group whole menue

        GameData.menuType = menuType;
    }

} //end class
