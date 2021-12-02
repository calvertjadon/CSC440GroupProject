DROP TRIGGER IF EXISTS `calvert_grade_before_delete`;

CREATE TRIGGER `calvert_grade_before_delete` BEFORE DELETE ON `calvert_grade` FOR EACH ROW # subtract old credit hours and grade points
BEGIN
UPDATE
	calvert_student
SET
	GradePoints = GradePoints - (
		SELECT
			calvert_map_gradeletter_to_gradepoint(grade.letter, course.hours)
		FROM
			calvert_course course
			JOIN calvert_grade grade ON course.Prefix = grade.CoursePrefix
			AND course.Number = grade.CourseNum
			AND course.Year = grade.Year
			AND course.Semester = grade.Semester
		WHERE
			grade.StudentId = OLD.StudentId
			AND grade.CoursePrefix = OLD.CoursePrefix
			AND grade.CourseNum = OLD.CourseNum
			AND grade.Year = OLD.Year
			AND grade.Semester = OLD.Semester
	),
	CreditHours = CreditHours - (
		SELECT
			course.Hours
		FROM
			calvert_course course
			JOIN calvert_grade grade ON course.Prefix = grade.CoursePrefix
			AND course.Number = grade.CourseNum
			AND course.Year = grade.Year
			AND course.Semester = grade.Semester
		WHERE
			grade.StudentId = OLD.StudentId
			AND grade.CoursePrefix = OLD.CoursePrefix
			AND grade.CourseNum = OLD.CourseNum
			AND grade.Year = OLD.Year
			AND grade.Semester = OLD.Semester
	),
	GPA = IFNULL((GradePoints / NULLIF(CreditHours, 0)), 0)
WHERE
	Id = OLD.StudentId;

END