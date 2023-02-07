import { NomenclatureDto } from "src/infrastructure/models/nomenclature.dto";
import { InstitutionDto } from "../helpers/institution.dto";
import { StudentStatusDto } from "../helpers/student-status.dto";

export class EducationBasicDto {
  id: number;
  institution: InstitutionDto;
  speciality: NomenclatureDto;
  educationalQualification: NomenclatureDto;
  educationalForm: NomenclatureDto;
  status: StudentStatusDto;
}