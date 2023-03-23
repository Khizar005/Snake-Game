using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Food : MonoBehaviour
{
    public static Food instance;
    [SerializeField] private BoxCollider2D gridArea;
    [SerializeField] private TextMeshProUGUI scoreText;
    [HideInInspector] public int scoreToAdd;

    private void Start()
    {
        scoreText.text = "Score: " + scoreToAdd;
        instance = this;
        RandomizePosition();
    }
    public void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), transform.position.z);
    }

    public void AddScore()
    {
        scoreToAdd++;
        scoreText.text = "Score: " + scoreToAdd;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RandomizePosition();
        }
       
    }
}
