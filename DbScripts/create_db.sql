create database WAESAssignmentDiffDb
GO

use WAESAssignmentDiffDb

GO

create table "DifferenceLeft"(
	Id int,
	Base64String varchar(8000)
);

create table "DifferenceRight"(
	Id int,
	Base64String varchar(8000)
);