import { NomenclatureDto } from "src/infrastructure/models/nomenclature.dto";
import { Semester } from "src/modules/student/enums/semester.enum";

export class PeriodDto extends NomenclatureDto {
  year: number;
  semester: Semester;
}