using UnityEngine;
using System.Collections;

public class LevelGen : MonoBehaviour {

    public GameObject _wall;
    public GameObject _ground;

	void Start () {
        var filename = "Assets/Level/Level.txt";
        var iniData = "";
        var prefix = "";

        if (!Application.isWebPlayer)
            prefix = "file://";

        var pathname = prefix + Application.dataPath + "/../" + filename;
        var www = new WWW(pathname);

        while (!www.isDone) { };
            
        iniData = www.text;

        var posX = 0;
        var posZ = 0;

        var aStrings = iniData.Split('\n');
	    foreach (var line in aStrings) {
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
                }

                Instantiate(tmpObj, new Vector3(posX, posY, posZ), Quaternion.identity);

                posZ += 10;
            }

            posZ = 0;
            posX += 10;
	    }
	}

	void Update () {
	
	}
}
