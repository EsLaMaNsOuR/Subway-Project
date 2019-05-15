using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class create : MonoBehaviour {

	public GameObject player;
	public Transform coin;
	public Transform tree;
	public Transform col;
	public Transform key;
	public Transform land;
	public Transform coin_100;
	public float zAxes=70;
	public float z=150;
	float rand, rand2;
	public int i;
	//public Transform v;
	// Use this for initialization
	void Start () {
		i = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
		if ( player.GetComponent<objMove>().control==true){
			if (zAxes > 90) {
				rand = Random.Range (1, 20);
				rand2 = Random.Range (1, 20);

				if (rand %2==0 && rand <=9  ) {
					Instantiate (coin, new Vector3 (56.81f, -7f, zAxes), coin.rotation);
				}
				if ( rand %2==0 && rand >9 && rand <14 ) {
					Instantiate (coin, new Vector3 (57.81f, -7f, zAxes), coin.rotation);
				}
				if (rand %2==0 && rand >=14 && rand <=20 )  {
					Instantiate (coin, new Vector3 (55.81f, -7f, zAxes), coin.rotation);
				}




				if (rand == 5 && rand %2!=0) {
					Instantiate (tree, new Vector3 (57.81f, -7f, zAxes), tree.rotation);
				}

				if (rand == 7 && rand %2!=0) {
					Instantiate (tree, new Vector3 (56.81f, -7f, zAxes), tree.rotation);
				}



				if (rand == 3 && rand %2!=0) {
					Instantiate (col, new Vector3 (56.81f, -7.5f, zAxes), col.rotation);
				}
				if (rand == 5 && rand %2!=0) {
					Instantiate (col, new Vector3 (55.81f, -7.5f, zAxes), col.rotation);
				}
				if (rand == 7 && rand %2!=0) {
					Instantiate (col, new Vector3 (57.81f, -7.5f, zAxes), col.rotation);
				}



			
				if (rand ==13  && rand %2!=0) {
					Instantiate (key, new Vector3 (57.81f, -7f, zAxes), key.rotation);
				}
				if (rand == 19 && rand %2!=0 ) {
					Instantiate (key, new Vector3 (55.81f, -7f, zAxes), key.rotation);
				}
				if (rand == 11 && rand %2!=0 ) {
					Instantiate (key, new Vector3 (56.81f, -7f, zAxes), key.rotation);
				}


				if (rand == 15 && rand %2!=0 ) {
					Instantiate (coin_100, new Vector3 (56.81f, -7f, zAxes), coin_100.rotation);
				}
				if (rand == 9 && rand %2!=0 ) {
					Instantiate (coin_100, new Vector3 (55.81f, -7f, zAxes), coin_100.rotation);
				}
				if (rand == 17 && rand %2!=0 ) {
					Instantiate (coin_100, new Vector3 (57.81f, -7f, zAxes), coin_100.rotation);
				}
			
			}
			if (zAxes % 100 == 0) {
				Instantiate (land, new Vector3 (56.8f, -7.356875f, 200 + (50 * i)), land.rotation);
				i++;
			}

			zAxes += 5;	

			if (zAxes < 600) {
				player.GetComponent<objMove> ().runSpeed = 7;
			}
			if ( zAxes > 1200 ) {
				player.GetComponent<objMove> ().runSpeed = 9;
			}
			if (zAxes > 1600) {
				player.GetComponent<objMove> ().runSpeed = 11;
			}
			if (zAxes >= 2000 ) {
				player.GetComponent<objMove> ().runSpeed = 13;
			}

			
		}
	}
}
