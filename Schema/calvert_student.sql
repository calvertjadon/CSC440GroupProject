DROP TABLE IF EXISTS `calvert_student`;

CREATE TABLE IF NOT EXISTS `calvert_student` (
  `Id` varchar(4) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `GPA` float(3, 2) NOT NULL DEFAULT 0.00,
  `CreditHours` int(11) NOT NULL DEFAULT 0,
  `GradePoints` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`Id`)
);