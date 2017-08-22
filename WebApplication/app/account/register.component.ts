import { Component } from "@angular/core";

import { Router } from '@angular/router';

import { AccountService } from './account.service';
import { NotificationService } from '../common/notification/notification.service';

@Component({
    templateUrl: './register.component.html'
})
export class RegisterComponent {
    login: string;
    password: string;
    passwordConfirm: string;

    constructor(private accountService: AccountService, private notificationService: NotificationService, private router: Router) { }

    public register(): void {
        this.accountService.register(this.login, this.password, this.passwordConfirm)
            .then(response => {
                if (response.success) {
                    this.router.navigateByUrl('/');
                }
                else {
                    this.notificationService.error("Błąd rejestracji", response.error);
                }
            });
    }
}