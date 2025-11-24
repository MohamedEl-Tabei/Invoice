import { TRole } from "../../Types/TRole";

export interface User {
    userName: string;
    role:TRole;
    token: string;
    isAuthenticated: boolean;
}
