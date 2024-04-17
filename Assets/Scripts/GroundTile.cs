using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
     groundSpawner = GameObject.FindObjectOfType<GroundSpawner>(); 
     SpawnObstacle();  
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
}
