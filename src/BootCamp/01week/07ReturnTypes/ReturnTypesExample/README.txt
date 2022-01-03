# Sanal Pos Entegrasyon Projesi

### Açýklama:

Sanal pos entegrasyon projesi ödeme saðlayýcýlarý veya bankalarla entegrasyon kurup ödeme ve ödeme sonrasý iþlemleri yapabilmemizi saðlamaktadýr.

#### Entegrasyonlarda aþaðýdaki iþlevler yer almaktadýr;

* **auth**: Müþteriden ücret çekilmesini saðlamaktadýr.
* **refund**: Baþarýyla gerçekleþmiþ bir ödemenin müþteriye iadesini saðlamaktadýr.
* **fetchRedirectionUrl**: Müþterinin ödeme saðlayýcýsýnýn sayfasýna yönlenebileceði URL’i alabilmeyi saðlar. Bu URL ile müþteri ödeme saðlayýcýnýn sayfasýna yönelir. Ödemeyi bu sayfada gerçekleþtirir.

Yukarýda saydýðýmýz iþlemler projede her ödeme saðlayýcý için ayrý ayrý entegre edilir. Her ödeme saðlayýcý veya banka için ayrý entegrasyon yapýlýr. Yapýlan entegrasyonlarý kullanabilmek için REST katmaný oluþturulmuþtur. Verilen Dotnet projesinde “Sofort”, “Est” gibi ödeme saðlayýcýlara ait entegrasyonlar **tamamlanmýþ durumdadýr.**

#### Projedeki Ödeme Saðlayýcýlar ve Bankalar;

* **Adyen**: Yurtdýþý ödemelerinde ödeme ile ilgili iþlemlerin yapýlabilmesini saðlayan ödeme saðlayýcýdýr. Sofort ve Paypal isminde iki ödeme yöntemi sunmaktadýr.

* **Est**: Kartlý iþlemler yoluyla ödeme ile ilgili iþlemlerin yapýlabilmesini saðlayan ödeme saðlayýcýdýr.

* **TyBank**: Kartlý iþlemler yoluyla ödeme ile ilgili iþlemlerin yapýlabilmesini saðlayan bankadýr.

#### Projede aþaðýdaki iþlemler tamamlanmýþtýr;

* Est ödeme saðlayýcýsýna ait “auth”, “refund” iþlevleri entegre edilmiþtir. Est saðlayýcýsý “fetchRedirectionUrl” iþlevi desteklememektedir.
* Adyen ödeme saðlayýcýsý altýndaki “Sofort” ödeme yöntemine ait “refund” ve “fetchRedirectionUrl” iþlevleri entegre edilmiþtir. “Sofort” ödeme yöntemi “auth” iþlevi desteklememektedir.
* Tamamlanan entegrasyonlara ait Request/Response sýnýflarý hazýrlanmýþtýr.
* Yapýlan sanal pos entegrasyonlarýný kullanabilmek için REST katmaný hazýrlanmýþtýr.
* Tamamlanan entegrasyonlara ait birim testleri yazýlmýþtýr.


#### Yapýlmasý istenenler:

1 - Paypal ödeme yöntemine ait “PaypalPosService” sýnýfýndaki “fetchRedirectionUrl” iþlevinin entegrasyonu sizin tarafýnýzdan tamamlanmalýdýr.
“RedirectUrlRequest” veri modelindeki alanlar doldurulur. “https://www.adyen.com/api/v1/sofort/redirection/url” adresine HTTP POST isteði atýlýr.
Gelen cevapta “url”, “rawBody” alanlarý yer almaktadýr.

2 - TyBank’a ait “TyBankPosService” sýnýfýndaki “refund” iþlevi sizin tarafýnýzdan tamamlanmalýdýr.
“refund” iþleminde “RefundRequest” veri modelindeki alanlar doldurulur. “https://www.tybank.com/pos/api/v1/tybank/refund ” adresine HTTP POST isteði atýlmalýdýr.
Gelen cevabý “TyBankRefundResponse” ile modelleyiniz. Sýnýfa ait alanlar aþaðýdaki gibidir.
“response”, “errorCode”, “message”

3 - TyBank’a ait “TyBankPosService” sýnýfýndaki “auth” iþlevi sizin tarafýnýzdan tamamlanmalýdýr.
“auth” iþleminde “AuthRequest” veri modelindeki alanlar doldurulur. “https://www.tybank.com/pos/api/v1/tybank/auth ” adresine HTTP POST isteði atýlmalýdýr.
Gelen cevabý “TyBankAuthResponse” ile modelleyiniz. Sýnýfa ait alanlar aþaðýdaki gibidir.
“response”, “authCode”, “transactionId”, “errMsg”

4 - Projede önceden yazýlmýþ kodlar da dahil olmak üzere SOLID, Clean Code, OOP prensipleri açýsýndan her türlü refactoring iþlemini gerçekleþtirmeniz beklenmektedir.

5 - Projede yeni yapýlacak entegrasyonlara ait birim testlerini yazmanýz gerekmektedir.
