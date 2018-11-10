using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Screen {
	public class GameOver : MonoBehaviour {
		public Text scoreText;
		int score;

		void Start () {
			score = Game.GetScore ();
			SetScore ();
		}
		void Update () {
			if (Input.GetKey (KeyCode.R)) {
				TransitionNextScene ();
			}
		}

		void SetScore () {
			scoreText.text = score.ToString ();
		}

		void TransitionNextScene () {
			SceneManager.LoadScene ("Title");
		}
	}
}
