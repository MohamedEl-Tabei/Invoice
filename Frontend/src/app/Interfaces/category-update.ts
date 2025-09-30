export interface CategoryUpdate {
    id: string,
    concurrencyStamp: string,
    newName: string,
    oldName: string
}
