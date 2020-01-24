using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public GameObject projectile;
    public float health = 150f;
    public float projectileSpeed = 10f;
    public float shotsPerSeconds = 0.5f;
    public int scoreValue = 150;
    private ScoreKeeper scoreKeeper;
    public AudioClip fireSound;
    public AudioClip deathSound;

    private void Start()
    {
       scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    private void Update()
    {
        float probability = Time.deltaTime * shotsPerSeconds;
        if(Random.value < probability)
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject missile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        Projectile missile = collision.gameObject.GetComponent<Projectile>();
        if(missile){
            health -= missile.getDamage();
            missile.Hit();
            if(health <= 0){
                Die();
            }
        }
    }

    private void Die(){
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(gameObject);
        scoreKeeper.Score(scoreValue);
    }
}
