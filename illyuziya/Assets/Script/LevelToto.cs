using UnityEngine;

public class LevelToto : MonoBehaviour
{
    [SerializeField] public GameObject movingPlatform;
    [SerializeField] public GameObject firstWall;
    [SerializeField] public GameObject box;
    [SerializeField] public GameObject player;
    private GameObject movingPlatformInstance;
    private GameObject firstWallInstance;
    private GameObject boxInstance;

    public void Start()
    {
        movingPlatformInstance = Instantiate(movingPlatform);
        movingPlatformInstance.transform.parent = this.gameObject.transform;

        firstWallInstance = Instantiate(firstWall);
        firstWallInstance.transform.parent = this.gameObject.transform;
        firstWall.GetComponent<VisibilityChanger>().player = player;

        boxInstance = Instantiate(box);
        boxInstance.transform.parent = this.gameObject.transform;
    }

    public void ResetLevel()
    {
        Destroy(movingPlatformInstance);
        Destroy(firstWallInstance);
        Destroy(boxInstance);

        movingPlatformInstance = Instantiate(movingPlatform);
        movingPlatformInstance.transform.parent = this.gameObject.transform;

        firstWallInstance = Instantiate(firstWall);
        firstWall.GetComponent<VisibilityChanger>().player = player;
        firstWallInstance.transform.parent = this.gameObject.transform;

        boxInstance = Instantiate(box);
        boxInstance.transform.parent = this.gameObject.transform;

        player.transform.position = transform.position + new Vector3(0, 1, 0);
    }
}
