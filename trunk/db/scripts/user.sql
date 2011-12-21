use mysql;
CREATE USER 'wiserss'@'localhost' IDENTIFIED BY 'wiserss';
GRANT ALL PRIVILEGES ON wiserss.* TO 'wiserss'@'localhost';