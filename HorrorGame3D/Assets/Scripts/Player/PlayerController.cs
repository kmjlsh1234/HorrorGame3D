using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Object;
namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("PlayerMove&Rotate")]
        [SerializeField] float turnSpeed = 4.0f; // 마우스 회전 속도
        [SerializeField] float _speed;
        [SerializeField] float _normalSpeed = 5f;
        [SerializeField] float _runSpeed = 10f;
        // 마우스 회전
        private float xRotate = 0.0f; // 내부 사용할 X축 회전량은 별도 정의 ( 카메라 위 아래 방향 )
        Rigidbody body; // Rigidbody를 가져올 변수

        [Header("Interaction")]
        [SerializeField] private float MaxDistance;
        private RaycastHit hit;

        [HideInInspector] public bool _canMove = true;
        [HideInInspector] public bool _canRotate = true;

        [SerializeField] private ObjectBase _curInteractObj = null;
        void Start()
        {
            body = GetComponent<Rigidbody>();           // Rigidbody를 가져온다.
            transform.rotation = Quaternion.identity;   // 회전 상태를 정면으로 초기화
        }

        void Update()
        {
            if(_canMove) Move();
            if (_canRotate) Rotate();
            if (Input.GetKeyDown(KeyCode.Space)) Interaction();
        }

        #region :::: PlayerMove
        void Move()
        {
            //  키보드에 따른 이동량 측정
            Vector3 move =
                transform.forward * Input.GetAxis("Vertical") +
                transform.right * Input.GetAxis("Horizontal");

            // 이동량을 좌표에 반영
            if (Input.GetKey(KeyCode.LeftShift))
                _speed = _runSpeed;
            else
                _speed = _normalSpeed;

            transform.position += move * _speed * Time.deltaTime;

        }

        void Rotate()
        {
            // 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 양 계산
            float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
            // 현재 y축 회전값에 더한 새로운 회전각도 계산
            float yRotate = transform.eulerAngles.y + yRotateSize;

            // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
            float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
            // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
            // Clamp 는 값의 범위를 제한하는 함수
            xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

            // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
            transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        }
        #endregion

        #region :::: Interaction
        private void Interaction()
        {
            if(_curInteractObj == null)
            {
                Debug.DrawRay(transform.position, transform.forward * MaxDistance, Color.green, 0.5f);
                if (Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance))
                {
                    Debug.Log("현재 RayCast Target : " + hit.transform.gameObject.name);
                    ObjectBase _targetScript = hit.transform.GetComponent<ObjectBase>();
                    if (_targetScript != null)
                    {
                        _curInteractObj = _targetScript;
                        _targetScript.SetPlayerController(this);
                        _targetScript.SetInteraction();
                    }
                }
            }
            else
                _curInteractObj.SetInteraction();
        }
        #endregion

        public void StartInteraction()
        {
            _canMove = false;
            _canRotate = false;
        }

        public void FinishInteraction()
        {
            _canMove = true;
            _canRotate = true;
            _curInteractObj = null;
        }
    }
}
