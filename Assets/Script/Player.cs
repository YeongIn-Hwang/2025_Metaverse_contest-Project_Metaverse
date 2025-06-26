using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    [Header("입력 액션")]
    public InputActionReference moveAction;

    [Header("이동 속도")]
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
        // Vector2 방향 입력값 받기 (x = 좌우, y = 앞뒤)
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Debug.Log("Move 입력값: " + input);

        // 이동 방향 (x, z로 변환해서 월드에 적용)
        Vector3 moveDirection = new Vector3(input.x, 0, input.y);

        // 실제 이동
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
