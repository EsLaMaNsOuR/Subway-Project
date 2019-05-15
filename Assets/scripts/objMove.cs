using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
public class objMove : MonoBehaviour {
	//Added
	Text key;
	Text score ;
	Text highScore;
	public GameObject controlImg;
	public GameObject exitControlImg;
	public GameObject exitGame;
	public GameObject Mutebtn;
	public GameObject voiceSlider;
	public Sprite muteImg;
	public Sprite soundImg;
	public int scoreCounter =0;
	public int scoreKey = 0;
	public AudioClip coinPlusOne;
	public AudioClip loser;
	public AudioClip onplay;
	public GameObject cam; 
	public GameObject gameOver;
	public Transform obj;
	public float h_move = 0;
	public float runSpeed =7f; 
	public int line = 0; 
	public bool control;
	Rigidbody rig;
	public float jump;
	public float force = 100f;
	public float VoiceNow;
	string dataFile ;
	bool EditToFile;
	bool isdead;
	public bool isMute;
	float jumpSpeed;
	// Use this for initialization

	void Start () {
		controlImg.SetActive(false);
		exitControlImg.SetActive (false);
		exitGame.SetActive (false);
		Mutebtn.SetActive (false);
		voiceSlider.SetActive (false);
		isdead = false;
		isMute = false;
		EditToFile = false;
		rig = this.GetComponent<Rigidbody> ();
		gameObject.GetComponent<AudioSource>().clip = onplay;
		gameObject.GetComponent<AudioSource> ().Play ();
		runSpeed = 7f; 
		jumpSpeed = 0;
		cam.GetComponent<camMove> ().runSpeed = runSpeed;
		GetComponent<Rigidbody> ().velocity = new Vector3 (h_move, jumpSpeed, runSpeed);
		score = GameObject.Find ("coinsCount").GetComponent<Text> ();
		//Added
		key = GameObject.Find ("keyCount").GetComponent<Text> ();
		highScore =  GameObject.Find ("highScore").GetComponent<Text> ();
		highScore.text = dataFile = Read_File ();

		control = true;
		jump = 10f;

	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<Rigidbody> ().velocity = new Vector3 (h_move, jumpSpeed, runSpeed);
		cam.GetComponent<camMove> ().runSpeed = runSpeed;


		if (scoreCounter > int.Parse(dataFile)) {
			highScore.color = new Color (255, 0, 0);
			highScore.text = scoreCounter.ToString();
			EditToFile = true;
		}

		if (isdead) {
			runSpeed = 0;
			control = false;
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			if (isdead == false) {
				if (Time.timeScale == 1) {
					//GetComponent<AudioSource> ().Pause ();
					//MuteButton.SetActive(true);
					//volumeSlideer.SetActive (true);
					Time.timeScale = 0;
					control = false;
					controlImg.SetActive(true);
					exitControlImg.SetActive (true);
					exitGame.SetActive (true);
					Mutebtn.SetActive (true);
					voiceSlider.SetActive (true);
					//pauseButton.GetComponent<Image> ().sprite = playImg;
					//exitBtnII.SetActive (true);
					//Debug.Log ("DDD");
				} else {
					//GetComponent<AudioSource> ().Play ();
					//MuteButton.SetActive(false);
					//volumeSlideer.SetActive (false);
					Time.timeScale = 1;
					control = true;
					controlImg.SetActive(false);
					exitControlImg.SetActive (false);
					exitGame.SetActive (false);
					Mutebtn.SetActive (false);
					voiceSlider.SetActive (false);
					//pauseButton.GetComponent<Image> ().sprite = PauseImg;
					//exitBtnII.SetActive (false);
				}
			}

		}
		if (Input.GetKey (KeyCode.A) && line>-1 && control==true) {
			StartCoroutine (controlMove ('l'));
			line--;
			control = false;
			Debug.Log (line);
		}
		if (Input.GetKey (KeyCode.D) && line<1 && control==true) {
			StartCoroutine (controlMove ('r'));
			line++;
			control = false;
			//Debug.Log (line);
		}
		if(Input.GetKey (KeyCode.W) && control==true){
			StartCoroutine (jumpControl());
			control = false;
		}
		/*
		if (Input.GetKey (KeyCode.Space)) {
			StartCoroutine (jumpControl());
		}
		*/
		if (Input.GetKeyDown (KeyCode.M)) {
			if (isMute == false) {
				isMute = true;
				cam.GetComponent<AudioListener> ().enabled = false;
				Mutebtn.GetComponent<Image> ().sprite = muteImg;
				VoiceNow = GetComponent<AudioSource> ().volume;
				voiceSlider.GetComponent<Slider> ().value = 0;
			} else {
				isMute = false;
				cam.GetComponent<AudioListener> ().enabled = true;
				Mutebtn.GetComponent<Image> ().sprite = soundImg;
				GetComponent<AudioSource> ().volume = VoiceNow;
				voiceSlider.GetComponent<Slider> ().value = VoiceNow;
			}
		}
		float vol = voiceSlider.GetComponent <Slider> ().value;
		cam.GetComponent<AudioSource> ().volume  = vol;

	}
	void OnCollisionEnter(Collision col){
		if (( col.gameObject.tag=="train"  || col.gameObject.tag=="block" || col.gameObject.tag=="tree" ) && isdead ==false){
			
			float oldx = gameObject.GetComponent<Transform> ().position.x;
			float oldy = gameObject.GetComponent<Transform> ().position.y;
			float oldz = gameObject.GetComponent<Transform> ().position.z;
			//if (scoreKey > 0  ) {						// if dead --> create another obj 
				//Destroy (gameObject);
 				//Instantiate (obj, new Vector3 (oldx, oldy, oldz+1f), obj.rotation);
				//GetComponent<Rigidbody> ().velocity = new Vector3 (h_move, 0, runSpeed);
				//Destroy (gameObject);
				//scoreKey--;
				//key.text = scoreKey.ToString ();
			//}
			//else{
				runSpeed = 0;
				control = false;
				cam.GetComponent<AudioSource> ().Stop ();
				gameObject.GetComponent<AudioSource>().clip = loser;
				gameObject.GetComponent<AudioSource> ().Play ();
				gameOver.SetActive(true);
				isdead = true;
				if (EditToFile)
					Write_File (highScore.text);
			

				//cam.GetComponent<camMove> ().runSpeed = 0f;
			//}
		}


	

	}
	void OnTriggerEnter(Collider col){
		if ( col.gameObject.tag=="coin+1"){
			gameObject.GetComponent<AudioSource>().clip = coinPlusOne;
			gameObject.GetComponent<AudioSource> ().Play ();
			Destroy (col.gameObject);
			scoreCounter++;
			score.text = scoreCounter.ToString ();
		}

		//Added
		if ( col.gameObject.tag=="keyCount"){
			gameObject.GetComponent<AudioSource>().clip = coinPlusOne;
			gameObject.GetComponent<AudioSource> ().Play ();
			Destroy (col.gameObject);
			scoreKey++;
			key.text = scoreKey.ToString ();
		}
		if ( col.gameObject.tag=="coin-100"){
			gameObject.GetComponent<AudioSource>().clip = coinPlusOne;
			gameObject.GetComponent<AudioSource> ().Play ();
			Destroy (col.gameObject);
			scoreCounter-=10;
			if (scoreCounter <= 0)
				scoreCounter = 0;
			score.text = scoreCounter.ToString ();
		}


	}	

	IEnumerator controlMove(char ch){
		if (ch == 'l') {
			h_move = -2	;
		} else if (ch == 'r') {
			h_move = 2;
		}
		yield return new WaitForSeconds (0.5f);
		h_move = 0;
		control = true;

	}
	IEnumerator jumpControl(){
		jumpSpeed = 1.5f;
		control = false;
		yield return new WaitForSeconds (0.5f);
		StartCoroutine(fallControl());

	}
	IEnumerator fallControl(){
		jumpSpeed = -1.5f;
		yield return new WaitForSeconds (0.5f);
		StartCoroutine(afterFall());
	}
	IEnumerator afterFall(){
		jumpSpeed = 0f;
		yield return new WaitForSeconds (0.5f);
		control = true;
	}

	/*
	IEnumerator jumpControl (){

		this.GetComponent<Animator> ().SetBool ("isJump", true);
		rig.AddForce (new Vector3(0,20,0)*force);
		yield return new WaitForSeconds (1f);
		falling();


	}

	void  falling (){
		//yield return new WaitForSeconds (1f);
		this.GetComponent<Animator> ().SetBool ("isJump", false);
		rig.AddForce (new Vector3(0,-20,0)*force);

	}
	*/
	[MenuItem("Tools/Write file")]
	static void Write_File(string data){
		string path="Assets/highscore.txt";
		File.WriteAllText (path, data);
		//StreamWriter writer = new StreamWriter (path, true);
		//writer.WriteLine ("testr");
		//writer.Close ();

		/*AssetDatabase.ImportAsset (path);
		TextAsset asset = Resources.Load ("test");
*/
		//Debug.Log (asset.text);
	}

	[MenuItem("Tools/Read file")]
	static string  Read_File(){
		
		string path="Assets/highscore.txt";
		//string data = ToString(File.ReadAllLines (Path));
		//string data = File.ReadAllText(path);
		StreamReader reader = new StreamReader (path);
		return reader.ReadToEnd();
		reader.Close ();

	}
}
