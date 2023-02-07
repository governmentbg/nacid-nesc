import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { IMenuItem } from 'src/infrastructure/interfaces/IMenuItem';

@Component({
  selector: 'app-menu-items',
  templateUrl: './app-menu-items.component.html'
})
export class AppMenuItemComponent {
  menuOpened: boolean = false;
  @Input() menuItems: IMenuItem[] = [];
  @Input() isMobile: boolean;
  @Input() isLoggedIn: boolean;

  constructor(public translate: TranslateService,
    public router: Router) {
  }
}