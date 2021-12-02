DROP TRIGGER IF EXISTS `calvert_grade_after_insert`;

CREATE TRIGGER `calvert_grade_after_insert`
AFTER
INSERT
	ON `calvert_grade` FOR EACH ROW # add new credit hours and grade points
	BEGIN
UPDATE
	calvert_student
SET
	GradePoints = GradePoints + (
		SELECT
			calvert_map_gradeletter_to_gradepoint(grade.letter, course.hours)
		FROM
			calvert_course course
			JOIN calvert_grade grade ON course.Prefix = grade.CoursePrefix
			AND course.Number = grade.CourseNum
			AND course.Year = grade.Year
			AND course.Semester = grade.Semester
		WHERE
			grade.StudentId = NEW.StudentId
			AND grade.CoursePrefix = NEW.CoursePrefix
			AND grade.CourseNum = NEW.CourseNum
			AND grade.Year = NEW.Year
			AND grade.Semester = NEW.Semester
	),
	CreditHours = CreditHours + (
		SELECT
			course.Hours
		FROM
			calvert_course course
			JOIN calvert_grade grade ON course.Prefix = grade.CoursePrefix
			AND course.Number = grade.CourseNum
			AND course.Year = grade.Year
			AND course.Semester = grade.Semester
		WHERE
			grade.StudentId = NEW.StudentId
			AND grade.CoursePrefix = NEW.CoursePrefix
			AND grade.CourseNum = NEW.CourseNum
			AND grade.Year = NEW.Year
			AND grade.Semester = NEW.Semester
	),
	GPA = IFNULL((GradePoints / NULLIF(CreditHours, 0)), 0)
WHERE
	Id = NEW.StudentId;

END