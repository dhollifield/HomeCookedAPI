USE [master]
GO
IF DB_ID('HomeCooked') IS NULL
CREATE DATABASE [HomeCooked]
GO
USE [HomeCooked]
GO

DROP TABLE IF EXISTS users
DROP TABLE IF EXISTS meals
DROP TABLE IF EXISTS meal_types
DROP TABLE IF EXISTS fuel_types
DROP TABLE IF EXISTS user_meals
DROP TABLE IF EXISTS family_members

CREATE TABLE users (
  id integer PRIMARY KEY IDENTITY,
  email varchar(255),
  first_name varchar(255),
  last_name varchar(255)
);

CREATE TABLE meals (
  id integer PRIMARY KEY IDENTITY,
  main_dish varchar(255),
  side_dish_1 varchar(255),
  side_dish_2 varchar(255),
  fuel_type_id integer
);

CREATE TABLE meal_types (
  id integer PRIMARY KEY IDENTITY,
  meal_type_name varchar(255)
);

CREATE TABLE fuel_types (
  id integer PRIMARY KEY IDENTITY,
  fuel_type_name varchar(255)
);

CREATE TABLE user_meals (
  id integer PRIMARY KEY IDENTITY,
  user_id integer,
  meal_id integer,
  meal_type_id integer,
  meal_date date
);

CREATE TABLE family_members (
  id integer PRIMARY KEY IDENTITY,
  user_id integer,
  member_name varchar(255)
);

ALTER TABLE meals ADD FOREIGN KEY (fuel_type_id) REFERENCES fuel_types (id);

ALTER TABLE user_meals ADD FOREIGN KEY (user_id) REFERENCES users (id);

ALTER TABLE user_meals ADD FOREIGN KEY (meal_id) REFERENCES meals (id);

ALTER TABLE user_meals ADD FOREIGN KEY (meal_type_id) REFERENCES meal_types (id);

ALTER TABLE family_members ADD FOREIGN KEY (user_id) REFERENCES users (id);

INSERT INTO 
meal_types(meal_type_name)
VALUES 
('Breakfast'),
('Brunch'),
('Lunch'),
('Dinner'),
('Snack');

INSERT INTO 
users(email, first_name, last_name)
VALUES 
('deannahollifield@gmail.com', 'Deanna', 'Hollifield'),
('katie@rhp.com', 'Katie', 'Greenwood'),
('dkilgore@randallhouse.com', 'Deborah', 'Kilgore');

INSERT INTO 
fuel_types(fuel_type_name)
VALUES
('S'),
('E'),
('FP'),
('XO'),
('PC'),
('NOP');

INSERT INTO 
meals(main_dish, side_dish_1, side_dish_2, fuel_type_id)
VALUES
('Cowboy Lasagna', 'Caesar Salad', 'Garlic Bread', 1),
('Meatloaf', 'Green Beans', 'Mashed Cauliflower', 1),
('No Bean Sweet Potato & Turkey Chili', 'Crackers', NULL, 2),
('Fake Hot Pocket', 'Strawberries', NULL, 1),
('Cinnamon Apple Oatmeal', NULL, NULL, 2),
('Bacon Cheese Wrap', 'Strawberries', NULL, 1)

INSERT INTO 
user_meals(user_id, meal_id, meal_type_id, meal_date)
VALUES
(3, 2, 4, '10-01-2023'),
(1, 3, 4, '09-24-2023'),
(2, 5, 1, '09-30-2023'),
(1, 6, 1, '09-25-2023');

INSERT INTO
family_members(user_id, member_name)
VALUES
(1, 'Michael'),
(1, 'Nick'),
(1, 'Audrey'),
(2, 'Steve'),
(2, 'Abby'),
(2, 'Ally'),
(2, 'Andie'),
(3, 'Wade');