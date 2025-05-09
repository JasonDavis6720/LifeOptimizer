import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; // Add this
import { AddItemComponent } from './features/items/add-item/add-item.component'; // Correct path

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule, AddItemComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'lifeoptimizer.client';
}
