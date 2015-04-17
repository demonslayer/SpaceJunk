using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuitClickListener : MonoBehaviour {

	void Start () {

		Button butt = GetComponent<Button>();
		butt.onClick.AddListener(delegate() { 
			Application.Quit();
		});

	
	}

}
