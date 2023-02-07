import { PersonStudentDiplomaFile } from "./person-student-diploma-file.dto";

export class PersonStudentDiplomaDto {
  diplomaNumber: string;
  registrationDiplomaNumber: string;
  diplomaDate: Date | null;
  file: PersonStudentDiplomaFile;
  isValid: boolean;
}