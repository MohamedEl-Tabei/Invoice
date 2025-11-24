import { UserLoginBase } from "./user-login-base";

export interface UserLoginByEmail extends UserLoginBase {
    email: string;
    
}
