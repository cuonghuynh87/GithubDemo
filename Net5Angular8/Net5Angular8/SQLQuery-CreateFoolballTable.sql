CREATE TABLE Positions (
    Id int NOT NULL PRIMARY KEY,
    Name nvarchar(255),
    DisplayOrder int
);


CREATE TABLE Players (
    Id int NOT NULL PRIMARY KEY,
	ShirtNo int,
    Name nvarchar(50),
    PositionId int FOREIGN KEY REFERENCES Positions(Id),
	Appearances int,
	Goals int
);


INSERT INTO Positions (Id, Name, DisplayOrder)
VALUES
    (1, 'Forward', 1),
    (2, 'Midfielder', 2),
    (3, 'Defender', 3),
	(4, 'Goalkeeper', 4);


INSERT INTO Players (Id, ShirtNo, Name, PositionId, Appearances, Goals)
VALUES
    (1, 8, 'Juan Mata', 1, 268, 58),
    (2, 6, 'Paul Pogba', 2, 130, 28),
    (3, 4, 'Phil Jones', 3, 200, 2),
	(4, 1, 'David de Gea', 4, 335, 0);