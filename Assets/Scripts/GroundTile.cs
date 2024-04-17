using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
     groundSpawner = GameObject.FindObjectOfType<GroundSpawner>(); 
     SpawnObstacle(); 
     SpawnCoins(); 
    }

private void OnTriggerExit(Collider other){
    groundSpawner.SpawnTile();
    Destroy(gameObject, 2);
}
    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject ObstaclePrefab;

    void SpawnObstacle(){
        //Scegliere un punto a caso in cui creare l'ostacolo
    int obstacleSpawnIndex = Random.Range(2,5);
    Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
 
        //creare l'ostacolo nella posizione
    Instantiate(ObstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public GameObject coinPrefab;

        void SpawnCoins()
        {
            int coinsToSpawn = 10;
                for(int i=0; i< coinsToSpawn; i++){
               GameObject temp  = Instantiate(coinPrefab);
               temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
                }
        }

        Vector3 GetRandomPointInCollider(Collider collider)
        {
            Vector3 point = new Vector3(
                Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                Random.Range(collider.bounds.min.z, collider.bounds.max.z)
                );
                if(point!= collider.ClosestPoint(point)) {
                    point = GetRandomPointInCollider(collider);
                }

                point.y = 1;
                return point;
        }
}
