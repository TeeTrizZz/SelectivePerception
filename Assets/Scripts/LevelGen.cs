using UnityEngine;
using System.Collections;

public class LevelGen : MonoBehaviour {

    public GameObject _wall;
    public GameObject _ground;
    public GameObject _light;
	public GameObject Char;

	void Start () {

	}

	void Update () {
	
	}

    public void SetChar(GameObject _char)
    {
        Char = _char;
    }

    public void Init()
    {
        var filename1 = "External/Level/Level.txt";
        var filename2 = "External/Level/Light.txt";

        var prefix = "";

        if (!Application.isWebPlayer)
            prefix = "file://";

        var pathname1 = prefix + Application.dataPath + "/../" + filename1;
        var pathname2 = prefix + Application.dataPath + "/../" + filename2;

        LoadLevel(pathname1);
        LoadLight(pathname2);
    }

    void LoadLevel(string pathname)
    {
        var www = new WWW(pathname);

        while (!www.isDone) { };

        var iniData = www.text;

        var posX = 0;
        var posZ = 0;

        var startX = 0;
        var startZ = 0;

        // level
        var aStrings = iniData.Split('\n');
        foreach (var line in aStrings)
        {
            foreach (var part in line)
            {
                var tmpObj = _ground;
                var posY = 0;

                switch (part)
                {
                    case '0':
                        tmpObj = _ground;
                        break;
                    case '1':
                        posY = 5;
                        tmpObj = _wall;
                        break;
                    case '2':
                        posY = 5;
                        tmpObj = _ground;

                        startX = posX;
                        startZ = posZ;

                        break;
                }

                Instantiate(tmpObj, new Vector3(posX, posY, posZ), Quaternion.identity);

                posZ += 10;
            }

            posZ = 0;
            posX += 10;
        }

		Char.transform.position = new Vector3(startX, 4, startZ);
    }

    void LoadLight(string pathname)
    {
        var www = new WWW(pathname);

        while (!www.isDone) { };

        var iniData = www.text;

        var posX = 0;
        var posZ = 0;

        // light
        var aStrings = iniData.Split('\n');
        foreach (var line in aStrings)
        {
            foreach (var part in line)
            {
                if (part == '1')
                    Instantiate(_light, new Vector3(posX, 5, posZ), Quaternion.identity);

                posZ += 10;
            }

            posZ = 0;
            posX += 10;
        }
    }
}
