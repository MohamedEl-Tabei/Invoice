import { UserUniqueInputData } from "../Interfaces/user-unique-input-data";
import { TRole } from "../Types/TRole";
import { TTheme } from "../Types/TTheme";
import { AppValidators } from "../Validators";

export class Constants {
  //#region api
  public static readonly API_URL = 'https://localhost:7237/api/';
  //#endregion
  //#region user unique data used in login
  public static readonly UserUniqueInputData: UserUniqueInputData[] = [
    { label: 'Email', inputType: 'email', placeholder: 'user@invoice.com', id: 'email', validators: AppValidators.email },
    { label: 'Phone', inputType: 'tel', placeholder: '01020210495', id: 'phone', validators: AppValidators.phone },
    { label: 'Name', inputType: 'text', placeholder: 'USer123', id: 'name', validators: AppValidators.name },
  ]
  //#endregion
  //#region theme
  public static readonly Theme: { light: TTheme, dark: TTheme } = {
    light: "light",
    dark: "dark",
  }
  //#endregion
  //#region roles
  public static readonly Roles: { Customer: TRole, Admin: TRole, Shop: TRole, Restaurant: TRole, List: TRole[] } = {
    Customer: "Customer",
    Admin: "Admin",
    Shop: "Shop",
    Restaurant: "Restaurant",
    List: ["Customer"]
  }
  //#endregion
  //#region valid & invalid used in direcives
  public static readonly ValidationClass = {
    valid: ['dark:text-gray-500', 'text-gray-700'],
    invalid: ['text-red-500']
  }
  //#endregion
  //#region local storage keys
  public static readonly localStorageKey = {
    token: "token", theme: "theme"
  }
  //#endregion
  //#region toastr config
  public static readonly toastrConfig = {
    timeOut: 5000,
    positionClass: 'toast-bottom-left',
    progressBar: true,
    messageClass:"text-light"
  }
  //#endregion
}