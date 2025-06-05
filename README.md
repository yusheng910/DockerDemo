## DockerDemo

This is a demonstration project showing how to containerize a .NET app with Nginx reverse proxy and PostgreSQL using Docker Compose.

本專案為示範專案，展示如何使用 Docker Compose 將 .NET 應用程式、Nginx 反向代理，以及 PostgreSQL 容器整合部署。

### Project Structure | 專案結構

```
DockerDemo/
├── README.md
├── demo-web-api 
│   ├── Dockerfile
│   ├── Program.cs
│   ├── appsettings.Development.json
│   ├── appsettings.json
│   └── <Other files>
├── docker-compose.yml
├── docs
│   ├── db_setup.sql
│   └── docker-compose.yml
└── nginx
    └── conf.d
        └── default.conf
```
### Setup Steps | 執行步驟

1. Run Docker Compose for .Net app and Nginx (target: DockerDemo/docker-compose.yml)
2. Run Docker Compose for PostgreSQL (target: DockerDemo/docs/docker-compose.yml)

### Notes | 注意事項
	
- In production, the database may be hosted outside Docker. For this reason, the compose files are separated.

    正式環境中資料庫通常不以容器執行，因此本專案分開管理 compose 檔。

- The PostgreSQL container is for development and testing only.

    資料庫（PostgreSQL）容器僅供開發與測試環境使用。

- All containers must be on the same Docker network to ensure communication between the app, database, and Nginx (note: the database may be hosted externally in the future).

    所有容器必須在同一個 Docker 網路中，確保應用程式、資料庫與 Nginx 之間能正常通訊（資料庫未來可能另行部署）。

<br>If necessary, you can inspect the Docker network:
```
docker network ls
docker network inspect <network-name>
```
