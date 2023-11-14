# Moonglade-saigkill Blog

The [.NET](https://dotnet.microsoft.com/) blog system that optimized for [**Microsoft Azure**](https://azure.microsoft.com/en-us/). Designed for developers, enabling most common blogging features including posts, comments, categories, archive, tags and pages.

This `saigkill` Version is a fork of the original project. It enables Site verifying services (Bing, Yandex, Norton Safe Web and World of Trust), a basic support of Dublin Core, also some Analytics services (Google Analytics, MS Clarity).

The upstream project provides managing sites. This feature is also present in this version. Becuase of a lack of page localization i decided to use plain razor pages for my pages. If you want to use my fork, and want to use the native pages support, so delete the pages `About`, `Contact`, `CurriculumVitae`, `Imprint`, `Privacy`, `Talks` and `Testimonials`.

**IMPORTANT: Moonglade will move to .NET 8 LTS in November 2023 with v14.x release**

## 📦 Deployment

- Please use stable code from [Release](https://github.com/EdiWang/Moonglade/releases) branch rather than master branch.

- HTTPS is required, and it is recommended to enable HTTP/2 support on your web server.

### ☁ Full Deploy on Azure

This is the way https://edi.wang is deployed, by taking advantage of as many Azure services as possible, the blog can run very fast and secure. 

There is no automated script to deploy it, you need to manually create all the resources.

![image](https://cdn-blog.edi.wang/web-assets/ediwang-azure-arch-visio-nov2022.png)

### 🐋 Quick Deploy on Azure (App Service on Linux)

Use automated deployment script to get your Moonglade up and running in 10 minutes with minimal Azure components, follow instructions [here](https://github.com/EdiWang/Moonglade/wiki/Quick-Deploy-on-Azure)

### 🐋 Quick Deploy with Docker-Compose

Simply go the the root folder of this repo and run:

```bash
docker-compose build
docker-compose up
```

That's it! Now open: [Browser: http://localhost:8080](http://localhost:8080)

### 🐧 Quick Deploy on Linux without Docker

To quickly get it running on a new Linux machine without Docker, follow instructions [here](https://github.com/EdiWang/Moonglade/wiki/Quick-Install-on-Linux-Machine). You can watch video tutorial [here](https://anduins-site.player.aiur.site/moonglade-install.mp4).

## 🐵 Development

Tools | Alternative
--- | ---
[Visual Studio 2022 v17.8+](https://visualstudio.microsoft.com/) | [Visual Studio Code](https://code.visualstudio.com/) with [.NET 8.0 SDK](http://dot.net)
[SQL Server 2022](https://www.microsoft.com/en-us/sql-server/sql-server-2022) | [SQL Server LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16&WT.mc_id=AZ-MVP-5002809), PostgreSQL or MySQL 

### 💾 Setup Database

Moonglade supports three types of database. You can choose from SQL Server, PostgreSQL or MySQL.

Update your database connection string in `appsettings.*.json`

#### SQL Server

```json
"ConnectionStrings": {
  "MoongladeDatabase": "Server=(localdb)\\MSSQLLocalDB;Database=Moonglade;Trusted_Connection=True;",
  "DatabaseType": "SqlServer"
}
```
#### MySQL

```json
"ConnectionStrings": {
  "MoongladeDatabase": "Server=localhost;Port=3306;Database=moonglade;Uid=root;Pwd=******;",
  "DatabaseType": "MySql"
}
```

#### PostgreSql

```json
"ConnectionStrings": {
  "MoongladeDatabase": "User ID=****;Password=****;Host=localhost;Port=5432;Database=****;Pooling=true;",
  "DatabaseType": "PostgreSql"
}
```

### 🔨 Build Source

Build and run `./src/Moonglade.sln`
- Admin: `https://localhost:1055/admin`
- Default username: `admin`
- Default password: `admin123`

## ⚙ Configuration

> This section discuss environment settings in **appsettings.[env].json**. For blog settings, please use "/admin/settings" UI.

### 🛡 Authentication

> You can choose one authentication provider from below.

#### [Microsoft Entra ID](https://azure.microsoft.com/en-us/services/active-directory/)

See [Wiki document](https://github.com/EdiWang/Moonglade/wiki/Use-Microsoft-Entra-ID-Authentication)

#### Local Account

Set `Authentication:Provider` to `"Local"`. You can manage accounts in `/admin/settings/account`

### 🖼 Image Storage
`ImageStorage` controls how blog post images are stored.

#### [Azure Blob Storage](https://azure.microsoft.com/en-us/services/storage/blobs/) (Preferred)

You need to create an [**Azure Blob Storage**](https://azure.microsoft.com/en-us/services/storage/blobs/) with **container level permission**. 

```json
{
  "Provider": "azurestorage"
  "AzureStorageSettings": {
    "ConnectionString": "YOUR CONNECTION STRING",
    "ContainerName": "YOUR CONTAINER NAME"
  }
}
```

When configured the image storage to use Azure Blob, you can take advantage of CDN for your image resources. Just enable CDN in admin settings, the blog will get images from CDN.

#### [Minio Blob Storage](https://min.io/)

You need to hava an [**Minio Server**](https://docs.min.io/). 

```json
"Provider": "miniostorage"
"MinioStorageSettings": {
  "EndPoint": "Minio Server Endpoint(eg:localhost:9600)",
  "AccessKey": "Your Access Key",
  "SecretKey": "Your Secret Key",
  "BucketName": "Your BucketName",
  "WithSSL": false
}
```

#### File System (Not Recommended)

You can also choose File System for image storage if you don't have a cloud option.

```json
{
  "Provider": "filesystem",
  "FileSystemPath": "C:\\UploadedImages"
}
```

### 🤬 Comment Moderator

See https://github.com/EdiWang/Moonglade.ContentSecurity

### 📧 Email Notification

If you need email notification for new comments, new replies and pingbacks, you have to setup the [Moonglade.Email Azure Function](https://github.com/EdiWang/Moonglade.Email) first, and then enable notification in admin portal.

### 🔩 Others

- [System Settings](https://github.com/EdiWang/Moonglade/wiki/System-Settings)
- [Security Headers (CSP, XSS, etc.)](https://github.com/EdiWang/Moonglade/wiki/Security-Headers-(CSP,-XSS,-etc.))

## 🎉 Blog Protocols or Standards

- [X] RSS
- [X] Atom
- [X] OPML
- [X] Open Search
- [X] Pingback
- [X] Reader View
- [X] FOAF
- [X] RSD
- [X] MetaWeblog (Basic Support)
- [X] Dublin Core Metadata (Basic Support)
- [ ] BlogML - Not planned
- [ ] APML - Not planned
- [ ] Trackback - Not planned

## ⚖️ Disclaimer (Global)

The following disclaimer applies to the software named "Moonglade" developed by Edi Wang and other [contributors](https://github.com/EdiWang/Moonglade/graphs/contributors) (hereinafter referred to as "the software developer"):

This project is not affiliated with Microsoft Corporation. All product names, logos, and brands are property of their respective owners. All company, product and service names used in this website are for identification purposes only. Use of these names, logos, and brands does not imply endorsement.

The software developer does not provide any warranties or guarantees regarding the functionality, performance, or suitability of Moonglade for any specific purpose. The software is provided "as is," and the software developer shall not be held liable for any direct or indirect damages arising from the use or inability to use Moonglade.

### Data Privacy

Moonglade does not send any user data or information to any government, **including the Chinese government**. The software is designed to prioritize and respect user privacy.

### Data Collection

While using Moonglade, please note that the platform on which you deploy the software may collect data and usage information. This data collection is solely the responsibility of the platform and not the software developer. We encourage you to review thier privacy policy and terms of service of the platform to understand how your data is handled.

### User Responsibility

As a user of Moonglade, it is your responsibility to ensure compliance with applicable laws and regulations regarding data privacy and usage. The software developer shall not be held liable for any misuse, unauthorized access, or mishandling of data by the user or the platform on which Moonglade is deployed.

### Updates and Modifications

The software developer may release updates or modifications to Moonglade from time to time. It is recommended that users stay informed about these updates and apply them to ensure optimal performance and security.

## 免责申明

此项目(Moonglade)及其配套组件均为免费开源的产品，仅用于学习交流，并且不直接向中国提供服务，中国用户请于下载后立即删除。

任何中国境内的组织及个人不得使用此项目(Moonglade)及其配套组件构建任何形式的面向中国境内用户的网站或服务。

不可用于任何违反中华人民共和国(含台湾省)或使用者所在地区法律法规的用途。

因为作者即本人仅完成代码的开发和开源活动(开源即任何人都可以下载使用)，从未参与用户的任何运营和盈利活动。

且不知晓用户后续将程序源代码用于何种用途，故用户使用过程中所带来的任何法律责任即由用户自己承担。

[《开源软件有漏洞，作者需要负责吗？是的！》](https://go.edi.wang/aka/os251)