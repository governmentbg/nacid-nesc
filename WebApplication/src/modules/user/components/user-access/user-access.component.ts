import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ChangeTabService } from 'src/modules/student/services/change-tab.service';
import { UserLoginService } from '../../services/user-login.service';

@Component({
  selector: 'user-access',
  templateUrl: 'user-access.component.html',
  styleUrls: ['./user-access.component.css']
})

export class UserAccessComponent implements OnInit {
  selectedIndex: number = 0;

  constructor(
    private router: Router,
    private userLoginService: UserLoginService,
    private changeTabService: ChangeTabService,
  ) {
    this.changeTabService.changeTabSubject.subscribe((index: number) => this.selectedIndex = index);
    this.selectedIndex = this.changeTabService.index;
  }

  ngOnInit(): void {
    if (this.userLoginService.isLogged) {
      this.router.navigate(['']);
    }
  }
}
