import { NomenclatureDto } from "src/infrastructure/models/nomenclature.dto";
import { PreviousEducationType } from "src/modules/student/enums/previous-education-type.enum";
import { PreviousHighSchoolEducationType } from "src/modules/student/enums/previous-high-school-education-type.enum";

export class BasePeDto {
  peType: PreviousEducationType;
  peHighSchoolType?: PreviousHighSchoolEducationType;

  peDiplomaNumber: string;
  peDiplomaDate: Date;
  peResearchArea: NomenclatureDto;

  peEducationalQualification: NomenclatureDto;
  peAcquiredForeignEducationalQualification: NomenclatureDto;

  peInstitution: NomenclatureDto;
  peSubordinate: NomenclatureDto;
  peSpeciality: NomenclatureDto;

  peInstitutionName: string;
  peSubordinateName: string;

  peSpecialityName: string;

  peCountry: NomenclatureDto;
  peRecognizedSpeciality: string;
  peAcquiredSpeciality: string;

  peRecognitionNumber: string;
  peRecognitionDate: Date;
}