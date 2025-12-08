import { TRole } from "../../Types/TRole";

export interface User {
    userName: string;
    roles:TRole[];
    token: string;
    isAuthenticated: boolean;
}
