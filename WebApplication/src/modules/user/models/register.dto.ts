import { RegisterIdentificationEnum } from "../enums/register-identification.enum";

export class RegisterDto {
  email: string;
  identificationType: RegisterIdentificationEnum;
  identificator: string;
}