import { TRole } from "../Types/TRole";

export interface UserSignup {
    userName: string
    email: string
    phoneNumber: string
    password: string
    confirmPassword: string
    role: TRole
}
