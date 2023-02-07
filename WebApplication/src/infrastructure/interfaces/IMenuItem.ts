export interface IMenuItem {
  title: string;
  titleAlt: string;
  alias: string;
  routerLink?: string;
  icon?: string;
  isVisible: boolean;
  children?: IMenuItem[];
}
