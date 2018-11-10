using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Objects {
	static class RepeatConstants {
		public static readonly float TIME = 0.05f;
		public static readonly float REPEAT_RATE = 0.1f;
	}

	public class Snake : MonoBehaviour {
		public GameObject tailPrefab;
		Vector2 arrowKeyInput;
		List<Transform> tail = new List<Transform> ();
		bool isAteFood = false;

		void Start () {
			InvokeRepeating ("ManagementSnake", RepeatConstants.TIME, RepeatConstants.REPEAT_RATE);
		}

		void Update () {
			if (Input.GetKey (KeyCode.UpArrow) && arrowKeyInput != Vector2.down) {
				arrowKeyInput = Vector2.up;
			}
			else if (Input.GetKey (KeyCode.DownArrow) && arrowKeyInput != Vector2.up) {
				arrowKeyInput = Vector2.down;
			}
			else if (Input.GetKey (KeyCode.LeftArrow) && arrowKeyInput != Vector2.right) {
				arrowKeyInput = Vector2.left;
			}
			else if (Input.GetKey (KeyCode.RightArrow) && arrowKeyInput != Vector2.left) {
				arrowKeyInput = Vector2.right;
			}
		}

		void OnTriggerEnter2D (Collider2D c) {
			if (c.name.StartsWith ("Food")) {
				isAteFood = true;
				Destroy (c.gameObject);
			}
			else {
				Screen.Game.TransitionNextScene ();
			}
		}

		void ManagementSnake () {
			Vector2 headDirection = arrowKeyInput;
			Vector2 headCoordinate = transform.position;

			MoveHead (headDirection);
			MoveTail (headCoordinate);

			if (isAteFood == true) {
				AddTail (headCoordinate);
				isAteFood = false;
			}
		}

		void MoveHead (Vector2 targetDirection) {
			transform.Translate (targetDirection);
		}

		void MoveTail (Vector2 targetCoordinate) {
			if (tail.Count > 0) {
				tail.Last ().position = targetCoordinate;
				tail.Insert (0, tail.Last ());
				tail.RemoveAt (tail.Count - 1);
			}
		}

		void AddTail (Vector2 targetCoordinate) {
			GameObject newTail = (GameObject) Instantiate (tailPrefab, targetCoordinate, Quaternion.identity);

			tail.Insert (0, newTail.transform);
		}
	}
}
