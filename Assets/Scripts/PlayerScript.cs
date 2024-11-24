using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    CharacterController cc;

    [SerializeField]
    GameObject dayLight;

    [SerializeField]
    UIDocument UID;

    Label healthUI;
    Label coinsUI;
    Label deathUI;

    float maxWalkingSpeed = 10.0f;
    float maxJumpingSpeed = 15.0f;

    float gravity = -50f;

    float xSpeed = 0;
    float ySpeed = 0;

    int jumpCount;
    bool doubleJumpBonus = false;

    float doubleJumpRate = 0.3f;
    float doubleJumpNext = 0f;

    ushort coinCount = 0;
    ushort health = 3;

    void Start()
    {
        cc = this.GetComponent<CharacterController>();
        healthUI = UID.rootVisualElement.Q<Label>("Health");
        coinsUI = UID.rootVisualElement.Q<Label>("Coin");
        deathUI = UID.rootVisualElement.Q<Label>("Death");
    }

    void Update()
    {
        Movement();
        UpdateUI();
    }

    // Player'ın hareket fonksiyonu
    void Movement()
    {
        // xSpeed Atanması
        xSpeed = maxWalkingSpeed * Input.GetAxis("Horizontal");

        // Double Jump Kontrolü
        if(doubleJumpBonus && (Time.time >= doubleJumpNext) && (jumpCount < 2) && Input.GetKey(KeyCode.Space))
        {
            ySpeed = maxJumpingSpeed; 
            jumpCount++;
        }

        // Yere değiyor mu
        if (cc.isGrounded)
        {
            jumpCount = 0;
            ySpeed = Mathf.Max(ySpeed, 0); // Hızı sıfırla ama negatif olmayacak şekilde

            if (Input.GetKey(KeyCode.Space))
            {
                doubleJumpNext = Time.time + doubleJumpRate;
                ySpeed = maxJumpingSpeed;
                jumpCount++;
            }
        }

        // Mantar etkisi sonrası yer çekimi sonucunda mantarın colliderının içine düşmeyi önlemek için minimum hız kontrolü
        if (ySpeed < 0 && !cc.isGrounded)
        {
            ySpeed = Mathf.Max(ySpeed, -30f); // Negatif hız sınırı
        }

        // ySpeed'in gravity'e göre güncellenmesi
        ySpeed += gravity * Time.deltaTime;

        // Hızların uygulanması
        cc.Move(new Vector3(xSpeed, ySpeed, 0) * Time.deltaTime);

        // Sağa ve sola döndüğünde yavaşça dönmesi
        transform.rotation = Quaternion.Euler(0, -90 * Input.GetAxis("Horizontal") + 180, 0);
    }

    // UI'ın güncellenmesi
    void UpdateUI()
    {
        healthUI.text = "HP: " + health + "x\u2764";
        coinsUI.text = "Coin: " + coinCount + "/128 \n" + (doubleJumpBonus == false ? "Tavşan: " + Mathf.Clamp(coinCount, 0, 50) + "/50" : "Çift Zıplama Aktif");
    }

    // Coin toplanınca CoinScript içinden çalıştırılacak fonksiyon
    public void CoinCollected()
    {
        coinCount++;
    }

    // Coin Getter fonksiyonu
    public ushort GetCoins()
    {
        return coinCount;
    }

    // Health Getter fonksiyonu
    public ushort GetHealth()
    {
        return health;
    }

    // Burger yenince BurgerScript içinden çalıştırılacak fonksiyon
    public void BurgerEated()
    {
        health++;
        if(health > 3)
            health = 3;
    }

    // Enemy ile temasa geçince EnemyScript içinden çalıştırılacak fonksiyon
    public void GetDamage()
    {
        health--;
        if(health <= 0)
        {
            health = 0;
            deathUI.style.display = DisplayStyle.Flex;
            Time.timeScale = 0;
        }
    }

    // Mushroom ile temasa geçince JumpingMushScript içinden çalıştırılacak fonksiyon
    public void SetYSpeed(float y)
    {
        ySpeed = y;
    }
    
    // Rabbit ile temasa geçince RabbitScript içinden çalıştırılacak fonksiyon
    public void SetDoubleJump()
    {
        doubleJumpBonus = true;
    }

    // Candy ile temasa geçince CandyScript içinden çalıştırılacak fonksiyon
    public void SetMaxXSpeed(float x)
    {
        maxWalkingSpeed = x;
        dayLight.GetComponent<DayNightCycleScript>().SetCycle(true);
        StartCoroutine(MakeSpeedNormal());
    }

    // 5 saniye sonra hız bonusunu kapatan fonksiyon
    IEnumerator MakeSpeedNormal()
    {
        yield return new WaitForSeconds(5.0f);
        dayLight.GetComponent<DayNightCycleScript>().SetCycle(false);
        maxWalkingSpeed = 10.0f;
    }
}
