CREATE TABLE
  IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) UNIQUE COMMENT 'User Email',
    picture varchar(255) COMMENT 'User Picture'
  ) default charset utf8mb4 COMMENT '';

CREATE TABLE
  cars (
    -- It is very important that the id is the first column of the table
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    make VARCHAR(255) NOT NULL,
    model VARCHAR(255) NOT NULL,
    year SMALLINT UNSIGNED NOT NULL,
    price INT UNSIGNED NOT NULL,
    color VARCHAR(255) NOT NULL,
    engineType ENUM ("4 cylinder", "v8", "v11", "chunko", "unknown") DEFAULT "unknown" NOT NULL,
    leaksOil BOOLEAN NOT NULL DEFAULT false,
    description TEXT,
    imgUrl TEXT NOT NULL,
    -- this data type
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
  );

-- If you need to make big changes to a table, it is easy to just drop and start again
DROP TABLE cars;

DELETE FROM accounts;

SELECT
  *
FROM
  accounts
WHERE
  id = "66bb7bd91baeacf46d3e7517";

UPDATE accounts
SET
  NAME = "Miata 4 EVER"
WHERE
  id = "66bb7bd91baeacf46d3e7517";

SELECT
  cars.*,
  accounts.*
FROM
  cars
  JOIN accounts ON accounts.id = cars.creatorId;

INSERT INTO
  cars (
    make,
    model,
    year,
    price,
    imgUrl,
    description,
    engineType,
    leaksOil,
    color,
    creatorId
  )
VALUES
  (
    "ford",
    "focus",
    "2009",
    "18000",
    "https://images.unsplash.com/photo-1689406393659-a47bc1d94eab?q=80&w=2187&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
    "Running great, trust me",
    "v11",
    false,
    "yellow",
    "66bb8385904c176f444e8947"
  );