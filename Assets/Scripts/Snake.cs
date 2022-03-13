using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Snake : MonoBehaviour
{
    public int initialSize = 3;
    public Transform segmentPrefab;

    private Vector2 direction = Vector2.right;
    private List<Transform> segments = new List<Transform>();
    private Vector2 input;

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        if (direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                input = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                input = Vector2.down;
            }
        }
        else if (direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                input = Vector2.right;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                input = Vector2.left;
            }
        }
    }

    private void FixedUpdate()
    {

        if (input != Vector2.zero)
        {
            direction = input;
        }

        for (int i = segments.Count - 1; i > 0; i--)
            segments[i].position = segments[i - 1].position;

        float x = Mathf.Round(transform.position.x) + direction.x;
        float y = Mathf.Round(transform.position.y) + direction.y;

        transform.position = new Vector2(x, y);
    }

    private void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    private void ResetState()
    {
        for (int i = 1; i < segments.Count; i++)
            Destroy(segments[i].gameObject);

        segments.Clear();
        segments.Add(transform);

        for (int i = 1; i < initialSize; i++)
            segments.Add(Instantiate(segmentPrefab));

        transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food")) Grow();
        else if (other.gameObject.CompareTag("Obstacle")) ResetState();
    }

}
