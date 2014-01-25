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

        var posX = 0f;
        var posZ = 0f;

        var startX = 0f;
        var startZ = 0f;

        // level
        var aStrings = iniData.Split('\n');
        foreach (var line in aStrings)
        {
            foreach (var part in line)
            {
                var tmpObj = _ground;
                var posY = 0f;

                switch (part)
                {
                    case '0':
                        tmpObj = _ground;
                        break;
                    case '1':
                        posY = 0.5f;
                        tmpObj = _wall;
                        break;
                    case '2':
                        tmpObj = _ground;

                        startX = posX;
                        startZ = posZ;

                        break;
                }

                Instantiate(tmpObj, new Vector3(posX, posY, posZ), Quaternion.identity);

                posZ += 1;
            }

            posZ = 0;
            posX += 1;
        }

		Char.transform.position = new Vector3(startX, 0.4f, startZ);
    }

    void LoadLight(string pathname)
    {
        var www = new WWW(pathname);

        while (!www.isDone) { };

        var iniData = www.text;

        var posX = 0f;
        var posZ = 0f;

        // light
        var aStrings = iniData.Split('\n');
        foreach (var line in aStrings)
        {
            foreach (var part in line)
            {
                if (part == '1')
                    Instantiate(_light, new Vector3(posX, 0.5f, posZ), Quaternion.identity);

                posZ += 1;
            }

            posZ = 0;
            posX += 1;
        }
    }
}
