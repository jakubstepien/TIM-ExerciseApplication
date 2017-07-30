import { Component } from "@angular/core";

@Component({
    template: `<h1>{{title}}</h1>
    <a routerLink="details">Test</a>
    <router-outlet></router-outlet>
    `
})
export class ExercisesComponent {
    title = "Exercises";
}