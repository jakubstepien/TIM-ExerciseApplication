import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';

import { Notification, NotificationType } from './Notification';

@Injectable()
export class NotificationService {
    private data: Subject<Notification> = new Subject<Notification>();


    get notification(): Observable<Notification> {
        return this.data;
    }

    info(title: string, message: string = ""): void {
        this.alert(NotificationType.Info, title, message);
    }

    warning(title: string, message: string = ""): void {
        this.alert(NotificationType.Warning,title, message);
    }

    error(title: string, message: string = ""): void {
        this.alert(NotificationType.Error, title, message);
    }

    alert( type: NotificationType, title: string, message: string = ""): void {
        this.data.next({ message: message, title: title, type: type });
    }
}