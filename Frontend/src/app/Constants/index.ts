import { UserUniqueInputData } from "../Interfaces/user-unique-input-data";
import { TTheme } from "../Types/TTheme";
import { AppValidators } from "../Validators";

export class Constants {
  public static readonly API_URL = 'https://localhost:7237/api/';
  public static readonly UserUniqueInputData: UserUniqueInputData[] = [
    { label: 'Email', inputType: 'email', placeholder: 'user@invoice.com', id: 'email', validators: AppValidators.email },
    { label: 'Phone', inputType: 'tel', placeholder: '01020210495', id: 'phone', validators: AppValidators.phone },
    { label: 'Name', inputType: 'text', placeholder: 'USer123', id: 'name', validators: AppValidators.name },
  ]
  public static readonly Theme: { light: TTheme, dark: TTheme } = {
    light: "light",
    dark: "dark",
  }
}