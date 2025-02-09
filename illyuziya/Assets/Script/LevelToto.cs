using UnityEngine;

public class LevelToto : MonoBehaviour
{
    [SerializeField] public GameObject movingPlatform;
    [SerializeField] public GameObject firstWall;
    [SerializeField] public GameObject secondWall;
    [SerializeField] public GameObject box;
    [SerializeField] public GameObject box2;
    [SerializeField] public GameObject player;
    private GameObject movingPlatformInstance;
    private GameObject firstWallInstance;
    private GameObject secondWallInstance;
    private GameObject boxInstance;
    private GameObject box2Instance;

    public void Start()
    {
        movingPlatformInstance = Instantiate(movingPlatform);
        movingPlatformInstance.transform.parent = this.gameObject.transform;
        movingPlatformInstance.transform.position += this.gameObject.transform.position;

        firstWallInstance = Instantiate(firstWall);
        firstWallInstance.transform.parent = this.gameObject.transform;
        firstWall.GetComponent<VisibilityChanger>().player = player;
        firstWallInstance.transform.position += this.gameObject.transform.position;

        secondWallInstance = Instantiate(secondWall);
        secondWallInstance.transform.parent = this.gameObject.transform;
        secondWallInstance.GetComponent<VisibilityChanger>().player = player;
        secondWallInstance.transform.position += this.gameObject.transform.position;

        boxInstance = Instantiate(box);
        boxInstance.transform.parent = this.gameObject.transform;
        boxInstance.GetComponent<ShapeChanger>().player = player;
        boxInstance.transform.position += this.gameObject.transform.position;

        box2Instance = Instantiate(box2);
        box2Instance.transform.parent = this.gameObject.transform;
        box2Instance.GetComponent<ShapeChanger>().player = player;
        box2Instance.transform.position += this.gameObject.transform.position;
    }

    public void ResetLevel()
    {
        Destroy(movingPlatformInstance);
        Destroy(firstWallInstance);
        Destroy(secondWallInstance);
        Destroy(boxInstance);
        Destroy(box2Instance);

        movingPlatformInstance = Instantiate(movingPlatform);
        movingPlatformInstance.transform.parent = this.gameObject.transform;
        movingPlatformInstance.transform.position += this.gameObject.transform.position;

        firstWallInstance = Instantiate(firstWall);
        firstWall.GetComponent<VisibilityChanger>().player = player;
        firstWallInstance.transform.parent = this.gameObject.transform;
        firstWallInstance.transform.position += this.gameObject.transform.position;

        secondWallInstance = Instantiate(secondWall);
        secondWallInstance.GetComponent<VisibilityChanger>().player = player;
        secondWallInstance.transform.parent = this.gameObject.transform;
        secondWallInstance.transform.position += this.gameObject.transform.position;

        boxInstance = Instantiate(box);
        boxInstance.transform.parent = this.gameObject.transform;
        boxInstance.GetComponent<ShapeChanger>().player = player;
        boxInstance.transform.position += this.gameObject.transform.position;

        box2Instance = Instantiate(box2);
        box2Instance.transform.parent = this.gameObject.transform;
        box2Instance.GetComponent<ShapeChanger>().player = player;
        box2Instance.transform.position += this.gameObject.transform.position;

        player.transform.position = transform.position + new Vector3(0, 1, 0);
    }
}
