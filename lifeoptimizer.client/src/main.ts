import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { provideHttpClient } from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { routes } from './app/app.routes'; // Import routes from the new app.routes.ts

bootstrapApplication(AppComponent, {
  providers: [
    provideHttpClient(), // Provide HttpClient here
    provideRouter(routes), // Provide routing here
  ],
}).catch((err) => console.error(err));
