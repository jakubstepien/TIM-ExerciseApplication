export interface Notification {
    title: string;
    message: string;
    timeToShow?: number;
    type: NotificationType;
}

export enum NotificationType {
    Info = 0,
    Warning = 1,
    Error = 2
}