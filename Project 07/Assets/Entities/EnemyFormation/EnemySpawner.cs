using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float spawnDelay = 0.5f;
    public float width = 10f;
    public float height = 5f;
    private bool movingRight = true;
    public float speed = 5f;
    private float xmax;
    private float xmin;

	void Start ()
    {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xmax = rightEdge.x;
        xmin = leftEdge.x;
        SpawnUntilFull();
	}

    void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if(freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    void Update ()
    {
		if(movingRight){
            transform.position += Vector3.right * speed * Time.deltaTime;
        }else{
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        float rightEdgeOfFormation = transform.position.x + (0.5f * width);
        float leftEdgeOfFormation = transform.position.x - (0.5f * width);

        if ( leftEdgeOfFormation < xmin ){
            movingRight = true;
        }
        else if( rightEdgeOfFormation > xmax ){
            movingRight = false;
        }

        if(AllMembersAreDead()){
            SpawnUntilFull();
        }
	}

    Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObj in transform)
        {
            if (childPositionGameObj.childCount == 0)
            {
                return childPositionGameObj;
            }
        }
        return null;
    }

    bool AllMembersAreDead()
    {
        foreach(Transform childPositionGameObj in transform)
        {
            if(childPositionGameObj.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }
}
