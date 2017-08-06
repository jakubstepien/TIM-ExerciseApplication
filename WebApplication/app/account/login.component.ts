import { Component } from "@angular/core";

import { AccountService } from './account.service';
import { NotificationService } from '../common/notification/notification.service';

@Component({
    templateUrl: './login.component.html',
})
export class LoginComponent {
    login: string;
    password: string;

    constructor(private accountService: AccountService, private notificationService: NotificationService) { };

    signIn(): void {
        this.accountService.login(this.login, this.password).then(result => {
            if (result.success) {
                this.notificationService.info("Udało się","kokokokok");
            }
            else {
                this.notificationService.error("Bład logowania", result.error);
            }
        });
    }
}