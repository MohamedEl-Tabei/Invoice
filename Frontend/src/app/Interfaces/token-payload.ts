import { JwtPayload } from "jwt-decode";
import { TRole } from "../Types/TRole";

export interface TokenPayload extends JwtPayload {
    unique_name:string,
    role:TRole,
    roles:[TRole],
    
}
