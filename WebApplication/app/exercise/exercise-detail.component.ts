import { Component, OnInit } from "@angular/core";
import { NgForm } from '@angular/forms';

import { ExercisesService } from './exercises.service';
import { ExerciseDTO } from './exercise';


@Component({
    templateUrl: './exercise-detail.component.html',
})
export class ExercseDetailComponent implements OnInit {
    constructor(private exercisesService: ExercisesService) { }

    exercise: ExerciseDTO;
    show: boolean;

    ngOnInit() {
        this.exercise = { CaloriesPerHour: null, Description: "", IdExercise: "", ImageName: "", Name: "", IsFavourite: false };
        this.show = true;
    }

    uploadImage(event: any) {
        var file: File = event.target.files[0];
        this.exercisesService.saveImage(file, "83CBF1FC-BDC6-457B-850E-E34D56122AF6");
    }

    saveExercise(form: NgForm) {
        console.log(form);
        console.log(this.exercise);
    }
}