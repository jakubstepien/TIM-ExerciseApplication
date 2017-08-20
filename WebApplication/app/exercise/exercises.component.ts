import { Component, OnInit } from "@angular/core";

import { ExercisesService } from './exercises.service';

@Component({
    template: `<h1>{{title}}</h1>
    <a routerLink="details">Test</a>
    <router-outlet></router-outlet>
    `
})
export class ExercisesComponent implements OnInit {
    title = "Exercises";

    constructor(private exercisesService: ExercisesService) { };

    ngOnInit() {
        this.exercisesService.getExercises();
    }
}