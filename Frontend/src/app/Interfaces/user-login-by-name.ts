import { UserLoginBase } from "./user-login-base";

export interface UserLoginByName extends UserLoginBase {
    name: string;
}
