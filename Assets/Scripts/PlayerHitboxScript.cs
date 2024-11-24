using UnityEngine;

public class PlayerHitboxScript : MonoBehaviour
{
    // Player'ın Hitbox'ının hasar veren fonksiyonu
    void OnTriggerStay(Collider collider)
    {
        if(Input.GetMouseButton(0) && collider.tag == "Enemy")
        {
            EnemyScript es = collider.GetComponent<EnemyScript>();

            if(es != null)
            {
                Destroy(collider.gameObject);
            }
        }
    }
}
