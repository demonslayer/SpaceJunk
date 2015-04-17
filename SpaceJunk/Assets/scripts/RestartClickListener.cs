﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RestartClickListener : MonoBehaviour {

	void Start () {

		Button butt = GetComponent<Button>();
		butt.onClick.AddListener(delegate() { 
			Application.LoadLevel(Application.loadedLevel);
		});
	
	}

}
