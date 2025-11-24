export interface AuditLog {
    date: Date
    details: string,
    action:"Create"|"Delete"|"Update"
}
