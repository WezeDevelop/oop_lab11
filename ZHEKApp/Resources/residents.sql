-- residents.sql
CREATE TABLE Residents (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Phone TEXT,
    Email TEXT,
    Photo TEXT
);

CREATE TABLE Requests (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    ResidentId INTEGER,
    Date TEXT,
    Description TEXT,
    FOREIGN KEY(ResidentId) REFERENCES Residents(Id)
);
