DROP FUNCTION IF EXISTS `calvert_map_gradeletter_to_gradepoint`;

CREATE FUNCTION `calvert_map_gradeletter_to_gradepoint`(
	`gradeLetter` VARCHAR(1),
	`creditHours` INT
) RETURNS int(11) BEGIN DECLARE gradePoints INT;

IF gradeLetter = 'A' THEN
SET
	gradePoints = 4 * creditHours;

ELSEIF gradeLetter = 'B' THEN
SET
	gradePoints = 3 * creditHours;

ELSEIF gradeLetter = 'C' THEN
SET
	gradePoints = 2 * creditHours;

ELSEIF gradeLetter = 'D' THEN
SET
	gradePoints = 1 * creditHours;

ELSE
SET
	gradePoints = 0;

END IF;

RETURN (gradePoints);

END