import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { AppNavigationComponent } from './app-navigation.component';
import { HomeComponent } from './home/home.component';
import { ExercisesComponent } from './exercise/exercises.component';
import { ExercseDetailComponent } from './exercise/exercise-detail.component';
import { LoginComponent } from './account/login.component';
import { RegisterComponent } from './account/register.component';


import { AppRoutingModule } from './app-routing.module';

@NgModule({
    imports: [BrowserModule, AppRoutingModule, FormsModule],
    declarations: [
        AppComponent,
        HomeComponent,
        ExercisesComponent,
        ExercseDetailComponent,
        AppNavigationComponent,
        LoginComponent,
        RegisterComponent
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
