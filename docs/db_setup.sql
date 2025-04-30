-- 創建資料庫動作由 Docker Compose 執行
-- 1. 創建表格 [Category]
CREATE TABLE Category (
    id SERIAL PRIMARY KEY,
    category_name VARCHAR(50) NOT NULL,
    description VARCHAR(50) NULL
);

-- 2. 創建表格 [Restaurant]
CREATE TABLE Restaurant (
    id SERIAL PRIMARY KEY,
    restaurant_name VARCHAR(50) NOT NULL,
    category_id INT NOT NULL,
    FOREIGN KEY (category_id) REFERENCES Category(id)
);

-- 3. 插入 Category 資料
INSERT INTO Category (category_name, description) VALUES
    ('Breakfast', '早午餐'),
    ('Japanese', '日式'),
    ('Ramen', '拉麵'),
    ('Noodles', '中式麵食'),
    ('Other', '其他'),
    ('Hamburger', '漢堡'),
    ('Delivery', '外送');

-- 4. 插入 Restaurant 資料
INSERT INTO Restaurant (restaurant_name, category_id) VALUES
    ('麥味登', 1),
    ('檸檬草', 1),
    ('威美', 1),
    ('楓川', 2),
    ('九鬼魚屋', 2),
    ('呂舖咖哩飯', 2),
    ('麵匡匡', 3),
    ('一真亭', 3),
    ('建忠牛肉麵', 4),
	('南村小吃店', 4),
    ('圓環頂蚵仔煎', 5),
    ('丁媽虱目魚', 5),
    ('萊客多虱目魚', 5),
    ('摩斯漢堡', 6),
    ('肯德基', 7),
    ('漢堡王', 7);
