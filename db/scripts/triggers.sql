USE wiserss;
DELIMITER $$

# trigger before insert on categories
DROP TRIGGER IF EXISTS categories_b_ins $$
CREATE TRIGGER categories_b_ins BEFORE INSERT ON categories
FOR EACH ROW
BEGIN

DECLARE row_count INT UNSIGNED;
DECLARE row_max INT UNSIGNED;

SELECT COUNT(id)
INTO row_count
FROM categories;

SELECT COALESCE(MAX(id),0)
INTO row_max
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

SELECT COALESCE(MAX(id),0)
INTO row_max
FROM languages;

IF ((SELECT id FROM languages WHERE id = (row_count+1)) IS NULL) THEN
  SET NEW.id = row_count + 1;
ELSE
  SET NEW.id = row_max + 1;
END IF;
END $$

# trigger before insert on enclosures
DROP TRIGGER IF EXISTS enclosures_b_ins $$
CREATE TRIGGER enclosures_b_ins BEFORE INSERT ON enclosures
FOR EACH ROW
BEGIN

DECLARE row_count INT UNSIGNED;
DECLARE row_max INT UNSIGNED;

SELECT COUNT(id)
INTO row_count
FROM enclosures;

SELECT COALESCE(MAX(id),0)
INTO row_max
FROM enclosures;

IF ((SELECT id FROM enclosures WHERE id = (row_count+1)) IS NULL) THEN
  SET NEW.id = row_count + 1;
ELSE
  SET NEW.id = row_max + 1;
END IF;
END $$

# trigger before insert on rss_channel_images
DROP TRIGGER IF EXISTS rss_channel_images_b_ins $$
CREATE TRIGGER rss_channel_images_b_ins BEFORE INSERT ON rss_channel_images
FOR EACH ROW
BEGIN

DECLARE row_count INT UNSIGNED;
DECLARE row_max INT UNSIGNED;

SELECT COUNT(id)
INTO row_count
FROM rss_channel_images;

SELECT COALESCE(MAX(id),0)
INTO row_max
FROM rss_channel_images;

IF ((SELECT id FROM rss_channel_images WHERE id = (row_count+1)) IS NULL) THEN
  SET NEW.id = row_count + 1;
ELSE
  SET NEW.id = row_max + 1;
END IF;
END $$

# trigger before insert on text_inputs
DROP TRIGGER IF EXISTS text_inputs_b_ins $$
CREATE TRIGGER text_inputs_b_ins BEFORE INSERT ON text_inputs
FOR EACH ROW
BEGIN

DECLARE row_count INT UNSIGNED;
DECLARE row_max INT UNSIGNED;

SELECT COUNT(id)
INTO row_count
FROM text_inputs;

SELECT COALESCE(MAX(id),0)
INTO row_max
FROM text_inputs;

IF ((SELECT id FROM text_inputs WHERE id = (row_count+1)) IS NULL) THEN
  SET NEW.id = row_count + 1;
ELSE
  SET NEW.id = row_max + 1;
END IF;
END $$

# trigger before insert on clouds
DROP TRIGGER IF EXISTS clouds_b_ins $$
CREATE TRIGGER clouds_b_ins BEFORE INSERT ON clouds
FOR EACH ROW
BEGIN

DECLARE row_count INT UNSIGNED;
DECLARE row_max INT UNSIGNED;

SELECT COUNT(id)
INTO row_count
FROM clouds;

SELECT COALESCE(MAX(id),0)
INTO row_max
FROM clouds;

IF ((SELECT id FROM clouds WHERE id = (row_count+1)) IS NULL) THEN
  SET NEW.id = row_count + 1;
ELSE
  SET NEW.id = row_max + 1;
END IF;
END $$

# trigger before insert on rss_item_categories
DROP TRIGGER IF EXISTS rss_item_categories_b_ins $$
CREATE TRIGGER rss_item_categories_b_ins BEFORE INSERT ON rss_item_categories
FOR EACH ROW
BEGIN

DECLARE row_count INT UNSIGNED;
DECLARE row_max INT UNSIGNED;

SELECT COUNT(id)
INTO row_count
FROM rss_item_categories;

SELECT COALESCE(MAX(id),0)
INTO row_max
FROM rss_item_categories;

IF ((SELECT id FROM rss_item_categories WHERE id = (row_count+1)) IS NULL) THEN
  SET NEW.id = row_count + 1;
ELSE
  SET NEW.id = row_max + 1;
END IF;
END $$

# trigger before insert on rss_channel_categories
DROP TRIGGER IF EXISTS rss_channel_categories_b_ins $$
CREATE TRIGGER rss_channel_categories_b_ins BEFORE INSERT ON rss_channel_categories
FOR EACH ROW
BEGIN

DECLARE row_count INT UNSIGNED;
DECLARE row_max INT UNSIGNED;

SELECT COUNT(id)
INTO row_count
FROM rss_channel_categories;

SELECT COALESCE(MAX(id),0)
INTO row_max
FROM rss_channel_categories;

IF ((SELECT id FROM rss_channel_categories WHERE id = (row_count+1)) IS NULL) THEN
  SET NEW.id = row_count + 1;
ELSE
  SET NEW.id = row_max + 1;
END IF;
END $$

# trigger before insert on rss_items
DROP TRIGGER IF EXISTS rss_items_b_ins $$
CREATE TRIGGER rss_items_b_ins BEFORE INSERT ON rss_items
FOR EACH ROW
BEGIN

DECLARE row_count INT UNSIGNED;
DECLARE row_max INT UNSIGNED;

SELECT COUNT(id)
INTO row_count
FROM rss_items;

SELECT COALESCE(MAX(id),0)
INTO row_max
FROM rss_items;

IF ((SELECT id FROM rss_items WHERE id = (row_count+1)) IS NULL) THEN
  SET NEW.id = row_count + 1;
ELSE
  SET NEW.id = row_max + 1;
END IF;
END $$

# trigger before insert on rss_channels
DROP TRIGGER IF EXISTS rss_channels_b_ins $$
CREATE TRIGGER rss_channels_b_ins BEFORE INSERT ON rss_channels
FOR EACH ROW
BEGIN

DECLARE row_count INT UNSIGNED;
DECLARE row_max INT UNSIGNED;

SELECT COUNT(id)
INTO row_count
FROM rss_channels;

SELECT MAX(id)
INTO row_max
FROM rss_channels;

IF ((SELECT id FROM rss_channels WHERE id = (row_count+1)) IS NULL) THEN
  SET NEW.id = row_count + 1;
ELSE
  SET NEW.id = row_max + 1;
END IF;
END $$

DELIMITER ;