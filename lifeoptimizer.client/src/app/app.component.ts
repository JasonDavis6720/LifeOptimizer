import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; // Add this
import { AddItemComponent } from './features/items/add-item/add-item.component'; // Correct path
import { provideHttpClient } from '@angular/common/http';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule, AddItemComponent],
  providers: [provideHttpClient()], // Add FormsModule here
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'lifeoptimizer.client';
}
