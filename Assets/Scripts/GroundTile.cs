using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public Transform spawnPos1;
    public Transform spawnPos2;
    public Transform[] obstacleSpawn1; 

    [SerializeField]
    private int aidNumber;
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

    public GameObject[] ObstaclePrefab;

    void SpawnObstacle(){
        //Scegliere un punto a caso in cui creare l'ostacolo
    //int obstacleSpawnIndex1 = Random.Range(2,5);
    int obstacleSpawnIndex2 = Random.Range(5,8);
    //Transform spawnPoint1 = transform.GetChild(obstacleSpawnIndex1).transform;
    Transform spawnPoint2 = transform.GetChild(obstacleSpawnIndex2).transform;
 
        //creare l'ostacolo nella posizione
        //int rnd1 = Random.Range(0,ObstaclePrefab.Length);
        int rnd2 = Random.Range(0,ObstaclePrefab.Length);
    //Instantiate(ObstaclePrefab[rnd1], spawnPoint1.position, Quaternion.identity, transform);
    Instantiate(ObstaclePrefab[rnd2], spawnPoint2.position, Quaternion.identity, transform);

    int spawnPositionIndex1 = Random.Range(0, obstacleSpawn1.Length);
    int spawnPositionIndex2;

    int rnd = Random.Range(0, ObstaclePrefab.Length);
    Instantiate(ObstaclePrefab[rnd],obstacleSpawn1[spawnPositionIndex1].position, Quaternion.identity, transform);
    do{
        spawnPositionIndex2 = Random.Range(0, obstacleSpawn1.Length);
    }while(spawnPositionIndex1 == spawnPositionIndex2);
    Instantiate(ObstaclePrefab[rnd], obstacleSpawn1[spawnPositionIndex2].position, Quaternion.identity, transform);




    }

    public GameObject[] coinPrefab;

        void SpawnCoins()
        {
            
                for(int i=0; i< aidNumber; i++){
                    int rnd = Random.Range(0, coinPrefab.Length);
               //     Vector3 spawnPos = new Vector3(Random.Range(spawnPos1.position.x , spawnPos2.position.x), gameObject.transform.position.y+2, Random.Range(spawnPos1.position.z, spawnPos2.position.z));
               // GameObject temp  = Instantiate(coinPrefab[rnd],  spawnPos, Quaternion.identity);
               GameObject temp  = Instantiate(coinPrefab[rnd],  transform);
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

                point.y = 2;
                return point;
        }
}
