using UnityEngine;

public class BurgerScript : MonoBehaviour
{
    float scalingSpeed = 2f;
    float maxScale = 1.5f;
    float minScale = 0.8f;

    Vector3 originalScale;

    [SerializeField]
    GameObject player;
    PlayerScript ps;

    void Start()
    {
        originalScale = transform.localScale;
        ps = player.GetComponent<PlayerScript>();
        if(ps == null)
            Debug.LogError("Player Scriptine erişilemedi!!!");
    }

    void Update()
    {
        // Player'ın canı azken animasyonu aktif etmesi
        if(player.GetComponent<PlayerScript>().GetHealth() < 3)
            BurgerMovement();
    }

    // Burger'in büyüyüp küçülmesini sağlayan fonksiyon
    void BurgerMovement()
    {
        float scale = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(Time.time * scalingSpeed) + 1) / 2);
        transform.localScale = originalScale * scale;
    }

    // Burger'e dokunulduğunda can dolu değilse 1 can arttıran fonksiyon
    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            ps.BurgerEated();
            Destroy(this.gameObject);
        }
    }
}
