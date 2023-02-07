import { Injectable } from '@angular/core';
import { IMenuItem } from 'src/infrastructure/interfaces/IMenuItem';

@Injectable({
  providedIn: 'root'
})
export class MenuItemsService {
  constructor() { }

  getMainMenuItems(isLoggedInUser: boolean): IMenuItem[] {
    if (!isLoggedInUser) {
      return [
        {
          title: 'ЗA НЕСК', titleAlt: 'ABOUT NESC', alias: 'about-nesc', isVisible: true, children: [
            { title: 'За портала', titleAlt: 'About portal', alias: 'portal-info', icon: 'auto_stories_outline', routerLink: 'aboutportal', isVisible: true },
            { title: 'Какво е НЕСК?', titleAlt: 'What is NESC?', alias: 'nesc-info', icon: 'help_outline', routerLink: 'aboutnesc', isVisible: true },
            { title: 'Справка по ЕАН', titleAlt: 'UAN verification', alias: 'uan-info', icon: 'folder_shared_outline', routerLink: 'aboutuan', isVisible: true }
          ]
        }
      ]
    }

    return [
      {
        title: 'За НЕСК', titleAlt: 'About NESC', alias: 'about-nesc', icon:  'info_outline', isVisible: true, children: [
          { title: 'За портала', titleAlt: 'About portal', alias: 'portal-info', icon: 'auto_stories_outline', routerLink: 'aboutportal', isVisible: true },
          { title: 'Какво е НЕСК?', titleAlt: 'What is NESC?', alias: 'nesc-info', icon: 'help_outline', routerLink: 'aboutnesc', isVisible: true },
          { title: 'Справка по ЕАН', titleAlt: 'UAN verification', alias: 'uan-info', icon: 'folder_shared_outline', routerLink: 'aboutuan', isVisible: true }
        ]
      },
      {
        title: 'Студентска карта', titleAlt: 'Student card', alias: 'student-card', icon: 'credit_card', routerLink: '/electronic/card', isVisible: true
      }
    ]
  }
}
