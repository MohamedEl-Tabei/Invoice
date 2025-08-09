import { LoginBy } from "../Interfaces/login-by";

export class Constants {
  public static readonly API_URL = 'https://localhost:7237/api/';
  public static readonly loginTypes: LoginBy[] = [
    { by: 'Email', inputType: 'email', placeholder: 'user@invoice.com', id: 'email' ,value: ''},
    { by: 'Phone', inputType: 'tel', placeholder: '01020210495', id: 'phone' ,value: ''},
    { by: 'Name', inputType: 'text', placeholder: 'USer123', id: 'name', value: ''},
  ]
}