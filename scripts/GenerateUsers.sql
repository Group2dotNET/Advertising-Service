select * from public."User"

insert into "User"
select gen_random_uuid(), concat('user', s.id), s.id
from generate_series(2, 50) as s(id);