drop table if exists rss_channels;
CREATE TABLE rss_channels (
  id int(11) NOT NULL auto_increment,
  title text NOT NULL,
  description mediumtext NOT NULL,
  link text NOT NULL,
  published_date date,
  favorite tinyint(1),
  PRIMARY KEY (id)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

drop table if exists rss_items;
CREATE TABLE rss_items (
  id int(11) NOT NULL auto_increment,
  rss_id int(11) NOT NULL,
  title text NOT NULL,
  category_id int(11),
  description mediumtext NOT NULL,
  link text,
  PRIMARY KEY (id),
  CONSTRAINT rss_id
  FOREIGN KEY (rss_id)
  REFERENCES rss_channels(rss_id)
  ON DELETE CASCADE
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

drop table if exists categories;
CREATE TABLE categories (
  id int(11) NOT NULL auto_increment,
  name text NOT NULL,
  PRIMARY KEY (id)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

drop table if exists rss_images;
CREATE TABLE rss_images (
  id int(11) NOT NULL auto_increment,
  rssitem_id int(11) NOT NULL,
  image blob,
  PRIMARY KEY (id),
  CONSTRAINT rss_id
  FOREIGN KEY (rssitem_id)
  REFERENCES rss_items(rssitem_id)
  ON DELETE CASCADE
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

