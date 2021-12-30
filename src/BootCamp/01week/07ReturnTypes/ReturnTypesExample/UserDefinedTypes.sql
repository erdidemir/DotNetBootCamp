--Aliases for INT NOT NULL and VARCHAR(100)
  CREATE TYPE id FROM INT NOT NULL;
  CREATE TYPE location FROM VARCHAR(100);

  CREATE TABLE person
  (
     id id PRIMARY KEY,
     location location DEFAULT 'n/a'
  );
 
  INSERT INTO person VALUES (1, 'Paris, France');
  --# 1 row(s) affected