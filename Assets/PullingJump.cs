using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour {

	private Rigidbody rb;

	private Vector3 clickPosition;
	[SerializeField]
	private float jumpPower = 10.0f;
	private bool isCanJump;

	void Start() {
		rb = gameObject.GetComponent<Rigidbody>();
	}


	void Update() {

		if (Input.GetMouseButtonDown(0)) {
			clickPosition = Input.mousePosition;
		}

		if (isCanJump && Input.GetMouseButtonUp(0)) {

			// クリックした座標と離した座標の差分を取得
			Vector3 dist = clickPosition - Input.mousePosition;

			// クリックとリリースが同じ座標ならば無視
			if (dist.sqrMagnitude == 0) { return; }

			// 差分を標準化し, jumpPowerを掛け合わせた値を移動量にする
			rb.velocity = dist.normalized * jumpPower;

		}
	}

	private void OnCollisionEnter(Collision collision) {
		// 衝突した際に呼び出される
		isCanJump = false;
	}

	private void OnCollisionExit(Collision collision) {
		// 離れたときに呼び出される
		isCanJump = false;
	}
}