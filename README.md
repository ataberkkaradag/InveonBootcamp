**Library Management System**
----------------------------------------------


Bu proje, bir kütüphane yönetim sistemi için geliştirilmiştir. 
Kullanıcılar kitapları listeleyebilir, dtaylarını görebilir.Ayrıca, kullanıcı ve rol yönetimi yapılabilmektedir. 
Proje, Entity Framework Core, Repository Pattern, Unit of Work Pattern ve IdentityServer kullanarak geliştirilmiştir.

**Özellikler**
-----------------------------------------------------------------------------

*Kitap Yönetimi*:
---------------------------------------------------

- Kitap bilgilerini listeleyin.
- Kitap detay bilgilerini listeleyin.
- `/Book`  
- `/Book/Detail/{id}`


*Kullanıcı Yönetimi*:
------------------------------------------------------------------------
- Kullanıcılar login,register,logout olabilir.
- Kullanıcıları oluşturun, güncelleyin ve silin.
- Admin ve user rolleri tanımlanabilir.


*Rol Yönetimi*:
-----------------------------------------------------------------------------
- Admin rolüne sahip kullanıcılar, tüm işlemleri yapabilir.
- User rolüne sahip kullanıcılar kitapları listeler profil bilgilerini listeler.
- Admin rolüne sahip kullanıcı rol ekleyebilir ,oluşturabilir atayabilir.
- Admin rolüne sahip kullanıcı, kullanıcı ekleyebilir ,oluşturabilir atayabilir.


Kimlik Doğrulama ve Yetkilendirme:
--------------------------------------------------------------------------
- ASP.NET Identity ile kullanıcı kimlik doğrulaması.
- Admin sayfası yalnızca admin kullanıcılarına erişim izni verir.
- Kullanıcılar rollerinin izin verdiği işlemleri yapar.

**Teknolojiler**
-------------------------------------------------
- ASP.NET Core
- Entity Framework Core
- ASP.NET Identity
- Repository Pattern
- Unit of Work Pattern

Admin Paneline Erişim
-------------------------------------------------------------------
Admin paneline erişmek için, Admin rolüne sahip bir kullanıcı ile giriş yapmanız gerekmektedir. Admin kullanıcıları için başlangıç bilgileri şu şekildedir:
migration yaptıktan sonra ulaşılabilir.


*Kullanıcı Adı*: admin
----------------------------------------
*Şifre*: Admin1234*
-----------------------------------------
- `/Admin/UserList`  
- `/Admin/RoleList`
Sayfalarından admin ile ilgili bütün işlemler yapılabilir.



