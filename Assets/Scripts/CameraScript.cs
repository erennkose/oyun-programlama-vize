using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    float maxX = 500f;
    float minX = -500f;

    void Start()
    {
        transform.Rotate(3,0,0);
    }

    // Oyuncuyu takip etmesi için oyuncunun konumuna göre kameranın pozisyonunu ayarlayan kod parçası
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, minX, maxX), player.transform.position.y + 4.9f, 11);
    }
}
