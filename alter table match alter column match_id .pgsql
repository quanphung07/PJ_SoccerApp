alter table match alter column match_id add generated ALWAYS as IDENTITY
(start with 1 INCREMENT by 1);
insert into match(datetime,attendance,stadium_id,awayteam_name,hometeam_name) values
('01/01/2021',10000,1,'Brighton & Hove Albion','Arsenal'),
('01/08/2021',10000,1,'Tottenham Hotspur','Arsenal'),
('01/15/2021',10000,1,'Manchester City','Arsenal'),
('01/21/2021',10000,1,'Aston Villa','Arsenal'),
('01/28/2021',10000,1,'West Ham United','Arsenal'),
('02/04/2021',10000,1,'Chelsea','Arsenal'),
('02/11/2021',10000,1,'Everton','Arsenal'),
('02/18/2021',10000,1,'Sheffield United','Arsenal'),
('02/24/2021',10000,1,'Southampton','Arsenal'),
('03/01/2021',10000,1,'Leicester City','Arsenal'),
('03/08/2021',10000,1,'Leeds United','Arsenal'),
('03/14/2021',10000,1,'Liverpool','Arsenal'),
('03/21/2021',10000,1,'Fulham','Arsenal'),
('03/28/2021',10000,1,'West Bromwich Albion','Arsenal'),
('04/04/2021',10000,1,'Wolverhampton Wanderers','Arsenal'),
('04/11/2021',10000,1,'Crystal Palace','Arsenal'),
('04/18/2021',10000,1,'Newcastle','Arsenal'),
('04/22/2021',10000,1,'Manchester United','Arsenal'),
('04/29/2021',10000,1,'Burnley','Arsenal'),('01/01/2021',10000,1,'Brighton & Hove Albion','Arsenal'),
('01/02/2021',10000,15,'Arsenal','Brighton & Hove Albion'),
('01/08/2021',10000,15,'Tottenham Hotspur','Brighton & Hove Albion'	),
('01/15/2021',10000,15,'Manchester City','Brighton & Hove Albion'	),
('01/21/2021',10000,15,'Aston Villa','Brighton & Hove Albion'	),
('01/28/2021',10000,15,'West Ham United','Brighton & Hove Albion'	),
('02/04/2021',10000,15,'Chelsea','Brighton & Hove Albion'	),
('02/11/2021',10000,15,'Everton','Brighton & Hove Albion'	),
('02/18/2021',10000,15,'Sheffield United','Brighton & Hove Albion'	),
('02/24/2021',10000,15,'Southampton','Brighton & Hove Albion'	),
('03/01/2021',10000,15,'Leicester City','Brighton & Hove Albion'	),
('03/08/2021',10000,15,'Leeds United','Brighton & Hove Albion'	),
('03/14/2021',10000,15,'Liverpool','Brighton & Hove Albion'	),
('03/21/2021',10000,15,'Fulham','Brighton & Hove Albion'	),
('03/28/2021',10000,15,'West Bromwich Albion','Brighton & Hove Albion'	),
('04/04/2021',10000,15,'Wolverhampton Wanderers','Brighton & Hove Albion'	),
('04/11/2021',10000,15,'Crystal Palace','Brighton & Hove Albion'	),
('04/18/2021',10000,15,'Newcastle','Brighton & Hove Albion'	),
('04/22/2021',10000,15,'Manchester United','Brighton & Hove Albion'	),
('04/29/2021',10000,15,'Burnley','Brighton & Hove Albion')





