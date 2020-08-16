using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20;
    public float panBorderThickness = 10;

    GameObject map;
    bool initialized;

    public void Init(GameObject map) 
    {
        this.map = map;
        initialized = true;
    }

    public void Reset() {
        this.map = null;
        this.transform.position = Vector3.zero;
        initialized = false;
    }

    void Update()
    {
        if (!initialized) {
            return;
        }

        Vector3 pos = transform.position;
        float amount = panSpeed * Time.deltaTime;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += amount;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.y -= amount;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += amount;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= amount;
        }

        float camHeight = 2f * Camera.main.orthographicSize;
        float camWidth = camHeight * Camera.main.aspect;
        float mapHeight = map.GetComponent<TilemapRenderer>().bounds.size.y;
        float mapWidth = map.GetComponent<TilemapRenderer>().bounds.size.x;

        float widthClamp = (mapWidth - camWidth) / 2;
        float heightClamp = (mapHeight - camHeight) / 2;

        pos.x = Mathf.Clamp(pos.x, -widthClamp, widthClamp);
        pos.y = Mathf.Clamp(pos.y, -heightClamp, heightClamp);



        transform.position = pos;
    }
}
