using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    CharacterController cc;

    [SerializeField]
    GameObject player;
    PlayerScript ps;

    float gravity = -50f;

    float xSpeed = -3f;
    float ySpeed = 0;

    float oldX = 0;
    ushort oldCoin = 0;

    void Start()
    {
        cc = this.GetComponent<CharacterController>();
        ps = player.GetComponent<PlayerScript>();
    }

    void Update()
    {
        EnemyMovement();
    }

    // Enemy'nin hareket fonksiyonu
    void EnemyMovement()
    {
        // Player her coin topladığında bütün Enemy'lerin hızını arttıran kod
        if(oldCoin < ps.GetCoins())
        {
            xSpeed *= 1.015f;
            oldCoin = ps.GetCoins();
        }

        // Yere değiyor mu
        if(cc.isGrounded)
            ySpeed = 0;
        
        // ySpeed'in gravity'e göre güncellenmesi
        ySpeed += gravity * Time.deltaTime;

        // Yön değiştirmesi için bir kontrol
        if(transform.position.x-oldX == 0)
        {
            xSpeed = -xSpeed;
            transform.Rotate(0, 0, 180);
        }
        oldX = transform.position.x;

        // xSpeed ve ySpeed'e göre Enemy objesinin hareket ettirilmesi
        cc.Move(new Vector3(xSpeed, ySpeed, 0) * Time.deltaTime);
    }

    // Enemy Player'a dokununca hasar veren fonksiyon
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            PlayerScript ps = hit.gameObject.GetComponent<PlayerScript>();

            if(ps != null)
            {
                ps.GetDamage();
                Destroy(this.gameObject);
            }
        }
    }

}
