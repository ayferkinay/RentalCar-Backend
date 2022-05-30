# RentalCar-Backend
## ⭐ Introduction 
- **Entities, DataAccess, Business, Core ve WebAPI katmanlarından oluşan araba kiralama projesidir. Bu projede Katmanlı mimari yapısı ve SOLID prensiplerine dikkate alınarak yazılmıştır. JWT entegrasyonu; Transaction, Cache, Validation ve Performance aspect'lerinin implementasyonu gerçekleştirilmiştir.** 
- **Validation için FluentValidation desteği, IoC için ise Autofac desteği eklenmiştir.**
- **[Sql query](https://github.com/gulceselim/re-cap-project-with-csharp/blob/main/RentACarSQLQuery.sql) dosyamı da ekledim isteyen varsa faydalanabilir.**


## Kullanılan Teknolojiler & Yapılar

<ul>
    <li>Back-End
    <ul>
        <li>C# Vers. 7.3</li>
        <li>Restful Web Api Vers. .Net Core 3.1</li>
        <li>Katmanlı Mimari</li>
        <li>Temel Result Türü</li>
        <li>Interceptor, Aspectler</li>
        <li>Cache, Validate, Authorize Aspect</li>
        <li>Autofac</li>
        <li>AutoFilterer</li>
        <li>Fluent Validation</li>
        <li>Json Web Token</li>
        <li>Repository Design Pattern</li>
        <li>Asenkron Yapı</li>
    </ul>
    </li>

</ul>




## SQL Tables
![rcp](https://user-images.githubusercontent.com/51466724/108183763-7b341a80-711b-11eb-9f84-110b0998e560.jpg)





#### Prerequest 

 - [ ] EntityFrameworkCore.SqlServer 3.1.11
 - [ ]  FluentValidation 7.3.3
 - [ ] Autofac 6.1.0
 - [ ] Autofac.Extensions.DependencyInjection 7.1.0
 - [ ] Autofac.Extras.DynamicProxy 6.0.0 


### Kullanılan Teknolojiler

- .Net Core 3.1
- Restful API
- Result Türleri
- Interceptor
- Autofac
    - IoC Containers
    - AOP, Aspect Oriented Programming
        - Caching
        - Performance
        - Transaction
        - Validation
- Fluent Validation
- Cache yönetimi
- JWT Authentication
- Repository Design Pattern
- Cross Cutting Concerns
    - Caching
    - Validation
- Extensions
    - Claim
        - Claim Principal
    - Exception Middleware
    - Service Collection
    - Error Handling
        - Error Details
        - Validation Error Details



### Katmanlar

- **Core**: Projenin çekirdek katmanı, evrensel operasyonlar için kullanılmaktadır.
- **DataAccess**: Projenin, Veritabanı ile bağını kuran katmandır.
- **Entities**: Veritabanındaki tablolarımızın projemizde nesne olarak kullanılması için oluşturulmuştur. DTO nesnelerinide
  barındırmaktadır.
- **Business**: Projemizin iş katmanıdır. Türlü iş kuralları; Veri kontrolleri, validasyonlar, IoC Container'lar ve yetki
  kontrolleri
  
  
  
  
### Backend Tecnologies

- Asp.Net Core for Restful api
- MsSql
- EntityFramework Core
- Autofac
- FluentValidation

### Backend Techniques
- Layered Architecture Design Pattern
- AOP
- JWT
- Autofac dependency resolver
- IOC
- Aspects
- File upload
- **WebAPI**: Prjenin Restful API Katmanıdır. Kullanılan methodlar: Get, Post, Put, Delete
