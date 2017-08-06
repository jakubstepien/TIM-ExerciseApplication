import { Component, OnInit, animate  } from '@angular/core';

import { Notification, NotificationType } from './Notification';

import { NotificationService } from './notification.service';

@Component({
    selector: 'notification',
    templateUrl: './notivication.template.html'
})
export class NotificationComponent implements OnInit {
    show: boolean;
    notification: Notification;
    timer: number;

    constructor(private notificationService: NotificationService) {
        this.timer;
    }

    ngOnInit(): void {
        this.notificationService.notification.subscribe((next) => {
            if (this.timer) {
                window.clearTimeout(this.timer)
            }
            let time = next.timeToShow ? next.timeToShow : 5000;
            this.timer = window.setTimeout(() => { this.show = false; this.timer = null }, time);
            this.notification = next;
            this.show = true;
        });
    }

    endNotificationTime() {

    }

    close(): void {
        this.show = false;
    }
}