create role developer superuser createdb login password 'developer';
grant all privileges on database AdServiceDB to developer;

create role application_user superuser login password 'appuser';
grant all privileges on database AdServiceDB to application_user;