using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    float rotationSpeed = 100.0f;

    float currY;

    void Start()
    {
        currY = transform.position.y;
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) <= 10)
            CoinMovement();
    }
    
    // Coinin dönüşü ve hafif hareket fonksiyonu
    void CoinMovement()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        float newY = (Mathf.Sin(Time.time * 2) / 4 + currY);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    // Coin'e dokununca coin sayacını arttırıp Coin'i yok eden fonksiyon
    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            PlayerScript ps = collider.GetComponent<PlayerScript>();

            if(ps != null)
            {
                ps.CoinCollected();
                Destroy(this.gameObject);
            }
        }
    }
}
