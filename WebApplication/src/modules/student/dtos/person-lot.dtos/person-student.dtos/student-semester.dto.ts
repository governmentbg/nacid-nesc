import { CourseType } from "src/modules/student/enums/course-type.enum";
import { Semester } from "src/modules/student/enums/semester.enum";
import { BaseSemesterDto } from "../base.dtos/base-semester.dto";
import { PeriodDto } from "../helpers/period.dto";

export class StudentSemesterDto extends BaseSemesterDto {
  period: PeriodDto;
  course: CourseType;
  semester: Semester;
}