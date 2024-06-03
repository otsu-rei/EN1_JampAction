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

			// �N���b�N�������W�Ɨ��������W�̍������擾
			Vector3 dist = clickPosition - Input.mousePosition;

			// �N���b�N�ƃ����[�X���������W�Ȃ�Ζ���
			if (dist.sqrMagnitude == 0) { return; }

			// ������W������, jumpPower���|�����킹���l���ړ��ʂɂ���
			rb.velocity = dist.normalized * jumpPower;

		}
	}

	private void OnCollisionEnter(Collision collision) {
		// �Փ˂����ۂɌĂяo�����
		isCanJump = false;
	}

	private void OnCollisionExit(Collision collision) {
		// ���ꂽ�Ƃ��ɌĂяo�����
		isCanJump = false;
	}
}