using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float time = 0;
    private GameObject pow;
    private float timeCheck;
    [SerializeField] private Transform powerPrefab;
    private Vector3 powerPosition;
    private Vector3 startPosition;
    private float power;
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    public static bool jumped;
    public static float screenWidth;
    private Vector2 basePosition;
    [SerializeField] private Transform basePrefab;

    private void Start()
    {
        pow = GameObject.Find("PowerRadar");
        startPosition = new Vector3(-8f, -2.5f, -1f);
        powerPosition = startPosition;
        rb = GetComponent<Rigidbody2D>();
        jumped = false;
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        basePosition = new Vector2(-4f, -2f);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(time == 0)
            {
                startPosition = GameObject.Find("Player").transform.position;
                powerPosition = new Vector3(startPosition.x - 4f, -2.5f, -1f);
            }
            time += 0.2f;
            if(time>timeCheck && timeCheck <= 10f)
            {
                Transform p = Instantiate(powerPrefab, powerPosition, Quaternion.identity);
                p.parent = pow.transform;
                timeCheck += 1;
                powerPosition = new Vector3(powerPosition.x, powerPosition.y + 0.5f, powerPosition.z);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            time = 0;
            power = timeCheck;
            timeCheck = 0;
            Destroy(pow.gameObject);
            pow = new GameObject("PowerRadar");
            Jump();
        }
        SpawnBase();
    }

    void Jump()
    {
        if (jumped == false)
        {
            rb.AddForce(new Vector2(0.5f,1f) * power * jumpForce);
            jumped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Base")
        {
            jumped = false;
        }
    }

    void SpawnBase()
    {
        if (basePosition.x < (transform.position.x + (2 * screenWidth)))
        {
            float rand = Random.Range(6f, 10f);
            basePosition = new Vector2(basePosition.x + rand, basePosition.y);
            Instantiate(basePrefab, basePosition, Quaternion.identity);
        }
    }
}
