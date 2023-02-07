import { YearType } from "src/modules/student/enums/year-type.enum";
import { BaseSemesterDto } from "../base.dtos/base-semester.dto";

export class DoctoralSemesterDto extends BaseSemesterDto {
  protocolDate: Date;
  protocolNumber: string;
  yearType: YearType;
}