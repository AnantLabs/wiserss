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
SELECT *
FROM categories;
END $$

# get category
DROP PROCEDURE IF EXISTS GetCategory $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetCategory(IN p_id INT UNSIGNED)
BEGIN
SELECT *
FROM categories
WHERE id = p_id
LIMIT 1;
END $$

# function get category ID
DROP FUNCTION IF EXISTS GetCategoryID $$
CREATE DEFINER=`wiserss`@`localhost`
FUNCTION GetCategoryID(p_name VARCHAR(255)) RETURNS INT UNSIGNED
  CONTAINS SQL
	DETERMINISTIC
  SQL SECURITY INVOKER
BEGIN
DECLARE p_id INT UNSIGNED DEFAULT 0;
  SELECT id
  INTO p_id
  FROM categories
  WHERE name = p_name
  LIMIT 1;
RETURN p_id;
END $$

# delete category ID
DROP PROCEDURE IF EXISTS DeleteCategory $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE DeleteCategory(IN p_id INT UNSIGNED)
BEGIN
IF p_id > 0 THEN
  DELETE FROM categories
    WHERE id = p_id;
END IF;
END $$

# insert category
DROP PROCEDURE IF EXISTS InsertCategory $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE InsertCategory(IN p_name VARCHAR(255),
                         OUT p_id INT UNSIGNED)
BEGIN
SET p_id = GetCategoryID(p_name);
IF p_id = 0 THEN
  INSERT INTO categories(id,name)
    VALUES(id,p_name);
  SET p_id = GetCategoryID(p_name);
END IF;
END $$

# update category
DROP PROCEDURE IF EXISTS UpdateCategory $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE UpdateCategory(IN p_id INT UNSIGNED,
                         IN p_name VARCHAR(255))
BEGIN
IF p_id > 0 THEN
  UPDATE categories
    SET name = p_name
    WHERE id = p_id;
END IF;
END $$

###################################################
#################### Languages ####################
###################################################
# get languages
DROP PROCEDURE IF EXISTS GetLanguages $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetLanguages()
BEGIN
SELECT *
FROM languages;
END $$

# get language
DROP PROCEDURE IF EXISTS GetLanguage $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetLanguage(IN p_id INT UNSIGNED)
BEGIN
SELECT *
FROM languages
WHERE id = p_id
LIMIT 1;
END $$

# get language ID
DROP PROCEDURE IF EXISTS GetLanguageID $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetLanguageID(p_identifier VARCHAR(5))
BEGIN
SELECT id
FROM languages
WHERE identifier = p_identifier
LIMIT 1;
END $$

# function get language ID
DROP FUNCTION IF EXISTS GetLanguageID $$
CREATE DEFINER=`wiserss`@`localhost`
FUNCTION GetLanguageID(p_identifier VARCHAR(5)) RETURNS INT UNSIGNED
  CONTAINS SQL
	DETERMINISTIC
  SQL SECURITY INVOKER
BEGIN
DECLARE p_id INT UNSIGNED DEFAULT 0;
  SELECT id
  INTO p_id
  FROM languages
  WHERE identifier = p_identifier
  LIMIT 1;
RETURN p_id;
END $$

# delete language
DROP PROCEDURE IF EXISTS DeleteLanguage $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE DeleteLanguage(IN p_id INT UNSIGNED)
BEGIN
IF p_id > 0 THEN
  DELETE FROM languages
    WHERE id = p_id;
END IF;
END $$

# insert language
DROP PROCEDURE IF EXISTS InsertLanguage $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE InsertLanguage(IN p_identifier VARCHAR(5),
                         IN p_language VARCHAR(64),
                         OUT p_id INT UNSIGNED)
BEGIN
SET p_id = GetLanguageID(p_identifier);
IF p_id = 0 THEN
  INSERT INTO languages(id,identifier,language)
    VALUES(id,p_identifier,p_language);
  SET p_id = GetLanguageID(p_identifier);
END IF;
END $$

# update language
DROP PROCEDURE IF EXISTS UpdateLanguage $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE UpdateLanguage(IN p_id INT UNSIGNED,
                         IN p_identifier VARCHAR(5),
                         IN p_language VARCHAR(64))
BEGIN
IF p_id > 0 THEN
  UPDATE languages
    SET identifier = p_identifier,
        language   = p_language
    WHERE id = p_id;
END IF;
END $$

###################################################
################### RSS Channel ###################
###################################################

# get rss channels
DROP PROCEDURE IF EXISTS GetRssChannels $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetRssChannels()
BEGIN
SELECT *
FROM rss_channels;
END $$

# get rss channel urls
DROP PROCEDURE IF EXISTS GetRssChannelUrls $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetRssChannelUrls()
BEGIN
SELECT link
FROM rss_channels;
END $$

# get rss channel
DROP PROCEDURE IF EXISTS GetRssChannel $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetRssChannel(IN p_id INT UNSIGNED)
BEGIN
SELECT *
FROM rss_channels
WHERE id = p_id
LIMIT 1;
END $$

# function get rss channel ID
DROP FUNCTION IF EXISTS GetRssChannelID $$
CREATE DEFINER=`wiserss`@`localhost`
FUNCTION GetRssChannelID(p_link TEXT) RETURNS INT UNSIGNED
  CONTAINS SQL
	DETERMINISTIC
  SQL SECURITY INVOKER
BEGIN
DECLARE p_id INT UNSIGNED DEFAULT 0;
  SELECT id
  INTO p_id
  FROM rss_channels
  WHERE link = p_link
  LIMIT 1;
RETURN p_id;
END $$

# get rss channel ID
DROP PROCEDURE IF EXISTS GetRssChannelID $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetRssChannelID(IN p_link TEXT,
                          OUT p_id INT UNSIGNED)
BEGIN
SET p_id = GetRssChannelID(p_link);
END $$

# get categories for rss channel
DROP PROCEDURE IF EXISTS GetRssChannelCategories $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetRssChannelCategories(IN p_id INT)
BEGIN
SELECT c.*
FROM rss_channel_categories rcc
  JOIN categories c
  ON rcc.category_id = c.id
WHERE rcc.rss_channel_id = p_id;
END $$

# get rss items for channel
DROP PROCEDURE IF EXISTS GetRssChannelItems $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetRssChannelItems(IN p_channel_id INT UNSIGNED)
BEGIN
SELECT *
FROM rss_items
WHERE channel_id = p_channel_id;
END $$

# get text input for channel
DROP PROCEDURE IF EXISTS GetRssChannelTextInput $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetRssChannelTextInput(IN p_id INT UNSIGNED)
BEGIN
SELECT ti.*
FROM rss_channels rc
  JOIN text_inputs ti
  ON rc.text_input_id = ti.id
WHERE rc.id = p_id
LIMIT 1;
END $$

# insert rss channel
DROP PROCEDURE IF EXISTS InsertRssChannel $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE InsertRssChannel(IN p_cloud_id INT UNSIGNED,
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
                           OUT p_id INT UNSIGNED)
BEGIN
SET p_id = GetRssChannelID(p_link);
IF p_id = 0 THEN
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
              webmaster)
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
              p_webmaster);

  SET p_id = GetRssChannelID(p_link);
END IF;
END $$

# update rss channel
DROP PROCEDURE IF EXISTS UpdateRssChannel $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE UpdateRssChannel(IN p_id INT UNSIGNED,
                           IN p_cloud_id INT UNSIGNED,
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
                           IN p_webmaster TEXT)
BEGIN
IF p_id > 0 THEN
  UPDATE rss_channels
    SET cloud_id = p_cloud_id,
        copyright = p_copyright,
        description = p_description,
        docs = p_docs,
        generator = p_generator,
        language_id = p_language_id,
        last_build_date = p_last_build_date,
        managing_editor = p_managing_editor,
        publication_date = p_publication_date,
        rating = p_rating,
        skip_days = p_skip_days,
        skip_hours = p_skip_hours,
        text_input_id = p_text_input_id,
        title = p_title,
        ttl = p_ttl,
        webmaster = p_webmaster
  WHERE id = p_id;
END IF;
END $$

# delete rss channel
DROP PROCEDURE IF EXISTS DeleteRssChannel $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE DeleteRssChannel(IN p_id INT UNSIGNED)
BEGIN
IF p_id > 0 THEN
  DELETE FROM rss_channels
    WHERE id = p_id;
END IF;
END $$

###################################################
############### RSS Channel Images ################
###################################################

# get rss channel images
DROP PROCEDURE IF EXISTS GetRssChannelImages $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetRssChannelImages()
BEGIN
SELECT *
FROM rss_channel_images;
END $$

# get rss channel image
DROP PROCEDURE IF EXISTS GetRssChannelImage $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetRssChannelImage(IN p_id INT UNSIGNED)
BEGIN
SELECT *
FROM rss_channel_images
WHERE rss_channel_id = p_id
LIMIT 1;
END $$

# function get rss channel image ID
DROP FUNCTION IF EXISTS GetRssChannelImageID $$
CREATE DEFINER=`wiserss`@`localhost`
FUNCTION GetRssChannelImageID(p_url TEXT) RETURNS INT UNSIGNED
  CONTAINS SQL
	DETERMINISTIC
  SQL SECURITY INVOKER
BEGIN
DECLARE p_id INT UNSIGNED DEFAULT 0;
  SELECT id
  INTO p_id
  FROM rss_channel_images
  WHERE url = p_url
  LIMIT 1;
RETURN p_id;
END $$

# insert rss channel image
DROP PROCEDURE IF EXISTS InsertRssChannelImage $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE InsertRssChannelImage(IN p_rss_channel_id INT UNSIGNED,
                                IN p_url TEXT,
                                IN p_title VARCHAR(255),
                                IN p_link TEXT,
                                IN p_image_path TEXT,
                                OUT p_id INT UNSIGNED)
BEGIN
SET p_id = GetRssChannelImageID(p_url);
IF p_id = 0 THEN
  INSERT INTO rss_channel_images(id,
                                rss_channel_id,
                                url,
                                title,
                                link,
                                image_path)
                         VALUES(id,
                                p_rss_channel_id,
                                p_url,
                                p_title,
                                p_link,
                                p_image_path);
  SET p_id = GetRssChannelImageID(p_url);
END IF;
END $$

# update rss channel image
DROP PROCEDURE IF EXISTS UpdateRssChannelImage $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE UpdateRssChannelImage(IN p_id INT UNSIGNED,
                                IN p_rss_channel_id INT UNSIGNED,
                                IN p_url TEXT,
                                IN p_title VARCHAR(255),
                                IN p_link TEXT,
                                IN p_image_path TEXT)
BEGIN
IF p_id > 0 THEN
  UPDATE rss_channel_images
    SET rss_channel_id = p_rss_channel_id,
        url = p_url,
        title = p_title,
        link = p_link,
        image_path = p_image_path
    WHERE id = p_id;
END IF;
END $$

# delete rss channel image
DROP PROCEDURE IF EXISTS DeleteRssChannelImage $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE DeleteRssChannelImage(IN p_id INT UNSIGNED)
BEGIN
IF p_id > 0 THEN
  DELETE FROM rss_channel_images
    WHERE id = p_id;
END IF;
END $$

###################################################
################### Enclosures ####################
###################################################

# get enclosures
DROP PROCEDURE IF EXISTS GetEnclosures $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetEnclosures()
BEGIN
SELECT *
FROM enclosures;
END $$

# get enclosure
DROP PROCEDURE IF EXISTS GetEnclosure $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetEnclosure(IN p_id INT UNSIGNED)
BEGIN
SELECT *
FROM enclosures
WHERE id = p_id
LIMIT 1;
END $$

# function get enclosure ID
DROP FUNCTION IF EXISTS GetEnclosureID $$
CREATE DEFINER=`wiserss`@`localhost`
FUNCTION GetEnclosureID(p_url TEXT) RETURNS INT UNSIGNED
  CONTAINS SQL
	DETERMINISTIC
  SQL SECURITY INVOKER
BEGIN
DECLARE p_id INT UNSIGNED DEFAULT 0;
  SELECT id
  INTO p_id
  FROM enclosures
  WHERE url = p_url
  LIMIT 1;
RETURN p_id;
END $$

# insert enclosure
DROP PROCEDURE IF EXISTS InsertEnclosure $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE InsertEnclosure(IN p_rss_item_id INT UNSIGNED,
                          IN p_length INT UNSIGNED,
                          IN p_type VARCHAR(255),
                          IN p_url TEXT,
                          IN p_file BLOB,
                          OUT p_id INT UNSIGNED)
BEGIN
SET p_id = GetEnclosureID(p_url);
IF p_id = 0 THEN
  INSERT INTO enclosures(id,
                         rss_item_id,
                         length,
                         type,
                         url,
                         file)
                  VALUES(id,
                         p_rss_item_id,
                         p_length,
                         p_type,
                         p_url,
                         p_file);
  SET p_id = GetEnclosureID(p_url);
END IF;
END $$

# update enclosure
DROP PROCEDURE IF EXISTS UpdateEnclosure $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE UpdateEnclosure(IN p_id INT UNSIGNED,
                          IN p_rss_item_id INT UNSIGNED,
                          IN p_length INT UNSIGNED,
                          IN p_type VARCHAR(255),
                          IN p_url TEXT,
                          IN p_file BLOB)
BEGIN
IF p_id > 0 THEN
  UPDATE enclosures
    SET rss_item_id = p_rss_item_id,
        length = p_length,
        type = p_type,
        url = p_url,
        file = p_file
    WHERE id = p_id;
END IF;
END $$

# delete enclosure
DROP PROCEDURE IF EXISTS DeleteEnclosure $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE DeleteEnclosure(IN p_id INT UNSIGNED)
BEGIN
IF p_id > 0 THEN
  DELETE FROM enclosures
    WHERE id = p_id;
END IF;
END $$

###################################################
#################### RSS Item #####################
###################################################

# get rss items
DROP PROCEDURE IF EXISTS GetRssItems $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetRssItems()
BEGIN
SELECT *
FROM rss_items;
END $$

# get rss item
DROP PROCEDURE IF EXISTS GetRssItem $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetRssItem(IN p_id BIGINT UNSIGNED)
BEGIN
SELECT *
FROM rss_items
WHERE id = p_id
LIMIT 1;
END $$

# get categories rss item
DROP PROCEDURE IF EXISTS GetRssItemCategories $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetRssItemCategories(IN p_id INT)
BEGIN
SELECT ric.*
FROM rss_item_categories ric
WHERE ric.rss_item_id = p_id;
END $$

# get enclosures for rss item
DROP PROCEDURE IF EXISTS GetRssItemEnclosures $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetRssItemEnclosures(IN p_id INT)
BEGIN
SELECT e.*
FROM enclosures e
WHERE e.rss_item_id = p_id;
END $$

# function get rss item ID
DROP FUNCTION IF EXISTS GetRssItemID $$
CREATE DEFINER=`wiserss`@`localhost`
FUNCTION GetRssItemID(p_link TEXT)
  RETURNS INT UNSIGNED
  CONTAINS SQL
	DETERMINISTIC
  SQL SECURITY INVOKER
BEGIN
DECLARE p_id INT UNSIGNED DEFAULT 0;
SELECT id
INTO p_id
FROM rss_items
WHERE link = p_link
LIMIT 1;
RETURN p_id;
END $$

# insert rss item
DROP PROCEDURE IF EXISTS InsertRssItem $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE InsertRssItem(IN p_channel_id INT UNSIGNED,
                        IN p_author VARCHAR(255),
                        IN p_category_id INT UNSIGNED,
                        IN p_comments TEXT,
                        IN p_description MEDIUMTEXT,
                        IN p_guid TEXT,
                        IN p_link TEXT,
                        IN p_source TEXT,
                        IN p_publication_date DATETIME,
                        IN p_title TEXT,
                        IN p_favorite TINYINT(1),
                        OUT p_id BIGINT UNSIGNED)
BEGIN
SET p_id = GetRssItemID(p_link);
IF p_id = 0 THEN
  INSERT INTO rss_items(id,
                        channel_id,
                        author,
                        category_id,
                        comments,
                        description,
                        guid,
                        link,
                        source,
                        publication_date,
                        title,
                        favorite)
                 VALUES(id,
                        p_channel_id,
                        p_author,
                        p_category_id,
                        p_comments,
                        p_description,
                        p_guid,
                        p_link,
                        p_source,
                        p_publication_date,
                        p_title,
                        p_favorite);
  SET p_id = GetRssItemID(p_link);
END IF;
END $$

# update rss item
DROP PROCEDURE IF EXISTS UpdateRssItem $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE UpdateRssItem(IN p_id BIGINT UNSIGNED,
                        IN p_channel_id INT UNSIGNED,
                        IN p_author VARCHAR(255),
                        IN p_category_id INT UNSIGNED,
                        IN p_comments TEXT,
                        IN p_description MEDIUMTEXT,
                        IN p_guid TEXT,
                        IN p_link TEXT,
                        IN p_source TEXT,
                        IN p_publication_date DATETIME,
                        IN p_title TEXT,
                        IN p_favorite TINYINT(1))
BEGIN
IF p_id > 0 THEN
  UPDATE rss_items
    SET channel_id = p_channel_id,
        author = p_author,
        category_id = p_category_id,
        comments = p_comments,
        description = p_description,
        guid = p_guid,
        link = p_link,
        source = p_source,
        publication_date = p_publication_date,
        title = p_title,
        favorite = p_favorite
  WHERE id = p_id;
END IF;
END $$

# delete rss item
DROP PROCEDURE IF EXISTS DeleteRssItem $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE DeleteRssItem(IN p_id INT UNSIGNED)
BEGIN
IF p_id > 0 THEN
  DELETE FROM rss_items
    WHERE id = p_id;
END IF;
END $$

##################################################
##################### Clouds #####################
##################################################

# get clouds
DROP PROCEDURE IF EXISTS GetClouds $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetClouds()
BEGIN
SELECT *
FROM clouds;
END $$

# get cloud
DROP PROCEDURE IF EXISTS GetCloud $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetCloud(IN p_id INT UNSIGNED)
BEGIN
SELECT *
FROM clouds
WHERE id = p_id
LIMIT 1;
END $$

# get cloud for channel
DROP PROCEDURE IF EXISTS GetCloudForChannel $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetCloudForChannel(IN p_id INT UNSIGNED)
BEGIN
SELECT c.*
FROM rss_channels rc
  JOIN clouds c
  ON rc.cloud_id = c.id
WHERE rc.id = p_id
LIMIT 1;
END $$

# function get cloud ID
DROP FUNCTION IF EXISTS GetCloudID $$
CREATE DEFINER=`wiserss`@`localhost`
FUNCTION GetCloudID(p_domain TEXT,
                    p_port SMALLINT UNSIGNED,
                    p_path TEXT,
                    p_register_procedure TEXT,
                    p_protocol BIT(4))
  RETURNS INT UNSIGNED
  CONTAINS SQL
	DETERMINISTIC
  SQL SECURITY INVOKER
BEGIN
DECLARE p_id INT UNSIGNED DEFAULT 0;
SELECT id
INTO p_id
FROM clouds
WHERE domain = p_domain
  AND port   = p_port
  AND path   = p_path
  AND register_procedure = p_register_procedure
  AND protocol = p_protocol
LIMIT 1;
RETURN p_id;
END $$

# insert cloud
DROP PROCEDURE IF EXISTS InsertCloud $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE InsertCloud(IN p_domain TEXT,
                      IN p_port SMALLINT UNSIGNED,
                      IN p_path TEXT,
                      IN p_register_procedure TEXT,
                      IN p_protocol BIT(4),
                      OUT p_id INT UNSIGNED)
BEGIN
SET p_id = GetCloudID(p_domain,p_port,p_path,p_register_procedure,p_protocol);
IF p_id = 0 THEN
  INSERT INTO clouds(id,
                     domain,
                     port,
                     path,
                     register_procedure,
                     protocol)
              VALUES(id,
                     p_domain,
                     p_port,
                     p_path,
                     p_register_procedure,
                     p_protocol);
  SET p_id = GetCloudID(p_domain,p_port,p_path,p_register_procedure,p_protocol);
END IF;
END $$

# update cloud
DROP PROCEDURE IF EXISTS UpdateCloud $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE UpdateCloud(IN p_id INT UNSIGNED,
                      IN p_domain TEXT,
                      IN p_port SMALLINT UNSIGNED,
                      IN p_path TEXT,
                      IN p_register_procedure TEXT,
                      IN p_protocol BIT(4))
BEGIN
IF p_id > 0 THEN
  UPDATE clouds
    SET domain = p_domain,
        port = p_port,
        path = p_path,
        register_procedure = p_register_procedure,
        protocol = p_protocol
  WHERE id = p_id;
END IF;
END $$

# delete cloud
DROP PROCEDURE IF EXISTS DeleteCloud $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE DeleteCloud(IN p_id INT UNSIGNED)
BEGIN
IF p_id > 0 THEN
  DELETE FROM clouds
    WHERE id = p_id;
END IF;
END $$

##################################################
################### Text inputs ##################
##################################################

# get text inputs
DROP PROCEDURE IF EXISTS GetTextInputs $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetTextInputs()
BEGIN
SELECT *
FROM text_inputs;
END $$

# get text input
DROP PROCEDURE IF EXISTS GetTextInput $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE GetTextInput(IN p_id INT UNSIGNED)
BEGIN
SELECT *
FROM text_inputs
WHERE id = p_id
LIMIT 1;
END $$

# function rss text input ID
DROP FUNCTION IF EXISTS GetTextInputID $$
CREATE DEFINER=`wiserss`@`localhost`
FUNCTION GetTextInputID(p_link VARCHAR(255)) RETURNS INT UNSIGNED
  CONTAINS SQL
	DETERMINISTIC
  SQL SECURITY INVOKER
BEGIN
DECLARE p_id INT UNSIGNED DEFAULT 0;
SELECT id
INTO p_id
FROM text_inputs
WHERE link = p_link
LIMIT 1;
RETURN p_id;
END $$

# insert text input
DROP PROCEDURE IF EXISTS InsertTextInput $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE InsertTextInput(IN p_description VARCHAR(255),
                          IN p_name VARCHAR(255),
                          IN p_link VARCHAR(255),
                          IN p_title VARCHAR(255),
                          OUT p_id INT UNSIGNED)
BEGIN
SET p_id = GetTextInputID(p_link);
IF p_id = 0 THEN
  INSERT INTO text_inputs(id,
                          description,
                          name,
                          link,
                          title)
                   VALUES(id,
                          p_description,
                          p_name,
                          p_link,
                          p_title);
  SET p_id = GetTextInputID(p_link);
END IF;
END $$

# update text input
DROP PROCEDURE IF EXISTS UpdateTextInput $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE UpdateTextInput(IN p_id INT UNSIGNED,
                          IN p_description VARCHAR(255),
                          IN p_name VARCHAR(255),
                          IN p_link VARCHAR(255),
                          IN p_title VARCHAR(255))
BEGIN
IF p_id > 0 THEN
  UPDATE text_inputs
    SET description = p_description,
        link = p_link,
        name = p_name,
        title = p_title
  WHERE id = p_id;
END IF;
END $$

# delete text input
DROP PROCEDURE IF EXISTS DeleteTextInput $$
CREATE DEFINER=`wiserss`@`localhost`
PROCEDURE DeleteTextInput(IN p_id INT UNSIGNED)
BEGIN
IF p_id > 0 THEN
  DELETE FROM text_inputs
    WHERE id = p_id;
END IF;
END $$

DELIMITER ;