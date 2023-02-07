import { NomenclatureDto } from "src/infrastructure/models/nomenclature.dto";
import { StudentStatusDto } from "../helpers/student-status.dto";

export class BaseSemesterDto {
  studentStatus: StudentStatusDto;
  studentEvent: NomenclatureDto;
  educationFeeType: NomenclatureDto;
}