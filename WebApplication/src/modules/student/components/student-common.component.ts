import { Component } from '@angular/core';
import { LoadingIndicatorService } from 'src/app/loading-indicator/loading-indicator.service';
import { PersonLotDto } from '../dtos/person-lot.dtos/person-lot.dto';
import { StudentResource } from '../resources/student.resource';
import { ChangeTabService } from '../services/change-tab.service';
import { finalize } from 'rxjs/operators';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-student-common',
  templateUrl: './student-common.component.html',
  styleUrls: ['./student-common.component.css']
})
export class StudentCommonComponent {
  student: PersonLotDto = new PersonLotDto();
  selectedIndex: number = 0;

  constructor(
    private changeTabService: ChangeTabService,
    private studentResource: StudentResource,
    private loadingIndicator: LoadingIndicatorService,
    public translate: TranslateService
  ) {
    this.changeTabService.changeTabSubject.subscribe((index: number) => this.selectedIndex = index);
  }

  ngOnInit(): void {
    this.loadingIndicator.show();
    this.studentResource.getStudent()
      .pipe(
        finalize(() => this.loadingIndicator.hide())
      )
      .subscribe({
        next: (student: PersonLotDto) => {
          this.student = student;
        }
      });
  }
}
