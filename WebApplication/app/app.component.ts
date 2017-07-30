import { Component } from '@angular/core';

import { AppNavigationComponent } from './app-navigation.component';

@Component({
  selector: 'my-app',
  template: `
    <app-nav></app-nav>
    <div class="main-container">
        <router-outlet></router-outlet>
    </div>
  `,
})
export class AppComponent  { }
