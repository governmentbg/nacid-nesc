import { AttachedFile } from "src/infrastructure/models/attached-file.model";

export class ElectronicCardDto {
  uan: string;
  fullName: string;
  fullNameAlt: string;
  qrCodeImageBg: string;
  qrCodeImageEn: string;
  imageFile: AttachedFile;
  birthDate: Date;
  hasActiveSpecialities: boolean;
  hasActiveDoctorals: boolean;
}