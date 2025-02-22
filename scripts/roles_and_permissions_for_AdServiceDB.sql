create role developer superuser createdb login password 'developer';
grant all privileges on database AnnouncementsServiceDB to developer;

create role application_user superuser login password 'appuser';
grant all privileges on database AnnouncementsServiceDB to application_user;