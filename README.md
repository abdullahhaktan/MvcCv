# CVManagementSystem

[TR]

**Model-View-Controller (MVC) Kullanılarak Geliştirilmiş Dinamik CV Yönetim Sistemi**

[![ASP.NET MVC](https://img.shields.io/badge/Framework-ASP.NET_MVC-602C78.svg)](https://dotnet.microsoft.com/apps/aspnet/mvc)
[![C#](https://img.shields.io/badge/Language-C%23-blue.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![GitHub repo size](https://img.shields.io/github/repo-size/kullaniciadi/proje-adi)](https://github.com/kullaniciadi/proje-adi)

---

## 💻 Proje Hakkında

---

## ✨ Temel Özellikler

### Mimari ve Tasarım
* **MVC (Model-View-Controller)** prensipleri temel alınarak geliştirilmiştir.
* **Admin Paneli** desteği ile dinamik içerik yönetimi.
* **AdminLTE** şablonu kullanılarak modern ve güçlü bir arayüz sağlanmıştır.
* **Bootstrap** ile tam **responsive tasarım** desteği.
* **Repository Design Pattern** kullanılarak **Clean Code (Temiz Kod)** yaklaşımı benimsenmiştir.

### İşlevsellik
* Yönetimi kolaylaştırmak için **Partial View** bileşenleri kullanılmıştır.
* **Controller** katmanı ile tüm sistem yönetimi ve iş mantığı kontrolü.
* **Dinamik veriler** ile çalışan, kolayca güncellenebilir CV içeriği.

### Kullanılan Teknolojiler
* **C#**
* **ASP.NET MVC**
* **Razor View Engine**
* **AdminLTE**

---

## 📐 MVC Prensipleri

* **Model:** Uygulamanın veri yapısını ve iş kurallarını temsil eder (Basit sınıflar ve listeler).
* **View:** Kullanıcıya verileri gösteren arayüz katmanıdır.
* **Controller:** Kullanıcı isteklerini işler, iş mantığını yürütür ve statik/dinamik verileri View katmanına gönderir.

---

## 🚀 Nasıl Çalıştırılır?

Bu proje, yerel bir **SQL Server** veritabanı kurulumu gerektirir.

1.  **Projeyi Klonlama:**
    ```bash
    git clone [https://github.com/kullaniciadi/proje-adi.git](https://github.com/kullaniciadi/proje-adi.git)
    cd proje-adi
    ```

2.  **Veritabanını Kurma:**
    * **SQL Server Management Studio'yu** açın.
    * Yeni bir veritabanı oluşturun (Örneğin: `MyDb`).
    * Projenin içindeki **`Database/CreateSchema.sql`** dosyasını bu veritabanında çalıştırarak tablo yapısını oluşturun.

3.  **Bağlantı Dizesini Ayarlama:**
    * **`Web.config`** dosyasını açın ve aşağıdaki `connectionString` alanını kendi veritabanı ayarlarınıza göre güncelleyin.
        ```xml
        <connectionStrings>
          <add name="MyDbEntities" connectionString="data source=.;initial catalog=MyDb;integrated security=True;MultipleActiveResultSets=True;" providerName="System.Data.SqlClient" />
        </connectionStrings>
        ```
    * *(Not: `MyDbEntities` ve bağlantı dizesindeki `initial catalog` (MyDb) projenizin adlandırma standartlarına göre değişebilir.)*

4.  **Projeyi Başlatma:**
    * **Visual Studio** ile `.sln` dosyasını açın.
    * Gerekliyse: `Tools > NuGet Package Manager > Restore NuGet Packages` adımlarını uygulayın.
    * Projeyi çalıştırın (F5).

---
---

[EN]

# CVManagementSystem

**Dynamic CV Management System Developed Using Model-View-Controller (MVC)**

---

## 💻 About the Project

---

## ✨ Core Features

### Architecture and Design
* Developed based on **MVC (Model-View-Controller)** principles.
* Includes **Admin Panel** support for dynamic content management.
* A modern and robust interface is provided using the **AdminLTE** template.
* Full **responsive design** support with **Bootstrap**.
* **Clean Code** approach is adopted by utilizing the **Repository Design Pattern**.

### Functionality
* **Partial View** components are used to simplify management.
* **Controller** layer handles all system management and business logic control.
* Easily updatable CV content powered by **dynamic data**.

### Technologies Used
* **C#**
* **ASP.NET MVC**
* **Razor View Engine**
* **AdminLTE**

---

## 📐 MVC Principles

* **Model:** Represents the application's data structure and business rules (Simple classes and lists in this project).
* **View:** The interface layer that displays data to the user.
* **Controller:** Processes user requests, executes business logic, and passes static/dynamic data to the View layer.

---

## 🚀 How to Run

This project requires a local **SQL Server** database setup.

1.  **Cloning the Project:**
    ```bash
    git clone [https://github.com/kullaniciadi/proje-adi.git](https://github.com/kullaniciadi/proje-adi.git)
    cd proje-adi
    ```

2.  **Setting up the Database:**
    * Open **SQL Server Management Studio**.
    * Create a new database (Example: `MyDb`).
    * Run the **`Database/CreateSchema.sql`** file within the project on this new database to establish the table structure.

3.  **Configuring the Connection String:**
    * Open the **`Web.config`** file and update the `connectionString` below with your local database settings.
        ```xml
        <connectionStrings>
          <add name="MyDbEntities" connectionString="data source=.;initial catalog=MyDb;integrated security=True;MultipleActiveResultSets=True;" providerName="System.Data.SqlClient" />
        </connectionStrings>
        ```
    * *(Note: `MyDbEntities` and the `initial catalog` (MyDb) in the connection string may vary based on your project's naming conventions.)*

4.  **Starting the Project:**
    * Open the `.sln` file using **Visual Studio**.
    * If necessary: Go to `Tools > NuGet Package Manager > Restore NuGet Packages`.
    * Run the project (F5).

---
---



![image](https://github.com/user-attachments/assets/efcb7144-9cb0-4d7a-870e-08df9acca3ce)
![image](https://github.com/user-attachments/assets/f9c4b242-7f1e-4531-b4e0-613de03b6ca3)
![image](https://github.com/user-attachments/assets/f221471c-e057-4489-8bfe-a8eb247962a7)
![image](https://github.com/user-attachments/assets/21f863bb-24e9-4db4-9ebd-9cf3552afc8a)
![image](https://github.com/user-attachments/assets/9fd5ecbb-778a-4df7-b84f-5373c8007486)
![image](https://github.com/user-attachments/assets/74481349-cf03-4270-9279-3b474b3c5dcc)
![image](https://github.com/user-attachments/assets/7aa01742-bcce-4308-95a3-c652f148aecb)
![image](https://github.com/user-attachments/assets/2297459c-148c-4acc-9c12-b2e1637e6c28)
![image](https://github.com/user-attachments/assets/1475713b-6d09-4de5-b469-6839463154c8)

