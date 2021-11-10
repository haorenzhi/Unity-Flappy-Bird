using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip scoresound;
    private AudioSource source;
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    public Sprite Wingsup;
    public Sprite Wingsdown;
    private Vector2 force;
    private Vector3 rotation;
    float lasttime;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        force = new Vector2(0, 800);
        rotation = new Vector3(0, 0, 15);
        spriteRenderer = GetComponent<SpriteRenderer>();
        lasttime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.angularVelocity = -30;

        if (Input.GetKeyDown(KeyCode.Space) && (Time.time - lasttime > 0.2f))
        {
            rigidBody.AddForce(force);
            lasttime = Time.time;
            rigidBody.MoveRotation(Quaternion.Euler(rotation));
            
        }

        if (Input.GetKeyDown(KeyCode.Escape) || IsTouchedScreen(gameObject))
        {
            ResetScene();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            spriteRenderer.sprite = Wingsdown;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            spriteRenderer.sprite = Wingsup;
        }
    }
    private void FixedUpdate()
    {
        
    }
    private void ResetScene()
    {
        Record.GetRecord();
        ScoreKeeper.ClearScore();
        var curtime = Time.time;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pipe")
        {
            ResetScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreKeeper.AddToScore(1);
        source.PlayOneShot(scoresound);
    }

    bool IsTouchedScreen(GameObject obj)
    {
        var position = Camera.main.WorldToScreenPoint(obj.transform.position);
        return position.y < 20 ||  position.y > Screen.height - 20;
    }

}
