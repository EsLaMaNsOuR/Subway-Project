using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour {
	public GameObject cam;
	public GameObject obj;
	public GameObject controlImg;
	public GameObject exitControlImg;
	public GameObject exitGame;
	public GameObject Mutebtn;
	public GameObject voiceSlider;

	public void close( ) {
		Application.Quit ();
		Debug.Log ("You Press Exit :)");
	}
	public void mute( ) {
		if (obj.GetComponent<objMove>().isMute == false) {
			obj.GetComponent<objMove>().isMute = true;
			cam.GetComponent<AudioListener> ().enabled = false;
			Mutebtn.GetComponent<Image> ().sprite = obj.GetComponent<objMove>().muteImg;
		} else {
			obj.GetComponent<objMove>().isMute = false;
			cam.GetComponent<AudioListener> ().enabled = true;
			Mutebtn.GetComponent<Image> ().sprite = obj.GetComponent<objMove>().soundImg;
		}
	}
	public void exitMenu( ) {
		Time.timeScale = 1;
		obj.GetComponent<objMove>().control = true;
		controlImg.SetActive(false);
		exitControlImg.SetActive (false);
		exitGame.SetActive (false);
		Mutebtn.SetActive (false);
		voiceSlider.SetActive (false);
	}

}
