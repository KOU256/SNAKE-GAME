using System.Collections;
using System.Collections.Generic;
using Screen;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Screen {
	public class Title : MonoBehaviour {
		void Update () {
			if (Input.GetKey (KeyCode.S)) {
				TransitionNextScene ();
			}
		}

		void TransitionNextScene () {
			SceneManager.LoadScene ("Game");
		}
	}
}
