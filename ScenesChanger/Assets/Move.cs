using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ�
    public float jumpForce = 7f; // ���� ��
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody ��������
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A, D �Ǵ� ��, �� Ű
        float moveZ = Input.GetAxis("Vertical");   // W, S �Ǵ� ��, �� Ű

        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z); // ������ �̵� ����

        // ���� (�����̽���)
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // �ٴ� ���� �Լ�
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
