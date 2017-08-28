import { Component } from "@angular/core";
import { Observable } from 'rxjs/Observable';
import { ActivatedRouteSnapshot, RouterStateSnapshot} from '@angular/router';

import { UserService } from './common/user.service';

@Component({
    selector: 'app-nav',
    templateUrl: './app-navigation.component.html'
})
export class AppNavigationComponent {
    constructor(private userService: UserService) { }
    asdasdTest : boolean = false;

    public isLoggedIn(): Observable<boolean> | Promise<boolean> | boolean {
        return this.userService.isLoggedIn();
    }

    public isInRole(role: string): Observable<boolean> | Promise<boolean> | boolean {
        return this.userService.isInRole(role);
    }
}