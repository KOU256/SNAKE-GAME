using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Screen {
	static class ScoreConstans {
		public static readonly int SCORE_MAGNIFICATION = 10;
	}

	public class Game : MonoBehaviour {

		public Text scoreText;
		public static int score;
		void Start () {
			InitializeScore ();
		}

		void Update () {
			IncrementScore ();
			scoreText.text = score.ToString ();
		}

		void InitializeScore () {
			score = 0;
		}

		void IncrementScore () {
			GameObject [] tailNumber = GameObject.FindGameObjectsWithTag ("Tails");
			score = tailNumber.Length * ScoreConstans.SCORE_MAGNIFICATION;
		}

		public static void TransitionNextScene () {
			SceneManager.LoadScene ("GameOver");
		}

		public static int GetScore () {
			return score;
		}
	}
}
