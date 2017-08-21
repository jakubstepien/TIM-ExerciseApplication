﻿import { Component, OnInit } from "@angular/core";

import { ActivatedRoute, Router } from '@angular/router';

import { AccountService } from './account.service';
import { NotificationService } from '../common/notification/notification.service';
import 'rxjs/add/operator/map';

@Component({
    templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {
    login: string;
    password: string;
    redirectUrl: string

    constructor(private accountService: AccountService, private notificationService: NotificationService, private router: Router, private route: ActivatedRoute) { };

    ngOnInit() {
        this.route.queryParamMap.subscribe(parms => {
            this.redirectUrl = parms.get('redirect') || '/';
        });
    }

    signIn(): void {
        this.accountService.login(this.login, this.password).then(result => {
            if (result.success) {
                this.router.navigateByUrl(this.redirectUrl);
            }
            else {
                this.notificationService.error("Bład logowania", result.error);
            }
        });
    }
}