create database if not exists wiserss;
use wiserss;

drop table if exists rss_channels;
CREATE TABLE rss_channels (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT,
  cloud_id INT UNSIGNED COMMENT 'Allows processes to register with a cloud to be notified of updates to the channel,
                                 implementing a lightweight publish-subscribe protocol for RSS feeds',
  copyright TEXT COMMENT 'Copyright notice for content in the channel.',
  description MEDIUMTEXT NOT NULL COMMENT 'Phrase or sentence describing the channel',
  docs VARCHAR(255) COMMENT 'A URL that points to the documentation for the format used in the RSS file',
  generator VARCHAR(255) COMMENT 'A string indicating the program used to generate the channel',
  language_id INT UNSIGNED COMMENT 'The language the channel is written in',
  last_build_date DATETIME COMMENT 'The last time the content of the channel changed',
  link TEXT NOT NULL COMMENT 'The URL to the HTML website corresponding to the channel',
  managing_editor TEXT COMMENT 'Email address for person responsible for editorial content',
  publication_date DATETIME COMMENT 'The publication date for the content in the channel',
  rating VARCHAR(255) COMMENT 'The PICS rating for the channel',
  skip_days INT UNSIGNED COMMENT 'A hint for aggregators telling them which hours they can skip',
  skip_hours INT UNSIGNED COMMENT 'A hint for aggregators telling them which days they can skip',
  text_input_id INT UNSIGNED COMMENT 'Specifies a text input box that can be displayed with the channel',
  title TEXT NOT NULL COMMENT 'The name of the channel. Its how people refer to service',
  ttl INTEGER UNSIGNED COMMENT 'Number of minutes that indicates how long a channel can be cached before refreshing from the source',
  webmaster TEXT COMMENT 'Email address for person responsible for technical issues relating to channel',
  count SMALLINT UNSIGNED NOT NULL COMMENT '',
  PRIMARY KEY (id),
  CONSTRAINT FK_cloud_id FOREIGN KEY (cloud_id) REFERENCES clouds(id)
  ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT FK_language_id FOREIGN KEY (language_id) REFERENCES languages(id)
  ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT FK_text_input_id FOREIGN KEY (text_input_id) REFERENCES text_inputs(id)
  ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/* A channel may contain any number of <item>s.
   An item may represent a "story" -- much like a story in a newspaper
   or magazine; if so its description is a synopsis of the story,
   and the link points to the full story.
   An item may also be complete in itself, if so, the description
   contains the text (entity-encoded HTML is allowed; see examples),
  and the link and title may be omitted. All elements of an item are optional,
  however at least one of title or description must be present.
 */
drop table if exists rss_items;
CREATE TABLE rss_items (
  id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  channel_id INT UNSIGNED NOT NULL,
  author VARCHAR(255) COMMENT 'Email address of the author of the item',
  category_id INT UNSIGNED COMMENT 'Includes the item in one or more categories',
  comments TEXT COMMENT 'Allows an item to link to comments about that item',
  description MEDIUMTEXT NOT NULL COMMENT 'The item synopsis',
  guid TEXT COMMENT 'A string that uniquely identifies the item',
  link TEXT COMMENT 'The URL of the item',
  source TEXT COMMENT 'The RSS channel that the item came from',
  publication_date DATETIME COMMENT 'Indicates when the item was published',
  title TEXT NOT NULL COMMENT 'The title of the item',
  favorite BIT COMMENT 'Specifies if the item is marked as favorite (1=favorite)',
  PRIMARY KEY (id),
  INDEX item_idx(id),
  INDEX channel_idx(channel_id),
  INDEX category_idx(category_id),
  CONSTRAINT FK_channel_id FOREIGN KEY (channel_id) REFERENCES rss_channels(id)
  ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT FK_category FOREIGN KEY (category_id) REFERENCES categories(id)
  ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/* Specify one or more categories that the channel belongs to */
drop table if exists rss_channel_categories;
CREATE TABLE rss_channel_categories (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT,
  category_id INT UNSIGNED NOT NULL,
  rss_channel_id INT UNSIGNED NOT NULL,
  PRIMARY KEY (id),
  INDEX rc_categories_idx(id),
  INDEX category_idx(category_id),
  INDEX rss_channel_idx(rss_channel_id),
  CONSTRAINT FK_category FOREIGN KEY (category_id) REFERENCES categories(id)
  ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT FK_rss_channel FOREIGN KEY (rss_channel_id) REFERENCES rss_channels(id)
  ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

drop table if exists rss_item_categories;
CREATE TABLE rss_item_categories (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT,
  category_id INT UNSIGNED NOT NULL,
  rss_item_id INT UNSIGNED NOT NULL,
  PRIMARY KEY (id),
  INDEX ri_categories_idx(id),
  INDEX category_idx(category_id),
  INDEX rss_item_idx(rss_item_id),
  CONSTRAINT FK_category FOREIGN KEY (category_id) REFERENCES categories(id)
  ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT FK_rss_item FOREIGN KEY (rss_item_id) REFERENCES rss_items(id)
  ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

drop table if exists categories;
CREATE TABLE categories (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT,
  name VARCHAR(255) NOT NULL,
  PRIMARY KEY (id),
  INDEX categories_idx(id),
  INDEX categories_name_idx(name)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

drop table if exists clouds;
CREATE TABLE clouds (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT,
  domain TEXT NOT NULL,
  port SMALLINT UNSIGNED NOT NULL,
  path TEXT NOT NULL,
  register_procedure TEXT NOT NULL,
  protocol BIT(4) NOT NULL,
  PRIMARY KEY (id),
  INDEX clouds_idx(id)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

drop table if exists languages;
CREATE TABLE languages (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT,
  identifier VARCHAR(5) NOT NULL,
  language VARCHAR(64),
  PRIMARY KEY (id),
  INDEX languages_idx(id),
  INDEX indentifier_idx(identifier),
  INDEX language_idx(language)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;


/* The purpose of the <textInput> element is something of a mystery.
 *  You can use it to specify a search engine box.
 *  Or to allow a reader to provide feedback. Most aggregators ignore it.
 */
drop table if exists text_inputs;
CREATE TABLE text_inputs (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT,
  description VARCHAR(255) NOT NULL COMMENT 'Explains the text input area',
  name VARCHAR(255) NOT NULL COMMENT 'The name of the text object in the text input area',
  link VARCHAR(255) NOT NULL COMMENT 'The URL of the CGI script that processes text input requests',
  title VARCHAR(255) NOT NULL COMMENT 'The label of the Submit button in the text input area.',
  PRIMARY KEY (id),
  INDEX text_inputs_idx(id)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/* Specifies a image that can be displayed with the channel */
drop table if exists rss_channel_images;
CREATE TABLE rss_channel_images (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT,
  rss_channel_id INT UNSIGNED NOT NULL,
  url TEXT COMMENT 'Defines the URL to the image',
  title VARCHAR(255) COMMENT 'Defines the text to display if the image could not be shown',
  link TEXT COMMENT 'Defines the hyperlink to the website that offers the channel',
  image_path TEXT NOT NULL,
  PRIMARY KEY (id),
  INDEX rss_channel_images_idx(id, rss_channel_id),
  CONSTRAINT FK_rss_channel_id FOREIGN KEY (rss_channel_id) REFERENCES rss_channels(id)
  ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/* files included in an item */
drop table if exists enclosures;
CREATE TABLE enclosures (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT,
  rss_item_id INT UNSIGNED NOT NULL,
  length INT UNSIGNED NOT NULL COMMENT 'Defines the length (in bytes) of the media file',
  type VARCHAR(255) NOT NULL COMMENT 'Defines the MIME type of media file',
  url TEXT NOT NULL COMMENT 'Defines the URL to the media file',
  file BLOB NOT NULL,
  PRIMARY KEY (id),
  INDEX enclosures_idx(id),
  INDEX rss_item_images_idx(id, rss_item_id),
  CONSTRAINT FK_rss_item_id FOREIGN KEY (rss_item_id) REFERENCES rss_items(id)
  ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=MyISAM DEFAULT CHARSET=utf8;