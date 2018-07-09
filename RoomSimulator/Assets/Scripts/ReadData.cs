using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class ReadData : MonoBehaviour {

	public string file;

	// Use this for initialization
	void Start () {
		Load (file);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private bool Load(string fileName) {
		try {
			string line;
			StreamReader theReader = new StreamReader(fileName, Encoding.Default);
			using(theReader) {
				do {
					line = theReader.ReadLine();
					if(line!=null) {
						Debug.Log(line);
						/*string[] entries = line.Split(' ');
						if(entries.Length > 0) {
							
						}*/
					} 
				} while (line != null);

				theReader.Close();
				return true;
			}
		} catch (IOException e) {
			Debug.Log(e.Message);
			return false;
		} 
	}
}
