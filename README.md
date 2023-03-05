# 
<h1 align="center">Pracitum Final Case Application</h1>

<details>
  <summary>İçindekiler</summary>
  
  1. <a href="#About Project">Proje Hakkında</a>
      * <a href="#Objective">Projenin Amacı</a>
      * <a href="#Goals">Minimum Teknoloji Gereksinimleri</a>
      * <a href="#Tools and Technologies">Kullanılan Araçlar ve Teknolojiler</a>
      * <a href="#Design Patterns and Archtitectures">Kullanılan Tasarım Desenleri ve Mimariler</a>
  2. <a href="#Build up Guide">Projeyi Nasıl Çalıştırabiliriz?</a>
  3. <a href="#Contact">Contact</a>
  
</details>

# <p id="About Project">Proje Hakkında</p>

## <p id="Objective">Projenin Amacı</p>
Kullanıcıların almayı planladıkları ürünleri kaydedip takibini yapabilecekleri web api geliştirilmesi.

## <p id="Goals">Minimum Teknoloji Gereksinimleri</p>
* Veritabanı (NoSql) 
* EF
* Postman veya Swagger
* Solid Principles
* Rabbitmq (Opsiyonel)
* Redis (Opsiyonel)

## <p id="Tools and Technologies">Kullanılan Araç ve Tekonolojiler</p>
<div>

### Araçlar  
* Visual Studio
* Swagger
* Microsoft Sql Server Management Studio
* Docker Desktop
* GitHub
* xUnit
### Teknolojiler
* ASP.NET Core
* Microsoft Sql Server
* Entity Framework Core
* Redis
* RabbitMQ
* Docker
* AutoMapper
* MediatR 
* Shouldly Asssertion
* Serilog
* JWT Authentication
</div> 

## <p id="Design Patterns and Archtitectures">Kullanılan Tasarım Desenleri, Mimariler ve Prensibler</p>
<div>
  
* Repository Pattern
* CQRS(Command and Query Responsibility Segregation)
* Mediator Pattern
* Clean(Onion) Architecture
* SOLID
* DRY
* Dependency Injection 
</div> 

# <p id="Build up Guide">Projeyi Nasıl Çalıştırabiliriz?</p>

* İlk adım olarak proje reposunu local makinenize çekin(klonlayın).
* Makinenizde hali hazırda docker kurulu değilse aşağıdaki linken kurulumunu gerçekleştirin.
 ```
 https://docs.docker.com/desktop/install/windows-install/
 ```
 * RabbitMq ve Redis' i docker üzerinde container olarak çalıştırabilmek için proje dosyalarında bulunan 'docker-compose-files/rabbitmq' ve 'docker-compose-files/redis' dizinlerinde bir terminal çalıştırarak aşağıdaki komutu giriniz.
```
docker-compose up
```
* Ana veritabanı olarak Mssql Server kullanıldığı için yüklü değilse yine onu da docker üzerinde yada makinenize kurabilirsiniz.
```
Docker kurulum
https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver16&pivots=cs1-cmd
```
```
Doğrudan makinenize kurulum
https://www.guru99.com/download-install-sql-server.html
```
* Projenin 'src\Presentation\PracticumFinalCase.WebApi' dizininde yer alan 'appsettings.json' dosyası içerisindeki SqlServerConnection veritabanı ConnectionString' ini kendi Mssql bağlatınız ile değiştiriniz.
* 'PracticumFinalCase.sln' dosyasını çalıştırdıktan sonra WebApi ve ShoppingListConsumer projelerini birlikte ayağa kaldırın.
```
Birden fazla projeyi aynı anda ayağa kaldırmak için aşağıda yer alan linkteki adımları uygulayabilirsiniz.
https://learn.microsoft.com/en-us/visualstudio/ide/how-to-set-multiple-startup-projects?view=vs-2022
```
* Tüm bu adımları eksiksiz uygulandığınız senaryoda uygulamanız Postman, Swagger vb. araçlar üzerinden istek almaya hazırdır.

# <p id="Contact">Contact</p>

<div>
<a href="https://www.linkedin.com/in/eray-berbero%C4%9Flu"><img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/linkedin/linkedin-original-wordmark.svg" alt="LinkedIn" width="75"/></a>
<a href="https://github.com/candem15"><img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/github/github-original-wordmark.svg" alt="Github" width="75"/></a>
<a href="mailto:eraybrbr@gmail.com"><img src="https://storage.googleapis.com/gweb-uniblog-publish-prod/images/Gmail.max-1100x1100.png" alt="Gmail" width="75"/></a>
</div>
