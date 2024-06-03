using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour {

	[SerializeField]
	private Image arrowImage;
	private Vector3 clickPosition;

	// Update is called once per frame
	void Update() {

		arrowImage.enabled = false;

		if (Input.GetMouseButtonDown(0)) {
			clickPosition = Input.mousePosition;
		}

		if (Input.GetMouseButton(0)) {

			arrowImage.enabled = true;

			Vector3 dist = clickPosition - Input.mousePosition;

			// �x�N�g���̒����̎Z�o
			float size = dist.magnitude;

			// �x�N�g������p�x(radian)�̎Z�o
			float angleRed = Mathf.Atan2(dist.y, dist.x);

			// ���̉摜���N���b�N�����ꏊ�ɉ摜�̈ړ�
			arrowImage.rectTransform.position = clickPosition;

			// ���̉摜���x�N�g������Z�o�����p�x��degree�ɕϊ�����z����]
			arrowImage.rectTransform.rotation
				= Quaternion.Euler(0.0f, 0.0f, angleRed * Mathf.Rad2Deg);

			// ���̉摜�̑傫�����h���b�O���������ɍ��킹��
			arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
		}
	}
}
