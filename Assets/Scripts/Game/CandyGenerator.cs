using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CandyGenerator : MonoBehaviour
{
    public ObjectPool objectPool;
    public List<GameObject> candies = new List<GameObject>();
    public float time_to_create = 4f;
    private float actual_time = 0f;
    private float limitSuperior;
    private float limitInferior;
    public List<GameObject> actualCandies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SetMinMax();
    }

    // Update is called once per frame
    void Update()
    {
        actual_time += Time.deltaTime;
        if (time_to_create <= actual_time)
        {
            GameObject candy = objectPool.GetObject(candies[Random.Range(0, candies.Count)]);
            candy.transform.position = new Vector3(transform.position.x, Random.Range(limitInferior, limitSuperior), 0f);
            candy.GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, 0);
            actual_time = 0f;
        }
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -(bounds.y * 0.9f);
        limitSuperior = (bounds.y * 0.9f);
    }

    private void ManageCandy(CandyController candy_script)
    {

    }

    public void ManageCandy(CandyController candy_script, PlayerManager player_script)
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Devolver el objeto al pool
            objectPool.ReturnObject(other.gameObject);
        }
    }

}
