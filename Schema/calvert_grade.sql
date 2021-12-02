DROP TABLE IF EXISTS `calvert_grade`;

CREATE TABLE IF NOT EXISTS `calvert_grade` (
  `Letter` varchar(1) NOT NULL,
  `CoursePrefix` varchar(3) NOT NULL,
  `CourseNum` varchar(3) NOT NULL,
  `StudentId` varchar(4) NOT NULL,
  `Year` varchar(4) NOT NULL,
  `Semester` varchar(10) NOT NULL,
  PRIMARY KEY (
    `CoursePrefix`,
    `CourseNum`,
    `StudentId`,
    `Year`,
    `Semester`
  ),
  KEY `FK_Course` (`CoursePrefix`, `CourseNum`, `Year`, `Semester`),
  KEY `FK_Student` (`StudentId`),
  CONSTRAINT `FK_Course` FOREIGN KEY (`CoursePrefix`, `CourseNum`, `Year`, `Semester`) REFERENCES `calvert_course` (`Prefix`, `Number`, `Year`, `Semester`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_Student` FOREIGN KEY (`StudentId`) REFERENCES `calvert_student` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `valid_grade_letter` CHECK (
    `Letter` = 'A'
    or `Letter` = 'B'
    or `Letter` = 'C'
    or `Letter` = 'D'
    or `Letter` = 'F'
  )
);