# Bu proje, Model-View-Controller (MVC) kullanılarak Admin Paneli destekli CV yönetim sistemi geliştirilmiştir

## Özellikler

- AdminLTE kullanarak güçlü template desteği
- Dinmaik veriler 
- Controller ile sistemin yönetimi
- Partial View kullanarak yönetimin kolaylaştırılması   
- Repository design pattern kullanarak clean code yazımı
- boostrap ile responsive tasarım

## MVC Prensipleri

- **Model:** Uygulamanın veri yapısını temsil eder (burada basit sınıflar ve listeler).  
- **View:** Kullanıcıya veri gösteren arayüz.  
- **Controller:** Kullanıcı isteklerini işler, statik verileri View’a gönderir.

## Kullanılan Teknolojiler

- C#  
- ASP.NET MVC  
- Razor View Engine
- Repository design pattern
- AdminLTE

## Nasıl Çalıştırılır?

Projeyi klonlayın:

git clone https://github.com/kullaniciadi/proje-adi.git
cd proje-adi

Veritabanını oluşturun:

SQL Server Management Studio'yu açın.

Yeni bir veritabanı oluşturun (örnek: MyDb).

Database/CreateSchema.sql dosyasını çalıştırarak tablo yapısını oluşturun.

Bağlantı dizesini ayarlayın (Web.config içinde):

<connectionStrings>
  <add name="MyDbEntities" connectionString="metadata=res://*/Models.Model1.csdl|res://*/Models.Model1.ssdl|res://*/Models.Model1.msl;provider=System.Data.SqlClient;provider connection string='data source=.;initial catalog=MyDb;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework'" providerName="System.Data.EntityClient" />
</connectionStrings>

📌 MyDbEntities ve Model1 projenize göre değişebilir.




Projeyi çalıştırın:

Visual Studio ile .sln dosyasını açın.

Gerekirse: Tools > NuGet Package Manager > Restore NuGet Packages




![image](https://github.com/user-attachments/assets/efcb7144-9cb0-4d7a-870e-08df9acca3ce)
![image](https://github.com/user-attachments/assets/f9c4b242-7f1e-4531-b4e0-613de03b6ca3)
![image](https://github.com/user-attachments/assets/f221471c-e057-4489-8bfe-a8eb247962a7)
![image](https://github.com/user-attachments/assets/21f863bb-24e9-4db4-9ebd-9cf3552afc8a)
![image](https://github.com/user-attachments/assets/74481349-cf03-4270-9279-3b474b3c5dcc)
![image](https://github.com/user-attachments/assets/7aa01742-bcce-4308-95a3-c652f148aecb)
![image](https://github.com/user-attachments/assets/2297459c-148c-4acc-9c12-b2e1637e6c28)
![image](https://github.com/user-attachments/assets/1475713b-6d09-4de5-b469-6839463154c8)

