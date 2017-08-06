import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';


import { AppComponent } from './app.component';
import { NotificationComponent } from './common/notification/notification.component';
import { AppNavigationComponent } from './app-navigation.component';
import { HomeComponent } from './home/home.component';
import { ExercisesComponent } from './exercise/exercises.component';
import { ExercseDetailComponent } from './exercise/exercise-detail.component';
import { LoginComponent } from './account/login.component';
import { RegisterComponent } from './account/register.component';

import { AccountService } from './account/account.service';
import { NotificationService } from './common/notification/notification.service';

import { AppRoutingModule } from './app-routing.module';

@NgModule({
    imports: [BrowserModule, AppRoutingModule, FormsModule, HttpModule],
    declarations: [
        AppComponent,
        HomeComponent,
        NotificationComponent,
        ExercisesComponent,
        ExercseDetailComponent,
        AppNavigationComponent,
        LoginComponent,
        RegisterComponent
    ],
    providers: [AccountService, NotificationService],
    bootstrap: [AppComponent]
})
export class AppModule { }
