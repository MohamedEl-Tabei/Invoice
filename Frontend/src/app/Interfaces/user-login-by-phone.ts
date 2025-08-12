import { UserLoginBase } from "./user-login-base";

export interface UserLoginByPhone extends UserLoginBase {
    phone: string;
}
