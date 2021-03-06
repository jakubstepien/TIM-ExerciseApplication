﻿import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, ParamMap, Router, NavigationEnd } from '@angular/router';
import 'rxjs/add/operator/filter';


import { ExercisesService } from './exercises.service';
import { ExerciseDTO } from './exercise';
import { NotificationService } from '../common/notification/notification.service';

@Component({
    templateUrl: './exercises.component.html',
})
export class ExercisesComponent implements OnInit {
    title = "Cwiczenia";
    url: string;
    exercises: ExerciseDTO[];
    currentPage: number;
    pageSize: number = 20;
    lastPage: number;
    total: number;

    constructor(private exercisesService: ExercisesService, private notificationService: NotificationService, private activatedRoute: ActivatedRoute) { };

    ngOnInit() {
        this.activatedRoute.params.subscribe(parms => {
            this.currentPage = +parms['page'];
            this.loadExercises();
        });
        this.exercisesService.dataChanged.subscribe(changed => {
            if (changed) {
                this.loadExercises();
            }
        })
    }

    private loadExercises() {
        this.exercisesService.getExercises(this.currentPage, this.pageSize).then((response) => {
            if (response.success) {
                this.exercises = response.data.Items;
                this.currentPage = response.data.CurrentPage;
                this.total = response.data.TotalCount;
                this.lastPage = Math.ceil(this.total / this.pageSize);
            }
            else {
                throw new Error();
            }
        })
            .catch(reason => {
                this.notificationService.error("Błąd pobierania ćwiczeń");
            });
    }

    delete(id: string) {
        var promise = this.exercisesService.deleteExercise(id);
        let showError = () => this.notificationService.error("Błąd usuwania ćwiczenia");
        promise.then(result => {
            if (result.success) {
                this.notificationService.info("Ćwiczenie zostało usunięte");
            }
            else {
                showError();
            }
        }).catch(reason => showError());
    }
}