using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    [Header("�Է� �׼�")]
    public InputActionReference moveAction;

    [Header("�̵� �ӵ�")]
    public float moveSpeed = 4.0f;

    private void Start()
    {
    }
    void OnEnable()
    {
        moveAction?.action?.Enable();
    }

    void Update()
    {
        // Vector2 ���� �Է°� �ޱ� (x = �¿�, y = �յ�)
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Debug.Log("Move �Է°�: " + input);

        // �̵� ���� (x, z�� ��ȯ�ؼ� ���忡 ����)
        Vector3 moveDirection = new Vector3(input.x, 0, input.y);

        // ���� �̵�
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
