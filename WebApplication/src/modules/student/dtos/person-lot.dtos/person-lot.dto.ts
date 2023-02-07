import { LotState } from "../../enums/lot-state.enum";
import { PersonBasicDto } from "./person-basic.dtos/person-basic.dto";
import { PersonDoctoralDto } from "./person-doctoral.dtos/person-doctoral.dto";
import { PersonSecondaryDto } from "./person-secondary.dtos/person-secondary.dto";
import { PersonStudentDto } from "./person-student.dtos/person-student.dto";

export class PersonLotDto {
  uan: string;
  lotState: LotState;
  createDate: Date;

  personBasicDto: PersonBasicDto = new PersonBasicDto();
  personSecondaryDto: PersonSecondaryDto = new PersonSecondaryDto();
  personStudentsDto: PersonStudentDto[] = [];
  personDoctoralsDto: PersonDoctoralDto[] = [];
}