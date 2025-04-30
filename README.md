### DB docker-compose.yml example:

```yaml
services:
  db:
    image: postgres:16
    container_name: demo-postgres
    environment:
      POSTGRES_USER: your_name
      POSTGRES_PASSWORD: your_password
      POSTGRES_DB: database_name
    ports:
      - "5432:5432"
    volumes:
      - ./db_setup.sql:/docker-entrypoint-initdb.d/init.sql   # 初始 SQL（只執行一次）
      - db_data:/var/lib/postgresql/data                  # 持久化資料（重點）

volumes:
  db_data:   # name volume 的宣告區，Docker 自動管理
```

Place this file in the same directory as db_setup.sql.  
The db_setup.sql file can be found in the docs directory of this repository.
