import { NomenclatureDto } from "src/infrastructure/models/nomenclature.dto";

export class PersonSecondaryDto {
  graduationYear: number;
  country: NomenclatureDto;
  school: NomenclatureDto;
  schoolSettlement: NomenclatureDto;
  foreignSchoolName: string;
  profession: string;
  diplomaNumber: string;
  diplomaDate: Date;
}