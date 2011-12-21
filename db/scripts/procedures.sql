USE wiserss;
DELIMITER $$

##################################################
################### Categories ###################
##################################################
# get categories
DROP PROCEDURE IF EXISTS GetCategories $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetCategories()
BEGIN
SELECT
  *
FROM
  categories;
END $$

# delete category
DROP PROCEDURE IF EXISTS DeleteCategory $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE DeleteCategory(IN p_category_name VARCHAR(255))
BEGIN
DECLARE category_id INT UNSIGNED;

SELECT id
INTO category_id
FROM categories
WHERE name = p_category_name
LIMIT 1;

DELETE FROM categories
  WHERE id = category_id;
END $$

# insert category
DROP PROCEDURE IF EXISTS InsertCategory $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE InsertCategory(IN p_category_name VARCHAR(255))
BEGIN

DECLARE counter INT UNSIGNED DEFAULT 0;

SELECT COUNT(id)
INTO counter
FROM categories
WHERE name = p_category_name;

IF counter = 0 THEN
  INSERT INTO categories(id,name)
    VALUES(id,p_category_name);
END IF;
END $$

# update category
DROP PROCEDURE IF EXISTS UpdateCategory $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE UpdateCategory(IN p_category_name VARCHAR(255), p_new_category_name VARCHAR(255))
BEGIN

DECLARE category_id INT UNSIGNED;

SELECT id
INTO category_id
FROM categories
WHERE name = p_category_name
LIMIT 1;

UPDATE categories
  SET name = p_new_category_name
  WHERE id = category_id;
END $$

###################################################
#################### Languages ####################
###################################################
# get languages
DROP PROCEDURE IF EXISTS GetLanguages $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetLanguages()
BEGIN
SELECT
  *
FROM
  languages;
END $$

# delete language
DROP PROCEDURE IF EXISTS DeleteLanguage $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE DeleteLanguage(IN p_identifier VARCHAR(5))
BEGIN
DECLARE language_id INT UNSIGNED;

SELECT id
INTO language_id
FROM languages
WHERE identifier = p_identifier
LIMIT 1;

DELETE FROM languages
  WHERE id = language_id;
END $$

# insert language
DROP PROCEDURE IF EXISTS InsertLanguage $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE InsertLanguage(IN p_identifier VARCHAR(5))
BEGIN

DECLARE counter INT UNSIGNED DEFAULT 0;

SELECT COUNT(id)
INTO counter
FROM languages
WHERE identifier = p_identifier;

IF counter = 0 THEN
  INSERT INTO languages(id,identifier)
    VALUES(id,p_identifier);
END IF;
END $$

# update language
DROP PROCEDURE IF EXISTS UpdateLanguage $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE UpdateLanguage(IN p_identifier VARCHAR(5), p_language VARCHAR(64))
BEGIN

DECLARE language_id INT UNSIGNED;

SELECT id
INTO language_id
FROM languages
WHERE identifier = p_identifier
LIMIT 1;

UPDATE languages
  SET language = p_language
  WHERE id = language_id;
END $$

###################################################
################### RSS Channel ###################
###################################################

# get channels
DROP PROCEDURE IF EXISTS GetRssChannels $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetRssChannels()
BEGIN
SELECT
  *
FROM
  rss_channels;
END $$

# insert channel
DROP PROCEDURE IF EXISTS InsertChannel $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE InsertChannel(IN p_cloud_id INT UNSIGNED,
                        IN p_copyright TEXT,
                        IN p_description MEDIUMTEXT,
                        IN p_docs VARCHAR(255),
                        IN p_generator VARCHAR(255),
                        IN p_language_id INT UNSIGNED,
                        IN p_last_build_date DATETIME,
                        IN p_link TEXT,
                        IN p_managing_editor TEXT,
                        IN p_publication_date DATETIME,
                        IN p_rating VARCHAR(255),
                        IN p_skip_days INT UNSIGNED,
                        IN p_skip_hours INT UNSIGNED,
                        IN p_text_input_id INT UNSIGNED,
                        IN p_title TEXT,
                        IN p_ttl INTEGER UNSIGNED,
                        IN p_webmaster TEXT,
                        IN p_favorite TINYINT(1) UNSIGNED,
                        IN p_count SMALLINT UNSIGNED)
BEGIN

DECLARE counter INT UNSIGNED DEFAULT 0;

SELECT COUNT(id)
INTO counter
FROM rss_channels
WHERE link = p_link;

IF counter = 0 THEN
INSERT INTO
  rss_channels(id,
              cloud_id,
              copyright,
              description,
              docs,
              generator,
              language_id,
              last_build_date,
              link,
              managing_editor,
              publication_date,
              rating,
              skip_days,
              skip_hours,
              text_input_id,
              title,
              ttl,
              webmaster,
              favorite)
        VALUES(id,
              p_cloud_id,
              p_copyright,
              p_description,
              p_docs,
              p_generator,
              p_language_id,
              p_last_build_date,
              p_link,
              p_managing_editor,
              p_publication_date,
              p_rating,
              p_skip_days,
              p_skip_hours,
              p_text_input_id,
              p_title,
              p_ttl,
              p_webmaster,
              p_favorite);
END IF;

END $$

###################################################
############# RSS Channel Categories ##############
###################################################

# get categories for channel
DROP PROCEDURE IF EXISTS GetCategoriesForChannel $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetCategoriesForChannel(IN p_channel_id INT)
BEGIN
SELECT c.*
FROM rss_channel_categories rcc
  JOIN categories c ON rcc.category_id = c.id
WHERE rcc.rss_channel_id = p_channel_id;
END $$


DELIMITER ;