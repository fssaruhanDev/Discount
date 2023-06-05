 # 👀 This repo is for .net core candidate selection. 👀 


Prosedür

Lütfen bu görev için bir github reposu açın ve adresini bizimle paylaşın.
Görevin .NET CORE ile tamamlanması beklenmektedir.
Veritabanı, kuyruk vb. 3.ncü parti araçları gerektiren görevlerde ürün/teknoloji sınırlaması yoktur.
Yapay zeka hariç dilediğiniz dış kaynaklardan faydalanabilirsiniz. Lütfen kullandığınız dış kaynak ve kodları görev içerisinde yorum olarak belirtin.
Görev sizlere iletildikten sonra 7 günlük bir zaman limitiniz bulunmaktadır.
Yazılım mimarisi kullanmak zorundasınız. Ancak dilediğiniz mimariyi kullanmakta serbestsiniz.
Commitleriniz ilerleyişi kontrol etmemiz için değerlidir.
Projeyi tamamen tamamlamanız gerekmemektedir. İlerlediğiniz kadarını da gönderebilirsiniz. Burada ki amacımız sizlerin clean code’a yaklaşımınız.

Docker

Görev geliştirmesi Docker platformu üzerinde ayağa kaldırılıp test edilebilmelidir.

1: Auth Sistemi - JWT Bearer Token
Kullanıcı, geçerli bir kullanıcı adı ve şifre ile oturum açabilmelidir.

Kullanıcı, oturum açarken geçersiz bir kullanıcı adı veya şifre girdiğinde hata almalıdır.

Kullanıcı, oturum açtıktan sonra alınan JWT Bearer Token'ı kullanarak diğer API isteklerini yapabilmelidir.

Kullanıcı, geçerli bir JWT Bearer Token kullanmadan API isteği yapmaya çalıştığında yetkilendirme hatası almalıdır.

Kullanıcı, JWT Bearer Token'ın süresi dolmuşsa otomatik olarak oturumdan çıkış yapmalıdır


2: Swagger Dökümantasyonu

1-Kullanıcı, uygulamaya eriştiğinde Swagger UI arayüzünü görmelidir.

2 -Kullanıcı, Swagger UI arayüzünde tüm API endpoint'lerini ve parametrelerini görüntüleyebilmelidir.

3 -Kullanıcı, Swagger UI arayüzünden herhangi bir API isteğini deneyebilmeli ve sonuçları görebilmelidir.

4 -Kullanıcı, Swagger UI arayüzünde herhangi bir hata durumunda uygun hata mesajını görmelidir.


3: Ürünler ve Sepet
 Kullanıcı, ürünleri ekleyebilmeli ve gerekli alanları doğru bir şekilde doldurmalıdır.

Kullanıcı ürünleri listeleyebilmeli

Kullanıcı ürünleri sepetine ekleyebilmeli

Kullanıcı eğer sepetine eklemeye çalıştığı ürünün stoğu yoksa hata almalı 


4: İndirimler API'si

Sepetine erişmek istediğinde sepette indirim hesaplaması yapılabilmelidir.

Sistem, sepetinin toplam tutarının 1000 TL ve üzerinde olduğunda %10 indirim uygulandığını doğrulamalıdır.

Sistem, 2 ID'li bir kategoriye ait 6 adet ürün satın alındığında bir tanesinin ücretsiz olarak verildiğini doğrulamalıdır.

Sistem, 1 ID'li bir kategoriden iki veya daha fazla ürün satın alındığında en ucuz ürüne %20 indirim uygulandığını doğrulamalıdır.

Sistem, gelecekte eklenebilecek yeni indirim kurallarını dikkate alarak doğru indirim hesaplamalarını yapabilmelidir.


