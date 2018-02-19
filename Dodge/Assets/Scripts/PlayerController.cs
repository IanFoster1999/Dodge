using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float rotationSpeed;
    public float speed;
    public bool enable = false;

    public GameObject[] barriers;
    public Vector2 lastBarrier;

    public int scoreToAdd = 1;
    private ScoreManager scoreManager;
    public Text instuction;

    void Start ()
    { 
        SpawnBarrier();
        instuction.enabled = true;
        scoreManager = FindObjectOfType<ScoreManager>();
    }
	

	void Update ()
    {

        if (enable == true)
        {
            Vector2 rotTarget = this.transform.position;

            if(Input.touchCount > 0)
            {
                rotTarget = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                rotTarget.y += 3;
            }
            else 
            {
                rotTarget.y += 3;
            }

            Vector2 direction = rotTarget - (Vector2)this.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                Begin();
        }
	}

    void Begin()
    {
        enable = true;
        instuction.enabled = false;
    }

    void Death()
    {
        Destroy(this.gameObject);
        Initiate.Fade("Test", Color.black, 2.0f);
    }

    void Goal()
    {
        speed = speed + (speed * 0.05f);

        scoreManager.scoreCount += scoreToAdd;

        SpawnBarrier();
    }

    void SpawnBarrier()
    {
        lastBarrier = new Vector2(Random.Range(-1.75f, 1.75f), lastBarrier.y += 5);
        Instantiate(barriers[Random.Range(0, barriers.Length)], lastBarrier, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Goal")
        {
            Goal();
        }

        if(other.tag == "Death")
        {
            Death();
        }
    }
}
