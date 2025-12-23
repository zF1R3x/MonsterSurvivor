using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private UIManager uiManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        uiManager = FindFirstObjectByType<UIManager>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            uiManager.Pause();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    void LateUpdate()
    {
        ClampToCamera();
    }

    void ClampToCamera()
    {
        Camera cam = Camera.main;

        // Player world position
        Vector3 pos = transform.position;

        // Distance from camera to player
        float distanceZ = Mathf.Abs(cam.transform.position.z - pos.z);

        // Screen bounds (in world units)
        Vector3 leftBottom = cam.ScreenToWorldPoint(new Vector3(0, 0, distanceZ));
        Vector3 rightTop = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, distanceZ));

        // Clamp player position
        pos.x = Mathf.Clamp(pos.x, leftBottom.x, rightTop.x);
        pos.y = Mathf.Clamp(pos.y, leftBottom.y, rightTop.y);

        transform.position = pos;
    }

}
