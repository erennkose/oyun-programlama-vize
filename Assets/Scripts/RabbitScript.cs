using System;
using UnityEngine;

public class RabbitScript : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    PlayerScript ps;

    ushort coinPrice = 50;
    float currY;

    void Start()
    {
        currY = transform.position.y;
        ps = player.GetComponent<PlayerScript>();
        if(ps == null)
            Debug.LogError("Player Script bulunamadı!!!");
    }

    void Update()
    {
        // 50 Coinimiz olunca animasyonu aktif eden kod
        if(ps.GetCoins() >= coinPrice)
            RabbitMovement();
    }

    // Rabbit'in yerdeki animasyon fonksiyonu
    void RabbitMovement()
    {
        // Sinüste negatif kısma düşülmemesi için mutlak değerle alt kısımların yukarı çıkarılması
        float newY = (Math.Abs(Mathf.Sin(Time.time*10))/2 + currY);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    // Rabbit'e temas edince double jump özelliğini aktif eden fonksiyon
    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player" && player.GetComponent<PlayerScript>().GetCoins() >= coinPrice)
        {
            ps.SetDoubleJump();
            Destroy(this.gameObject);
        }
    }
}
