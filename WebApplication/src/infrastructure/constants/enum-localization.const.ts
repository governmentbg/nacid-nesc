import { CourseType } from "src/modules/student/enums/course-type.enum";
import { GenderType } from "src/modules/student/enums/gender-type.enum";
import { LotState } from "src/modules/student/enums/lot-state.enum";
import { PreviousEducationType } from "src/modules/student/enums/previous-education-type.enum";
import { PreviousHighSchoolEducationType } from "src/modules/student/enums/previous-high-school-education-type.enum";
import { Semester } from "src/modules/student/enums/semester.enum";
import { StudentProtocolType } from "src/modules/student/enums/student-protocol-type.enum";
import { YearType } from "src/modules/student/enums/year-type.enum";

export const CourseTypeEnumLocalization = {
  [CourseType.first]: 'Първи',
  [CourseType.second]: 'Втори',
  [CourseType.third]: 'Трети',
  [CourseType.fourth]: 'Четвърти',
  [CourseType.fifth]: 'Пети',
  [CourseType.sixth]: 'Шести',
  [CourseType.seventh]: 'Седми',
};

export const GenderTypeEnumLocalization = {
  [GenderType.male]: 'Мъж',
  [GenderType.female]: 'Жена',
};

export const LotStateEnumLocalization = {
  [LotState.actual]: 'Актуално състояние',
  [LotState.pendingApproval]: 'Изпратен за вписване',
  [LotState.cancelApproval]: 'Върнат за редакция',
  [LotState.missingPassportCopy]: 'Липсва документ за самоличност',
  [LotState.erased]: 'Изтрит',
};

export const PreviousEducationTypeEnumLocalization = {
  [PreviousEducationType.secondary]: 'Средно',
  [PreviousEducationType.highSchool]: 'Висше',
};

export const PreviousHighSchoolEducationTypeEnumLocalization = {
  [PreviousHighSchoolEducationType.fromRegister]: 'В България',
  [PreviousHighSchoolEducationType.missingInRegister]: 'В България',
  [PreviousHighSchoolEducationType.abroad]: 'В чужбина',
  [PreviousHighSchoolEducationType.closedInstitution]: 'Закрито ВУ/НО в България',
};

export const SemesterEnumLocalization = {
  [Semester.first]: 'I',
  [Semester.second]: 'II',
};

export const YearTypeEnumLocalization = {
  [YearType.firstYear]: 'Първа година',
  [YearType.secondYear]: 'Втора година',
  [YearType.thirdYear]: 'Трета година',
  [YearType.fourthYear]: 'Четвърта година',
  [YearType.fifthYear]: 'Пета година',
}

export const StudentProtocolTypeEnumLocalization = {
  [StudentProtocolType.stateExamination]: 'Държавен изпит',
  [StudentProtocolType.thesisDefense]: 'Защита на дипломна работа',
  [StudentProtocolType.stateExaminationOrThesisDefense]: 'Държавен изпит/Защита на дипломна работа',
}