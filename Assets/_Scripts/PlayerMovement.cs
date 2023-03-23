using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segmant;

    [SerializeField] Transform snakeTailPrefab;
    private bool isPaused = false;

    private void Start()
    {
        _segmant = new List<Transform>();
        _segmant.Add(transform);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _direction = Vector2.left;

        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            _direction = Vector2.down;

        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _direction = Vector2.right;

        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _direction = Vector2.up;

        }
    }

    private void FixedUpdate()
    {
        for (int i = _segmant.Count - 1; i > 0; i--)
        {
            _segmant[i].position = _segmant[i - 1].position;
        }

        transform.position = new Vector3(
          Mathf.Round(transform.position.x + _direction.x),
          Mathf.Round(transform.position.y + _direction.y),
          0.0f);
    }

    public void GrowSnake()
    {
        Transform segmant = Instantiate(snakeTailPrefab);
        segmant.position = _segmant[_segmant.Count - 1].position;

        _segmant.Add(segmant);
    }
    public void Pause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            GrowSnake();
            Food.instance.AddScore();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


}
