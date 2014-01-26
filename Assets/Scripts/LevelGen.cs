using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LevelGen : MonoBehaviour {

    public GameObject _wall;
    public GameObject _ground;
    public GameObject _light;
    public GameObject _trap;
    public GameObject _wire;
    public GameObject _start;
    public GameObject _goal;
	public GameObject Char;

    private float startX = 0f;
    private float startZ = 0f;

    private PlayerMove moveScript;
    private List<Vector3> emptyFields;


    void Update()
    {
        if (moveScript != null)
        {
            if (moveScript.BlockMe)
                StartCoroutine(BlockChar());
            else
                StopCoroutine("BlockChar");

            if (moveScript != null)
                if (moveScript.SetMeSomeWhere != null)
                    StartCoroutine(FallDown());
                else
                    StopCoroutine("FallDown");
        }
    }

    IEnumerator BlockChar()
    {
        yield return new WaitForSeconds(5);
        moveScript.YouAreFree();
    }

    IEnumerator FallDown()
    {
        moveScript.SetMeSomeWhere.GetComponent<Collider>().enabled = false;
        Char.GetComponent<Rigidbody>().useGravity = true;

        yield return new WaitForSeconds(2);

        if (moveScript.SetMeSomeWhere != null)
        {
            Char.GetComponent<Rigidbody>().useGravity = false;
            moveScript.SetMeSomeWhere.GetComponent<Collider>().enabled = true;
            
            int randomIndex = Random.Range(0, emptyFields.Count - 1);
            Char.transform.position = emptyFields[randomIndex];
            moveScript.SetYouBack();
        }
    }

    public void SetChar(GameObject _char)
    {
        Char = _char;
        moveScript = Char.GetComponent<PlayerMove>();
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

        // level
        emptyFields = new List<Vector3>();

        var aStrings = iniData.Split('\n');
        foreach (var line in aStrings)
        {
            for (var p = 0; p < line.Length; p++)
            {
                var part = line[p];

                var tmpObj = _ground;
                var posY = 0f;

                switch (part)
                {
                    case '0':
                        tmpObj = _ground;
                        emptyFields.Add(new Vector3(posX, 0.4f, posZ));

                        break;

                    case '1':
                        posY = 0.5f;
                        tmpObj = _wall;
                        break;

                    case '2':
                        tmpObj = _start;

                        startX = posX;
                        startZ = posZ;

                        break;

                    case '3':
                        tmpObj = _goal;
                        break;

                    case '4':
                        tmpObj = _trap;
                        break;

                    case '5':
                        tmpObj = _wire;
                        break;
                }

                var quat = Quaternion.identity;
                if (p > 0 && p < line.Length - 1)
                    if (line[p - 1] != '0' || line[p + 1] != '0')
                        quat = Quaternion.AngleAxis(90, new Vector3(0, 1, 0));

                Instantiate(tmpObj, new Vector3(posX, posY, posZ), quat);

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
