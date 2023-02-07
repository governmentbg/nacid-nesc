import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EAuthRedirectResponseComponent } from './e_authentication/eAuth-redirect-response.component';
import { AppAboutNescComponent } from './menu/app-menu-about-nesc/components/app-about-nesc/app-about-nesc.component';
import { AppAboutPortalComponent } from './menu/app-menu-about-nesc/components/app-about-portal/app-about-portal.component';
import { AppAboutUanVerificationComponent } from './menu/app-menu-about-nesc/components/app-about-uan-verification/app-about-uan-verification.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'student',
    pathMatch: 'full'
  },
  {
    path: 'eAuth',
    component: EAuthRedirectResponseComponent
  },
  {
    path: 'aboutnesc',
    component: AppAboutNescComponent
  },
  {
    path: 'aboutportal',
    component: AppAboutPortalComponent
  },
  {
    path: 'aboutuan',
    component: AppAboutUanVerificationComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy', scrollPositionRestoration: 'enabled', onSameUrlNavigation: 'reload' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
