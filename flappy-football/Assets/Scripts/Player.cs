
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    /// <summary>
    /// public properties I can access and edit through Unity
    /// </summary>
    public float gravity = -9.8f;
    public float strength = 5f;
    public AudioSource ballSound;
    public AudioSource whistle;

    private void Update()
    {
        //if the user clicks the space button or their left mouse the ball will go upwards
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
            ballSound.Play();
        }

       //to make sure that the ball is constantly being pulled by gravity, not doing this step makes the ball go upwards indefiniatly.
        direction.y += gravity * Time.deltaTime;
        
        transform.position += direction * Time.deltaTime;

      //physics need to understand

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            FindObjectOfType<GameManager>().GameOver();
        } else if (other.gameObject.CompareTag("scoring") || other.gameObject.CompareTag("friend"))
        {
            FindObjectOfType<GameManager>().IncreaseScore();
            whistle.Play();
        }
       
    }



    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        position.x = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
}
