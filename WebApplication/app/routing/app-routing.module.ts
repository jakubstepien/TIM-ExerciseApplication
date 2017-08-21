﻿import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from '../home/home.component';
import { ExercisesComponent } from '../exercise/exercises.component';
import { ExercseDetailComponent } from '../exercise/exercise-detail.component';
import { LoginComponent } from '../account/login.component';
import { RegisterComponent } from '../account/register.component';

import { LoggedInGuard } from './loggedin-guard';
import { RoleGuard } from './role-guard';

const routes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: 'exercises', component: ExercisesComponent,
        canActivate: [LoggedInGuard],
        children: [{
            path: "details", component: ExercseDetailComponent
        }]
    },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
    providers: [LoggedInGuard, RoleGuard],
})
export class AppRoutingModule { }