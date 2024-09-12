using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D myRB;
    private float limitSuperior;
    private float limitInferior;
    private Vector2 targetPosition;
    private bool isMoving;


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        SetMinMax();
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -bounds.y;
        limitSuperior = bounds.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy")
        {
            
        }

        if(other.tag == "Enemy")
        {
            
        }
    }
    private void FixedUpdate()
    {
        if (isMoving)
        {
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        Vector2 direction = (targetPosition - myRB.position).normalized;
        Vector2 movement = direction * speed * Time.deltaTime;

        myRB.MovePosition(myRB.position + movement);

        if (Vector2.Distance(myRB.position, targetPosition) < 0.1f)
        {
            myRB.position = targetPosition;
            isMoving = false;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPosition.z = 0; 
            targetPosition = (Vector2)touchPosition;
            Debug.Log("Tap");
            isMoving = true;
        }
    }

}
