import { AttachedFile } from "src/infrastructure/models/attached-file.model";
import { EducationBasicDto } from "./education-basic.dto";

export class StudentPortalSearchDto {
  fullName: string;
  fullNameAlt: string;
  lastNameAlt: string;
  uan: string;
  birthDate: Date;
  imgFile: AttachedFile;
  universities: EducationBasicDto[];
  doctorals: EducationBasicDto[];
}