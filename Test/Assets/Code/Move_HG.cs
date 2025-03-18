using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    public float jumpHeight = 2f; // 점프 높이
    public float gravity = -9.8f; // 중력 값

    private CharacterController characterController;
    private Vector3 velocity; // 캐릭터의 속도

    private void Start()
    {
        characterController = GetComponent<CharacterController>(); // CharacterController 컴포넌트를 가져옴
    }

    private void Update()
    {
        // 수평 이동
        float moveX = Input.GetAxis("Horizontal"); // A, D, 왼쪽, 오른쪽 화살표 키
        float moveZ = Input.GetAxis("Vertical"); // W, S, 위, 아래 화살표 키
        Vector3 move = transform.right * moveX + transform.forward * moveZ; // 이동 방향 계산

        characterController.Move(move * moveSpeed * Time.deltaTime); // 이동

        // 점프 기능
        if (characterController.isGrounded) // 바닥에 닿았을 때
        {
            velocity.y = -2f; // 바닥에 있을 때 작은 하강 속도 유지

            if (Input.GetButtonDown("Jump")) // Space 키로 점프
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // 점프 속도 계산
            }
        }

        velocity.y += gravity * Time.deltaTime; // 중력 적용
        characterController.Move(velocity * Time.deltaTime); // 중력에 의한 이동
    }
}
