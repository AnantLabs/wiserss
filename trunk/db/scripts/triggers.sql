USE wiserss;

DELIMITER $$

# trigger before insert on categories
DROP TRIGGER IF EXISTS categories_b_ins $$
CREATE TRIGGER categories_b_ins BEFORE INSERT ON categories
FOR EACH ROW
BEGIN

DECLARE row_count INT UNSIGNED;

SELECT COUNT(id)
INTO row_count
FROM categories;

IF ((SELECT id FROM categories WHERE id = (row_count+1)) IS NULL) THEN
  SET NEW.id = row_count + 1;
ELSE
  SET NEW.id = row_max + 1;
END IF;
END $$

# trigger before insert on languages
DROP TRIGGER IF EXISTS languages_b_ins $$
CREATE TRIGGER languages_b_ins BEFORE INSERT ON languages
FOR EACH ROW
BEGIN

DECLARE row_count INT UNSIGNED;
DECLARE row_max INT UNSIGNED;

SELECT COUNT(id)
INTO row_count
FROM languages;

SELECT MAX(id)
INTO row_max
FROM languages;

IF ((SELECT id FROM languages WHERE id = (row_count+1)) IS NULL) THEN
  SET NEW.id = row_count + 1;
ELSE
  SET NEW.id = row_max + 1;
END IF;
END $$

DELIMITER ;