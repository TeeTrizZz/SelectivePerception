using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class CountLevels : MonoBehaviour {

	private DirectoryInfo dirMain;
	private FileInfo[] allSubFolders;
	private FileInfo[] subFiles;
	private int countFolders=0;
	private List<string> fileNames = new List<string>();


	// Use this for initialization
	void Start () {
		if (!Application.isWebPlayer) {
			countLevels ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void countLevels()
	{

		//Get all directories which are located in the External folder
		DirectoryInfo dirMain = new DirectoryInfo(@"\..\External\");
		Debug.Log (dirMain);
		DirectoryInfo[] allSubFolders = dirMain.GetDirectories();
		foreach (DirectoryInfo subFolder in allSubFolders) 
		{
			//Count the amount of folders
			countFolders++;
			/* Get the names of the files in the folder
			subFiles = subFolder.GetFiles();
			foreach(FileInfo subFile in subFiles)
			{
				fileNames.Add(subFile.Name);
			}
			*/
		}
		fileNames.ForEach (print);
	}
}
