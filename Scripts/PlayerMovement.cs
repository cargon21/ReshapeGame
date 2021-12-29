using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    InputMaster controls;
    public float speed;
    string direction = "Right";
    string size = "Medium";
    public float growScale = 1.2f;
    public float shrinkScale = 1f;
    public float baseSpeed = 1f;
    public float deathDepth = -30f;
    public Text attempts;
    public static int attemptsNum = 1;
    bool increased = false;
    public Rigidbody rb;


    void Awake()
    {
        // Detects controller inputs
        controls = new InputMaster();
        controls.Player.Right.performed += ctx => GoRight();
        controls.Player.Left.performed += ctx => GoLeft();
        controls.Player.Grow.performed += ctx => Grow();
        controls.Player.Shrink.performed += ctx => Shrink();
    }

    // Start is called before the first frame update
    void Start()
    {
        attempts.text = "Attempts: " + attemptsNum.ToString();
    }

    public void OnEnable()
    {
        controls.Enable();
    }

    public void OnDisable()
    {
        controls.Disable();
    }

    // Excecutes when the player wants to turn right
    void GoRight()
    {
        transform.RotateAround(transform.position, Vector3.up, 90);

        if (direction == "Forwards")
        {
            direction = "Right";
        }
        else if (direction == "Right")
        {
            direction = "Backwards";
        }
        else if (direction == "Backwards")
        {
            direction = "Left";
        }
        else if (direction == "Left")
        {
            direction = "Forwards";
        } 
    }

    // Excecutes when the player wants to turn left
    void GoLeft()
    {
        transform.RotateAround(transform.position, Vector3.up, -90);

        if (direction == "Forwards")
        {
            direction = "Left";
        }
        else if (direction == "Left")
        {
            direction = "Backwards";
        }
        else if (direction == "Backwards")
        {
            direction = "Right";
        }
        else if (direction == "Right")
        {
            direction = "Forwards";
        }
    }

    // Excecutes when the player wants to grow
    void Grow()
    {
        if (size == "Small")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            transform.localScale += new Vector3(growScale, growScale + 0.2f, growScale - 3);
            size = "Medium";
        }
        else if (size == "Medium")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
            transform.localScale += new Vector3(growScale + 3, growScale + 0.3f, growScale);
            size = "Large";
        }

        else if (size == "Large")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y -0.6f, transform.position.z);
            transform.localScale += new Vector3(-2 * shrinkScale - 3, (-2 * shrinkScale) - 0.5f, -2 * shrinkScale + 3);
            size = "Small";
        }
    }

    // Excecutes when the player wants to shrink
    void Shrink()
    {
        if (size == "Large")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
            transform.localScale += new Vector3(-shrinkScale - 3, -shrinkScale - 0.3f, -shrinkScale);
            size = "Medium";
        }
        else if (size == "Medium")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
            transform.localScale += new Vector3(-shrinkScale, -shrinkScale - 0.2f, -shrinkScale + 3);
            size = "Small";
        }

        else if (size == "Small")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.65f, transform.position.z);
            transform.localScale += new Vector3(2 * growScale + 3, (2 * growScale) + 0.5f, 2 * growScale - 3);
            size = "Large";
        }
    }

    void FixedUpdate()
    {
        // Changes speed based on the size of the player
        if (size == "Small")
        {
            baseSpeed = 1.25f;
        }
        else if (size == "Medium")
        {
            baseSpeed = 1f;
        }
        else if (size == "Large")
        {
            baseSpeed = 0.75f;
        }

        // Moves the player based on position
        if (direction == "Forwards")
        {
            transform.position += Vector3.forward * Time.deltaTime * speed * baseSpeed;
        }
        else if (direction == "Right") {
            transform.position += Vector3.right * Time.deltaTime * speed * baseSpeed;
        }
        else if (direction == "Backwards") {
            transform.position += -Vector3.forward * Time.deltaTime * speed * baseSpeed;
        }
        else if (direction == "Left") {
            transform.position += - Vector3.right * Time.deltaTime * speed * baseSpeed;
        }

        // Detects if the player has fallen off the map
        if(transform.position.y <= deathDepth)
        {
            OnDisable();
            attemptsNum += 1;
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    // Detects if the player collides with an object
    void OnCollisionEnter(Collision obj)
    {
        if(obj.collider.tag == "Wall")
        {
            OnDisable();
            if (!increased) // Bc when the player collides with tunnel pillars, it increases by 2
            {
                attemptsNum += 1;
                increased = true;
            }
            FindObjectOfType<GameManager>().GameOver();
        }

        if (obj.collider.tag == "Completed")
        {
            OnDisable();
            attemptsNum = 1;
            FindObjectOfType<GameManager>().LevelComplete();
        }

        /*
        Bounce Wall feature that could be implemented
        if(obj.collider.tag == "BounceWall" )
        {
            rb.AddForce(0, 3000, 0);
        }
        */
    } 
}
