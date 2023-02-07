import { CourseType } from "src/modules/student/enums/course-type.enum";
import { GenderType } from "src/modules/student/enums/gender-type.enum";
import { LotState } from "src/modules/student/enums/lot-state.enum";
import { PreviousEducationType } from "src/modules/student/enums/previous-education-type.enum";
import { PreviousHighSchoolEducationType } from "src/modules/student/enums/previous-high-school-education-type.enum";
import { Semester } from "src/modules/student/enums/semester.enum";
import { StudentProtocolType } from "src/modules/student/enums/student-protocol-type.enum";
import { YearType } from "src/modules/student/enums/year-type.enum";

export const CourseTypeEnumLocalizationEn = {
  [CourseType.first]: 'First',
  [CourseType.second]: 'Second',
  [CourseType.third]: 'Third',
  [CourseType.fourth]: 'Fourth',
  [CourseType.fifth]: 'Fifth',
  [CourseType.sixth]: 'Sixth',
  [CourseType.seventh]: 'Seventh',
};

export const GenderTypeEnumLocalizationEn = {
  [GenderType.male]: 'Male',
  [GenderType.female]: 'Female',
};

export const LotStateEnumLocalizationEn = {
  [LotState.actual]: 'Actual',
  [LotState.pendingApproval]: 'Pending approval',
  [LotState.cancelApproval]: 'Canceled approval',
  [LotState.missingPassportCopy]: 'Missing passport copy',
  [LotState.erased]: 'Erased',
};

export const PreviousEducationTypeEnumLocalizationEn = {
  [PreviousEducationType.secondary]: 'Secondary',
  [PreviousEducationType.highSchool]: 'Higher',
};

export const PreviousHighSchoolEducationTypeEnumLocalizationEn = {
  [PreviousHighSchoolEducationType.fromRegister]: 'In Bulgaria',
  [PreviousHighSchoolEducationType.missingInRegister]: 'In Bulgaria',
  [PreviousHighSchoolEducationType.abroad]: 'Abroad',
  [PreviousHighSchoolEducationType.closedInstitution]: 'Closed institution',
};

export const SemesterEnumLocalizationEn = {
  [Semester.first]: 'I',
  [Semester.second]: 'II',
};

export const YearTypeEnumLocalizationEn = {
  [YearType.firstYear]: 'First year',
  [YearType.secondYear]: 'Second year',
  [YearType.thirdYear]: 'Third year',
  [YearType.fourthYear]: 'Fourth year',
  [YearType.fifthYear]: 'Fifth year',
}

export const StudentProtocolTypeEnumLocalization = {
  [StudentProtocolType.stateExamination]: 'State Examination',
  [StudentProtocolType.thesisDefense]: 'Thesis defense',
  [StudentProtocolType.stateExaminationOrThesisDefense]: 'State exam/Thesis defense',
}