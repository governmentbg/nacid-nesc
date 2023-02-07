import { BaseStudentDoctoralDto } from "../base.dtos/base-student-doctoral.dto";
import { DoctoralSemesterDto } from "./doctoral-semester.dto";

export class PersonDoctoralDto extends BaseStudentDoctoralDto {
  startDate: Date;
  endDate: Date;
  semesters: DoctoralSemesterDto[];
}