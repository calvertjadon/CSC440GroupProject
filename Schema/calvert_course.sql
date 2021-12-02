DROP TABLE IF EXISTS `calvert_course`;

CREATE TABLE IF NOT EXISTS `calvert_course` (
  `Prefix` varchar(3) NOT NULL,
  `Number` varchar(3) NOT NULL,
  `Year` varchar(4) NOT NULL,
  `Semester` varchar(10) NOT NULL,
  `Hours` int(11) NOT NULL DEFAULT 3,
  PRIMARY KEY (`Prefix`, `Number`, `Year`, `Semester`)
);