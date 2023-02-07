import { NomenclatureDto } from "src/infrastructure/models/nomenclature.dto";
import { BaseStudentDoctoralDto } from "../base.dtos/base-student-doctoral.dto";
import { PersonStudentDiplomaDto } from "./person-student-diploma.dto";
import { StudentSemesterDto } from "./student-semester.dto";

export class PersonStudentDto extends BaseStudentDoctoralDto {
  facultyNumber: string;
  qualification: string;
  semesters: StudentSemesterDto[];
  school: NomenclatureDto;
  schoolSettlement: NomenclatureDto;
  diploma: PersonStudentDiplomaDto;
}