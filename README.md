# The Coin Crusade
Oyun Programlama dersi vizesi için geliştirmiş olduğumuz Unity oyunu 

## Oynanış Bilgileri ve Bağlantı
Oyunumuz; şövalyemiz Aaron'ın önünde bulunan macerada, önüne çıkan coinleri toplayıp, aynı zamanda karşısına çıkan kötü karakterlerle savaşmasını konu alan 2.5D platformer oyunudur.

### Oynanış
* **Hareket**: Karakterinizi A,D veya yön tuşlarıyla sağa sola hareket ettirin.
* **Zıplama**: Yüksek yerlere çıkmak ya da engelleri aşmak için Boşluk (Space) tuşuna basın. Ayrıca bazı yerlerde bulunan yeşil mantarlarla kendinizi daha yükseğe fırlatın!
* **Saldırı**: Düşmanları yenmek için Sol Tık (Mouse Left Click) ile saldırı yapın.
* **Düşmanlara Dikkat**: Yol boyunca sizi engellemek için yerleştirilmiş düşmanlar olacak. Düşmanlardan kaçınmak için dikkatli bir şekilde hareket edin ve gerektiğinde sol clickle düşmanı etkisiz hale getirin!
* **Bonuslar**: Önünüze çıkan şeker (Belli bir süre boyunca hızı arttırır), tavşan (Çift zıplama özelliğini aktive eder), burger (Canınızı 1 arttırır) gibi bonuslarla güçlenin!
* **Altın Toplama**: 50 adet altına ulaştıktan sonra haritada bulunan tavşanı bulun ve çift zıplamanın tadını çıkarın! Unutmayın haritanın her yerine saçılmış şekilde altınlar bulunmaktadır!
* **Bitiş**: Lolipopa ulaşıp oyunu kazanın!

### Oyun İçi Nesneler
![Burger](./readme-pictures/Collectables/burger.png)
![Candy](./readme-pictures/Collectables/candy.png)
![Coin](./readme-pictures/Collectables/coin.png)
![Lollipop](./readme-pictures/Collectables/lollipop.png)
![Rabbit](./readme-pictures/Collectables/rabbit.png)
![Enemy](./readme-pictures/Collectables/enemy.png)

### Oyunumuzun Haritası:
![Harita](./readme-pictures/map.png)

Oyun Bağlantısı: https://erenkose75.itch.io/the-coin-crusade

## Üyelerin Kodladığı Aksiyonlar
### Eren Köse - 22360859075
* Coin nesnenin oyuncunun 10 birim yakınındayken kendi ekseni etrafında dönmesi ve yukarı aşağı haraket etmesi CoinScript.cs: 25
* Player nesnesinin Coin nesnesiyle teması sonucu Coin nesnesinin toplanması ve Player scriptindeki Coin sayacının arttırılması CoinScript.cs: 32
* Burger nesnesinin oyuncunun canı 3'den küçükse olduğu yerde büyüyüp küçülmesi BurgerScript.cs: 
* Player nesnesinin Burger nesnesiyle teması sonucu Burger nesnesinin toplanıp Player scriptindeki Player canının arttırılması BurgerScript.cs: 26, PlayerScript.cs: 77
* Candy nesnesinin Player tarafından alındıktan sonra 10 saniye boyunca X ve Y eksenlerinde sinüsel haraket (Titreşim) etmesi
* Player nesnesinin Candy nesnesiyle teması sonucu hızının artması

### Eren Güreli - 222360859016
* Player nesnesinin A,D veya yön tuşlarıyla X ekseni boyunca haraket etmesi
* Player nesnesinin Boşluk(Space) tuşu ile zıplaması ve yerçekimi etkisiyle yere düşmesi
* Player nesnesinin sol click ile saldırırması
* Enemy nesnesinin hareketleri
* Enemy nesnesinine çarpıldığında oyuncunun canının azalması
* Enemy nesnesinin hızının coin sayısı başına 1.015 kat artması
* Oyuncu nesnesinin Lollipop nesnesiyle teması sonucu oyunun bitmesi

### Mustafa Aykut - 22360859028
* Kameranın oyuncuyu takip etmesi
* Candy nesnesi alındıktan sonra 10 saniye boyunca gece - gündüz döngüsünün yapılması
* Double Jump mekaniği
* Yeşil zıplama mantarına basılınca oyuncunun havaya fırlaması
* Player nesnesinin Candy nesnesiyle temasından sonra Candy nesneninin Disable olup 10 saniye sonra yeniden Enable olması
* Oyuncu nesnesiyle Rabbit nesnesinin teması sonucu Rabbit nesnesinin toplanıp Double Jump özelliğinin aktif edilmesi
* Rabbit nesnesinin 50 coin toplandıktan sonra olduğu yerde zıplaması ve toplanabilir hâle gelmesi


## Referanslar
* Çevre Assetleri: https://fertile-soil-productions.itch.io/modular-platformer
* Karakter Assetleri: https://kaylousberg.itch.io/kaykit-adventurers
* Burger Assetleri: https://www.fab.com/listings/e4579c6c-2e83-460e-8295-621c843852d5
* Şeker Asseti: https://sketchfab.com/3d-models/cute-candy-f6e5e6e53988414185ca010572a54563
* Tavşan Asseti: https://assetstore.unity.com/packages/3d/characters/animals/white-rabbit-138709
