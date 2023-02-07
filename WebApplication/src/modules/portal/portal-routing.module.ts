import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./components/home/home.component";
import { StudentPortalSearchComponent } from "./components/student-portal-search/student-portal-search.component";
import { StudentPortalSearchResolver } from "./services/student-portal-search.resolver";

const routes: Routes = [
  {
    path: 'search',
    component: HomeComponent,
    pathMatch: 'full'
  },
  {
    path: 'search/student',
    component: StudentPortalSearchComponent,
    resolve: {
      model: StudentPortalSearchResolver
    },
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PortalRoutingModule { }
