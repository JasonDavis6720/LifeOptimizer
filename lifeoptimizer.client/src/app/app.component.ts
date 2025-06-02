import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ShellComponent } from './layout/shell/shell.component';  // Import your layout shell

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ShellComponent, RouterModule],  // <-- Include RouterModule here
  templateUrl: './app.component.html'
})
export class AppComponent { }
