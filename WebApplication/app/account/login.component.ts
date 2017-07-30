import { Component } from "@angular/core";

@Component({
    templateUrl: './login.component.html',
})
export class LoginComponent {
    login: string;
    password: string;

    signIn(): void {
        console.log(this.login);
        console.log(this.password);
    }
}