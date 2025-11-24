import { ApiError } from "./api-error";

export interface ApiResponse<T> {
    data: T;
    successed: boolean;
    errors: ApiError[];
}
