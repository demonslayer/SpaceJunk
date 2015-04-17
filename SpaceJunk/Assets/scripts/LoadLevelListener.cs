using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LoadLevelListener : MonoBehaviour {

	public string levelName;

	void Start () {
		Button butt = GetComponent<Button>();
		butt.onClick.AddListener(delegate() { 
			Debug.Log("Pressed the button to load level " + levelName);
			Application.LoadLevel(levelName);
		});
	
	}
	
}
