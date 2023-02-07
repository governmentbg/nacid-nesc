import { NomenclatureDto } from "src/infrastructure/models/nomenclature.dto";

export class InstitutionDto extends NomenclatureDto {
  shortName: string;
  shortNameAlt: string;
}