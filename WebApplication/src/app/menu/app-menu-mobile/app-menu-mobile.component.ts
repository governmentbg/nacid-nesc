import { Component, Input } from '@angular/core';
import { IMenuItem } from 'src/infrastructure/interfaces/IMenuItem';
import { ChangeTabService } from 'src/modules/student/services/change-tab.service';

@Component({
  selector: 'app-menu-mobile',
  templateUrl: './app-menu-mobile.component.html',
  styleUrls: ['./app-menu-mobile.component.css'],
})
export class AppMenuMobileComponent {
  @Input() menuOpened: boolean;
  @Input() menuItems: IMenuItem[] = [];
  @Input() isLoggedIn: boolean;

  constructor(private changeTabService: ChangeTabService) {
  }

  switchTab(index: number) {
    this.changeTabService.setTabIndex(index);
  }
}