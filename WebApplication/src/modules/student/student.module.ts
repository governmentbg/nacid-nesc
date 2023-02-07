import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { CommonBootstrapModule } from 'src/infrastructure/common-bootstrap.module';
import { CommonMaterialModule } from 'src/infrastructure/common-material.module';
import { ElectronicCardComponent } from './components/electronic-card/electronic-card.component';
import { StudentBasicAdditionalTabsComponent } from './components/student-basic/additional-tabs/student-basic-additional-tabs.component';
import { StudentBasicComponent } from './components/student-basic/student-basic.component';
import { StudentCommonComponent } from './components/student-common.component';
import { DoctoralComponent } from './components/student-doctoral/doctoral/doctoral.component';
import { StudentDoctoralSemesterComponent } from './components/student-doctoral/doctoral/student-doctoral-semester.component';
import { StudentDoctoralComponent } from './components/student-doctoral/student-doctoral.component';
import { StudentPreviousEducationAbroadComponent } from './components/student-previous-education-abroad/student-previous-education-abroad.component';
import { StudentPreviousEducationComponent } from './components/student-previous-education/student-previous-education.component';
import { StudentSecondaryComponent } from './components/student-secondary/student-secondary.component';
import { StudentUniversityComponent } from './components/student-university/student-university.component';
import { StudentDiplomaComponent } from './components/student-university/university/student-diploma.component';
import { StudentSemesterComponent } from './components/student-university/university/student-semester.component';
import { UniversityComponent } from './components/student-university/university/university.component';
import { ElectronicCardResource } from './resources/electronic-card.resource';
import { StudentResource } from './resources/student.resource';
import { StudentRoutingModule } from './student-routing.module';

@NgModule({
  declarations: [
    StudentBasicComponent,
    StudentBasicAdditionalTabsComponent,
    StudentCommonComponent,
    StudentUniversityComponent,
    StudentSecondaryComponent,
    StudentPreviousEducationComponent,
    StudentPreviousEducationAbroadComponent,
    StudentDoctoralComponent,
    UniversityComponent,
    DoctoralComponent,
    StudentDiplomaComponent,
    StudentSemesterComponent,
    StudentDoctoralSemesterComponent,
    ElectronicCardComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    CommonBootstrapModule,
    CommonMaterialModule,
    TranslateModule,
    StudentRoutingModule
  ],
  providers: [
    StudentResource,
    ElectronicCardResource
  ]
})
export class StudentModule { }
