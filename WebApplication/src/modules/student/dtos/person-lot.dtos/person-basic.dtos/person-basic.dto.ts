import { AttachedFile } from "src/infrastructure/models/attached-file.model";
import { NomenclatureCodeDto } from "src/infrastructure/models/nomenclature-code.dto";
import { NomenclatureDto } from "src/infrastructure/models/nomenclature.dto";
import { GenderType } from "src/modules/student/enums/gender-type.enum";

export class PersonBasicDto {
  firstName: string;
  middleName: string;
  lastName: string;
  otherNames: string;

  firstNameAlt: string;
  middleNameAlt: string;
  lastNameAlt: string;
  otherNamesAlt: string;

  uin: string;
  foreignerNumber: string;
  idnNumber: string;

  email: string;
  phoneNumber: string;

  gender: GenderType;
  birthDate: Date;

  birthCountry: NomenclatureCodeDto;
  birthDistrict: NomenclatureCodeDto;
  birthMunicipality: NomenclatureCodeDto;
  birthSettlement: NomenclatureCodeDto;

  citizenship: NomenclatureDto;
  secondCitizenship: NomenclatureDto;

  citizenshipFull: string;
  citizenshipFullAlt: string;

  residenceCountry: NomenclatureCodeDto;
  residenceDistrict: NomenclatureCodeDto;
  residenceMunicipality: NomenclatureCodeDto;
  residenceSettlement: NomenclatureCodeDto;
  residenceAddress: string;
  postCode: string;

  personImage: AttachedFile;

  residenceSettlementAndPostCode: string;
  residenceSettlementAndPostCodeAlt: string;
}