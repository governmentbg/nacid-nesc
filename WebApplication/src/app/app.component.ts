import { Component } from '@angular/core';
import { UserLoginService } from 'src/modules/user/services/user-login.service';
import { UserLoginEventEnum } from 'src/modules/user/enums/user-login-event.enum';
import { IMenuItem } from 'src/infrastructure/interfaces/IMenuItem';
import { MenuItemsService } from './menu/services/menu-items.service';
import { MatDialog } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isLoggedIn = false;
  menuItems: IMenuItem[] = [];
  currentYear: number;

  constructor(
    private userService: UserLoginService,
    private menuItemsService: MenuItemsService,
    public dialog: MatDialog,
    public translate: TranslateService
  ) {
    this.currentYear = new Date().getFullYear();
  }

  ngOnInit(): void {
    this.isLoggedIn = this.userService.isLogged;
    this.menuItems = this.menuItemsService.getMainMenuItems(this.isLoggedIn);

    this.userService.subscribe((value: { event: UserLoginEventEnum }) => {
      this.isLoggedIn = value.event === UserLoginEventEnum.login;
      this.menuItems = this.menuItemsService.getMainMenuItems(this.isLoggedIn);
    });
  }
}
