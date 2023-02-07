import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/infrastructure/guards/auth.guard';
import { ElectronicCardComponent } from './components/electronic-card/electronic-card.component';
import { StudentCommonComponent } from './components/student-common.component';

const routes: Routes = [
  {
    path: 'student',
    component: StudentCommonComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'electronic/card',
    component: ElectronicCardComponent,
    canActivate: [AuthGuard]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudentRoutingModule { }
