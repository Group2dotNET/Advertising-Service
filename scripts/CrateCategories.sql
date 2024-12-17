-- delete from "Category"

-- insert into "Category" ("Id", "Name", "Description", "ParentCategoryId")
-- values 
-- (1, 'Одежда', 'Одежда', null),
-- (2, 'Электроника', 'Электроника', null),
-- (3, 'Услуги', 'Услуги', null),
-- (4, 'Хобби', 'Хобби', null),
-- (5, 'Развлечения', 'Развлечения', null);

-- insert into "Category" ("Name", "Description", "ParentCategoryId")
-- values 
-- ('Верхняя одежда', '', 1),
-- ('Обувь', '', 1),
-- ('Аксессуары', '', 1),
-- ('Футболки', '', 1),
-- ('Штаны', '', 1);

-- insert into "Category" ("Name", "Description", "ParentCategoryId")
-- values 
-- ('Телефоны', '', 2),
-- ('Компьютеры', '', 2),
-- ('Аудио и видео', '', 2);

-- insert into "Category" ("Name", "Description", "ParentCategoryId")
-- values 
-- ('Красота и здоровье', '', 3),
-- ('Перевозки', '', 3),
-- ('Ремонт и строительство', '', 3);

-- insert into "Category" ("Name", "Description", "ParentCategoryId")
-- values 
-- ('Музыка', '', 4),
-- ('Рисование', '', 4),
-- ('Коллекционирование', '', 4);

-- insert into "Category" ("Name", "Description", "ParentCategoryId")
-- values 
-- ('Билеты', '', 5),
-- ('Фильмы', '', 5),
-- ('Игры', '', 5);

select * from "Category"