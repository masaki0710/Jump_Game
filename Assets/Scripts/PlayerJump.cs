using UnityEngine;
using UnityEngine.InputSystem; // 新しいInput Systemを利用するため追加

public class PlayerJump : MonoBehaviour
{
    public float minJumpForce = 5f; // 最小ジャンプ力
    public float maxJumpForce = 15f; // 最大ジャンプ力
    public float chargeSpeed = 10f; // 1秒間に溜まる力

    private Rigidbody rb;
    private bool isGrounded;

    private float currentJumpForce;
    private bool isCharging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        // 1. スペースキーを押し始めた瞬間（チャージ開始）
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            isCharging = true;
            currentJumpForce = minJumpForce;
        }

        // 2. 押し続けている間（チャージ中）
        if (isCharging && Keyboard.current.spaceKey.isPressed)
        {
            currentJumpForce += chargeSpeed * Time.deltaTime;

            // 最大値を超えないように制限
            if (currentJumpForce > maxJumpForce)
            {
                currentJumpForce = maxJumpForce;
            }
        }

        // 3. キーを離した瞬間（ジャンプ実行）
        if (isCharging && Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            Jump();
        }
    }

    void Jump()
    {
        // 溜めた力でジャンプ
        rb.AddForce(Vector3.up * currentJumpForce, ForceMode.Impulse);

        // 状態をリセット
        isGrounded = false;
        isCharging = false;
        currentJumpForce = 0f;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }
}