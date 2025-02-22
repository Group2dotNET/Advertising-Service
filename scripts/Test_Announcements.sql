select * from announcements a 

insert into announcements(title, description, create_date, update_date, category_id)
values 
	('iPhone 15 Pro Max, 256GB', '', (current_date - round(random() * 2000)::integer), null, 2),
	('iPhone 11, 64GB', 'Полный комплект: В отличном состоянии. Коробка. Использовался с защитным стеклом. Ростест. Отвязан от всех аккаунтов. Чехол в подарок. Все детали в рабочем состоянии. Любые проверки на месте. Не вскрывался.', (current_date - round(random() * 2000)::integer), null, 2),
	('Xiaomi POCO M3, 4/64GB', 'Телефон полностью в рабочем состоянии. В комплекте телефон, кабель, чехол. Обмен не интересует', (current_date - round(random() * 2000)::integer), null, 2),
	('Планшет Lenovo Tab4 10TB-X304L 10.1", 16GB', 'Планшет в защитном стекле, под стеклом экран новый. заряд держит отлично, мало использовался. Есть слот для сим карты или карты памяти. блок питания и зарядный провод в комплекте.', (current_date - round(random() * 2000)::integer), null, 2),
	('Телефон Диалог - На запчасти', 'Использовался часто. На корпусе имеются следы вскрытия.', (current_date - round(random() * 2000)::integer), null, 2),
	('Роутер mikrotik', 'MikroTik RB941Ui-2HnD Рабочий', (current_date - round(random() * 2000)::integer), null, 2),
	('Кологка Алиса миди новая', 'Продаю колонку Алиса , миди Подарили на день рождение 2 одинаковые.', (current_date - round(random() * 2000)::integer), null, 2), 
	('Apple TV 3 поколение', 'Полностью исправные.', (current_date - round(random() * 2000)::integer), null, 2),
	('Gopro 7', 'Состояние 5/5 только камера , акум новый', (current_date - round(random() * 2000)::integer), null, 2),
	('Видеокарта pelrdn', 'новая видеокарта, небольшой торг', (current_date - round(random() * 2000)::integer), null, 2), 
	('Сборка игровых ПК', 'Все делаем в лучшем качестве', (current_date - round(random() * 2000)::integer), null, 2)