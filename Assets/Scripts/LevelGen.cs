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
    public GameObject _text;
    public GameObject _particle;
	public GameObject Char;

    private float startX = 0f;
    private float startZ = 0f;

    private PlayerMove moveScript;
    private List<Vector3> emptyFields;

    private bool coRunning;

    void Start()
    {
        coRunning = false;
    }

    void Update()
    {
        if (moveScript != null)
        {
            if (moveScript.BlockMe)
            {
                if (!coRunning)
                {
                    coRunning = true;
                    StartCoroutine(PlayParticle());
                    StartCoroutine(BlockChar());
                }
            }
            else
            {
                StopCoroutine("PlayParticle");
                StopCoroutine("BlockChar");
               // coRunning = false;
            }

            if (moveScript != null)
                if (moveScript.SetMeSomeWhere != null)
                {
                    if (!coRunning)
                    {
                        coRunning = true;
                        StartCoroutine(FallDown());
                    }
                }
                else
                    StopCoroutine("FallDown");
        }
    }

    IEnumerator BlockChar()
    {
        yield return new WaitForSeconds(5);
        moveScript.YouAreFree();
        coRunning = false;
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

            StartCoroutine(PlayParticle());

            moveScript.SetYouBack();
        }

        coRunning = false;
    }

    IEnumerator PlayParticle()
    {
        var tmp = (GameObject)Network.Instantiate(_particle, Char.transform.position + Char.transform.forward * 0.01f, Quaternion.identity, 0);

        yield return new WaitForSeconds(5);

        Network.Destroy(tmp);
    }

    public void SetChar(GameObject _char)
    {
        Char = _char;
        moveScript = Char.GetComponent<PlayerMove>();
    }

    public void Init()
    {
        var filename1 = "External/Level" + GameData.levelID + "/Level.txt";
        var filename2 = "External/Level" + GameData.levelID + "/Light.txt";

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
        var crossCounter = 0;

        emptyFields = new List<Vector3>();
        var textMeshes = new List<MeshRenderer>();

        var aStrings = iniData.Split('\n');
        for (var ln = 0; ln < aStrings.Length; ln++)
        {
            var line = aStrings[ln];

            for (var p = 0; p < line.Length; p++)
            {
                var part = line[p];

                var tmpObj = _ground;
                var posY = 0f;

                var quat = Quaternion.identity;
                var isCr = IsCrossing(ln, p, line, aStrings);

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

                        if (p > 0 && p < line.Length - 1)
                            if (line[p - 1] != '0' || line[p + 1] != '0')
                                quat = Quaternion.AngleAxis(90, new Vector3(0, 1, 0));

                        break;
                }


                Instantiate(tmpObj, new Vector3(posX, posY, posZ), quat);

                if (isCr)
                {
                    crossCounter++;

                    var tm = (GameObject) Instantiate(_text, new Vector3(posX, posY+0.02f, posZ),
                            Quaternion.AngleAxis(-90, new Vector3(1, 0, 0)));

                    tm.transform.Rotate(new Vector3(1, 0, 0), 180);
                    tm.GetComponent<TextMesh>().text = crossCounter.ToString();

                    var mr = tm.GetComponent<MeshRenderer>();
                    mr.enabled = false;

                    textMeshes.Add(mr);
                }

                posZ += 1;
            }

            posZ = 0;
            posX += 1;
        }

		Char.transform.position = new Vector3(startX, 0.4f, startZ);
        
        var script = Char.GetComponent<UVElements>();
        if (script != null)
            script.SetText(textMeshes);
    }

    private bool IsCrossing(int ln, int p, string line, string[] txt)
    {
        if (line[p] == '1')
            return false;

        var ctFields1 = (CheckField(ln - 1, p, txt)) ? 1 : 0;
        var ctFields2 = (CheckField(ln + 1, p, txt)) ? 1 : 0;
        var ctFields3 = (CheckField(ln, p - 1, txt)) ? 1 : 0;
        var ctFields4 = (CheckField(ln, p + 1, txt)) ? 1 : 0;

        return (ctFields1 + ctFields2 + ctFields3 + ctFields4 > 2);
    }

    private bool CheckField(int ln, int p, string[] txt)
    {
        if (ln < 0 || ln > txt.Length - 1)
            return false;

        var line = txt[ln];

        if (p < 0 || p > line.Length - 1)
            return false;

        return (line[p] != '1');
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
