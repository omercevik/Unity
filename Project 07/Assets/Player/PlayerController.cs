using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 15.0f;
    public float padding = 1.0f;
    public float projectileSpeed;
    public float firingRate = 0.2f;
    public float health = 250f;
    public GameObject projectile;
    public AudioClip fireSound;
    public Text myText;
    float xmin;
    float xmax;

    void Start ()
    {
        myText.text = health.ToString();
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
    }

    private void Fire()
    {
        Vector3 offset = new Vector3(0f, 1f, 0f);
        GameObject beam = Instantiate(projectile, transform.position + offset, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    void Update ()
    {
        myText.text = health.ToString();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, firingRate);
        }

		if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime; 
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile missile = collision.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            health -= missile.getDamage();
            missile.Hit();
            if (health <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        man.LoadLevel("Win Screen");
        Destroy(gameObject);
    }
}
