import { Injectable } from '@angular/core';
import { CanActivate, RouterStateSnapshot, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { UserService } from '../common/user.service';

@Injectable()
export class RoleGuard implements CanActivate {
    constructor(private userService: UserService, private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
        var role = route.data['role'];
        if (role) {
            var isInRole = this.userService.isInRole(role);
            if (!isInRole) {
                this.router.navigate(['login']);
            }
            return isInRole;
        }
        return true;
    }
}