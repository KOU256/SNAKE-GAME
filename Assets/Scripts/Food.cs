using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects {
	static class FoodConstants {
		public static readonly int FOOD_MAX_NUMBER = 15;
	}
	public class Food : MonoBehaviour {

		public GameObject foodPrefab;
		public Transform borderTop;
		public Transform borderBottom;
		public Transform borderLeft;
		public Transform borderRight;

		void Start () {
			for (int i = 0; i < FoodConstants.FOOD_MAX_NUMBER; i++) {
				Instantiate (foodPrefab, GenerateRandomCoordinate (), Quaternion.identity);
			}
		}

		void Update () {
			GameObject [] foodNumber = GameObject.FindGameObjectsWithTag ("Foods");
			if (foodNumber.Length < FoodConstants.FOOD_MAX_NUMBER) {
				Instantiate (foodPrefab, GenerateRandomCoordinate (), Quaternion.identity);
			}
		}

		//画面内のランダムな座標にFoodを移動させる
		Vector2 GenerateRandomCoordinate () {
			int x = (int) Random.Range (borderLeft.position.x, borderRight.position.x);
			int y = (int) Random.Range (borderBottom.position.y, borderTop.position.y);
			return new Vector2 (x, y);
		}
	}
}
