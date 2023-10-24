using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        // ���콺 ȸ��
        public float turnSpeed = 4.0f; // ���콺 ȸ�� �ӵ�    
        private float xRotate = 0.0f; // ���� ����� X�� ȸ������ ���� ���� ( ī�޶� �� �Ʒ� ���� )
        public float moveSpeed = 4.0f; // �̵� �ӵ�
        Rigidbody body; // Rigidbody�� ������ ����


        // Start is called before the first frame update
        void Start()
        {
            body = GetComponent<Rigidbody>();           // Rigidbody�� �����´�.
            transform.rotation = Quaternion.identity;   // ȸ�� ���¸� �������� �ʱ�ȭ
        }

        void FixedUpdate()
        {
            Move();
        }

        void Move()
        {
            // �¿�� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� �¿�� ȸ���� �� ���
            float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
            // ���� y�� ȸ������ ���� ���ο� ȸ������ ���
            float yRotate = transform.eulerAngles.y + yRotateSize;

            // ���Ʒ��� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� ȸ���� �� ���(�ϴ�, �ٴ��� �ٶ󺸴� ����)
            float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
            // ���Ʒ� ȸ������ ���������� -45�� ~ 80���� ���� (-45:�ϴù���, 80:�ٴڹ���)
            // Clamp �� ���� ������ �����ϴ� �Լ�
            xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

            // ī�޶� ȸ������ ī�޶� �ݿ�(X, Y�ุ ȸ��)
            transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

            //  Ű���忡 ���� �̵��� ����
            Vector3 move =
                transform.forward * Input.GetAxis("Vertical") +
                transform.right * Input.GetAxis("Horizontal");

            // �̵����� ��ǥ�� �ݿ�
            transform.position += move * moveSpeed * Time.deltaTime;
        }     
    }
}