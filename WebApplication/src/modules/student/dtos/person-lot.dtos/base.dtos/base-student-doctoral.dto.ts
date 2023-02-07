import { NomenclatureDto } from "src/infrastructure/models/nomenclature.dto"
import { InstitutionDto } from "../helpers/insitution.dto";
import { BasePeDto } from "./base-pe.dto";

export class BaseStudentDoctoralDto extends BasePeDto {
  institution: InstitutionDto;
  subordinate: NomenclatureDto;
  speciality: NomenclatureDto;
  admissionReason: NomenclatureDto;
  educationalForm: NomenclatureDto;
  educationalQualification: NomenclatureDto;
  duration: number | null;
  studentStatus: NomenclatureDto;
  studentEvent: NomenclatureDto;
}