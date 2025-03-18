using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ�
    public float jumpHeight = 2f; // ���� ����
    public float gravity = -9.8f; // �߷� ��

    private CharacterController characterController;
    private Vector3 velocity; // ĳ������ �ӵ�

    private void Start()
    {
        characterController = GetComponent<CharacterController>(); // CharacterController ������Ʈ�� ������
    }

    private void Update()
    {
        // ���� �̵�
        float moveX = Input.GetAxis("Horizontal"); // A, D, ����, ������ ȭ��ǥ Ű
        float moveZ = Input.GetAxis("Vertical"); // W, S, ��, �Ʒ� ȭ��ǥ Ű
        Vector3 move = transform.right * moveX + transform.forward * moveZ; // �̵� ���� ���

        characterController.Move(move * moveSpeed * Time.deltaTime); // �̵�

        // ���� ���
        if (characterController.isGrounded) // �ٴڿ� ����� ��
        {
            velocity.y = -2f; // �ٴڿ� ���� �� ���� �ϰ� �ӵ� ����

            if (Input.GetButtonDown("Jump")) // Space Ű�� ����
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // ���� �ӵ� ���
            }
        }

        velocity.y += gravity * Time.deltaTime; // �߷� ����
        characterController.Move(velocity * Time.deltaTime); // �߷¿� ���� �̵�
    }
}
