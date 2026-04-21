using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float spd = 5f;

    private Vector3 moveDir = Vector3.zero;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        var cc = GetComponent<CharacterController>();
        if (cc != null && rb != null)
            cc.enabled = false;
    }

    void Start()
    {
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            moveDir = Vector3.right;

        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            moveDir = Vector3.left;

        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            moveDir = Vector3.up;

        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            moveDir = Vector3.down;

        if (rb == null)
            transform.position += moveDir * spd * Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (rb == null)
            return;

        if (rb.isKinematic)
        {
            rb.MovePosition(rb.position + moveDir * spd * Time.fixedDeltaTime);
            return;
        }

        Vector3 v = rb.velocity;
        v.x = moveDir.x * spd;
        v.z = moveDir.z * spd;

        if (Mathf.Abs(moveDir.y) > 1e-3f)
            v.y = moveDir.y * spd;

        rb.velocity = v;
    }
}
