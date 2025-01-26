![Logo](https://i.ibb.co/tD717gs/logo.png)
#

XerifeTv CMS is a content management system (CMS) developed for Over-The-Top (OTT) streaming platforms. This project enables efficient organization and management of movies, series, episodes, and TV channels, providing a comprehensive solution for digital content providers.

####
![screenshot](https://i.ibb.co/0C7Kjjp/Screenshot-4.png)

####
## ✔ Key Features:
- [X]  **Content Management:** Easily register, edit, and organize movies, series, episodes, and TV channels.
- [X]  **JWT Authentication:** Secure authentication system based on JSON Web Tokens.
- [X]  **Swagger Documentation:** REST API routes documented with Swagger.
- [X]  **API Content Route Caching:** Store the data returned from the content API in cache.
- [X]  **Supabase Storage Integration:** Store files (.vtt, images, etc...) in storage bucket.

## 🚀 Technologies:
- C#
- ASP.NET Core
- Razor Pages
- Bootstrap
- JWT Authentication
- MongoDB
- MVC Architecture
- Cache In Memory
- Supabase Storage
- Swagger
- Docker

## 📥 Installing the project

### Prerequisites

- **.NET SDK** version 6.0 or higher
- **MongoDB** installed and running locally or on a remote service

### Setup Steps


#### 1. Clone the repository:
    git clone https://github.com/malikwassd/XerifeTv.CMS.git


#### 2. Navigate to the project directory:
    cd XerifeTv.CMS

#### 3. Configure the MongoDB connection string in the `appsettings.json` file:
    {
      "MongoDBConfig": {
            "ConnectionString": "mongodb://localhost:00000",
            "DatabaseName": "xerifetv_content"
        }
    }

#### 4. Configure Hash Salt for password encryption in `appsettings.json` file:
    {
        "Hash": {
            "Salt": "HASHSALT0000HASH5555HASH0000"
        }
    }

#### 5. Configure the Settings for the JWT token in the `appsettings.json` file:
    {
        "Jwt": {
            "Key": "jwtkey555jwtksajdkl387432sdasda347823974923ns3676",
            "Issuer": "Xerifetvcms",
            "Audience": "Xerifetvcms"
        }
    }

#### 6. Configure the Settings for the Supabase in the `appsettings.json` file:
    {
        "Supabase": {
            "Url": "https://example8095.supabase.co",
            "Key": "example4533.exampleee.exammpple"
        }
    }

#### 7. Restore dependencies and compile the project:
    dotnet restore
    dotnet build


#### 8. Start the server:
    dotnet run


#### 9. Access the application in the browser:
    http://localhost:5000

## License

This project is licensed under the [MIT License](LICENSE).
